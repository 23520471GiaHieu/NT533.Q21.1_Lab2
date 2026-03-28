using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.HttpHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static NT533.Q21._1_Lab2.Compute.KeyPairService;
using static NT533.Q21._1_Lab2.Network.PoolMemberService;
using static NT533.Q21._1_Lab2.Network.RouterService;

namespace NT533.Q21._1_Lab2.Network
{
    internal class LoadBalancerService
    {
        private readonly HttpHelperService http = new HttpHelperService();
        private const string URL = "https://cloud-loadbalancer.uitiot.vn/v2/lbaas/loadbalancers";
        public class LoadBalancerResponse
        {
            public List<LoadBalancer> loadbalancers { get; set; }
            public LoadBalancer loadbalancer { get; set; }
        }

        public class LoadBalancer
        {
            public string id { get; set; }
            public string name { get; set; }
            public string vip_address { get; set; }
            public string provisioning_status { get; set; }
            public string operating_status { get; set; }

            public string admin_state_up { get; set; }
            public List<Pool> pools { get; set; }
            public string availability_zone { get; set; }

        }
        public class Pool
        {
            public string id { get; set; }
        }

        public async Task<(bool, string)> GetLoadBalancerAsync(string token, string lbid = null)
        {
            if (string.IsNullOrEmpty(Main._username) || string.IsNullOrEmpty(Main._password))
            {
                return (false, "Username hoặc Password đang null");
            }

            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            string url = URL;
            if (lbid!= null) url += "/" + lbid;

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
        public async Task<(bool, string)> PostLoadBalancerAsync(
                string token,
                string subnetid,
                string name,
                string description,
                bool adminStateUp,
                string fixip = null)
            {
            int maxRetry = 5;
            int delay = 500;
            string lastError = "";

            var body = new
            {
                loadbalancer = new
                {
                    name = name,
                    description = description,
                    vip_subnet_id = subnetid,
                    admin_state_up = adminStateUp
                }
            };

            string json = JsonConvert.SerializeObject(body);

            string url = URL;

            for (int i = 0; i < maxRetry; i++)
            {
                var response = await http.PostAsync(url, json, token);

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
                    if (!string.IsNullOrEmpty(fixip))
                    {
                        dynamic data = Newtonsoft.Json.Linq.JObject.Parse(content);
                        string portId = data.loadbalancer.vip_port_id;

                        var body1 = new
                        {
                            port = new
                            {
                                fixed_ips = new[]
                                        {
                    new
                    {
                        ip_address = fixip,
                        subnet_id = subnetid
                    }
                }
                            }
                        };

                        string json1 = JsonConvert.SerializeObject(body1);

                        string url1 = "https://cloud-network.uitiot.vn/v2.0/ports/" + portId;

                        var response1 = await http.PutAsync(url1, json1, token);
                        if (response1.IsSuccessStatusCode)
                        {
                            return (true, content);
                        }
                    }
                    return (true, content);
                }

                return (false, response.ReasonPhrase);
            }

            return (false, lastError == "" ? "Retry thất bại sau 5 lần" : lastError);
        }

