namespace NT533.Q21._1_Lab2
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.L_OS = new System.Windows.Forms.Label();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.TB_Pass = new System.Windows.Forms.TextBox();
            this.L_Name = new System.Windows.Forms.Label();
            this.L_Pass = new System.Windows.Forms.Label();
            this.B_Login = new System.Windows.Forms.Button();
            this.P_L_OS = new System.Windows.Forms.Panel();
            this.P_B_Login = new System.Windows.Forms.Panel();
            this.P_TB_LB_Login = new System.Windows.Forms.Panel();
            this.P_L_OS.SuspendLayout();
            this.P_B_Login.SuspendLayout();
            this.P_TB_LB_Login.SuspendLayout();
            this.SuspendLayout();
            // 
            // L_OS
            // 
            this.L_OS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.L_OS.AutoSize = true;
            this.L_OS.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F);
            this.L_OS.Location = new System.Drawing.Point(350, 28);
            this.L_OS.Name = "L_OS";
            this.L_OS.Size = new System.Drawing.Size(218, 46);
            this.L_OS.TabIndex = 0;
            this.L_OS.Text = "OpenStack";
            this.L_OS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TB_Name
            // 
            this.TB_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.TB_Name.Location = new System.Drawing.Point(443, 89);
            this.TB_Name.Multiline = true;
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(300, 31);
            this.TB_Name.TabIndex = 1;
            // 
            // TB_Pass
            // 
            this.TB_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.TB_Pass.Location = new System.Drawing.Point(443, 169);
            this.TB_Pass.Name = "TB_Pass";
            this.TB_Pass.PasswordChar = '*';
            this.TB_Pass.Size = new System.Drawing.Size(300, 32);
            this.TB_Pass.TabIndex = 2;
            this.TB_Pass.UseSystemPasswordChar = true;
            // 
            // L_Name
            // 
            this.L_Name.AutoSize = true;
            this.L_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.L_Name.Location = new System.Drawing.Point(194, 89);
            this.L_Name.Name = "L_Name";
            this.L_Name.Size = new System.Drawing.Size(139, 31);
            this.L_Name.TabIndex = 3;
            this.L_Name.Text = "Username";
            // 
            // L_Pass
            // 
            this.L_Pass.AutoSize = true;
            this.L_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.L_Pass.Location = new System.Drawing.Point(194, 169);
            this.L_Pass.Name = "L_Pass";
            this.L_Pass.Size = new System.Drawing.Size(134, 31);
            this.L_Pass.TabIndex = 4;
            this.L_Pass.Text = "Password";
            // 
            // B_Login
            // 
            this.B_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.B_Login.Location = new System.Drawing.Point(404, 22);
            this.B_Login.Name = "B_Login";
            this.B_Login.Size = new System.Drawing.Size(127, 57);
            this.B_Login.TabIndex = 5;
            this.B_Login.Text = "Login";
            this.B_Login.UseVisualStyleBackColor = true;
            this.B_Login.Click += new System.EventHandler(this.B_Login_Click);
            // 
            // P_L_OS
            // 
            this.P_L_OS.Controls.Add(this.L_OS);
            this.P_L_OS.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_OS.Location = new System.Drawing.Point(0, 0);
            this.P_L_OS.Name = "P_L_OS";
            this.P_L_OS.Size = new System.Drawing.Size(944, 100);
            this.P_L_OS.TabIndex = 6;
            this.P_L_OS.Resize += new System.EventHandler(this.P_L_OS_Resize);
            // 
            // P_B_Login
            // 
            this.P_B_Login.Controls.Add(this.B_Login);
            this.P_B_Login.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.P_B_Login.Location = new System.Drawing.Point(0, 401);
            this.P_B_Login.Name = "P_B_Login";
            this.P_B_Login.Size = new System.Drawing.Size(944, 100);
            this.P_B_Login.TabIndex = 7;
            this.P_B_Login.Resize += new System.EventHandler(this.P_B_Login_Resize);
            // 
            // P_TB_LB_Login
            // 
            this.P_TB_LB_Login.Controls.Add(this.TB_Pass);
            this.P_TB_LB_Login.Controls.Add(this.TB_Name);
            this.P_TB_LB_Login.Controls.Add(this.L_Pass);
            this.P_TB_LB_Login.Controls.Add(this.L_Name);
            this.P_TB_LB_Login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_TB_LB_Login.Location = new System.Drawing.Point(0, 100);
            this.P_TB_LB_Login.Name = "P_TB_LB_Login";
            this.P_TB_LB_Login.Size = new System.Drawing.Size(944, 301);
            this.P_TB_LB_Login.TabIndex = 8;
            this.P_TB_LB_Login.Resize += new System.EventHandler(this.P_TB_LB_Login_Resize);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.P_TB_LB_Login);
            this.Controls.Add(this.P_B_Login);
            this.Controls.Add(this.P_L_OS);
            this.Name = "Login";
            this.Text = "Login";
            this.P_L_OS.ResumeLayout(false);
            this.P_L_OS.PerformLayout();
            this.P_B_Login.ResumeLayout(false);
            this.P_TB_LB_Login.ResumeLayout(false);
            this.P_TB_LB_Login.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label L_OS;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.TextBox TB_Pass;
        private System.Windows.Forms.Label L_Name;
        private System.Windows.Forms.Label L_Pass;
        private System.Windows.Forms.Button B_Login;
        private System.Windows.Forms.Panel P_L_OS;
        private System.Windows.Forms.Panel P_B_Login;
        private System.Windows.Forms.Panel P_TB_LB_Login;
    }
}

