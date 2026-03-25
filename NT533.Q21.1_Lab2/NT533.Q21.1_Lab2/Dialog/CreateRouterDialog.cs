using NT533.Q21._1_Lab2.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NT533.Q21._1_Lab2.Network.NetworkService;

namespace NT533.Q21._1_Lab2.Dialog
{
    internal class CreateRouterDialog
    {
        public static async Task<(string routerName, bool adminState, string externalNetId)?> CreateRouterForm(string token)
        {
            Form form = new Form()
            {
                Width = 420,
                Height = 300,
                Text = "Create Router",
                StartPosition = FormStartPosition.CenterParent
            };

            // Router Name
            Label lb1 = new Label() { Text = "Router Name:", Top = 20, Left = 10, Width = 120 };
            TextBox tbName = new TextBox() { Top = 40, Left = 10, Width = 380 };

            // Enable Admin
            CheckBox cbAdmin = new CheckBox()
            {
                Text = "Enable Admin State",
                Top = 80,
                Left = 10,
                Checked = true
            };

            // External Network
            Label lb2 = new Label() { Text = "External Network:", Top = 110, Left = 10 };
            ComboBox cbNetwork = new ComboBox()
            {
                Top = 130,
                Left = 10,
                Width = 380,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Buttons
            Button btnCreate = new Button()
            {
                Text = "Create Router",
                Top = 200,
                Left = 230,
                Width = 120,
                BackColor = Color.Orange
            };

            Button btnCancel = new Button()
            {
                Text = "Cancel",
                Top = 200,
                Left = 120,
                Width = 90
            };

            form.Controls.AddRange(new Control[]
            {
        lb1, tbName,
        cbAdmin,
        lb2, cbNetwork,
        btnCreate, btnCancel
            });

            NetworkService networkService = new NetworkService();
            var resultAPI = await networkService.GetNetworkAsync(token);

            List<NetworkService.Network> externalList = new List<NetworkService.Network>();

            if (resultAPI.Item1)
            {
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<NetworkResponse>(resultAPI.Item2);

                externalList = data.networks
                    .Where(n => Boolean.Parse(n.external))
                    .ToList();

                cbNetwork.DataSource = externalList;
                cbNetwork.DisplayMember = "name";
                cbNetwork.ValueMember = "id";
            }
            else
            {
                MessageBox.Show("Lấy danh sách Networks thất bại!\n" + resultAPI.Item2);
            }

            (string, bool, string)? result = null;

            btnCreate.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tbName.Text))
                {
                    MessageBox.Show("Router Name is required!");
                    return;
                }

                if (cbNetwork.SelectedItem == null)
                {
                    MessageBox.Show("Chọn External Network!");
                    return;
                }

                result = (
                    tbName.Text,
                    cbAdmin.Checked,
                    cbNetwork.SelectedValue.ToString()
                );

                form.Close();
            };

            btnCancel.Click += (s, e) =>
            {
                form.Close();
            };

            form.ShowDialog();

            return result;
        }
    }
}