        public async Task<(bool, string)> DeleteLoadBalancerAsync(string token, string[] loadbalancerids)
        {
            var lbService = new LoadBalancerService();

            foreach (var lbId in loadbalancerids)
            {
                // =====================
                // 1. GET LB DETAIL
                // =====================
                var lbRes = await lbService.GetLoadBalancerAsync(token, lbId);
                if (!lbRes.Item1)
                    return lbRes;

                dynamic lbData = JsonConvert.DeserializeObject(lbRes.Item2);

                // =====================
                // 2. DELETE ALL POOLS (MEMBERS + MONITOR)
                // =====================
                if (lbData.loadbalancer.pools != null)
                {
                    foreach (var pool in lbData.loadbalancer.pools)
                    {
                        string poolId = pool.id;

                        // ---- GET POOL DETAIL ----
                        var resPool = await http.GetAsync(
                            $"https://cloud-loadbalancer.uitiot.vn/v2/lbaas/pools/{poolId}",
                            token);

                        if (!resPool.IsSuccessStatusCode)
                            return (false, await resPool.Content.ReadAsStringAsync());

                        dynamic poolData = JsonConvert.DeserializeObject(await resPool.Content.ReadAsStringAsync());

                        // ---- DELETE MEMBERS ----
                        if (poolData.pool.members != null)
                        {
                            foreach (var mem in poolData.pool.members)
                            {
                                string memId = mem.id;

                                await http.DeleteAsync(
                                    $"https://cloud-loadbalancer.uitiot.vn/v2/lbaas/pools/{poolId}/members/{memId}",
                                    token);
                            }

                            var waitMem = await WaitForActive(lbId);
                            if (!waitMem.Item1) return waitMem;
                        }

                        // ---- DELETE MONITOR ----
                        if (poolData.pool.healthmonitor_id != null)
                        {
                            await http.DeleteAsync(
                                $"https://cloud-loadbalancer.uitiot.vn/v2/lbaas/healthmonitors/{poolData.pool.healthmonitor_id}",
                                token);

                            var waitMon = await WaitForActive(lbId);
                            if (!waitMon.Item1) return waitMon;
                        }

                        // ---- DELETE POOL ----
                        await http.DeleteAsync(
                            $"https://cloud-loadbalancer.uitiot.vn/v2/lbaas/pools/{poolId}",
                            token);

                        var waitPool = await WaitForActive(lbId);
                        if (!waitPool.Item1) return waitPool;
                    }
                }

                // =====================
                // 3. DELETE LISTENERS
                // =====================
                if (lbData.loadbalancer.listeners != null)
                {
                    foreach (var listener in lbData.loadbalancer.listeners)
                    {
                        string listenerId = listener.id;

                        await http.DeleteAsync(
                            $"https://cloud-loadbalancer.uitiot.vn/v2/lbaas/listeners/{listenerId}",
                            token);

                        var waitLis = await WaitForActive(lbId);
                        if (!waitLis.Item1) return waitLis;
                    }
                }

                // =====================
                // 4. DELETE LOADBALANCER
                // =====================
                int maxRetry = 10;
                int delay = 2000;
                bool isDeleted = false;
                string lastError = "";

                string url = URL + "/" + lbId;

                for (int i = 0; i < maxRetry; i++)
                {
                    var response = await http.DeleteAsync(url, token);

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
                        isDeleted = true;
                        break;
                    }

                    lastError = await response.Content.ReadAsStringAsync();

                    // nếu còn bị lock thì chờ rồi retry
                    await Task.Delay(delay);
                }

                if (!isDeleted)
                {
                    return (false, $"Xóa loadbalancer '{lbId}' thất bại: {lastError}");
                }
            }

            return (true, null);
        }

        private async Task<(bool, string)> WaitForActive(string lbId)
        {
            var lbService = new LoadBalancerService();

            for (int i = 0; i < 20; i++)
            {
                var res = await lbService.GetLoadBalancerAsync(Main._token, lbId);

                if (!res.Item1)
                    return res;

                dynamic data = JsonConvert.DeserializeObject(res.Item2);
                string status = data.loadbalancer.provisioning_status;

                if (status == "ACTIVE")
                    return (true, null);

                if (status == "ERROR")
                    return (false, "LB bị ERROR");

                await Task.Delay(3000);
            }

            return (false, "Timeout chờ ACTIVE");
        }
        public async Task RemoveInstanceFromAllPools(string token, string ip, string subnetId)
        {
            try
            {
                PoolMemberService poolMemberService = new PoolMemberService();
                // Bước A: Lấy danh sách tất cả các Pool
                // URL: GET v2/lbaas/pools
                var pools = await poolMemberService.GetAllPools(token);

                foreach (var pool in pools)
                {
                    // Bước B: Lấy danh sách Member của từng Pool
                    // URL: GET v2/lbaas/pools/{pool_id}/members
                    var members = await poolMemberService.GetPoolMemberAsync(token, pool.Id);
                    if(members.Item1)
                    {
                        var memberdata = Newtonsoft.Json.JsonConvert.DeserializeObject<PoolMemberResponse>(members.Item2);

                        // Bước C: Tìm member khớp IP và Subnet
                        var targetMember = memberdata.members.FirstOrDefault(m => m.address == ip && m.subnet_id == subnetId);

                        if (targetMember != null)
                        {
                            // Bước D: Xóa Member này khỏi Pool
                            // URL: DELETE v2/lbaas/pools/{pool_id}/members/{member_id}
                            await poolMemberService.RemoveMemberFromPool(token, pool.Id, pool.loadbalancers[0].id,new string[] { targetMember.id});
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                // Log lỗi hoặc bỏ qua để tiếp tục xóa Instance
                Debug.WriteLine("Lỗi khi dọn dẹp LB: " + ex.Message);
            }
        }


    }
}
