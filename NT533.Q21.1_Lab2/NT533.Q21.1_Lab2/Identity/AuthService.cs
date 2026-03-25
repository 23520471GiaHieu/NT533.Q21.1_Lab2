using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NT533.Q21._1_Lab2.HttpHelper;

namespace NT533.Q21._1_Lab2.Auth
{
    internal class AuthService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-identity.uitiot.vn/v3/auth/tokens";

        public async Task<(bool,string)> PostLoginAsync(string username, string password)
        {
            string[] arr = null;
            var body = new
            {
                auth = new
                {
                    identity = new
                    {
                        methods = new[] { "password" },
                        password = new
                        {
                            user = new
                            {
                                name = username,
                                domain = new { name = "Default" },
                                password = password
                            }
                        }
                    },
                    scope = new
                    {
                        project = new
                        {
                            name = "NT533.Q21.G3",
                            domain = new { name = "Default" }
                        }
                    }
                }
            };

            string json = JsonConvert.SerializeObject(body);

            var response = await http.PostAsync(URL, json);

            if (response.IsSuccessStatusCode)
            {
                if (response.Headers.Contains("X-Subject-Token"))
                {
                    return (true, response.Headers.GetValues("X-Subject-Token").FirstOrDefault());
                }
            }
            else
            {
                return (false, response.ReasonPhrase);
            }
            return (false, null);
        }
    }
}
