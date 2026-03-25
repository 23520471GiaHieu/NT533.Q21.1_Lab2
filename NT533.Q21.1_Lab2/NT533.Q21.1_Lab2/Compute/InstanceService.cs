using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static NT533.Q21._1_Lab2.Volume.AvailabilityZoneService;
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
        public async Task<(bool, string)> PostInstanceAsync(
            string token,
            (string insname, string insdes, string insazone, string inscount) detail,
            (string imageorvolume, bool delvoloninsdel, string size, string sourceid) source,
            string flavorid,
            List<string> networkIds,
            List<string> secgroupIds,
            string keyname,
            string customscript
        )
        {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            // BUILD SERVER OBJECT
            var server = new Dictionary<string, object>();

            server["name"] = detail.insname;
            server["flavorRef"] = flavorid;

            // IMAGE / VOLUME
            if (source.imageorvolume == "0")
            {
                // Boot from image → nhưng phải tạo volume trung gian
                server["block_device_mapping_v2"] = new[]
                {
        new
        {
            uuid = source.sourceid,
            source_type = "image",
            destination_type = "volume",
            volume_size = int.Parse(source.size),
            boot_index = 0,
            delete_on_termination = source.delvoloninsdel
        }
    };
            }
            else
            {
                // Boot từ volume có sẵn
                server["block_device_mapping_v2"] = new[]
                {
        new
        {
            uuid = source.sourceid,
            source_type = "volume",
            destination_type = "volume",
            boot_index = 0,
            delete_on_termination = source.delvoloninsdel
        }
    };
            }

            // NETWORK
            server["networks"] = networkIds
                .Select(id => new { uuid = id })
                .ToArray();

            // SECURITY GROUP
            if (secgroupIds != null && secgroupIds.Count > 0)
            {
                server["security_groups"] = secgroupIds
                    .Select(id => new { name = id }) // ⚠️ thường là name
                    .ToArray();
            }

            // KEYPAIR
            if (!string.IsNullOrEmpty(keyname))
                server["key_name"] = keyname;

            // USER DATA
            if (!string.IsNullOrEmpty(customscript))
            {
                server["user_data"] = Convert.ToBase64String(
                    Encoding.UTF8.GetBytes(customscript)
                );
            }

            // AZ
            if (!string.IsNullOrEmpty(detail.insazone))
                server["availability_zone"] = detail.insazone;

            var body = new { server };
            string json = JsonConvert.SerializeObject(body);

            // DEBUG
            Console.WriteLine(json);

            for (int i = 0; i < maxRetry; i++)
            {
                var response = await http.PostAsync(URL, json, token);

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    TokenService tokenService = new TokenService();
                    var tokenResponse = await tokenService.GetTokenAsync(Main._username, Main._password);

                    if (tokenResponse.Item1)
                        token = tokenResponse.Item2;
                    else
                        lastError = "Không lấy được token mới";

                    await Task.Delay(delay);
                    continue;
                }

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return (true, content);
                }

                string err = await response.Content.ReadAsStringAsync();
                return (false, err);
            }

            return (false, lastError == "" ? "Retry thất bại" : lastError);
        }
        public async Task<(bool, string)> DeleteInstanceAsync(string token, string[] insids)
        {
            foreach (var insid in insids)
            {
                int maxRetry = 5;
                int delay = 500;
                string lastError = "";

                string url = URL + "/" + insid;

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
                    return (false, $"Xóa key '{insid}' thất bại: {lastError}");
                }
            }
            return (true, null);
        }
        public async Task<string> WaitForInstanceIP(string token, string instanceId)
        {
            int retry = 20;
            int delay = 3000;

            for (int i = 0; i < retry; i++)
            {
                var result = await GetInstanceAsync(token, instanceId);

                if (!result.Item1) return null;

                var data = JsonConvert.DeserializeObject<InstanceResponse>(result.Item2);
                var server = data.server;

                if (server.addresses != null)
                {
                    foreach (var net in server.addresses)
                    {
                        var ip = net.Value.FirstOrDefault(x => x.type == "fixed");
                        if (ip != null)
                            return ip.addr;
                    }
                }

                await Task.Delay(delay);
            }

            return null;
        }
    }
}
