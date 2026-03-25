using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NT533.Q21._1_Lab2.Network
{
    internal class NetworkService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-network.uitiot.vn/v2.0/networks";
        public class NetworkResponse
        {
            public List<Network> networks { get; set; }
            public Network network { get; set; }
        }

        public class Network
        {
            public string id { get; set; }
            public string name { get; set; }
            public string admin_state_up { get; set; }
            public string status { get; set; }
            public string[] subnets { get; set; }
            public string shared { get; set; }
            [Newtonsoft.Json.JsonProperty("router:external")]
            public string external { get; set; }
        }

        public async Task<(bool, string)> GetNetworkAsync(string token,string id=null)
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
        public async Task<(bool, string)> PostNetworkAsync(string token, string name, bool admin_state_up)
        {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            var body = new
            {
                network = new
                {
                    name = name,
                    admin_state_up = admin_state_up
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
        public async Task<(bool, string)> DeleteNetworkAsync(string token, string[] netids)
        {
            foreach (var netid in netids)
            {
                int maxRetry = 5;
                int delay = 500;
                string lastError = "";

                string url = URL + "/" + netid;

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
                    return (false, $"Xóa key '{netid}' thất bại: {lastError}");
                }
            }
            return (true, null);
        }
    }
}
