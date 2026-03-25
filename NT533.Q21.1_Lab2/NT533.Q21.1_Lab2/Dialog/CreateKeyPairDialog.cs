using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT533.Q21._1_Lab2.Dialog
{
    internal class CreateKeyPairDialog
    {
        public static (string keyName, string publicKey)? CreateKeyPairForm()
        {
            Form form = new Form()
            {
                Width = 400,
                Height = 250,
                Text = "Create KeyPair",
                StartPosition = FormStartPosition.CenterParent
            };

            Label lb1 = new Label() { Text = "Key Name:", Top = 20, Left = 10, Width = 100 };
            TextBox tbName = new TextBox() { Top = 40, Left = 10, Width = 360 };

            Label lb2 = new Label() { Text = "Public Key:", Top = 80, Left = 10, Width = 100 };
            TextBox tbPublic = new TextBox() { Top = 100, Left = 10, Width = 360 };

            Button ok = new Button() { Text = "OK", Top = 150, Left = 200, Width = 80 };
            Button cancel = new Button() { Text = "Cancel", Top = 150, Left = 290, Width = 80 };

            form.Controls.AddRange(new Control[] { lb1, tbName, lb2, tbPublic, ok, cancel });

            (string, string)? result = null;

            ok.Click += (s, e) =>
            {
                result = (tbName.Text, tbPublic.Text);
                form.Close();
            };

            cancel.Click += (s, e) =>
            {
                form.Close();
            };

            form.ShowDialog();

            return result;
        }
    }
}
