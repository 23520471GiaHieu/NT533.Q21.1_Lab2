using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static NT533.Q21._1_Lab2.Volume.AvailabilityZoneService;

namespace NT533.Q21._1_Lab2.Volume
{
    internal class VolumeService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-volume.uitiot.vn/v3/volumes";
        public class VolumeResponse
        {
            public List<Volume> volumes { get; set; }
            public Volume volume { get; set; }
        }

        public class Volume
        {
            public string id { get; set; }
            public string name { get; set; }
            public string description { get; set; }
            public int size { get; set; }
            public string status { get; set; }
            public string volume_type { get; set; }
            public List<Attachments> attachments { get; set; }
            public string availability_zone { get; set; }
            public string bootable { get; set; }
            public bool encrypted { get; set; }
            public VolumeImageMetadata volume_image_metadata { get; set; }
        }
        public class Attachments
        {
            public string server_id { get; set; }
            public string device { get; set; }
        }
        public class VolumeImageMetadata
        {
            public string image_name { get; set; }
            public string disk_format { get; set; }
        }

        public async Task<(bool, string)> GetVolumeAsync(string token,string id= null)
        {
            if (string.IsNullOrEmpty(Main._username) || string.IsNullOrEmpty(Main._password))
            {
                return (false, "Username hoặc Password đang null");
            }

            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            string url = URL;
            if (id != null)
            {
                url = URL + "/" + id;
            }
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
        public async Task<(bool, string)> PostVolumeAsync(string token, string size = null, string availability_zone = null, string source_volid = null, string description = null, string name = null, string imageRef = null)
        {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            var body = new
            {
                volume = new
                {
                    size = size,
                    availability_zone = availability_zone,
                    source_volid = source_volid,
                    description = description,
                    name = name,
                    imageRef = imageRef
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
        public async Task<(bool, string)> DeleteVolumeAsync(string token, string[] volids)
        {
            foreach (var volid in volids)
            {
                int maxRetry = 5;
                int delay = 500;
                string lastError = "";

                string url = URL + "/" + volid;

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
                    return (false, $"Xóa key '{volid}' thất bại: {lastError}");
                }
            }
            return (true, null);
        }
    }
}
