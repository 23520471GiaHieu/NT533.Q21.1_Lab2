using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT533.Q21._1_Lab2.Dialog
{
    internal class DisassociateFloatingIPDialog
    {
        public static (string floatingIpid, bool releaseIp)? DisassociateFloatingIPForm(List<(string id,string ipaddress)> availableIps)
        {
            Form form = new Form()
            {
                Width = 500,
                Height = 300,
                Text = "Disassociate Floating IP",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Label tiêu đề chính
            Label lblTitle = new Label() { Text = "Disassociate Floating IP", Top = 10, Left = 10, Width = 300, Font = new Font("Arial", 12, FontStyle.Bold) };

            // Group bên trái: Chọn IP
            Label lblIp = new Label() { Text = "Floating IP *", Top = 50, Left = 20, Width = 100 };
            ComboBox cbIp = new ComboBox() { Top = 75, Left = 20, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var ip in availableIps)
            {
                cbIp.Items.Add(ip.ipaddress);
            }
            if (cbIp.Items.Count > 0) cbIp.SelectedIndex = 0;

            // Group bên phải: Mô tả & Checkbox
            Label lblDescTitle = new Label() { Text = "Description:", Top = 60, Left = 240, Width = 200, Font = new Font("Arial", 10, FontStyle.Bold) };
            Label lblDesc = new Label()
            {
                Text = "Select the floating IP to be disassociated from the instance.",
                Top = 85,
                Left = 240,
                Width = 220,
                Height = 40
            };

            Label lblReleaseTitle = new Label() { Text = "Release Floating IP", Top = 130, Left = 240, Width = 200, Font = new Font("Arial", 10, FontStyle.Bold) };
            CheckBox chkRelease = new CheckBox()
            {
                Text = "If checked, the selected floating IP will be released at the same time.",
                Top = 150,
                Left = 240,
                Width = 220,
                Height = 50
            };

            // Nút bấm
            Button btnCancel = new Button() { Text = "Cancel", Top = 220, Left = 280, Width = 80, DialogResult = DialogResult.Cancel };
            Button btnDisassociate = new Button()
            {
                Text = "Disassociate",
                Top = 220,
                Left = 370,
                Width = 100,
                BackColor = Color.FromArgb(230, 74, 25), // Màu cam đỏ như hình
                ForeColor = Color.White,
                FlatAppearance = { BorderSize = 0 },
                FlatStyle = FlatStyle.Flat
            };

            form.Controls.AddRange(new Control[] { lblTitle, lblIp, cbIp, lblDescTitle, lblDesc, lblReleaseTitle, chkRelease, btnCancel, btnDisassociate });
            form.AcceptButton = btnDisassociate;
            form.CancelButton = btnCancel;

            (string, bool)? result = null;

            btnDisassociate.Click += (s, e) =>
            {
                if (cbIp.SelectedItem != null)
                {
                    int index = cbIp.SelectedIndex;
                    string fipid = availableIps[index].id;
                    result = (fipid, chkRelease.Checked);
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                }
            };

            btnCancel.Click += (s, e) => form.Close();

            form.ShowDialog();
            return result;
        }
    }
}
