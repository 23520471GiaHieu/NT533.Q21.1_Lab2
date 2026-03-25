using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT533.Q21._1_Lab2.Network
{
    internal class CreateSecurityGroupDialog
    {
        public static (string name, string description)? CreateSecurityGroupForm()
        {
            Form form = new Form()
            {
                Width = 420,
                Height = 260,
                Text = "Create Security Group",
                StartPosition = FormStartPosition.CenterParent
            };

            Label lb1 = new Label() { Text = "Name *:", Top = 20, Left = 10, Width = 120 };
            TextBox tbName = new TextBox() { Top = 40, Left = 10, Width = 380 };

            Label lb2 = new Label() { Text = "Description:", Top = 80, Left = 10, Width = 120 };
            TextBox tbDesc = new TextBox() { Top = 100, Left = 10, Width = 380 };

            // Buttons
            Button btnCreate = new Button()
            {
                Text = "Create",
                Top = 160,
                Left = 220,
                Width = 80,
                BackColor = Color.Orange
            };

            Button btnCancel = new Button()
            {
                Text = "Cancel",
                Top = 160,
                Left = 310,
                Width = 80
            };

            form.Controls.AddRange(new Control[]
            {
        lb1, tbName,
        lb2, tbDesc,
        btnCreate, btnCancel
            });

            (string, string)? result = null;

            btnCreate.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tbName.Text))
                {
                    MessageBox.Show("Name is required!");
                    return;
                }

                result = (tbName.Text, tbDesc.Text);
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
