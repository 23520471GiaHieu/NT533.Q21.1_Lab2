using System.Drawing;
using System.Windows.Forms;

namespace NT533.Q21._1_Lab2
{
    partial class AddRule
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
            this.P_L_AddRule = new System.Windows.Forms.Panel();
            this.L_AddRule = new System.Windows.Forms.Label();
            this.P_Cr_Can_Rule = new System.Windows.Forms.Panel();
            this.B_CancelRule = new System.Windows.Forms.Button();
            this.B_AddRule = new System.Windows.Forms.Button();
            this.P_Menu = new System.Windows.Forms.Panel();
            this.L_Remote = new System.Windows.Forms.Label();
            this.L_Direction = new System.Windows.Forms.Label();
            this.L_Description = new System.Windows.Forms.Label();
            this.tabControlFullPort = new System.Windows.Forms.TabControl();
            this.tabControlAllPort = new System.Windows.Forms.TabPage();
            this.cB_OpenPort = new System.Windows.Forms.ComboBox();
            this.tabControlPort = new System.Windows.Forms.TabControl();
            this.PortPage = new System.Windows.Forms.TabPage();
            this.tb_Port = new System.Windows.Forms.TextBox();
            this.L_Port = new System.Windows.Forms.Label();
            this.FrToPortPage = new System.Windows.Forms.TabPage();
            this.tb_ToPort = new System.Windows.Forms.TextBox();
            this.tb_FromPort = new System.Windows.Forms.TextBox();
            this.L_FromPort = new System.Windows.Forms.Label();
            this.L_ToPort = new System.Windows.Forms.Label();
            this.Page1 = new System.Windows.Forms.TabPage();
            this.L_OpenPort = new System.Windows.Forms.Label();
            this.CodePage = new System.Windows.Forms.TabPage();
            this.tb_Code = new System.Windows.Forms.TextBox();
            this.tb_Type = new System.Windows.Forms.TextBox();
            this.L_Type = new System.Windows.Forms.Label();
            this.L_Code = new System.Windows.Forms.Label();
            this.ProtocolPage = new System.Windows.Forms.TabPage();
            this.tb_Protocol = new System.Windows.Forms.TextBox();
            this.L_Protocol = new System.Windows.Forms.Label();
            this.Page0 = new System.Windows.Forms.TabPage();
            this.tabControlRemote = new System.Windows.Forms.TabControl();
            this.CIDRPage = new System.Windows.Forms.TabPage();
            this.tb_CIDR = new System.Windows.Forms.TextBox();
            this.L_CIDR = new System.Windows.Forms.Label();
            this.SecGroupPage = new System.Windows.Forms.TabPage();
            this.cB_EType = new System.Windows.Forms.ComboBox();
            this.cB_SecGroup = new System.Windows.Forms.ComboBox();
            this.L_SecGroup = new System.Windows.Forms.Label();
            this.L_EType = new System.Windows.Forms.Label();
            this.cB_Remote = new System.Windows.Forms.ComboBox();
            this.cB_Direction = new System.Windows.Forms.ComboBox();
            this.rtb_Description = new System.Windows.Forms.RichTextBox();
            this.cB_Rule = new System.Windows.Forms.ComboBox();
            this.L_Rule = new System.Windows.Forms.Label();
            this.P_L_AddRule.SuspendLayout();
            this.P_Cr_Can_Rule.SuspendLayout();
            this.P_Menu.SuspendLayout();
            this.tabControlFullPort.SuspendLayout();
            this.tabControlAllPort.SuspendLayout();
            this.tabControlPort.SuspendLayout();
            this.PortPage.SuspendLayout();
            this.FrToPortPage.SuspendLayout();
            this.CodePage.SuspendLayout();
            this.ProtocolPage.SuspendLayout();
            this.tabControlRemote.SuspendLayout();
            this.CIDRPage.SuspendLayout();
            this.SecGroupPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // P_L_AddRule
            // 
            this.P_L_AddRule.Controls.Add(this.L_AddRule);
            this.P_L_AddRule.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_AddRule.Location = new System.Drawing.Point(0, 0);
            this.P_L_AddRule.Name = "P_L_AddRule";
            this.P_L_AddRule.Size = new System.Drawing.Size(944, 50);
            this.P_L_AddRule.TabIndex = 0;
            // 
            // L_AddRule
            // 
            this.L_AddRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.L_AddRule.Location = new System.Drawing.Point(12, 9);
            this.L_AddRule.Name = "L_AddRule";
            this.L_AddRule.Size = new System.Drawing.Size(100, 35);
            this.L_AddRule.TabIndex = 0;
            this.L_AddRule.Text = "Add Rule";
            this.L_AddRule.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // P_Cr_Can_Rule
            // 
            this.P_Cr_Can_Rule.Controls.Add(this.B_CancelRule);
            this.P_Cr_Can_Rule.Controls.Add(this.B_AddRule);
            this.P_Cr_Can_Rule.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.P_Cr_Can_Rule.Location = new System.Drawing.Point(0, 606);
            this.P_Cr_Can_Rule.Name = "P_Cr_Can_Rule";
            this.P_Cr_Can_Rule.Size = new System.Drawing.Size(944, 75);
            this.P_Cr_Can_Rule.TabIndex = 1;
            // 
            // B_CancelRule
            // 
            this.B_CancelRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.B_CancelRule.Location = new System.Drawing.Point(690, 22);
            this.B_CancelRule.Name = "B_CancelRule";
            this.B_CancelRule.Size = new System.Drawing.Size(100, 35);
            this.B_CancelRule.TabIndex = 1;
            this.B_CancelRule.Text = "Cancel";
            this.B_CancelRule.UseVisualStyleBackColor = true;
            this.B_CancelRule.Click += new System.EventHandler(this.B_CancelRule_Click);
            // 
            // B_AddRule
            // 
            this.B_AddRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.B_AddRule.Location = new System.Drawing.Point(832, 22);
            this.B_AddRule.Name = "B_AddRule";
            this.B_AddRule.Size = new System.Drawing.Size(100, 35);
            this.B_AddRule.TabIndex = 0;
            this.B_AddRule.Text = "Add";
            this.B_AddRule.UseVisualStyleBackColor = true;
            this.B_AddRule.Click += new System.EventHandler(this.B_AddRule_Click);
            // 
            // P_Menu
            // 
            this.P_Menu.Controls.Add(this.L_Remote);
            this.P_Menu.Controls.Add(this.L_Direction);
            this.P_Menu.Controls.Add(this.L_Description);
            this.P_Menu.Controls.Add(this.tabControlFullPort);
            this.P_Menu.Controls.Add(this.tabControlRemote);
            this.P_Menu.Controls.Add(this.cB_Remote);
            this.P_Menu.Controls.Add(this.cB_Direction);
            this.P_Menu.Controls.Add(this.rtb_Description);
            this.P_Menu.Controls.Add(this.cB_Rule);
            this.P_Menu.Controls.Add(this.L_Rule);
            this.P_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_Menu.Location = new System.Drawing.Point(0, 50);
            this.P_Menu.Name = "P_Menu";
            this.P_Menu.Size = new System.Drawing.Size(944, 631);
            this.P_Menu.TabIndex = 1;
            // 
            // L_Remote
            // 
            this.L_Remote.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Remote.Location = new System.Drawing.Point(689, 17);
            this.L_Remote.Name = "L_Remote";
            this.L_Remote.Size = new System.Drawing.Size(140, 50);
            this.L_Remote.TabIndex = 19;
            this.L_Remote.Text = "Remote";
            this.L_Remote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Direction
            // 
            this.L_Direction.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Direction.Location = new System.Drawing.Point(30, 407);
            this.L_Direction.Name = "L_Direction";
            this.L_Direction.Size = new System.Drawing.Size(191, 50);
            this.L_Direction.TabIndex = 18;
            this.L_Direction.Text = "Direction";
            this.L_Direction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // L_Description
            // 
            this.L_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Description.Location = new System.Drawing.Point(33, 152);
            this.L_Description.Name = "L_Description";
            this.L_Description.Size = new System.Drawing.Size(191, 50);
            this.L_Description.TabIndex = 17;
            this.L_Description.Text = "Description";
            this.L_Description.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControlFullPort
            // 
            this.tabControlFullPort.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlFullPort.Controls.Add(this.tabControlAllPort);
            this.tabControlFullPort.Controls.Add(this.CodePage);
            this.tabControlFullPort.Controls.Add(this.ProtocolPage);
            this.tabControlFullPort.Controls.Add(this.Page0);
            this.tabControlFullPort.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlFullPort.Location = new System.Drawing.Point(255, 6);
            this.tabControlFullPort.Name = "tabControlFullPort";
            this.tabControlFullPort.SelectedIndex = 0;
            this.tabControlFullPort.Size = new System.Drawing.Size(371, 544);
            this.tabControlFullPort.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlFullPort.TabIndex = 16;
            // 
            // tabControlAllPort
            // 
            this.tabControlAllPort.Controls.Add(this.cB_OpenPort);
            this.tabControlAllPort.Controls.Add(this.tabControlPort);
            this.tabControlAllPort.Controls.Add(this.L_OpenPort);
            this.tabControlAllPort.Location = new System.Drawing.Point(4, 5);
            this.tabControlAllPort.Name = "tabControlAllPort";
            this.tabControlAllPort.Padding = new System.Windows.Forms.Padding(3);
            this.tabControlAllPort.Size = new System.Drawing.Size(363, 535);
            this.tabControlAllPort.TabIndex = 0;
            this.tabControlAllPort.Text = "tabPage6";
            this.tabControlAllPort.UseVisualStyleBackColor = true;
            // 
            // cB_OpenPort
            // 
            this.cB_OpenPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cB_OpenPort.FormattingEnabled = true;
            this.cB_OpenPort.Items.AddRange(new object[] {
            "Port",
            "Port Range",
            "All Port"});
            this.cB_OpenPort.Location = new System.Drawing.Point(88, 78);
            this.cB_OpenPort.Name = "cB_OpenPort";
            this.cB_OpenPort.Size = new System.Drawing.Size(184, 32);
            this.cB_OpenPort.TabIndex = 12;
            this.cB_OpenPort.SelectedIndexChanged += new System.EventHandler(this.cB_OpenPort_SelectedIndexChanged);
            // 
            // tabControlPort
            // 
            this.tabControlPort.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlPort.Controls.Add(this.PortPage);
            this.tabControlPort.Controls.Add(this.FrToPortPage);
            this.tabControlPort.Controls.Add(this.Page1);
            this.tabControlPort.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlPort.Location = new System.Drawing.Point(0, 141);
            this.tabControlPort.Name = "tabControlPort";
            this.tabControlPort.SelectedIndex = 0;
            this.tabControlPort.Size = new System.Drawing.Size(363, 394);
            this.tabControlPort.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlPort.TabIndex = 14;
            // 
            // PortPage
            // 
            this.PortPage.Controls.Add(this.tb_Port);
            this.PortPage.Controls.Add(this.L_Port);
            this.PortPage.Location = new System.Drawing.Point(4, 5);
            this.PortPage.Name = "PortPage";
            this.PortPage.Padding = new System.Windows.Forms.Padding(3);
            this.PortPage.Size = new System.Drawing.Size(355, 385);
            this.PortPage.TabIndex = 0;
            this.PortPage.Text = "tabPage1";
            this.PortPage.UseVisualStyleBackColor = true;
            // 
            // tb_Port
            // 
            this.tb_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tb_Port.Location = new System.Drawing.Point(84, 84);
            this.tb_Port.Multiline = true;
            this.tb_Port.Name = "tb_Port";
            this.tb_Port.Size = new System.Drawing.Size(184, 32);
            this.tb_Port.TabIndex = 15;
            // 
            // L_Port
            // 
            this.L_Port.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Port.Location = new System.Drawing.Point(77, 24);
            this.L_Port.Name = "L_Port";
            this.L_Port.Size = new System.Drawing.Size(140, 50);
            this.L_Port.TabIndex = 11;
            this.L_Port.Text = "Port";
            // 
            // FrToPortPage
            // 
            this.FrToPortPage.Controls.Add(this.tb_ToPort);
            this.FrToPortPage.Controls.Add(this.tb_FromPort);
            this.FrToPortPage.Controls.Add(this.L_FromPort);
            this.FrToPortPage.Controls.Add(this.L_ToPort);
            this.FrToPortPage.Location = new System.Drawing.Point(4, 5);
            this.FrToPortPage.Name = "FrToPortPage";
            this.FrToPortPage.Padding = new System.Windows.Forms.Padding(3);
            this.FrToPortPage.Size = new System.Drawing.Size(355, 385);
            this.FrToPortPage.TabIndex = 1;
            this.FrToPortPage.Text = "tabPage2";
            this.FrToPortPage.UseVisualStyleBackColor = true;
            // 
            // tb_ToPort
            // 
            this.tb_ToPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tb_ToPort.Location = new System.Drawing.Point(84, 180);
            this.tb_ToPort.Multiline = true;
            this.tb_ToPort.Name = "tb_ToPort";
            this.tb_ToPort.Size = new System.Drawing.Size(184, 32);
            this.tb_ToPort.TabIndex = 18;
            // 
            // tb_FromPort
            // 
            this.tb_FromPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tb_FromPort.Location = new System.Drawing.Point(84, 84);
            this.tb_FromPort.Multiline = true;
            this.tb_FromPort.Name = "tb_FromPort";
            this.tb_FromPort.Size = new System.Drawing.Size(184, 32);
            this.tb_FromPort.TabIndex = 17;
            // 
            // L_FromPort
            // 
            this.L_FromPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_FromPort.Location = new System.Drawing.Point(77, 24);
            this.L_FromPort.Name = "L_FromPort";
            this.L_FromPort.Size = new System.Drawing.Size(216, 50);
            this.L_FromPort.TabIndex = 12;
            this.L_FromPort.Text = "From Port";
            // 
            // L_ToPort
            // 
            this.L_ToPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_ToPort.Location = new System.Drawing.Point(77, 127);
            this.L_ToPort.Name = "L_ToPort";
            this.L_ToPort.Size = new System.Drawing.Size(140, 50);
            this.L_ToPort.TabIndex = 11;
            this.L_ToPort.Text = "To Port";
            // 
            // Page1
            // 
            this.Page1.Location = new System.Drawing.Point(4, 5);
            this.Page1.Name = "Page1";
            this.Page1.Padding = new System.Windows.Forms.Padding(3);
            this.Page1.Size = new System.Drawing.Size(355, 385);
            this.Page1.TabIndex = 2;
            this.Page1.Text = "tabPage5";
            this.Page1.UseVisualStyleBackColor = true;
            // 
            // L_OpenPort
            // 
            this.L_OpenPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_OpenPort.Location = new System.Drawing.Point(81, 13);
            this.L_OpenPort.Name = "L_OpenPort";
            this.L_OpenPort.Size = new System.Drawing.Size(216, 50);
            this.L_OpenPort.TabIndex = 11;
            this.L_OpenPort.Text = "Open Port";
            // 
            // CodePage
            // 
            this.CodePage.Controls.Add(this.tb_Code);
            this.CodePage.Controls.Add(this.tb_Type);
            this.CodePage.Controls.Add(this.L_Type);
            this.CodePage.Controls.Add(this.L_Code);
            this.CodePage.Location = new System.Drawing.Point(4, 5);
            this.CodePage.Name = "CodePage";
            this.CodePage.Padding = new System.Windows.Forms.Padding(3);
            this.CodePage.Size = new System.Drawing.Size(363, 535);
            this.CodePage.TabIndex = 1;
            this.CodePage.Text = "tabPage7";
            this.CodePage.UseVisualStyleBackColor = true;
            // 
            // tb_Code
            // 
            this.tb_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tb_Code.Location = new System.Drawing.Point(82, 223);
            this.tb_Code.Multiline = true;
            this.tb_Code.Name = "tb_Code";
            this.tb_Code.Size = new System.Drawing.Size(184, 32);
            this.tb_Code.TabIndex = 18;
            // 
            // tb_Type
            // 
            this.tb_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tb_Type.Location = new System.Drawing.Point(82, 78);
            this.tb_Type.Multiline = true;
            this.tb_Type.Name = "tb_Type";
            this.tb_Type.Size = new System.Drawing.Size(184, 32);
            this.tb_Type.TabIndex = 17;
            // 
            // L_Type
            // 
            this.L_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Type.Location = new System.Drawing.Point(75, 13);
            this.L_Type.Name = "L_Type";
            this.L_Type.Size = new System.Drawing.Size(216, 50);
            this.L_Type.TabIndex = 12;
            this.L_Type.Text = "Type";
            // 
            // L_Code
            // 
            this.L_Code.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Code.Location = new System.Drawing.Point(75, 148);
            this.L_Code.Name = "L_Code";
            this.L_Code.Size = new System.Drawing.Size(140, 50);
            this.L_Code.TabIndex = 11;
            this.L_Code.Text = "Code";
            // 
            // ProtocolPage
            // 
            this.ProtocolPage.Controls.Add(this.tb_Protocol);
            this.ProtocolPage.Controls.Add(this.L_Protocol);
            this.ProtocolPage.Location = new System.Drawing.Point(4, 5);
            this.ProtocolPage.Name = "ProtocolPage";
            this.ProtocolPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProtocolPage.Size = new System.Drawing.Size(363, 535);
            this.ProtocolPage.TabIndex = 2;
            this.ProtocolPage.Text = "tabPage8";
            this.ProtocolPage.UseVisualStyleBackColor = true;
            // 
            // tb_Protocol
            // 
            this.tb_Protocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tb_Protocol.Location = new System.Drawing.Point(83, 78);
            this.tb_Protocol.Multiline = true;
            this.tb_Protocol.Name = "tb_Protocol";
            this.tb_Protocol.Size = new System.Drawing.Size(184, 32);
            this.tb_Protocol.TabIndex = 17;
            // 
            // L_Protocol
            // 
            this.L_Protocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Protocol.Location = new System.Drawing.Point(76, 13);
            this.L_Protocol.Name = "L_Protocol";
            this.L_Protocol.Size = new System.Drawing.Size(216, 50);
            this.L_Protocol.TabIndex = 11;
            this.L_Protocol.Text = "IP Protocol";
            // 
            // Page0
            // 
            this.Page0.Location = new System.Drawing.Point(4, 5);
            this.Page0.Name = "Page0";
            this.Page0.Padding = new System.Windows.Forms.Padding(3);
            this.Page0.Size = new System.Drawing.Size(363, 535);
            this.Page0.TabIndex = 3;
            this.Page0.Text = "tabPage9";
            this.Page0.UseVisualStyleBackColor = true;
            // 
            // tabControlRemote
            // 
            this.tabControlRemote.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControlRemote.Controls.Add(this.CIDRPage);
            this.tabControlRemote.Controls.Add(this.SecGroupPage);
            this.tabControlRemote.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControlRemote.Location = new System.Drawing.Point(632, 152);
            this.tabControlRemote.Name = "tabControlRemote";
            this.tabControlRemote.SelectedIndex = 0;
            this.tabControlRemote.Size = new System.Drawing.Size(309, 398);
            this.tabControlRemote.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlRemote.TabIndex = 15;
            // 
            // CIDRPage
            // 
            this.CIDRPage.Controls.Add(this.tb_CIDR);
            this.CIDRPage.Controls.Add(this.L_CIDR);
            this.CIDRPage.Location = new System.Drawing.Point(4, 5);
            this.CIDRPage.Name = "CIDRPage";
            this.CIDRPage.Padding = new System.Windows.Forms.Padding(3);
            this.CIDRPage.Size = new System.Drawing.Size(301, 389);
            this.CIDRPage.TabIndex = 0;
            this.CIDRPage.Text = "tabPage3";
            this.CIDRPage.UseVisualStyleBackColor = true;
            // 
            // tb_CIDR
            // 
            this.tb_CIDR.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tb_CIDR.Location = new System.Drawing.Point(60, 84);
            this.tb_CIDR.Multiline = true;
            this.tb_CIDR.Name = "tb_CIDR";
            this.tb_CIDR.Size = new System.Drawing.Size(184, 32);
            this.tb_CIDR.TabIndex = 16;
            this.tb_CIDR.Text = "0.0.0.0/0";
            // 
            // L_CIDR
            // 
            this.L_CIDR.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_CIDR.Location = new System.Drawing.Point(53, 23);
            this.L_CIDR.Name = "L_CIDR";
            this.L_CIDR.Size = new System.Drawing.Size(216, 50);
            this.L_CIDR.TabIndex = 10;
            this.L_CIDR.Text = "CIDR";
            // 
            // SecGroupPage
            // 
            this.SecGroupPage.Controls.Add(this.cB_EType);
            this.SecGroupPage.Controls.Add(this.cB_SecGroup);
            this.SecGroupPage.Controls.Add(this.L_SecGroup);
            this.SecGroupPage.Controls.Add(this.L_EType);
            this.SecGroupPage.Location = new System.Drawing.Point(4, 5);
            this.SecGroupPage.Name = "SecGroupPage";
            this.SecGroupPage.Padding = new System.Windows.Forms.Padding(3);
            this.SecGroupPage.Size = new System.Drawing.Size(301, 389);
            this.SecGroupPage.TabIndex = 1;
            this.SecGroupPage.Text = "tabPage4";
            this.SecGroupPage.UseVisualStyleBackColor = true;
            // 
            // cB_EType
            // 
            this.cB_EType.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cB_EType.FormattingEnabled = true;
            this.cB_EType.Items.AddRange(new object[] {
            "IPv4",
            "IPv6"});
            this.cB_EType.Location = new System.Drawing.Point(60, 180);
            this.cB_EType.Name = "cB_EType";
            this.cB_EType.Size = new System.Drawing.Size(184, 32);
            this.cB_EType.TabIndex = 10;
            // 
            // cB_SecGroup
            // 
            this.cB_SecGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cB_SecGroup.FormattingEnabled = true;
            this.cB_SecGroup.Location = new System.Drawing.Point(60, 77);
            this.cB_SecGroup.Name = "cB_SecGroup";
            this.cB_SecGroup.Size = new System.Drawing.Size(184, 32);
            this.cB_SecGroup.TabIndex = 9;
            // 
            // L_SecGroup
            // 
            this.L_SecGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_SecGroup.Location = new System.Drawing.Point(53, 24);
            this.L_SecGroup.Name = "L_SecGroup";
            this.L_SecGroup.Size = new System.Drawing.Size(242, 50);
            this.L_SecGroup.TabIndex = 8;
            this.L_SecGroup.Text = "Security Group";
            // 
            // L_EType
            // 
            this.L_EType.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_EType.Location = new System.Drawing.Point(53, 127);
            this.L_EType.Name = "L_EType";
            this.L_EType.Size = new System.Drawing.Size(225, 50);
            this.L_EType.TabIndex = 6;
            this.L_EType.Text = "Ether Type";
            // 
            // cB_Remote
            // 
            this.cB_Remote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cB_Remote.FormattingEnabled = true;
            this.cB_Remote.Items.AddRange(new object[] {
            "CIDR",
            "Security Group"});
            this.cB_Remote.Location = new System.Drawing.Point(696, 89);
            this.cB_Remote.Name = "cB_Remote";
            this.cB_Remote.Size = new System.Drawing.Size(184, 32);
            this.cB_Remote.TabIndex = 13;
            this.cB_Remote.SelectedIndexChanged += new System.EventHandler(this.cB_Remote_SelectedIndexChanged);
            // 
            // cB_Direction
            // 
            this.cB_Direction.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cB_Direction.FormattingEnabled = true;
            this.cB_Direction.Items.AddRange(new object[] {
            "Ingress",
            "Egress"});
            this.cB_Direction.Location = new System.Drawing.Point(40, 475);
            this.cB_Direction.Name = "cB_Direction";
            this.cB_Direction.Size = new System.Drawing.Size(184, 32);
            this.cB_Direction.TabIndex = 9;
            // 
            // rtb_Description
            // 
            this.rtb_Description.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.rtb_Description.Location = new System.Drawing.Point(40, 215);
            this.rtb_Description.Name = "rtb_Description";
            this.rtb_Description.Size = new System.Drawing.Size(184, 154);
            this.rtb_Description.TabIndex = 3;
            this.rtb_Description.Text = "";
            // 
            // cB_Rule
            // 
            this.cB_Rule.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cB_Rule.FormattingEnabled = true;
            this.cB_Rule.Items.AddRange(new object[] {
            "Custom TCP Rule",
            "Custom UDP Rule",
            "Custom ICMP Rule",
            "Other Protocol",
            "All ICMP",
            "All TCP",
            "All UDP",
            "DNS",
            "HTTP",
            "HTTPS",
            "IMAP",
            "IMAPS",
            "LDAP",
            "MS SQL",
            "MYSQL",
            "POP3",
            "POP3S",
            "RDP",
            "SMTP",
            "SMTPS",
            "SSH"});
            this.cB_Rule.Location = new System.Drawing.Point(40, 89);
            this.cB_Rule.Name = "cB_Rule";
            this.cB_Rule.Size = new System.Drawing.Size(184, 32);
            this.cB_Rule.TabIndex = 1;
            this.cB_Rule.SelectedIndexChanged += new System.EventHandler(this.cB_Rule_SelectedIndexChanged);
            // 
            // L_Rule
            // 
            this.L_Rule.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Rule.Location = new System.Drawing.Point(33, 17);
            this.L_Rule.Name = "L_Rule";
            this.L_Rule.Size = new System.Drawing.Size(100, 50);
            this.L_Rule.TabIndex = 0;
            this.L_Rule.Text = "Rule";
            this.L_Rule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AddRule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 681);
            this.Controls.Add(this.P_Cr_Can_Rule);
            this.Controls.Add(this.P_Menu);
            this.Controls.Add(this.P_L_AddRule);
            this.Name = "AddRule";
            this.Text = "AddRule";
            this.P_L_AddRule.ResumeLayout(false);
            this.P_Cr_Can_Rule.ResumeLayout(false);
            this.P_Menu.ResumeLayout(false);
            this.tabControlFullPort.ResumeLayout(false);
            this.tabControlAllPort.ResumeLayout(false);
            this.tabControlPort.ResumeLayout(false);
            this.PortPage.ResumeLayout(false);
            this.PortPage.PerformLayout();
            this.FrToPortPage.ResumeLayout(false);
            this.FrToPortPage.PerformLayout();
            this.CodePage.ResumeLayout(false);
            this.CodePage.PerformLayout();
            this.ProtocolPage.ResumeLayout(false);
            this.ProtocolPage.PerformLayout();
            this.tabControlRemote.ResumeLayout(false);
            this.CIDRPage.ResumeLayout(false);
            this.CIDRPage.PerformLayout();
            this.SecGroupPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel P_L_AddRule;
        private System.Windows.Forms.Panel P_Cr_Can_Rule;
        private System.Windows.Forms.Panel P_Menu;
        private System.Windows.Forms.Button B_CancelRule;
        private System.Windows.Forms.Button B_AddRule;
        private System.Windows.Forms.Label L_AddRule;
        private System.Windows.Forms.ComboBox cB_Rule;
        private System.Windows.Forms.Label L_Rule;
        private System.Windows.Forms.ComboBox cB_Direction;
        private System.Windows.Forms.RichTextBox rtb_Description;
        private System.Windows.Forms.ComboBox cB_Remote;
        private System.Windows.Forms.TabControl tabControlPort;
        private System.Windows.Forms.TabPage PortPage;
        private System.Windows.Forms.TabPage FrToPortPage;
        private TabControl tabControlRemote;
        private TabPage CIDRPage;
        private TabPage SecGroupPage;
        private Label L_SecGroup;
        private Label L_EType;
        private TabControl tabControlFullPort;
        private TabPage tabControlAllPort;
        private TabPage Page1;
        private TabPage CodePage;
        private TabPage ProtocolPage;
        private TabPage Page0;
        private ComboBox cB_EType;
        private ComboBox cB_SecGroup;
        private Label L_Remote;
        private Label L_Direction;
        private Label L_Description;
        private ComboBox cB_OpenPort;
        private Label L_Port;
        private Label L_OpenPort;
        private Label L_Type;
        private Label L_Code;
        private Label L_Protocol;
        private Label L_CIDR;
        private Label L_FromPort;
        private Label L_ToPort;
        private TextBox tb_Port;
        private TextBox tb_ToPort;
        private TextBox tb_FromPort;
        private TextBox tb_Code;
        private TextBox tb_Type;
        private TextBox tb_CIDR;
        private TextBox tb_Protocol;
    }
}