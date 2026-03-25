using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NT533.Q21._1_Lab2.Network
{
    internal class SecurityGroupService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-network.uitiot.vn/v2.0/security-groups";
        public class SecurityGroupResponse
        {
            public List<SecurityGroup> security_groups { get; set; }
            public SecurityGroup security_group { get; set; }
        }

        public class SecurityGroup
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public string shared { get; set; }
        }


        public async Task<(bool, string)> GetSecurityGroupAsync(string token, string sgroupid = null)
        {
            if (string.IsNullOrEmpty(Main._username) || string.IsNullOrEmpty(Main._password))
            {
                return (false, "Username hoặc Password đang null");
            }

            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            string url = URL;
            if (!string.IsNullOrEmpty(sgroupid))
            {
                url += "/" + sgroupid;
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
        public async Task<(bool, string)> PostSecurityGroupAsync(string token, string name, string description)
        {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            var body = new
            {
                security_group = new
                {
                    name = name,
                    description = description
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
        public async Task<(bool, string)> DeleteSecurityGroupAsync(string token, string[] secids)
        {
            foreach (var secid in secids)
            {
                int maxRetry = 5;
                int delay = 500;
                string lastError = "";

                string url = URL + "/" + secid;

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
                    return (false, $"Xóa key '{secid}' thất bại: {lastError}");
                }
            }
            return (true, null);
        }
    }
}
