using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NT533.Q21._1_Lab2.Compute
{
    internal class ImageService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-image.uitiot.vn/v2/images";
        public class ImageResponse
        {
            public List<Image> images { get; set; }
        }

        public class Image
        {
            public string id { get; set; }
            public string name { get; set; }
            public string status { get; set; }
            public int min_ram { get; set; }
            public int min_disk { get; set; }
            public string visibility { get; set; }

            [Newtonsoft.Json.JsonProperty("protected")]
            public bool is_protected { get; set; }
            public string checksum { get; set; }
            public long size { get; set; }
            public string disk_format { get; set; }
            public string container_format { get; set; }
            public string owner { get; set; }
            public string description { get; set; }
            public DateTime updated_at { get; set; }
        }

        public async Task<(bool, string)> GetImageAsync(string token)
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
    }
}
