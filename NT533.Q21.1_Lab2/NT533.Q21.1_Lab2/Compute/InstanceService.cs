using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static NT533.Q21._1_Lab2.Volume.VolumeService;
using static System.Net.Mime.MediaTypeNames;

namespace NT533.Q21._1_Lab2.Compute
{
    internal class InstanceService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-compute.uitiot.vn/v2.1/servers";
        public class InstanceResponse
        {
            public List<Instance> servers { get; set; }
            public Instance server { get; set; }
        }

        public class Instance
        {
            public string id { get; set; }
            public string name { get; set; }

            [JsonProperty("os-extended-volumes:volumes_attached")]
            public List<VolumesAttached> volumes_attached { get; set; }

            public Dictionary<string, List<IPInfo>> addresses { get; set; }

            public Flavor flavor { get; set; }
            public string key_name { get; set; }
            public string status { get; set; }

            [JsonProperty("OS-EXT-AZ:availability_zone")]
            public string availability_zone { get; set; }

            [JsonProperty("OS-EXT-STS:task_state")]
            public string task_state { get; set; }

            [JsonProperty("OS-EXT-STS:power_state")]
            public int power_state { get; set; }
            public DateTime created { get; set; }
        }

        public class VolumesAttached
        {
            public string id { get; set; }
        }
        public class Flavor
        {
            public string id { get; set; }
        }
        public class IPInfo
        {
            public int version { get; set; }
            public string addr { get; set; }

            [Newtonsoft.Json.JsonProperty("OS-EXT-IPS:type")]
            public string type { get; set; }

            [Newtonsoft.Json.JsonProperty("OS-EXT-IPS-MAC:mac_addr")]
            public string mac_addr { get; set; }
        }

        public async Task<(bool, string)> GetInstanceAsync(string token, string id = null)
        {
            if (string.IsNullOrEmpty(Main._username) || string.IsNullOrEmpty(Main._password))
            {
                return (false, "Username hoặc Password đang null");
            }

            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            string url = URL;
            if (id != null) url = URL + "/" + id;
            else
            {
                url = URL + "/detail";
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
        public async Task<(bool, string)> PostKeyPairAsync(string token, string name, string publickey)
        {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            var body = new
            {
                keypair = new
                {
                    name = name,
                    public_key = publickey
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
        public async Task<(bool, string)> DeleteKeyPairAsync(string token, string[] names)
        {
            foreach (var name in names)
            {
                int maxRetry = 5;
                int delay = 500;
                string lastError = "";

                string url = URL + "/" + name;

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
                    return (false, $"Xóa key '{name}' thất bại: {lastError}");
                }
            }
            return (true, null);
        }
    }
}
