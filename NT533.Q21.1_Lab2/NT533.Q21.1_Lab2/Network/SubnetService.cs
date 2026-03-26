using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NT533.Q21._1_Lab2.Network
{
    internal class SubnetService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-network.uitiot.vn/v2.0/subnets";
        public class SubnetResponse
        {
            public List<Subnet> subnets { get; set; }
            public Subnet subnet { get; set; }
        }

        public class Subnet
        {
            public string id { get; set; }
            public string name { get; set; }
            public string gateway_ip { get; set; }
            public string cidr { get; set; }
            public string ip_version { get; set; }
            public string network_id {  get; set; }
        }

        public async Task<(bool, string)> GetSubnetAsync(string token, string id = null)
        {
            if (string.IsNullOrEmpty(Main._username) || string.IsNullOrEmpty(Main._password))
            {
                return (false, "Username hoặc Password đang null");
            }

            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            string url = URL;
            if (!string.IsNullOrEmpty(id))
            {
                url += "/" + id;
            }

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
        public async Task<(bool, string)> PostSubnetAsync(string token, string name, string cidr,string networkid,string ipversion,string gateway)
        {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            var body = new
            {
                subnet = new
                {
                    name = name,
                    network_id = networkid,
                    ip_version = int.Parse(ipversion),
                    cidr = cidr,
                    gateway_ip = gateway
                }
            };

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
        public async Task<(bool, string)> DeleteSubnetAsync(string token, string[] subids)
        {
            foreach (var subid in subids)
            {
                int maxRetry = 5;
                int delay = 500;
                string lastError = "";

                string url = URL + "/" + subid;

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
                    return (false, $"Xóa key '{subid}' thất bại: {lastError}");
                }
            }
            return (true, null);
        }
    }
}
