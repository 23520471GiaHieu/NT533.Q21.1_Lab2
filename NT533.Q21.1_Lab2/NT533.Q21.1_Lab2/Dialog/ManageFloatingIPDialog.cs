using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NT533.Q21._1_Lab2.Network.InterfaceService;

namespace NT533.Q21._1_Lab2.Dialog
{
    internal class ManageFloatingIPDialog
    {
        public static (string fipid, string portid)? ShowManageFloatingIP(List<(string,string)> availableIPs, List<(string, string)> availablePorts)
        {
            Form form = new Form()
            {
                Width = 550,
                Height = 320,
                Text = "Manage Floating IP Associations",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Tiêu đề chính
            Label lbTitle = new Label()
            {
                Text = "Manage Floating IP Associations",
                Top = 15,
                Left = 15,
                Width = 400,
                Font = new Font("Arial", 12, FontStyle.Regular)
            };

            // Phần chọn IP Address
            Label lbIP = new Label() { Text = "IP Address *", Top = 60, Left = 20, Width = 150, Font = new Font("Arial", 9, FontStyle.Bold) };
            ComboBox cbIP = new ComboBox() { Top = 85, Left = 20, Width = 280, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var ip in availableIPs)
            {
                cbIP.Items.Add(ip.Item2);
            }

            if (cbIP.Items.Count > 0) cbIP.SelectedIndex = 0;

            // Nút dấu cộng (+) bên cạnh IP
            //Button btnAddIP = new Button() { Text = "+", Top = 84, Left = 305, Width = 35, Height = 25, ForeColor = Color.OrangeRed };

            // Phần chọn Port
            Label lbPort = new Label() { Text = "Port to be associated *", Top = 130, Left = 20, Width = 200, Font = new Font("Arial", 9, FontStyle.Bold) };
            ComboBox cbPort = new ComboBox() { Top = 155, Left = 20, Width = 320, DropDownStyle = ComboBoxStyle.DropDownList };
            foreach (var port in availablePorts)
            {
                cbPort.Items.Add(port.Item2);
            }

            if (cbPort.Items.Count > 0) cbPort.SelectedIndex = 0;

            // Đoạn text hướng dẫn bên phải
            Label lbDescription = new Label()
            {
                Text = "Select the IP address you wish to associate with the selected instance or port.",
                Top = 75,
                Left = 360,
                Width = 160,
                Height = 100,
                ForeColor = Color.Gray
            };

            // Nút bấm phía dưới
            Button btnAssociate = new Button()
            {
                Text = "Associate",
                Top = 230,
                Left = 410,
                Width = 100,
                Height = 35,
                BackColor = Color.FromArgb(230, 81, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            Button btnCancel = new Button()
            {
                Text = "Cancel",
                Top = 230,
                Left = 320,
                Width = 80,
                Height = 35
            };

            // Thêm các control vào form
            form.Controls.AddRange(new Control[] { lbTitle, lbIP, cbIP, lbPort, cbPort, lbDescription, btnAssociate, btnCancel });

            (string, string)? result = null;

            btnAssociate.Click += (s, e) =>
            {
                if (cbIP.SelectedItem != null && cbPort.SelectedItem != null)
                {
                    string fipid = availableIPs[cbIP.SelectedIndex].Item1;
                    string portid = availablePorts[cbPort.SelectedIndex].Item1;
                    result = (fipid, portid);
                    form.Close();
                }
                else
                {
                    MessageBox.Show("Please select both IP and Port.");
                }
            };

            btnCancel.Click += (s, e) =>
            {
                form.Close();
            };

            form.ShowDialog();

            return result;
        }

        public static (string ipid,string netid)? AssociateFloatingIPForm(List<(string, string)> availableIPs, List<(string,string)> availableNets)
        {
            Form form = new Form()
            {
                Width = 500,
                Height = 300,
                Text = "Associate Floating IP Address",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Tiêu đề chính
            Label lbHeader = new Label()
            {
                Text = "Associate Floating IP Address",
                Top = 15,
                Left = 15,
                Width = 450,
                Font = new Font("Segoe UI", 12, FontStyle.Regular)
            };

            // Dòng hướng dẫn
            Label lbInstruction = new Label()
            {
                Text = "Select a floating IP address to associate with the load balancer or a floating IP pool in which to allocate a new floating IP address.",
                Top = 50,
                Left = 15,
                Width = 450,
                Height = 40
            };

            // Label cho ComboBox (có dấu * đỏ)
            Label lbSelect = new Label() { Text = "Floating IP address or pool *", Top = 100, Left = 15, Width = 250, Font = new Font("Segoe UI", 9, FontStyle.Bold) };

            // ComboBox để chọn IP hoặc Pool
            ComboBox cbIP = new ComboBox()
            {
                Top = 125,
                Left = 15,
                Width = 450,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Thêm dữ liệu mẫu vào ComboBox (giống trong ảnh)
            cbIP.Items.Add("--- Floating IP addresses ---");
            foreach(var ip in availableIPs)
            {
                cbIP.Items.Add(ip.Item2);
            }
            cbIP.Items.Add("--- Floating IP pools ---");
            foreach (var net in availableNets)
            {
                cbIP.Items.Add(net.Item2);
            }

            cbIP.SelectedIndex = 1; // Chọn mặc định dòng IP đầu tiên

            // Nút Associate (Màu cam)
            Button btnAssociate = new Button()
            {
                Text = "Associate",
                Top = 200,
                Left = 365,
                Width = 100,
                Height = 35,
                BackColor = Color.FromArgb(240, 132, 90), // Màu cam nhẹ
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // Nút Cancel
            Button btnCancel = new Button()
            {
                Text = "Cancel",
                Top = 200,
                Left = 275,
                Width = 80,
                Height = 35
            };

            form.Controls.AddRange(new Control[] { lbHeader, lbInstruction, lbSelect, cbIP, btnAssociate, btnCancel });

            (string, string)? result = null;

            btnAssociate.Click += (s, e) =>
            {
                // Kiểm tra nếu người dùng chọn các dòng tiêu đề thì không cho đóng form
                if (cbIP.Text.StartsWith("---"))
                {
                    MessageBox.Show("Please select a valid IP or Pool.");
                    return;
                }
                int index = cbIP.SelectedIndex;
                //selectedValue = cbIP.SelectedItem.ToString();
                int ipcount = availableIPs.Count;
                int netcount = availableNets.Count;

                string ipid = null;
                string netid = null;
                if(index > ipcount)
                {
                    netid = availableNets[index - ipcount - 2].Item1;
                }
                else
                {
                    ipid = availableIPs[index - 1].Item1;
                }
                result = (ipid, netid);
                form.DialogResult = DialogResult.OK;
                form.Close();
            };

            btnCancel.Click += (s, e) =>
            {
                form.DialogResult = DialogResult.Cancel;
                form.Close();
            };

            form.ShowDialog();

            return result;
        }
    }
}
