using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT533.Q21._1_Lab2.Dialog
{
    internal class CreateNetworkDialog
    {
        public static (string networkName, bool enableAdmin, bool createSubnet)? CreateNetworkForm()
        {
            Form form = new Form()
            {
                Width = 420,
                Height = 250,
                Text = "Create Network",
                StartPosition = FormStartPosition.CenterParent
            };

            // Network Name
            Label lb1 = new Label() { Text = "Network Name:", Top = 20, Left = 10, Width = 150 };
            TextBox tbName = new TextBox() { Top = 40, Left = 10, Width = 380 };

            // Enable Admin State
            CheckBox cbAdmin = new CheckBox()
            {
                Text = "Enable Admin State",
                Top = 80,
                Left = 10,
                Width = 200,
                Checked = true
            };

            // Create Subnet
            CheckBox cbSubnet = new CheckBox()
            {
                Text = "Create Subnet",
                Top = 110,
                Left = 10,
                Width = 200,
                Checked = true
            };

            // Buttons
            Button btnCreate = new Button()
            {
                Text = "Create",
                Top = 150,
                Left = 220,
                Width = 80
            };

            Button btnCancel = new Button()
            {
                Text = "Cancel",
                Top = 150,
                Left = 310,
                Width = 80
            };

            form.Controls.AddRange(new Control[]
            {
        lb1, tbName,
        cbAdmin, cbSubnet,
        btnCreate, btnCancel
            });

            (string, bool, bool)? result = null;

            btnCreate.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tbName.Text))
                {
                    MessageBox.Show("Network Name is required!");
                    return;
                }

                result = (
                    tbName.Text,
                    cbAdmin.Checked,
                    cbSubnet.Checked
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
