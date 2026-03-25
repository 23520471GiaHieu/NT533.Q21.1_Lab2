using Newtonsoft.Json.Linq;
using NT533.Q21._1_Lab2.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT533.Q21._1_Lab2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            P_L_OS_Resize(null, null);
            P_B_Login_Resize(null, null);
            P_TB_LB_Login_Resize(null, null);
        }
        private void P_L_OS_Resize(object sender, EventArgs e)
        {
            L_OS.Left = (P_L_OS.Width - L_OS.Width) / 2;
            L_OS.Top = (P_L_OS.Height - L_OS.Height) / 2;
        }
        private void P_B_Login_Resize(object sender, EventArgs e)
        {
            B_Login.Left = (P_B_Login.Width - B_Login.Width) / 2;
            B_Login.Top = (P_B_Login.Height - B_Login.Height) / 2;
        }
        private void P_TB_LB_Login_Resize(object sender, EventArgs e)
        {
            L_Name.Left = (P_TB_LB_Login.Width - L_Name.Width) / 2 - 200;
            L_Name.Top = (P_TB_LB_Login.Height - L_Name.Height) / 2 - 40;
            TB_Name.Left = (P_TB_LB_Login.Width - TB_Name.Width) / 2 + 100;
            TB_Name.Top = (P_TB_LB_Login.Height - TB_Name.Height) / 2 - 40;

            L_Pass.Left = (P_TB_LB_Login.Width - L_Pass.Width) / 2 - 200;
            L_Pass.Top = (P_TB_LB_Login.Height - L_Pass.Height) / 2 + 40;
            TB_Pass.Left = (P_TB_LB_Login.Width - TB_Pass.Width) / 2 + 100;
            TB_Pass.Top = (P_TB_LB_Login.Height - TB_Pass.Height) / 2 + 40;
        }
        private async void B_Login_Click(object sender, EventArgs e)
        {
            string name = TB_Name.Text;
            string pass = TB_Pass.Text;

            AuthService auth = new AuthService();

            (bool success,string message) result = await auth.PostLoginAsync(name, pass);

            if (result.success)
            {
                Main main = new Main((name,pass,result.message), this);
                main.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login thất bại!\n" + result.message);
            }
        }
    }
}
