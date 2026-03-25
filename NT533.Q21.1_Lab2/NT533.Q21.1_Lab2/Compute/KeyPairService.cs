using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NT533.Q21._1_Lab2.Compute
{
    internal class KeyPairService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-compute.uitiot.vn/v2.1/os-keypairs";
        public class KeyPairResponse
        {
            public List<KeyPairWrapper> keypairs { get; set; }
        }

        public class KeyPairWrapper
        {
            public KeyPair keypair { get; set; }
        }

        public class KeyPair
        {
            public string name { get; set; }
            public string public_key { get; set; }
            public string fingerprint { get; set; }
        }

        public async Task<(bool, string)> GetKeyPairAsync(string token)
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
