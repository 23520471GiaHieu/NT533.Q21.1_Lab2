using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static NT533.Q21._1_Lab2.Network.SecurityGroupService;

namespace NT533.Q21._1_Lab2.Network
{
    internal class RuleService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string POSTURL = "https://cloud-network.uitiot.vn/v2.0/security-group-rules";
        private const string GETURL = "https://cloud-network.uitiot.vn/v2.0/security-groups";
        public class RuleResponse
        {
            public SecurityGroup security_group { get; set; }
        }
        public class SecurityGroup
        {
            public List<Rule> security_group_rules { get; set; }
            public Rule security_group_rule { get; set; }
        }
        public class Rule
        {
            public string id { get; set; }
            public string security_group_id { get; set; }
            public string ethertype { get; set; }
            public string direction { get; set; } 
            public string protocol { get; set; }
            public string port_range_min { get; set; }
            public string port_range_max { get; set; }
            public string description { get; set; }
            public string remote_ip_prefix { get; set; }
            public string remote_group_id { get; set; }
        }

        public async Task<(bool, string)> GetRuleAsync(string token, string sgroupid = null)
        {
            if (string.IsNullOrEmpty(Main._username) || string.IsNullOrEmpty(Main._password))
            {
                return (false, "Username hoặc Password đang null");
            }

            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            string url = "";
            if (!string.IsNullOrEmpty(sgroupid))
            {
                url = GETURL + "/" + sgroupid;
            }
            else
            {
                url = POSTURL;
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
        public async Task<(bool, string)> PostRuleAsync(string token, string security_group_id, string Direction = "Ingress", string EtherType = "IPv4", string protocol = "TCP", string portmin = null, string portmax = null, string description = null, string remote_group_id = null, string remote_ip_prefix = null)
        {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            Direction = Direction.ToLower();
            protocol = protocol.ToLower();

            var body = new
            {
                security_group_rule = new
                {
                    remote_group_id = remote_group_id,
                    direction = Direction,
                    protocol = protocol,
                    ethertype = EtherType,
                    port_range_max = portmax,
                    port_range_min = portmin,
                    security_group_id = security_group_id,
                    remote_ip_prefix = remote_ip_prefix,
                    description = description
                }
            };

            string json = JsonConvert.SerializeObject(body);

            for (int i = 0; i < maxRetry; i++)
            {
                var response = await http.PostAsync(POSTURL, json, token);

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
        public async Task<(bool, string)> DeleteRuleAsync(string token, string[] ruleids)
        {
            foreach (var ruleid in ruleids)
            {
                int maxRetry = 5;
                int delay = 500;
                string lastError = "";

                string url = POSTURL + "/" + ruleid;

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
                    return (false, $"Xóa key '{ruleid}' thất bại: {lastError}");
                }
            }
            return (true, null);
        }
    }
}
