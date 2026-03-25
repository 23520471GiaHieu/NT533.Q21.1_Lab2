using Newtonsoft.Json;
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

    internal class FlavorService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-compute.uitiot.vn/v2.1/flavors";
        public class FlavorResponse
        {
            public List<Flavor> flavors { get; set; }
            public Flavor flavor { get; set; }
        }

        public class Flavor
        {
            public string id { get; set; }
            public string name { get; set; }
            public int ram { get; set; }
            public int disk { get; set; }
            public int vcpus { get; set; }
            [JsonProperty("OS-FLV-EXT-DATA:ephemeral")]
            public int ephemeral { get; set; }
            [JsonProperty("os-flavor-access:is_public")]
            public bool ispublic { get; set; }

        }

        public async Task<(bool, string)> GetFlavorAsync(string token,string id= null)
        {
            if (string.IsNullOrEmpty(Main._username) || string.IsNullOrEmpty(Main._password))
            {
                return (false, "Username hoặc Password đang null");
            }
            string url = URL;
            if (id != null)
            {
                url += "/" + id;
            }
            else
            {
                url += "/detail";
            }

            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

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
    }
}
