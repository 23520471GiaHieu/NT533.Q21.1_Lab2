using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT533.Q21._1_Lab2.Dialog
{
    internal class CreateSubnetDialog
    {
        public static (string subnetName, string networkAddress, string ipVersion, string gateway)? CreateSubnetForm()
        {
            Form form = new Form()
            {
                Width = 420,
                Height = 320,
                Text = "Create Subnet",
                StartPosition = FormStartPosition.CenterParent
            };

            // Subnet Name
            Label lb1 = new Label() { Text = "Subnet Name:", Top = 20, Left = 10, Width = 120 };
            TextBox tbName = new TextBox() { Top = 40, Left = 10, Width = 380 };

            // Network Address
            Label lb2 = new Label() { Text = "Network Address *:", Top = 70, Left = 10, Width = 150 };
            TextBox tbNetwork = new TextBox() { Top = 90, Left = 10, Width = 380 };

            // IP Version
            Label lb3 = new Label() { Text = "IP Version:", Top = 120, Left = 10, Width = 120 };
            ComboBox cbIP = new ComboBox() { Top = 140, Left = 10, Width = 200 };
            cbIP.Items.AddRange(new string[] { "IPv4", "IPv6" });
            cbIP.SelectedIndex = 0;

            // Gateway
            Label lb4 = new Label() { Text = "Gateway IP:", Top = 170, Left = 10, Width = 120 };
            TextBox tbGateway = new TextBox() { Top = 190, Left = 10, Width = 380 };

            // Buttons
            Button btnCreate = new Button() { Text = "Create", Top = 230, Left = 220, Width = 80 };
            Button btnCancel = new Button() { Text = "Cancel", Top = 230, Left = 310, Width = 80 };

            form.Controls.AddRange(new Control[] {
        lb1, tbName,
        lb2, tbNetwork,
        lb3, cbIP,
        lb4, tbGateway,
        btnCreate, btnCancel
    });

            (string, string, string, string)? result = null;

            btnCreate.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tbNetwork.Text))
                {
                    MessageBox.Show("Network Address is required!");
                    return;
                }

                result = (
                    tbName.Text,
                    tbNetwork.Text,
                    cbIP.SelectedIndex == 0 ? "4" : "6",
                    tbGateway.Text
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
