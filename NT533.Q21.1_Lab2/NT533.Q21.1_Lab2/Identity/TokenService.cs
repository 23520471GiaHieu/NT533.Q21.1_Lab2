using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace NT533.Q21._1_Lab2.Auth
{
    internal class TokenService
    {
        public async Task<(bool, string)> GetTokenAsync(string username, string password)
        {
            string name = username;
            string pass = password;

            AuthService auth = new AuthService();

            (bool success, string message) result = await auth.PostLoginAsync(name, pass);

            return (result.success, result.message);
        }
    }
}
