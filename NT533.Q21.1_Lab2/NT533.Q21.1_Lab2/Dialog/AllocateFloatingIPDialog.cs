using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT533.Q21._1_Lab2.Dialog
{
    internal class AllocateFloatingIPDialog
    {
        public static (string pool, string ip, string desc, string dnsDomain, string dnsName)? AllocateIPForm(List<string> pools)
        {
            Form form = new Form()
            {
                Width = 320,
                Height = 360,
                Text = "Allocate Floating IP",
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // ===== CONTROLS =====
            Label lbPool = new Label() { Text = "Pool *", Left = 10, Top = 15, Width = 120 };
            ComboBox cbPool = new ComboBox()
            {
                Left = 10,
                Top = 35,
                Width = 280,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // bạn truyền data vào đây
            cbPool.Items.AddRange(pools.ToArray());
            if (cbPool.Items.Count > 0)
                cbPool.SelectedIndex = 0;

            Label lbIP = new Label() { Text = "Floating IP Address (optional)", Left = 10, Top = 75, Width = 250 };
            TextBox tbIP = new TextBox() { Left = 10, Top = 95, Width = 280 };

            Label lbDesc = new Label() { Text = "Description", Left = 10, Top = 130, Width = 120 };
            TextBox tbDesc = new TextBox() { Left = 10, Top = 150, Width = 280 };

            Label lbDNSDomain = new Label() { Text = "DNS Domain", Left = 10, Top = 185, Width = 120 };
            TextBox tbDNSDomain = new TextBox() { Left = 10, Top = 205, Width = 280 };

            Label lbDNSName = new Label() { Text = "DNS Name", Left = 10, Top = 240, Width = 120 };
            TextBox tbDNSName = new TextBox() { Left = 10, Top = 260, Width = 280 };

            // ===== BUTTONS =====
            Button btnCancel = new Button()
            {
                Text = "Cancel",
                Width = 80,
                Left = 120,
                Top = 300
            };

            Button btnOK = new Button()
            {
                Text = "Allocate IP",
                Width = 100,
                Left = 200,
                Top = 300,
                BackColor = Color.OrangeRed,
                ForeColor = Color.White
            };

            (string, string, string, string, string)? result = null;

            btnOK.Click += (s, e) =>
            {
                result = (
                    cbPool.Text,
                    tbIP.Text,
                    tbDesc.Text,
                    tbDNSDomain.Text,
                    tbDNSName.Text
                );
                form.Close();
            };

            btnCancel.Click += (s, e) => form.Close();

            // ===== ADD =====
            form.Controls.AddRange(new Control[]
            {
        lbPool, cbPool,
        lbIP, tbIP,
        lbDesc, tbDesc,
        lbDNSDomain, tbDNSDomain,
        lbDNSName, tbDNSName,
        btnCancel, btnOK
            });

            form.ShowDialog();
            return result;
        }
    }
}
