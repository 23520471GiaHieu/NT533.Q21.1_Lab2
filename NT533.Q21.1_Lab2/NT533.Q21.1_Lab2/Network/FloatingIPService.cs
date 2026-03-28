using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static NT533.Q21._1_Lab2.Network.SubnetService;

namespace NT533.Q21._1_Lab2.Network
{
    internal class FloatingIPService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-network.uitiot.vn/v2.0/floatingips";
        public class FloatingIPResponse
        {
            public List<FloatingIP> floatingips { get; set; }
            public FloatingIP floatingip { get; set; }
        }

        public class FloatingIP
        {
            public string id { get; set; }
            public string floating_ip_address { get; set; }
            public string description { get; set; }
            public string dns_name { get; set; }
            public string dns_domain { get; set; }
            public string fixed_ip_address { get; set; }
            public string floating_network_id { get; set; }
            public string status { get; set; }
            public string port_id { get; set; }
            public PortDetails port_details { get; set; }
        }
        public class PortDetails
        {
            public string device_id { get; set; }
        }
        public async Task<(bool, string)> GetFloatingIPAsync(string token)
        {
            if (string.IsNullOrEmpty(Main._username) || string.IsNullOrEmpty(Main._password))
            {
                return (false, "Username hoặc Password đang null");
            }

            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            for (int i = 0; i < maxRetry; i++)
            {
                var response = await http.GetAsync(URL, token);

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
        public async Task<(bool, string)> PostFloatingIPAsync(string token,string id, string ip=null, string desc=null, string dnsDomain=null, string dnsName=null)
        {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            var data = new Dictionary<string, object>
    {
        { "floating_network_id", id },
        { "floating_ip_address", ip },
        { "description", desc },
        { "dns_domain", dnsDomain },
        { "dns_name", dnsName }
    };
            var filteredData = data.Where(pair => pair.Value != null)
                           .ToDictionary(pair => pair.Key, pair => pair.Value);

            var body = new { floatingip = filteredData };

            string json = JsonConvert.SerializeObject(body);

            for (int i = 0; i < maxRetry; i++)
            {
                var response = await http.PostAsync(URL, json, token);

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
        public async Task<(bool, string)> DeleteFloatingIPAsync(string token, string[] ids)
        {
            foreach (var id in ids)
            {
                int maxRetry = 5;
                int delay = 500;
                string lastError = "";

                string url = URL + "/" + id;

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
                        break;
                    }

                    lastError = response.ReasonPhrase;
                    break;
                }

                if (!isDeleted)
                {
                    return (false, $"Xóa floating id '{id}' thất bại: {lastError}");
                }
            }
            return (true, null);
        }
        public async Task<(bool, string)> AssociateFloatingIP(string token, string fipId, string portId)
        {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            var body = new
            {
                floatingip = new
                {
                    port_id = portId
                }
            };

            string url = URL + $"/{fipId}";

            string json = JsonConvert.SerializeObject(body);

            for (int i = 0; i < maxRetry; i++)
            {
                var response = await http.PutAsync(url, json, token);

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
        public async Task<(bool, string)> DisassociateFloatingIP(string token, string fipId)
        {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            // Để hủy gán (Disassociate), ta set port_id = null
            var body = new
            {
                floatingip = new
                {
                    port_id = (string)null
                }
            };

            string url = URL + $"/{fipId}";
            string json = JsonConvert.SerializeObject(body);

            for (int i = 0; i < maxRetry; i++)
            {
                // Vẫn dùng PUT để cập nhật trạng thái Floating IP
                var response = await http.PutAsync(url, json, token);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    TokenService tokenService = new TokenService();
                    // Lưu ý: Đảm bảo Main._username và Main._password có thể truy cập được ở đây
                    var tokenResponse = await tokenService.GetTokenAsync(Main._username, Main._password);

                    if (tokenResponse.Item1)
                    {
                        token = tokenResponse.Item2;
                    }
                    else
                    {
                        lastError = "Không lấy được token mới";
                        // Nếu không lấy được token, có thể break luôn hoặc retry tùy logic của bạn
                    }

                    await Task.Delay(delay);
                    continue;
                }

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return (true, "Disassociated successfully: " + content);
                }

                // Nếu lỗi không phải do Unauthorized, trả về lỗi ngay hoặc lưu lại để retry
                lastError = $"Error {response.StatusCode}: {response.ReasonPhrase}";
                await Task.Delay(delay);
            }

            return (false, string.IsNullOrEmpty(lastError) ? "Retry thất bại sau 5 lần" : lastError);
        }
    }
}
