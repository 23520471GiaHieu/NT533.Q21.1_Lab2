using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NT533.Q21._1_Lab2.HttpHelper
{
    public class HttpHelperService
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<HttpResponseMessage> PostAsync(string url, string jsonBody, string token = null)
        {
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Remove("X-Auth-Token");
                client.DefaultRequestHeaders.Add("X-Auth-Token", token);
            }

            return await client.PostAsync(url, content);
        }
        public async Task<HttpResponseMessage> PutAsync(string url, string jsonBody, string token = null)
        {
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Remove("X-Auth-Token");
                client.DefaultRequestHeaders.Add("X-Auth-Token", token);
            }

            return await client.PutAsync(url, content);
        }

        public async Task<HttpResponseMessage> GetAsync(string url, string token = null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Remove("X-Auth-Token");
                client.DefaultRequestHeaders.Add("X-Auth-Token", token);
            }

            return await client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url, string token = null)
        {
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Remove("X-Auth-Token");
                client.DefaultRequestHeaders.Add("X-Auth-Token", token);
            }

            return await client.DeleteAsync(url);
        }
    }
}
