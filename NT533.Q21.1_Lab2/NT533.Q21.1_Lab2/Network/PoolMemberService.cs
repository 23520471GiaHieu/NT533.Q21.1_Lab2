using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static NT533.Q21._1_Lab2.Compute.PortService;
using static NT533.Q21._1_Lab2.Network.LoadBalancerService;
using static System.Net.WebRequestMethods;

namespace NT533.Q21._1_Lab2.Network
{
    internal class PoolMemberService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-loadbalancer.uitiot.vn/v2/lbaas/pools";
        public class PoolResponse
        {
            [JsonProperty("pools")]
            public List<PoolItem> Pools { get; set; }
        }

        public class PoolItem
        {
            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("project_id")]
            public string ProjectId { get; set; }

            [JsonProperty("protocol")]
            public string Protocol { get; set; }

            public List<LoadBalancer> loadbalancers { get; set; }
        }

        public class PoolMemberResponse
        {
            public List<PoolMember> members { get; set; }
            public PoolMember member { get; set; }
        }
        public class PoolMember
        {
            public string address { get; set; }
            public bool admin_state_up { get; set; }
            public bool backup {  get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public int protocol_port { get; set; }
            public int weight { get; set; }
            public string operating_status { get; set; }
            public string provisioning_status { get; set; }
            public string subnet_id { get; set; }
        }
        public async Task<List<PoolItem>> GetAllPools(string token)
        {
            string url = URL;

            try
            {
                // Sử dụng hàm GetAsync từ HttpClient của bạn (giống logic Associate của bạn)
                var response = await http.GetAsync(url, token);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<PoolResponse>(content);

                    // Trả về danh sách pools, nếu null thì trả về list rỗng để tránh lỗi foreach
                    return data?.Pools ?? new List<PoolItem>();
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    // Logic làm mới token có thể thực hiện ở đây hoặc ở tầng gọi hàm này
                    Debug.WriteLine("Token hết hạn khi lấy danh sách Pool.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Lỗi hệ thống khi GetAllPools: {ex.Message}");
            }

            return new List<PoolItem>();
        }
        public async Task<(bool, string)> GetPoolMemberAsync(string token, string poolid, string memberid = null)
        {
            if (string.IsNullOrEmpty(Main._username) || string.IsNullOrEmpty(Main._password))
            {
                return (false, "Username hoặc Password đang null");
            }

            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            string url = URL + $"/{poolid}/members";

            if (memberid != null) url += $"/{memberid}";

            for (int i = 0; i < maxRetry; i++)
            {
                var response = await http.GetAsync(url, token);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    TokenService tokenService = new TokenService();
                    var tokenResponse = await tokenService.GetTokenAsync(Main._username, Main._password);

                    if (tokenResponse.Item1)
                    {
                        token = tokenResponse.Item2;
                    }
                    else
                    {
                        lastError = "Không lấy được token mới";
                    }

                    await Task.Delay(delay);
                    continue;
                }

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return (true, content);
                }

                return (false, response.ReasonPhrase);
            }

            return (false, lastError == "" ? "Retry thất bại sau 5 lần" : lastError);
        }

        public async Task<(bool, string)> AddMemberToPool(
    string token,
    string poolId,
    string ip,
    string subnetId,
    string name,
    int weight = 1,
    int port = 80
    )
        {
            string url = URL+ $"/{poolId}/members";

            var body = new
            {
                member = new
                {
                    name = name,
                    address = ip,
                    protocol_port = port,
                    subnet_id = subnetId,
                    weight = weight,
                }
            };

            string json = JsonConvert.SerializeObject(body);

            var response = await http.PostAsync(url, json, token);

            if (response.IsSuccessStatusCode)
            {
                return (true, await response.Content.ReadAsStringAsync());
            }

            return (false, await response.Content.ReadAsStringAsync());
        }
        public async Task<(bool, string)> RemoveMemberFromPool(string token,string poolId,string lbid,string[] memberids)
        {
            foreach (var memberid in memberids)
            {
                int maxRetry = 5;
                int delay = 500;
                string lastError = "";

                string url = URL + $"/{poolId}/members/{memberid}";

                bool isDeleted = false;

                for (int i = 0; i < maxRetry; i++)
                {
                    var response = await http.DeleteAsync(url, token);

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        TokenService tokenService = new TokenService();
                        var tokenResponse = await tokenService.GetTokenAsync(Main._username, Main._password);

                        if (tokenResponse.Item1)
                        {
                            token = tokenResponse.Item2;
                        }
                        else
                        {
                            lastError = "Không lấy được token mới";
                        }

                        await Task.Delay(delay);
                        continue;
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        isDeleted = true;
                        var wait1 = await WaitForActive(lbid);
                        if (!wait1.Item1)
                            return wait1;
                        break;
                    }

                    lastError = response.ReasonPhrase;
                    break;
                }

                if (!isDeleted)
                {
                    return (false, $"Xóa member '{memberid}' thất bại: {lastError}");
                }
            }
            return (true, null);
        }
        private async Task<(bool, string)> WaitForActive(string lbId)
        {
            var lbService = new LoadBalancerService();

            for (int i = 0; i < 20; i++)
            {
                var res = await lbService.GetLoadBalancerAsync(Main._token, lbId);

                if (!res.Item1)
                    return res;

                dynamic data = JsonConvert.DeserializeObject(res.Item2);
                string status = data.loadbalancer.provisioning_status;

                if (status == "ACTIVE")
                    return (true, null);

                if (status == "ERROR")
                    return (false, "LB bị ERROR");

                await Task.Delay(3000);
            }

            return (false, "Timeout chờ ACTIVE");
        }
    }
}
