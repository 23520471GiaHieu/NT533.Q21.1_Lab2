using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NT533.Q21._1_Lab2.Volume
{
    internal class AvailabilityZoneService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-compute.uitiot.vn/v2.1/os-availability-zone";
        public class AvailabilityZoneResponse
        {
            public List<AvailabilityZone> availabilityZoneInfo { get; set; }
        }

        public class AvailabilityZone
        {
            public string zoneName { get; set; }
            public ZoneState zoneState { get; set; }
            public object hosts { get; set; }
        }

        public class ZoneState
        {
            public bool available { get; set; }
        }

        public async Task<(bool, string)> GetAvailabilityZoneAsync(string token)
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
