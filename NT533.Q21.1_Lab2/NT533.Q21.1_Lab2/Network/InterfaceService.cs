using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static NT533.Q21._1_Lab2.Network.InterfaceService;
using static NT533.Q21._1_Lab2.Network.RouterService;
using static System.Net.WebRequestMethods;

namespace NT533.Q21._1_Lab2.Network
{
    internal class InterfaceService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string PUTURL = "https://cloud-network.uitiot.vn/v2.0/routers";
        private const string GETURL = "https://cloud-network.uitiot.vn/v2.0/ports?device_id=";
        public class InterfaceResponse
        {
            public List<Interface> ports { get; set; }
            public Interface port { get; set; }
        }

        public class Interface
        {
            public string id { get; set; }
            public string admin_state_up { get; set; }
            public string status { get; set; }
            public List<FixIP> fixed_ips { get; set; }

        }
        public class FixIP
        {
            public string subnet_id { get; set; }
            public string ip_address { get; set; }

        }

        public async Task<(bool, string)> GetInterfaceAsync(string token, string routerid)
        {
            if (string.IsNullOrEmpty(Main._username) || string.IsNullOrEmpty(Main._password))
            {
                return (false, "Username hoặc Password đang null");
            }

            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            string url = GETURL + routerid;

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
        public async Task<(bool, string)> PostInterfaceAsync(string token, string subnetid, string routerid, string fixip = null)
        {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            var body = new
            {
                subnet_id = subnetid,
            };

            string json = JsonConvert.SerializeObject(body);

            string url = PUTURL + "/" + routerid + "/add_router_interface";

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
                    if (fixip != null)
                    {
                        dynamic data = Newtonsoft.Json.Linq.JObject.Parse(content);
                        string portId = data.port_id;

                        var body1 = new
                        {
                            port = new
                            {
                                fixed_ips = new[]
                                {
                                    new
                                    {
                                         ip_address = fixip,
                                         subnet_id = subnetid
                                    }
                                }
                            }
                        };
                        string json1 = JsonConvert.SerializeObject(body1);

                        string url1 = "https://cloud-network.uitiot.vn/v2.0/ports/"+portId;
                        
                        var response1 = await http.PutAsync(url1, json1, token);
                        if (response1.IsSuccessStatusCode)
                        {
                            return (true, content);
                        }
                    }
                    return (true, content);
                }

                return (false, response.ReasonPhrase);
            }

            return (false, lastError == "" ? "Retry thất bại sau 5 lần" : lastError);
        }
        public async Task<(bool, string)> DeleteInterfaceAsync(string token, string[] subnetids, string routerid)
        {
            foreach (var subnetid in subnetids)
            {
                int maxRetry = 5;
                int delay = 500;
                string lastError = "";

                var body = new
                {
                    subnet_id = subnetid,
                };
                bool isDeleted = false;

                string json = JsonConvert.SerializeObject(body);

                string url = PUTURL + "/" + routerid + "/remove_router_interface";

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
                        isDeleted = true;
                        break;
                    }
                    lastError = response.ReasonPhrase;
                    break;
                }
                if (!isDeleted)
                {
                    return (false, $"Xóa interface '{subnetid}' thất bại: {lastError}");
                }
            }
            return (true, null);
        }
    }
}
