using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NT533.Q21._1_Lab2.Compute
{
    internal class PortService
    {
        public class PortResponse
        {
            public List<Port> ports { get; set; }
        }

        public class Port
        {
            public string id { get; set; }
            public string network_id { get; set; }
            public List<FixedIP> fixed_ips { get; set; }
        }

        public class FixedIP
        {
            public string ip_address { get; set; }
            public string subnet_id { get; set; }
        }
        private readonly HttpClient _httpClient;

        public PortService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Port>> GetPortsByInstance(string token, string instanceId)
        {
            try
            {
                // 🔥 URL Neutron (chỉnh lại endpoint của bạn)
                string url = $"https://cloud-network.uitiot.vn/v2.0/ports?device_id={instanceId}";

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

                // 🔑 Token OpenStack
                request.Headers.Add("X-Auth-Token", token);

                HttpResponseMessage response = await _httpClient.SendAsync(request);

                if (!response.IsSuccessStatusCode)
                    return null;

                string json = await response.Content.ReadAsStringAsync();

                var portResponse = JsonConvert.DeserializeObject<PortResponse>(json);

                return portResponse?.ports;
            }
            catch
            {
                return null;
            }
        }
    }
}
