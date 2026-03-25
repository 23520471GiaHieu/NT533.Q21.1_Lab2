using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT533.Q21._1_Lab2.Dialog
{
    internal class CreateInterfaceDialog
    {
        public static (string selectedSubnetid, string ipAddress)? AddInterfaceForm(List<(string,string)> subnetList)
        {
            // Tạo Form chính
            Form form = new Form()
            {
                Width = 450,
                Height = 300,
                Text = "Add Interface",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Label cho Subnet
            Label lbSubnet = new Label() { Text = "Subnet *", Top = 20, Left = 20, Width = 100, Font = new Font("Arial", 9, FontStyle.Bold) };

            // ComboBox hiển thị danh sách Subnet
            ComboBox cbSubnet = new ComboBox()
            {
                Top = 45,
                Left = 20,
                Width = 390,
                DropDownStyle = ComboBoxStyle.DropDownList // Chỉ cho phép chọn, không cho gõ bừa
            };

            // Add dữ liệu từ list bạn đã lấy từ API vào
            if (subnetList != null && subnetList.Count > 0)
            {
                foreach (var subnet in subnetList)
                {
                    cbSubnet.Items.Add(subnet.Item2);
                }
                cbSubnet.SelectedIndex = 0; // Chọn cái đầu tiên mặc định
            }

            // Label cho IP Address
            Label lbIP = new Label() { Text = "IP Address (optional)", Top = 90, Left = 20, Width = 200, Font = new Font("Arial", 9, FontStyle.Bold) };
            TextBox tbIP = new TextBox() { Top = 115, Left = 20, Width = 390 };

            // Nút Submit (màu cam nhẹ giống OpenStack)
            Button btnSubmit = new Button()
            {
                Text = "Submit",
                Top = 180,
                Left = 240,
                Width = 80,
                Height = 35,
                BackColor = Color.FromArgb(230, 81, 0),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // Nút Cancel
            Button btnCancel = new Button()
            {
                Text = "Cancel",
                Top = 180,
                Left = 330,
                Width = 80,
                Height = 35
            };

            form.Controls.AddRange(new Control[] { lbSubnet, cbSubnet, lbIP, tbIP, btnSubmit, btnCancel });

            (string, string)? result = null;

            btnSubmit.Click += (s, e) =>
            {
                if (cbSubnet.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn một Subnet!");
                    return;
                }
                int index = cbSubnet.SelectedIndex;
                string subnetid = subnetList[index].Item1;
                result = (subnetid, tbIP.Text);
                form.DialogResult = DialogResult.OK;
                form.Close();
            };

            btnCancel.Click += (s, e) =>
            {
                form.DialogResult = DialogResult.Cancel;
                form.Close();
            };

            // Hiển thị và đợi kết quả
            var dialogResult = form.ShowDialog();

            return dialogResult == DialogResult.OK ? result : null;
        }
    }
}
