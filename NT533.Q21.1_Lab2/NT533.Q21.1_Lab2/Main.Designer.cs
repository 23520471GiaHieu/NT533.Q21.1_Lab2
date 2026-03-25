using System;
using System.Drawing;
using System.Windows.Forms;

namespace NT533.Q21._1_Lab2
{
    partial class Main
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Tokens");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Identity", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Flavors");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Images");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Instances");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Key Pairs");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Compute", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Volumes");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Volume", new System.Windows.Forms.TreeNode[] {
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Networks");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Routers");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Security Groups");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Floating IPs");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Load Balancers");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Network", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.TrView_Menu = new System.Windows.Forms.TreeView();
            this.PageControl = new System.Windows.Forms.TabControl();
            this.TokenPage = new System.Windows.Forms.TabPage();
            this.P_RTB_Token = new System.Windows.Forms.Panel();
            this.RTB_Token = new System.Windows.Forms.RichTextBox();
            this.P_B_Token = new System.Windows.Forms.Panel();
            this.B_CNToken = new System.Windows.Forms.Button();
            this.P_L_Token = new System.Windows.Forms.Panel();
            this.L_Token = new System.Windows.Forms.Label();
            this.FlavorPage = new System.Windows.Forms.TabPage();
            this.P_DGV_Flavor = new System.Windows.Forms.Panel();
            this.DGV_Flavor = new System.Windows.Forms.DataGridView();
            this.Fl_Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fl_Col_RAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fl_Col_Disk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fl_Col_VCPU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_L_Flavor = new System.Windows.Forms.Panel();
            this.L_Flavor = new System.Windows.Forms.Label();
            this.ImagePage = new System.Windows.Forms.TabPage();
            this.P_DGV_Image = new System.Windows.Forms.Panel();
            this.DGV_Image = new System.Windows.Forms.DataGridView();
            this.Im_Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Im_Col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Im_Col_MinRAM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Im_Col_MinDisk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Im_Col_Visibility = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Im_Col_Protected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Im_Col_Checksum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Im_Col_Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Im_Col_DiskFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Im_Col_ContainerFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Im_Col_Owner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Im_Col_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_L_Image = new System.Windows.Forms.Panel();
            this.L_Image = new System.Windows.Forms.Label();
            this.InstancePage = new System.Windows.Forms.TabPage();
            this.P_DGV_Instances = new System.Windows.Forms.Panel();
            this.DGV_Instances = new System.Windows.Forms.DataGridView();
            this.In_Col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.In_Col_Inname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Col_Imname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Col_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Col_Flavor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Col_KeyPair = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Col_AZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Col_Task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Col_PS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.In_Col_Age = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_B_Cr_Del_Instances = new System.Windows.Forms.Panel();
            this.B_Del_Instances = new System.Windows.Forms.Button();
            this.B_Cr_Instances = new System.Windows.Forms.Button();
            this.P_L_Instances = new System.Windows.Forms.Panel();
            this.L_Instances = new System.Windows.Forms.Label();
            this.KeyPairPage = new System.Windows.Forms.TabPage();
            this.P_DGV_KeyPair = new System.Windows.Forms.Panel();
            this.DGV_KeyPair = new System.Windows.Forms.DataGridView();
            this.KP_Col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.KP_Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KP_Col_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KP_Col_FP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_B_Cr_Im_De_KeyPair = new System.Windows.Forms.Panel();
            this.B_Delete_KeyPair = new System.Windows.Forms.Button();
            this.B_Import_KeyPair = new System.Windows.Forms.Button();
            this.B_Create_KeyPair = new System.Windows.Forms.Button();
            this.P_L_KeyPair = new System.Windows.Forms.Panel();
            this.L_KeyPair = new System.Windows.Forms.Label();
            this.VolumePage = new System.Windows.Forms.TabPage();
            this.P_DGV_Volume = new System.Windows.Forms.Panel();
            this.DGV_Volume = new System.Windows.Forms.DataGridView();
            this.VL_Col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.VL_Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VL_Col_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VL_Col_Size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VL_Col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VL_Col_Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VL_Col_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VL_Col_AT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VL_Col_AZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VL_Col_Boot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VL_Col_En = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_B_Cr_De_Volume = new System.Windows.Forms.Panel();
            this.B_Delete_Volume = new System.Windows.Forms.Button();
            this.B_Create_Volume = new System.Windows.Forms.Button();
            this.P_L_Volume = new System.Windows.Forms.Panel();
            this.L_Volume = new System.Windows.Forms.Label();
            this.NetworkPage = new System.Windows.Forms.TabPage();
            this.P_DGV_Net = new System.Windows.Forms.Panel();
            this.DGV_Net = new System.Windows.Forms.DataGridView();
            this.Net_Col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Net_Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Net_Col_SubnetsAssociated = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Net_Col_Shared = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Net_Col_External = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Net_Col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Net_Col_AdminState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Net_Col_AvailabilityZones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_B_Cr_Del_Net = new System.Windows.Forms.Panel();
            this.B_Del_Net = new System.Windows.Forms.Button();
            this.B_Cr_Net = new System.Windows.Forms.Button();
            this.P_L_Networks = new System.Windows.Forms.Panel();
            this.L_Networks = new System.Windows.Forms.Label();
            this.RouterPage = new System.Windows.Forms.TabPage();
            this.P_DGV_Routers = new System.Windows.Forms.Panel();
            this.DGV_Routers = new System.Windows.Forms.DataGridView();
            this.RT_Col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RT_Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RT_Col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RT_Col_ExNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RT_Col_AS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RT_Col_AZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_B_Cr_Del_Routers = new System.Windows.Forms.Panel();
            this.B_Del_Routers = new System.Windows.Forms.Button();
            this.B_Cr_Routers = new System.Windows.Forms.Button();
            this.P_L_Routers = new System.Windows.Forms.Panel();
            this.L_Routers = new System.Windows.Forms.Label();
            this.SecurityGroupPage = new System.Windows.Forms.TabPage();
            this.P_DGV_SecurityGroup = new System.Windows.Forms.Panel();
            this.DGV_SecurityGroup = new System.Windows.Forms.DataGridView();
            this.SG_Col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SG_Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SG_Col_SGID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SG_Col_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SG_Col_Shared = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_B_Cr_Del_SecurityGroup = new System.Windows.Forms.Panel();
            this.B_Del_SecurityGroup = new System.Windows.Forms.Button();
            this.B_Cr_SecurityGroup = new System.Windows.Forms.Button();
            this.P_L_SecurityGroup = new System.Windows.Forms.Panel();
            this.L_SecurityGroup = new System.Windows.Forms.Label();
            this.FloatingIPPage = new System.Windows.Forms.TabPage();
            this.P_DGV_FlIP = new System.Windows.Forms.Panel();
            this.DGV_FlIP = new System.Windows.Forms.DataGridView();
            this.FlIP_Col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.FlIP_Col_IPAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlIP_Col_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlIP_Col_DNSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlIP_Col_DNSDomain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlIP_Col_MapIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlIP_Col_Pool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FlIP_Col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_B_Al_Re_IP = new System.Windows.Forms.Panel();
            this.B_ReleaseIP = new System.Windows.Forms.Button();
            this.B_AllocateIP = new System.Windows.Forms.Button();
            this.P_L_IP = new System.Windows.Forms.Panel();
            this.L_FloatingIP = new System.Windows.Forms.Label();
            this.LoadBalancerPage = new System.Windows.Forms.TabPage();
            this.P_DGV_LoadBalancer = new System.Windows.Forms.Panel();
            this.DGV_LoadBalancer = new System.Windows.Forms.DataGridView();
            this.LB_Col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.LB_Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LB_Col_IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LB_Col_AZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LB_Col_OS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LB_Col_PS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LB_Col_ASU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_B_Cr_Del_LoadBalancer = new System.Windows.Forms.Panel();
            this.B_Del_LoadBalancer = new System.Windows.Forms.Button();
            this.B_Cr_LoadBalancer = new System.Windows.Forms.Button();
            this.P_L_LoadBalancer = new System.Windows.Forms.Panel();
            this.L_LoadBalancer = new System.Windows.Forms.Label();
            this.Page0 = new System.Windows.Forms.TabPage();
            this.SubnetPage = new System.Windows.Forms.TabPage();
            this.P_DGV_Subnets = new System.Windows.Forms.Panel();
            this.DGV_Subnets = new System.Windows.Forms.DataGridView();
            this.Sub_Col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Sub_Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub_Col_NetAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub_Col_IPver = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sub_Col_GateIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_B_Cr_Del_Subnets = new System.Windows.Forms.Panel();
            this.B_Del_Subnets = new System.Windows.Forms.Button();
            this.B_Cr_Subnets = new System.Windows.Forms.Button();
            this.P_L_Subnet = new System.Windows.Forms.Panel();
            this.L_Subnet = new System.Windows.Forms.Label();
            this.P_L_Sub_Networks = new System.Windows.Forms.Panel();
            this.L_Sub_Networks = new System.Windows.Forms.Label();
            this.RouterInterfacePage = new System.Windows.Forms.TabPage();
            this.P_DGV_Interface = new System.Windows.Forms.Panel();
            this.DGV_Interface = new System.Windows.Forms.DataGridView();
            this.RI_Col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RI_Col_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RI_Col_FixIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RI_Col_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RI_Col_Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RI_Col_AS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_B_Cr_Del_Interface = new System.Windows.Forms.Panel();
            this.B_Del_Interface = new System.Windows.Forms.Button();
            this.B_Cr_Interface = new System.Windows.Forms.Button();
            this.P_L_Interface = new System.Windows.Forms.Panel();
            this.L_Interface = new System.Windows.Forms.Label();
            this.P_L_In_Router = new System.Windows.Forms.Panel();
            this.L_In_Router = new System.Windows.Forms.Label();
            this.RulePage = new System.Windows.Forms.TabPage();
            this.P_DGV_Rule = new System.Windows.Forms.Panel();
            this.DGV_Rule = new System.Windows.Forms.DataGridView();
            this.Ru_Col_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Ru_Col_Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ru_Col_Etype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ru_Col_Protocol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ru_Col_PR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ru_Col_RIPP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ru_Col_RSG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ru_Col_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.P_B_Cr_Del_Rule = new System.Windows.Forms.Panel();
            this.B_Del_Rule = new System.Windows.Forms.Button();
            this.B_Cr_Rule = new System.Windows.Forms.Button();
            this.P_L_Rule = new System.Windows.Forms.Panel();
            this.L_Rule = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.Panel2.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.PageControl.SuspendLayout();
            this.TokenPage.SuspendLayout();
            this.P_RTB_Token.SuspendLayout();
            this.P_B_Token.SuspendLayout();
            this.P_L_Token.SuspendLayout();
            this.FlavorPage.SuspendLayout();
            this.P_DGV_Flavor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Flavor)).BeginInit();
            this.P_L_Flavor.SuspendLayout();
            this.ImagePage.SuspendLayout();
            this.P_DGV_Image.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Image)).BeginInit();
            this.P_L_Image.SuspendLayout();
            this.InstancePage.SuspendLayout();
            this.P_DGV_Instances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Instances)).BeginInit();
            this.P_B_Cr_Del_Instances.SuspendLayout();
            this.P_L_Instances.SuspendLayout();
            this.KeyPairPage.SuspendLayout();
            this.P_DGV_KeyPair.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_KeyPair)).BeginInit();
            this.P_B_Cr_Im_De_KeyPair.SuspendLayout();
            this.P_L_KeyPair.SuspendLayout();
            this.VolumePage.SuspendLayout();
            this.P_DGV_Volume.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Volume)).BeginInit();
            this.P_B_Cr_De_Volume.SuspendLayout();
            this.P_L_Volume.SuspendLayout();
            this.NetworkPage.SuspendLayout();
            this.P_DGV_Net.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Net)).BeginInit();
            this.P_B_Cr_Del_Net.SuspendLayout();
            this.P_L_Networks.SuspendLayout();
            this.RouterPage.SuspendLayout();
            this.P_DGV_Routers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Routers)).BeginInit();
            this.P_B_Cr_Del_Routers.SuspendLayout();
            this.P_L_Routers.SuspendLayout();
            this.SecurityGroupPage.SuspendLayout();
            this.P_DGV_SecurityGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SecurityGroup)).BeginInit();
            this.P_B_Cr_Del_SecurityGroup.SuspendLayout();
            this.P_L_SecurityGroup.SuspendLayout();
            this.FloatingIPPage.SuspendLayout();
            this.P_DGV_FlIP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FlIP)).BeginInit();
            this.P_B_Al_Re_IP.SuspendLayout();
            this.P_L_IP.SuspendLayout();
            this.LoadBalancerPage.SuspendLayout();
            this.P_DGV_LoadBalancer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_LoadBalancer)).BeginInit();
            this.P_B_Cr_Del_LoadBalancer.SuspendLayout();
            this.P_L_LoadBalancer.SuspendLayout();
            this.SubnetPage.SuspendLayout();
            this.P_DGV_Subnets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Subnets)).BeginInit();
            this.P_B_Cr_Del_Subnets.SuspendLayout();
            this.P_L_Subnet.SuspendLayout();
            this.P_L_Sub_Networks.SuspendLayout();
            this.RouterInterfacePage.SuspendLayout();
            this.P_DGV_Interface.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Interface)).BeginInit();
            this.P_B_Cr_Del_Interface.SuspendLayout();
            this.P_L_Interface.SuspendLayout();
            this.P_L_In_Router.SuspendLayout();
            this.RulePage.SuspendLayout();
            this.P_DGV_Rule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Rule)).BeginInit();
            this.P_B_Cr_Del_Rule.SuspendLayout();
            this.P_L_Rule.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.BackColor = System.Drawing.Color.White;
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.TrView_Menu);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Controls.Add(this.PageControl);
            this.SplitContainer.Size = new System.Drawing.Size(944, 501);
            this.SplitContainer.SplitterDistance = 313;
            this.SplitContainer.TabIndex = 0;
            // 
            // TrView_Menu
            // 
            this.TrView_Menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrView_Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.TrView_Menu.Location = new System.Drawing.Point(0, 0);
            this.TrView_Menu.Name = "TrView_Menu";
            treeNode1.Name = "Tokens";
            treeNode1.Text = "Tokens";
            treeNode2.Name = "Identity";
            treeNode2.Text = "Identity";
            treeNode3.Name = "Flavors";
            treeNode3.Text = "Flavors";
            treeNode4.Name = "Images";
            treeNode4.Text = "Images";
            treeNode5.Name = "Instances";
            treeNode5.Text = "Instances";
            treeNode6.Name = "Key Pairs";
            treeNode6.Text = "Key Pairs";
            treeNode7.Name = "Compute";
            treeNode7.Text = "Compute";
            treeNode8.Name = "Volumes";
            treeNode8.Text = "Volumes";
            treeNode9.Name = "Volume";
            treeNode9.Text = "Volume";
            treeNode10.Name = "Networks";
            treeNode10.Text = "Networks";
            treeNode11.Name = "Routers";
            treeNode11.Text = "Routers";
            treeNode12.Name = "Security Groups";
            treeNode12.Text = "Security Groups";
            treeNode13.Name = "Floating IPs";
            treeNode13.Text = "Floating IPs";
            treeNode14.Name = "Load Balancers";
            treeNode14.Text = "Load Balancers";
            treeNode15.Name = "Network";
            treeNode15.Text = "Network";
            this.TrView_Menu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode7,
            treeNode9,
            treeNode15});
            this.TrView_Menu.Size = new System.Drawing.Size(313, 501);
            this.TrView_Menu.TabIndex = 0;
            this.TrView_Menu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TrView_Menu_AfterSelect);
            // 
            // PageControl
            // 
            this.PageControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.PageControl.Controls.Add(this.TokenPage);
            this.PageControl.Controls.Add(this.FlavorPage);
            this.PageControl.Controls.Add(this.ImagePage);
            this.PageControl.Controls.Add(this.InstancePage);
            this.PageControl.Controls.Add(this.KeyPairPage);
            this.PageControl.Controls.Add(this.VolumePage);
            this.PageControl.Controls.Add(this.NetworkPage);
            this.PageControl.Controls.Add(this.RouterPage);
            this.PageControl.Controls.Add(this.SecurityGroupPage);
            this.PageControl.Controls.Add(this.FloatingIPPage);
            this.PageControl.Controls.Add(this.LoadBalancerPage);
            this.PageControl.Controls.Add(this.Page0);
            this.PageControl.Controls.Add(this.SubnetPage);
            this.PageControl.Controls.Add(this.RouterInterfacePage);
            this.PageControl.Controls.Add(this.RulePage);
            this.PageControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PageControl.ItemSize = new System.Drawing.Size(0, 1);
            this.PageControl.Location = new System.Drawing.Point(0, 0);
            this.PageControl.Name = "PageControl";
            this.PageControl.SelectedIndex = 11;
            this.PageControl.Size = new System.Drawing.Size(627, 501);
            this.PageControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.PageControl.TabIndex = 0;
            // 
            // TokenPage
            // 
            this.TokenPage.BackColor = System.Drawing.Color.White;
            this.TokenPage.Controls.Add(this.P_RTB_Token);
            this.TokenPage.Controls.Add(this.P_B_Token);
            this.TokenPage.Controls.Add(this.P_L_Token);
            this.TokenPage.Location = new System.Drawing.Point(4, 5);
            this.TokenPage.Name = "TokenPage";
            this.TokenPage.Padding = new System.Windows.Forms.Padding(3);
            this.TokenPage.Size = new System.Drawing.Size(619, 492);
            this.TokenPage.TabIndex = 0;
            this.TokenPage.Text = "tabPage1";
            // 
            // P_RTB_Token
            // 
            this.P_RTB_Token.Controls.Add(this.RTB_Token);
            this.P_RTB_Token.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_RTB_Token.Location = new System.Drawing.Point(3, 66);
            this.P_RTB_Token.Name = "P_RTB_Token";
            this.P_RTB_Token.Size = new System.Drawing.Size(613, 323);
            this.P_RTB_Token.TabIndex = 5;
            // 
            // RTB_Token
            // 
            this.RTB_Token.BackColor = System.Drawing.Color.White;
            this.RTB_Token.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RTB_Token.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.RTB_Token.Location = new System.Drawing.Point(0, 0);
            this.RTB_Token.Name = "RTB_Token";
            this.RTB_Token.ReadOnly = true;
            this.RTB_Token.Size = new System.Drawing.Size(613, 323);
            this.RTB_Token.TabIndex = 0;
            this.RTB_Token.Text = "";
            // 
            // P_B_Token
            // 
            this.P_B_Token.Controls.Add(this.B_CNToken);
            this.P_B_Token.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.P_B_Token.Location = new System.Drawing.Point(3, 389);
            this.P_B_Token.Name = "P_B_Token";
            this.P_B_Token.Size = new System.Drawing.Size(613, 100);
            this.P_B_Token.TabIndex = 4;
            this.P_B_Token.Resize += new System.EventHandler(this.P_B_CNToken_Resize);
            // 
            // B_CNToken
            // 
            this.B_CNToken.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.B_CNToken.Location = new System.Drawing.Point(222, 28);
            this.B_CNToken.Name = "B_CNToken";
            this.B_CNToken.Size = new System.Drawing.Size(200, 48);
            this.B_CNToken.TabIndex = 1;
            this.B_CNToken.Text = "Cập Nhật Token";
            this.B_CNToken.UseVisualStyleBackColor = true;
            this.B_CNToken.Click += new System.EventHandler(this.B_CNToken_Click);
            // 
            // P_L_Token
            // 
            this.P_L_Token.Controls.Add(this.L_Token);
            this.P_L_Token.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_Token.Location = new System.Drawing.Point(3, 3);
            this.P_L_Token.Name = "P_L_Token";
            this.P_L_Token.Size = new System.Drawing.Size(613, 63);
            this.P_L_Token.TabIndex = 3;
            this.P_L_Token.Resize += new System.EventHandler(this.P_L_Token_Resize);
            // 
            // L_Token
            // 
            this.L_Token.AutoSize = true;
            this.L_Token.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Token.Location = new System.Drawing.Point(272, 14);
            this.L_Token.Name = "L_Token";
            this.L_Token.Size = new System.Drawing.Size(106, 37);
            this.L_Token.TabIndex = 2;
            this.L_Token.Text = "Token";
            // 
            // FlavorPage
            // 
            this.FlavorPage.BackColor = System.Drawing.Color.White;
            this.FlavorPage.Controls.Add(this.P_DGV_Flavor);
            this.FlavorPage.Controls.Add(this.P_L_Flavor);
            this.FlavorPage.Location = new System.Drawing.Point(4, 5);
            this.FlavorPage.Name = "FlavorPage";
            this.FlavorPage.Padding = new System.Windows.Forms.Padding(3);
            this.FlavorPage.Size = new System.Drawing.Size(619, 492);
            this.FlavorPage.TabIndex = 1;
            this.FlavorPage.Text = "tabPage2";
            // 
            // P_DGV_Flavor
            // 
            this.P_DGV_Flavor.Controls.Add(this.DGV_Flavor);
            this.P_DGV_Flavor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_Flavor.Location = new System.Drawing.Point(3, 79);
            this.P_DGV_Flavor.Name = "P_DGV_Flavor";
            this.P_DGV_Flavor.Size = new System.Drawing.Size(613, 410);
            this.P_DGV_Flavor.TabIndex = 1;
            // 
            // DGV_Flavor
            // 
            this.DGV_Flavor.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Flavor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Flavor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fl_Col_Name,
            this.Fl_Col_RAM,
            this.Fl_Col_Disk,
            this.Fl_Col_VCPU});
            this.DGV_Flavor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Flavor.Location = new System.Drawing.Point(0, 0);
            this.DGV_Flavor.Name = "DGV_Flavor";
            this.DGV_Flavor.Size = new System.Drawing.Size(613, 410);
            this.DGV_Flavor.TabIndex = 0;
            // 
            // Fl_Col_Name
            // 
            this.Fl_Col_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fl_Col_Name.HeaderText = "Name";
            this.Fl_Col_Name.Name = "Fl_Col_Name";
            this.Fl_Col_Name.ReadOnly = true;
            this.Fl_Col_Name.Width = 60;
            // 
            // Fl_Col_RAM
            // 
            this.Fl_Col_RAM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fl_Col_RAM.HeaderText = "RAM";
            this.Fl_Col_RAM.Name = "Fl_Col_RAM";
            this.Fl_Col_RAM.ReadOnly = true;
            this.Fl_Col_RAM.Width = 56;
            // 
            // Fl_Col_Disk
            // 
            this.Fl_Col_Disk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fl_Col_Disk.HeaderText = "Disk";
            this.Fl_Col_Disk.Name = "Fl_Col_Disk";
            this.Fl_Col_Disk.ReadOnly = true;
            this.Fl_Col_Disk.Width = 53;
            // 
            // Fl_Col_VCPU
            // 
            this.Fl_Col_VCPU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Fl_Col_VCPU.HeaderText = "VCPU";
            this.Fl_Col_VCPU.Name = "Fl_Col_VCPU";
            this.Fl_Col_VCPU.ReadOnly = true;
            this.Fl_Col_VCPU.Width = 61;
            // 
            // P_L_Flavor
            // 
            this.P_L_Flavor.Controls.Add(this.L_Flavor);
            this.P_L_Flavor.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_Flavor.Location = new System.Drawing.Point(3, 3);
            this.P_L_Flavor.Name = "P_L_Flavor";
            this.P_L_Flavor.Size = new System.Drawing.Size(613, 76);
            this.P_L_Flavor.TabIndex = 0;
            this.P_L_Flavor.Resize += new System.EventHandler(this.P_L_Flavor_Resize);
            // 
            // L_Flavor
            // 
            this.L_Flavor.AutoSize = true;
            this.L_Flavor.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Flavor.Location = new System.Drawing.Point(257, 21);
            this.L_Flavor.Name = "L_Flavor";
            this.L_Flavor.Size = new System.Drawing.Size(122, 37);
            this.L_Flavor.TabIndex = 3;
            this.L_Flavor.Text = "Flavors";
            // 
            // ImagePage
            // 
            this.ImagePage.BackColor = System.Drawing.Color.White;
            this.ImagePage.Controls.Add(this.P_DGV_Image);
            this.ImagePage.Controls.Add(this.P_L_Image);
            this.ImagePage.Location = new System.Drawing.Point(4, 5);
            this.ImagePage.Name = "ImagePage";
            this.ImagePage.Padding = new System.Windows.Forms.Padding(3);
            this.ImagePage.Size = new System.Drawing.Size(619, 492);
            this.ImagePage.TabIndex = 2;
            this.ImagePage.Text = "tabPage3";
            this.ImagePage.UseVisualStyleBackColor = true;
            // 
            // P_DGV_Image
            // 
            this.P_DGV_Image.Controls.Add(this.DGV_Image);
            this.P_DGV_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_Image.Location = new System.Drawing.Point(3, 79);
            this.P_DGV_Image.Name = "P_DGV_Image";
            this.P_DGV_Image.Size = new System.Drawing.Size(613, 410);
            this.P_DGV_Image.TabIndex = 2;
            // 
            // DGV_Image
            // 
            this.DGV_Image.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Image.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Image.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Im_Col_Name,
            this.Im_Col_Status,
            this.Im_Col_MinRAM,
            this.Im_Col_MinDisk,
            this.Im_Col_Visibility,
            this.Im_Col_Protected,
            this.Im_Col_Checksum,
            this.Im_Col_Size,
            this.Im_Col_DiskFormat,
            this.Im_Col_ContainerFormat,
            this.Im_Col_Owner,
            this.Im_Col_Description});
            this.DGV_Image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Image.Location = new System.Drawing.Point(0, 0);
            this.DGV_Image.Name = "DGV_Image";
            this.DGV_Image.Size = new System.Drawing.Size(613, 410);
            this.DGV_Image.TabIndex = 0;
            // 
            // Im_Col_Name
            // 
            this.Im_Col_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_Name.HeaderText = "Name";
            this.Im_Col_Name.Name = "Im_Col_Name";
            this.Im_Col_Name.ReadOnly = true;
            this.Im_Col_Name.Width = 60;
            // 
            // Im_Col_Status
            // 
            this.Im_Col_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_Status.HeaderText = "Status";
            this.Im_Col_Status.Name = "Im_Col_Status";
            this.Im_Col_Status.ReadOnly = true;
            this.Im_Col_Status.Width = 62;
            // 
            // Im_Col_MinRAM
            // 
            this.Im_Col_MinRAM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_MinRAM.HeaderText = "MinRAM";
            this.Im_Col_MinRAM.Name = "Im_Col_MinRAM";
            this.Im_Col_MinRAM.ReadOnly = true;
            this.Im_Col_MinRAM.Width = 73;
            // 
            // Im_Col_MinDisk
            // 
            this.Im_Col_MinDisk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_MinDisk.HeaderText = "MinDisk";
            this.Im_Col_MinDisk.Name = "Im_Col_MinDisk";
            this.Im_Col_MinDisk.ReadOnly = true;
            this.Im_Col_MinDisk.Width = 70;
            // 
            // Im_Col_Visibility
            // 
            this.Im_Col_Visibility.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_Visibility.HeaderText = "Visibility";
            this.Im_Col_Visibility.Name = "Im_Col_Visibility";
            this.Im_Col_Visibility.ReadOnly = true;
            this.Im_Col_Visibility.Width = 68;
            // 
            // Im_Col_Protected
            // 
            this.Im_Col_Protected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_Protected.HeaderText = "Protected";
            this.Im_Col_Protected.Name = "Im_Col_Protected";
            this.Im_Col_Protected.ReadOnly = true;
            this.Im_Col_Protected.Width = 78;
            // 
            // Im_Col_Checksum
            // 
            this.Im_Col_Checksum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_Checksum.HeaderText = "Checksum";
            this.Im_Col_Checksum.Name = "Im_Col_Checksum";
            this.Im_Col_Checksum.ReadOnly = true;
            this.Im_Col_Checksum.Width = 82;
            // 
            // Im_Col_Size
            // 
            this.Im_Col_Size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_Size.HeaderText = "Size";
            this.Im_Col_Size.Name = "Im_Col_Size";
            this.Im_Col_Size.ReadOnly = true;
            this.Im_Col_Size.Width = 52;
            // 
            // Im_Col_DiskFormat
            // 
            this.Im_Col_DiskFormat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_DiskFormat.HeaderText = "DiskFormat";
            this.Im_Col_DiskFormat.Name = "Im_Col_DiskFormat";
            this.Im_Col_DiskFormat.ReadOnly = true;
            this.Im_Col_DiskFormat.Width = 85;
            // 
            // Im_Col_ContainerFormat
            // 
            this.Im_Col_ContainerFormat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_ContainerFormat.HeaderText = "ContainerFormat";
            this.Im_Col_ContainerFormat.Name = "Im_Col_ContainerFormat";
            this.Im_Col_ContainerFormat.ReadOnly = true;
            this.Im_Col_ContainerFormat.Width = 109;
            // 
            // Im_Col_Owner
            // 
            this.Im_Col_Owner.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_Owner.HeaderText = "Owner";
            this.Im_Col_Owner.Name = "Im_Col_Owner";
            this.Im_Col_Owner.ReadOnly = true;
            this.Im_Col_Owner.Width = 63;
            // 
            // Im_Col_Description
            // 
            this.Im_Col_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Im_Col_Description.HeaderText = "Description";
            this.Im_Col_Description.Name = "Im_Col_Description";
            this.Im_Col_Description.ReadOnly = true;
            this.Im_Col_Description.Width = 85;
            // 
            // P_L_Image
            // 
            this.P_L_Image.Controls.Add(this.L_Image);
            this.P_L_Image.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_Image.Location = new System.Drawing.Point(3, 3);
            this.P_L_Image.Name = "P_L_Image";
            this.P_L_Image.Size = new System.Drawing.Size(613, 76);
            this.P_L_Image.TabIndex = 1;
            this.P_L_Image.Resize += new System.EventHandler(this.P_L_Image_Resize);
            // 
            // L_Image
            // 
            this.L_Image.AutoSize = true;
            this.L_Image.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Image.Location = new System.Drawing.Point(260, 21);
            this.L_Image.Name = "L_Image";
            this.L_Image.Size = new System.Drawing.Size(121, 37);
            this.L_Image.TabIndex = 3;
            this.L_Image.Text = "Images";
            // 
            // InstancePage
            // 
            this.InstancePage.BackColor = System.Drawing.Color.White;
            this.InstancePage.Controls.Add(this.P_DGV_Instances);
            this.InstancePage.Controls.Add(this.P_B_Cr_Del_Instances);
            this.InstancePage.Controls.Add(this.P_L_Instances);
            this.InstancePage.Location = new System.Drawing.Point(4, 5);
            this.InstancePage.Name = "InstancePage";
            this.InstancePage.Padding = new System.Windows.Forms.Padding(3);
            this.InstancePage.Size = new System.Drawing.Size(619, 492);
            this.InstancePage.TabIndex = 3;
            this.InstancePage.Text = "tabPage4";
            this.InstancePage.UseVisualStyleBackColor = true;
            // 
            // P_DGV_Instances
            // 
            this.P_DGV_Instances.Controls.Add(this.DGV_Instances);
            this.P_DGV_Instances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_Instances.Location = new System.Drawing.Point(3, 153);
            this.P_DGV_Instances.Name = "P_DGV_Instances";
            this.P_DGV_Instances.Size = new System.Drawing.Size(613, 336);
            this.P_DGV_Instances.TabIndex = 3;
            // 
            // DGV_Instances
            // 
            this.DGV_Instances.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Instances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Instances.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.In_Col_Select,
            this.In_Col_Inname,
            this.In_Col_Imname,
            this.In_Col_IP,
            this.In_Col_Flavor,
            this.In_Col_KeyPair,
            this.In_Col_Status,
            this.In_Col_AZ,
            this.In_Col_Task,
            this.In_Col_PS,
            this.In_Col_Age});
            this.DGV_Instances.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Instances.Location = new System.Drawing.Point(0, 0);
            this.DGV_Instances.Name = "DGV_Instances";
            this.DGV_Instances.Size = new System.Drawing.Size(613, 336);
            this.DGV_Instances.TabIndex = 0;
            // 
            // In_Col_Select
            // 
            this.In_Col_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.In_Col_Select.HeaderText = "Select";
            this.In_Col_Select.Name = "In_Col_Select";
            this.In_Col_Select.Width = 43;
            // 
            // In_Col_Inname
            // 
            this.In_Col_Inname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.In_Col_Inname.HeaderText = "Instance Name";
            this.In_Col_Inname.Name = "In_Col_Inname";
            this.In_Col_Inname.Width = 96;
            // 
            // In_Col_Imname
            // 
            this.In_Col_Imname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.In_Col_Imname.HeaderText = "Image Name";
            this.In_Col_Imname.Name = "In_Col_Imname";
            this.In_Col_Imname.Width = 85;
            // 
            // In_Col_IP
            // 
            this.In_Col_IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.In_Col_IP.HeaderText = "IP Address";
            this.In_Col_IP.Name = "In_Col_IP";
            this.In_Col_IP.Width = 77;
            // 
            // In_Col_Flavor
            // 
            this.In_Col_Flavor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.In_Col_Flavor.HeaderText = "Flavor";
            this.In_Col_Flavor.Name = "In_Col_Flavor";
            this.In_Col_Flavor.Width = 61;
            // 
            // In_Col_KeyPair
            // 
            this.In_Col_KeyPair.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.In_Col_KeyPair.HeaderText = "Key Pair";
            this.In_Col_KeyPair.Name = "In_Col_KeyPair";
            this.In_Col_KeyPair.Width = 50;
            // 
            // In_Col_Status
            // 
            this.In_Col_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.In_Col_Status.HeaderText = "Status";
            this.In_Col_Status.Name = "In_Col_Status";
            this.In_Col_Status.Width = 62;
            // 
            // In_Col_AZ
            // 
            this.In_Col_AZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.In_Col_AZ.HeaderText = "Availability Zone";
            this.In_Col_AZ.Name = "In_Col_AZ";
            // 
            // In_Col_Task
            // 
            this.In_Col_Task.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.In_Col_Task.HeaderText = "Task";
            this.In_Col_Task.Name = "In_Col_Task";
            this.In_Col_Task.Width = 56;
            // 
            // In_Col_PS
            // 
            this.In_Col_PS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.In_Col_PS.HeaderText = "Power State";
            this.In_Col_PS.Name = "In_Col_PS";
            this.In_Col_PS.Width = 83;
            // 
            // In_Col_Age
            // 
            this.In_Col_Age.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.In_Col_Age.HeaderText = "Age";
            this.In_Col_Age.Name = "In_Col_Age";
            this.In_Col_Age.Width = 51;
            // 
            // P_B_Cr_Del_Instances
            // 
            this.P_B_Cr_Del_Instances.Controls.Add(this.B_Del_Instances);
            this.P_B_Cr_Del_Instances.Controls.Add(this.B_Cr_Instances);
            this.P_B_Cr_Del_Instances.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_B_Cr_Del_Instances.Location = new System.Drawing.Point(3, 78);
            this.P_B_Cr_Del_Instances.Name = "P_B_Cr_Del_Instances";
            this.P_B_Cr_Del_Instances.Size = new System.Drawing.Size(613, 75);
            this.P_B_Cr_Del_Instances.TabIndex = 2;
            this.P_B_Cr_Del_Instances.Resize += new System.EventHandler(this.P_B_Cr_Del_Instances_Resize);
            // 
            // B_Del_Instances
            // 
            this.B_Del_Instances.Location = new System.Drawing.Point(516, 18);
            this.B_Del_Instances.Name = "B_Del_Instances";
            this.B_Del_Instances.Size = new System.Drawing.Size(80, 35);
            this.B_Del_Instances.TabIndex = 2;
            this.B_Del_Instances.Text = "Delete";
            this.B_Del_Instances.UseVisualStyleBackColor = true;
            this.B_Del_Instances.Click += new System.EventHandler(this.B_Del_Instances_Click);
            // 
            // B_Cr_Instances
            // 
            this.B_Cr_Instances.Location = new System.Drawing.Point(416, 18);
            this.B_Cr_Instances.Name = "B_Cr_Instances";
            this.B_Cr_Instances.Size = new System.Drawing.Size(80, 35);
            this.B_Cr_Instances.TabIndex = 1;
            this.B_Cr_Instances.Text = "Create";
            this.B_Cr_Instances.UseVisualStyleBackColor = true;
            this.B_Cr_Instances.Click += new System.EventHandler(this.B_Cr_Instances_Click);
            // 
            // P_L_Instances
            // 
            this.P_L_Instances.Controls.Add(this.L_Instances);
            this.P_L_Instances.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_Instances.Location = new System.Drawing.Point(3, 3);
            this.P_L_Instances.Name = "P_L_Instances";
            this.P_L_Instances.Size = new System.Drawing.Size(613, 75);
            this.P_L_Instances.TabIndex = 1;
            this.P_L_Instances.Resize += new System.EventHandler(this.P_L_Instances_Resize);
            // 
            // L_Instances
            // 
            this.L_Instances.AutoSize = true;
            this.L_Instances.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Instances.Location = new System.Drawing.Point(257, 17);
            this.L_Instances.Name = "L_Instances";
            this.L_Instances.Size = new System.Drawing.Size(153, 37);
            this.L_Instances.TabIndex = 0;
            this.L_Instances.Text = "Instances";
            // 
            // KeyPairPage
            // 
            this.KeyPairPage.BackColor = System.Drawing.Color.White;
            this.KeyPairPage.Controls.Add(this.P_DGV_KeyPair);
            this.KeyPairPage.Controls.Add(this.P_B_Cr_Im_De_KeyPair);
            this.KeyPairPage.Controls.Add(this.P_L_KeyPair);
            this.KeyPairPage.Location = new System.Drawing.Point(4, 5);
            this.KeyPairPage.Name = "KeyPairPage";
            this.KeyPairPage.Padding = new System.Windows.Forms.Padding(3);
            this.KeyPairPage.Size = new System.Drawing.Size(619, 492);
            this.KeyPairPage.TabIndex = 4;
            this.KeyPairPage.Text = "tabPage5";
            this.KeyPairPage.UseVisualStyleBackColor = true;
            // 
            // P_DGV_KeyPair
            // 
            this.P_DGV_KeyPair.Controls.Add(this.DGV_KeyPair);
            this.P_DGV_KeyPair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_KeyPair.Location = new System.Drawing.Point(3, 153);
            this.P_DGV_KeyPair.Name = "P_DGV_KeyPair";
            this.P_DGV_KeyPair.Size = new System.Drawing.Size(613, 336);
            this.P_DGV_KeyPair.TabIndex = 2;
            // 
            // DGV_KeyPair
            // 
            this.DGV_KeyPair.BackgroundColor = System.Drawing.Color.White;
            this.DGV_KeyPair.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_KeyPair.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KP_Col_Select,
            this.KP_Col_Name,
            this.KP_Col_Type,
            this.KP_Col_FP});
            this.DGV_KeyPair.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_KeyPair.Location = new System.Drawing.Point(0, 0);
            this.DGV_KeyPair.Name = "DGV_KeyPair";
            this.DGV_KeyPair.Size = new System.Drawing.Size(613, 336);
            this.DGV_KeyPair.TabIndex = 0;
            // 
            // KP_Col_Select
            // 
            this.KP_Col_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KP_Col_Select.HeaderText = "Select";
            this.KP_Col_Select.Name = "KP_Col_Select";
            this.KP_Col_Select.Width = 43;
            // 
            // KP_Col_Name
            // 
            this.KP_Col_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KP_Col_Name.HeaderText = "Name";
            this.KP_Col_Name.Name = "KP_Col_Name";
            this.KP_Col_Name.Width = 60;
            // 
            // KP_Col_Type
            // 
            this.KP_Col_Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KP_Col_Type.HeaderText = "Type";
            this.KP_Col_Type.Name = "KP_Col_Type";
            this.KP_Col_Type.Width = 56;
            // 
            // KP_Col_FP
            // 
            this.KP_Col_FP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.KP_Col_FP.HeaderText = "Fingerprint";
            this.KP_Col_FP.Name = "KP_Col_FP";
            this.KP_Col_FP.Width = 81;
            // 
            // P_B_Cr_Im_De_KeyPair
            // 
            this.P_B_Cr_Im_De_KeyPair.Controls.Add(this.B_Delete_KeyPair);
            this.P_B_Cr_Im_De_KeyPair.Controls.Add(this.B_Import_KeyPair);
            this.P_B_Cr_Im_De_KeyPair.Controls.Add(this.B_Create_KeyPair);
            this.P_B_Cr_Im_De_KeyPair.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_B_Cr_Im_De_KeyPair.Location = new System.Drawing.Point(3, 78);
            this.P_B_Cr_Im_De_KeyPair.Name = "P_B_Cr_Im_De_KeyPair";
            this.P_B_Cr_Im_De_KeyPair.Size = new System.Drawing.Size(613, 75);
            this.P_B_Cr_Im_De_KeyPair.TabIndex = 1;
            this.P_B_Cr_Im_De_KeyPair.Resize += new System.EventHandler(this.P_B_Cr_Im_De_KeyPair_Resize);
            // 
            // B_Delete_KeyPair
            // 
            this.B_Delete_KeyPair.Location = new System.Drawing.Point(516, 18);
            this.B_Delete_KeyPair.Name = "B_Delete_KeyPair";
            this.B_Delete_KeyPair.Size = new System.Drawing.Size(80, 35);
            this.B_Delete_KeyPair.TabIndex = 2;
            this.B_Delete_KeyPair.Text = "Delete";
            this.B_Delete_KeyPair.UseVisualStyleBackColor = true;
            this.B_Delete_KeyPair.Click += new System.EventHandler(this.B_Delete_KeyPair_Click);
            // 
            // B_Import_KeyPair
            // 
            this.B_Import_KeyPair.Location = new System.Drawing.Point(416, 18);
            this.B_Import_KeyPair.Name = "B_Import_KeyPair";
            this.B_Import_KeyPair.Size = new System.Drawing.Size(80, 35);
            this.B_Import_KeyPair.TabIndex = 1;
            this.B_Import_KeyPair.Text = "Import";
            this.B_Import_KeyPair.UseVisualStyleBackColor = true;
            this.B_Import_KeyPair.Click += new System.EventHandler(this.B_Import_KeyPair_Click);
            // 
            // B_Create_KeyPair
            // 
            this.B_Create_KeyPair.Location = new System.Drawing.Point(313, 18);
            this.B_Create_KeyPair.Name = "B_Create_KeyPair";
            this.B_Create_KeyPair.Size = new System.Drawing.Size(80, 35);
            this.B_Create_KeyPair.TabIndex = 0;
            this.B_Create_KeyPair.Text = "Create";
            this.B_Create_KeyPair.UseVisualStyleBackColor = true;
            this.B_Create_KeyPair.Click += new System.EventHandler(this.B_Create_KeyPair_Click);
            // 
            // P_L_KeyPair
            // 
            this.P_L_KeyPair.Controls.Add(this.L_KeyPair);
            this.P_L_KeyPair.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_KeyPair.Location = new System.Drawing.Point(3, 3);
            this.P_L_KeyPair.Name = "P_L_KeyPair";
            this.P_L_KeyPair.Size = new System.Drawing.Size(613, 75);
            this.P_L_KeyPair.TabIndex = 0;
            this.P_L_KeyPair.Resize += new System.EventHandler(this.P_L_KeyPair_Resize);
            // 
            // L_KeyPair
            // 
            this.L_KeyPair.AutoSize = true;
            this.L_KeyPair.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_KeyPair.Location = new System.Drawing.Point(257, 17);
            this.L_KeyPair.Name = "L_KeyPair";
            this.L_KeyPair.Size = new System.Drawing.Size(152, 37);
            this.L_KeyPair.TabIndex = 0;
            this.L_KeyPair.Text = "Key Pairs";
            // 
            // VolumePage
            // 
            this.VolumePage.BackColor = System.Drawing.Color.White;
            this.VolumePage.Controls.Add(this.P_DGV_Volume);
            this.VolumePage.Controls.Add(this.P_B_Cr_De_Volume);
            this.VolumePage.Controls.Add(this.P_L_Volume);
            this.VolumePage.Location = new System.Drawing.Point(4, 5);
            this.VolumePage.Name = "VolumePage";
            this.VolumePage.Padding = new System.Windows.Forms.Padding(3);
            this.VolumePage.Size = new System.Drawing.Size(619, 492);
            this.VolumePage.TabIndex = 5;
            this.VolumePage.Text = "tabPage6";
            this.VolumePage.UseVisualStyleBackColor = true;
            // 
            // P_DGV_Volume
            // 
            this.P_DGV_Volume.Controls.Add(this.DGV_Volume);
            this.P_DGV_Volume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_Volume.Location = new System.Drawing.Point(3, 153);
            this.P_DGV_Volume.Name = "P_DGV_Volume";
            this.P_DGV_Volume.Size = new System.Drawing.Size(613, 336);
            this.P_DGV_Volume.TabIndex = 3;
            // 
            // DGV_Volume
            // 
            this.DGV_Volume.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Volume.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Volume.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VL_Col_Select,
            this.VL_Col_Name,
            this.VL_Col_Description,
            this.VL_Col_Size,
            this.VL_Col_Status,
            this.VL_Col_Group,
            this.VL_Col_Type,
            this.VL_Col_AT,
            this.VL_Col_AZ,
            this.VL_Col_Boot,
            this.VL_Col_En});
            this.DGV_Volume.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Volume.Location = new System.Drawing.Point(0, 0);
            this.DGV_Volume.Name = "DGV_Volume";
            this.DGV_Volume.Size = new System.Drawing.Size(613, 336);
            this.DGV_Volume.TabIndex = 0;
            // 
            // VL_Col_Select
            // 
            this.VL_Col_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VL_Col_Select.HeaderText = "Select";
            this.VL_Col_Select.Name = "VL_Col_Select";
            this.VL_Col_Select.Width = 43;
            // 
            // VL_Col_Name
            // 
            this.VL_Col_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VL_Col_Name.HeaderText = "Name";
            this.VL_Col_Name.Name = "VL_Col_Name";
            this.VL_Col_Name.Width = 60;
            // 
            // VL_Col_Description
            // 
            this.VL_Col_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VL_Col_Description.HeaderText = "Description";
            this.VL_Col_Description.Name = "VL_Col_Description";
            this.VL_Col_Description.Width = 85;
            // 
            // VL_Col_Size
            // 
            this.VL_Col_Size.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VL_Col_Size.HeaderText = "Size";
            this.VL_Col_Size.Name = "VL_Col_Size";
            this.VL_Col_Size.Width = 52;
            // 
            // VL_Col_Status
            // 
            this.VL_Col_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VL_Col_Status.HeaderText = "Status";
            this.VL_Col_Status.Name = "VL_Col_Status";
            this.VL_Col_Status.Width = 62;
            // 
            // VL_Col_Group
            // 
            this.VL_Col_Group.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VL_Col_Group.HeaderText = "Group";
            this.VL_Col_Group.Name = "VL_Col_Group";
            this.VL_Col_Group.Width = 61;
            // 
            // VL_Col_Type
            // 
            this.VL_Col_Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VL_Col_Type.HeaderText = "Type";
            this.VL_Col_Type.Name = "VL_Col_Type";
            this.VL_Col_Type.Width = 56;
            // 
            // VL_Col_AT
            // 
            this.VL_Col_AT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VL_Col_AT.HeaderText = "Attached To";
            this.VL_Col_AT.Name = "VL_Col_AT";
            this.VL_Col_AT.Width = 84;
            // 
            // VL_Col_AZ
            // 
            this.VL_Col_AZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VL_Col_AZ.HeaderText = "Availability Zone";
            this.VL_Col_AZ.Name = "VL_Col_AZ";
            // 
            // VL_Col_Boot
            // 
            this.VL_Col_Boot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VL_Col_Boot.HeaderText = "Bootable";
            this.VL_Col_Boot.Name = "VL_Col_Boot";
            this.VL_Col_Boot.Width = 74;
            // 
            // VL_Col_En
            // 
            this.VL_Col_En.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VL_Col_En.HeaderText = "Encrypted";
            this.VL_Col_En.Name = "VL_Col_En";
            this.VL_Col_En.Width = 80;
            // 
            // P_B_Cr_De_Volume
            // 
            this.P_B_Cr_De_Volume.Controls.Add(this.B_Delete_Volume);
            this.P_B_Cr_De_Volume.Controls.Add(this.B_Create_Volume);
            this.P_B_Cr_De_Volume.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_B_Cr_De_Volume.Location = new System.Drawing.Point(3, 78);
            this.P_B_Cr_De_Volume.Name = "P_B_Cr_De_Volume";
            this.P_B_Cr_De_Volume.Size = new System.Drawing.Size(613, 75);
            this.P_B_Cr_De_Volume.TabIndex = 2;
            this.P_B_Cr_De_Volume.Resize += new System.EventHandler(this.P_B_Cr_De_Volume_Resize);
            // 
            // B_Delete_Volume
            // 
            this.B_Delete_Volume.Location = new System.Drawing.Point(515, 21);
            this.B_Delete_Volume.Name = "B_Delete_Volume";
            this.B_Delete_Volume.Size = new System.Drawing.Size(80, 35);
            this.B_Delete_Volume.TabIndex = 2;
            this.B_Delete_Volume.Text = "Delete";
            this.B_Delete_Volume.UseVisualStyleBackColor = true;
            this.B_Delete_Volume.Click += new System.EventHandler(this.B_Delete_Volume_Click);
            // 
            // B_Create_Volume
            // 
            this.B_Create_Volume.Location = new System.Drawing.Point(415, 21);
            this.B_Create_Volume.Name = "B_Create_Volume";
            this.B_Create_Volume.Size = new System.Drawing.Size(80, 35);
            this.B_Create_Volume.TabIndex = 1;
            this.B_Create_Volume.Text = "Create";
            this.B_Create_Volume.UseVisualStyleBackColor = true;
            this.B_Create_Volume.Click += new System.EventHandler(this.B_Create_Volume_Click);
            // 
            // P_L_Volume
            // 
            this.P_L_Volume.Controls.Add(this.L_Volume);
            this.P_L_Volume.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_Volume.Location = new System.Drawing.Point(3, 3);
            this.P_L_Volume.Name = "P_L_Volume";
            this.P_L_Volume.Size = new System.Drawing.Size(613, 75);
            this.P_L_Volume.TabIndex = 1;
            this.P_L_Volume.Resize += new System.EventHandler(this.P_L_Volume_Resize);
            // 
            // L_Volume
            // 
            this.L_Volume.AutoSize = true;
            this.L_Volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Volume.Location = new System.Drawing.Point(241, 18);
            this.L_Volume.Name = "L_Volume";
            this.L_Volume.Size = new System.Drawing.Size(142, 37);
            this.L_Volume.TabIndex = 0;
            this.L_Volume.Text = "Volumes";
            // 
            // NetworkPage
            // 
            this.NetworkPage.BackColor = System.Drawing.Color.White;
            this.NetworkPage.Controls.Add(this.P_DGV_Net);
            this.NetworkPage.Controls.Add(this.P_B_Cr_Del_Net);
            this.NetworkPage.Controls.Add(this.P_L_Networks);
            this.NetworkPage.Location = new System.Drawing.Point(4, 5);
            this.NetworkPage.Name = "NetworkPage";
            this.NetworkPage.Padding = new System.Windows.Forms.Padding(3);
            this.NetworkPage.Size = new System.Drawing.Size(619, 492);
            this.NetworkPage.TabIndex = 6;
            this.NetworkPage.Text = "tabPage7";
            this.NetworkPage.UseVisualStyleBackColor = true;
            // 
            // P_DGV_Net
            // 
            this.P_DGV_Net.Controls.Add(this.DGV_Net);
            this.P_DGV_Net.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_Net.Location = new System.Drawing.Point(3, 153);
            this.P_DGV_Net.Name = "P_DGV_Net";
            this.P_DGV_Net.Size = new System.Drawing.Size(613, 336);
            this.P_DGV_Net.TabIndex = 4;
            // 
            // DGV_Net
            // 
            this.DGV_Net.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Net.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Net.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Net_Col_Select,
            this.Net_Col_Name,
            this.Net_Col_SubnetsAssociated,
            this.Net_Col_Shared,
            this.Net_Col_External,
            this.Net_Col_Status,
            this.Net_Col_AdminState,
            this.Net_Col_AvailabilityZones});
            this.DGV_Net.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Net.Location = new System.Drawing.Point(0, 0);
            this.DGV_Net.Name = "DGV_Net";
            this.DGV_Net.Size = new System.Drawing.Size(613, 336);
            this.DGV_Net.TabIndex = 0;
            this.DGV_Net.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Net_CellContentClick);
            // 
            // Net_Col_Select
            // 
            this.Net_Col_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Net_Col_Select.Frozen = true;
            this.Net_Col_Select.HeaderText = "Select";
            this.Net_Col_Select.Name = "Net_Col_Select";
            this.Net_Col_Select.Width = 43;
            // 
            // Net_Col_Name
            // 
            this.Net_Col_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Net_Col_Name.DefaultCellStyle = dataGridViewCellStyle1;
            this.Net_Col_Name.HeaderText = "Name";
            this.Net_Col_Name.Name = "Net_Col_Name";
            this.Net_Col_Name.ReadOnly = true;
            this.Net_Col_Name.Width = 60;
            // 
            // Net_Col_SubnetsAssociated
            // 
            this.Net_Col_SubnetsAssociated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Net_Col_SubnetsAssociated.HeaderText = "Subnets Associated";
            this.Net_Col_SubnetsAssociated.Name = "Net_Col_SubnetsAssociated";
            this.Net_Col_SubnetsAssociated.ReadOnly = true;
            this.Net_Col_SubnetsAssociated.Width = 115;
            // 
            // Net_Col_Shared
            // 
            this.Net_Col_Shared.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Net_Col_Shared.HeaderText = "Shared";
            this.Net_Col_Shared.Name = "Net_Col_Shared";
            this.Net_Col_Shared.ReadOnly = true;
            this.Net_Col_Shared.Width = 66;
            // 
            // Net_Col_External
            // 
            this.Net_Col_External.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Net_Col_External.HeaderText = "External";
            this.Net_Col_External.Name = "Net_Col_External";
            this.Net_Col_External.ReadOnly = true;
            this.Net_Col_External.Width = 70;
            // 
            // Net_Col_Status
            // 
            this.Net_Col_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Net_Col_Status.HeaderText = "Status";
            this.Net_Col_Status.Name = "Net_Col_Status";
            this.Net_Col_Status.ReadOnly = true;
            this.Net_Col_Status.Width = 62;
            // 
            // Net_Col_AdminState
            // 
            this.Net_Col_AdminState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Net_Col_AdminState.HeaderText = "Admin State";
            this.Net_Col_AdminState.Name = "Net_Col_AdminState";
            this.Net_Col_AdminState.ReadOnly = true;
            this.Net_Col_AdminState.Width = 82;
            // 
            // Net_Col_AvailabilityZones
            // 
            this.Net_Col_AvailabilityZones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Net_Col_AvailabilityZones.HeaderText = "Availability Zones";
            this.Net_Col_AvailabilityZones.Name = "Net_Col_AvailabilityZones";
            this.Net_Col_AvailabilityZones.ReadOnly = true;
            this.Net_Col_AvailabilityZones.Width = 105;
            // 
            // P_B_Cr_Del_Net
            // 
            this.P_B_Cr_Del_Net.Controls.Add(this.B_Del_Net);
            this.P_B_Cr_Del_Net.Controls.Add(this.B_Cr_Net);
            this.P_B_Cr_Del_Net.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_B_Cr_Del_Net.Location = new System.Drawing.Point(3, 78);
            this.P_B_Cr_Del_Net.Name = "P_B_Cr_Del_Net";
            this.P_B_Cr_Del_Net.Size = new System.Drawing.Size(613, 75);
            this.P_B_Cr_Del_Net.TabIndex = 3;
            this.P_B_Cr_Del_Net.Resize += new System.EventHandler(this.P_B_Cr_Del_Net_Resize);
            // 
            // B_Del_Net
            // 
            this.B_Del_Net.Location = new System.Drawing.Point(516, 18);
            this.B_Del_Net.Name = "B_Del_Net";
            this.B_Del_Net.Size = new System.Drawing.Size(80, 35);
            this.B_Del_Net.TabIndex = 2;
            this.B_Del_Net.Text = "Delete";
            this.B_Del_Net.UseVisualStyleBackColor = true;
            this.B_Del_Net.Click += new System.EventHandler(this.B_Del_Net_Click);
            // 
            // B_Cr_Net
            // 
            this.B_Cr_Net.Location = new System.Drawing.Point(416, 18);
            this.B_Cr_Net.Name = "B_Cr_Net";
            this.B_Cr_Net.Size = new System.Drawing.Size(80, 35);
            this.B_Cr_Net.TabIndex = 1;
            this.B_Cr_Net.Text = "Create";
            this.B_Cr_Net.UseVisualStyleBackColor = true;
            this.B_Cr_Net.Click += new System.EventHandler(this.B_Cr_Net_Click);
            // 
            // P_L_Networks
            // 
            this.P_L_Networks.Controls.Add(this.L_Networks);
            this.P_L_Networks.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_Networks.Location = new System.Drawing.Point(3, 3);
            this.P_L_Networks.Name = "P_L_Networks";
            this.P_L_Networks.Size = new System.Drawing.Size(613, 75);
            this.P_L_Networks.TabIndex = 2;
            this.P_L_Networks.Resize += new System.EventHandler(this.P_L_Networks_Resize);
            // 
            // L_Networks
            // 
            this.L_Networks.AutoSize = true;
            this.L_Networks.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Networks.Location = new System.Drawing.Point(229, 18);
            this.L_Networks.Name = "L_Networks";
            this.L_Networks.Size = new System.Drawing.Size(151, 37);
            this.L_Networks.TabIndex = 0;
            this.L_Networks.Text = "Networks";
            // 
            // RouterPage
            // 
            this.RouterPage.BackColor = System.Drawing.Color.White;
            this.RouterPage.Controls.Add(this.P_DGV_Routers);
            this.RouterPage.Controls.Add(this.P_B_Cr_Del_Routers);
            this.RouterPage.Controls.Add(this.P_L_Routers);
            this.RouterPage.Location = new System.Drawing.Point(4, 5);
            this.RouterPage.Name = "RouterPage";
            this.RouterPage.Padding = new System.Windows.Forms.Padding(3);
            this.RouterPage.Size = new System.Drawing.Size(619, 492);
            this.RouterPage.TabIndex = 7;
            this.RouterPage.Text = "tabPage8";
            this.RouterPage.UseVisualStyleBackColor = true;
            // 
            // P_DGV_Routers
            // 
            this.P_DGV_Routers.Controls.Add(this.DGV_Routers);
            this.P_DGV_Routers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_Routers.Location = new System.Drawing.Point(3, 153);
            this.P_DGV_Routers.Name = "P_DGV_Routers";
            this.P_DGV_Routers.Size = new System.Drawing.Size(613, 336);
            this.P_DGV_Routers.TabIndex = 5;
            // 
            // DGV_Routers
            // 
            this.DGV_Routers.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Routers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Routers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RT_Col_Select,
            this.RT_Col_Name,
            this.RT_Col_Status,
            this.RT_Col_ExNet,
            this.RT_Col_AS,
            this.RT_Col_AZ});
            this.DGV_Routers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Routers.Location = new System.Drawing.Point(0, 0);
            this.DGV_Routers.Name = "DGV_Routers";
            this.DGV_Routers.Size = new System.Drawing.Size(613, 336);
            this.DGV_Routers.TabIndex = 0;
            this.DGV_Routers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Routers_CellContentClick);
            // 
            // RT_Col_Select
            // 
            this.RT_Col_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RT_Col_Select.HeaderText = "Select";
            this.RT_Col_Select.Name = "RT_Col_Select";
            this.RT_Col_Select.Width = 43;
            // 
            // RT_Col_Name
            // 
            this.RT_Col_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RT_Col_Name.HeaderText = "Name";
            this.RT_Col_Name.Name = "RT_Col_Name";
            this.RT_Col_Name.ReadOnly = true;
            this.RT_Col_Name.Width = 60;
            // 
            // RT_Col_Status
            // 
            this.RT_Col_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RT_Col_Status.HeaderText = "Status";
            this.RT_Col_Status.Name = "RT_Col_Status";
            this.RT_Col_Status.ReadOnly = true;
            this.RT_Col_Status.Width = 62;
            // 
            // RT_Col_ExNet
            // 
            this.RT_Col_ExNet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RT_Col_ExNet.HeaderText = "External  Network";
            this.RT_Col_ExNet.Name = "RT_Col_ExNet";
            this.RT_Col_ExNet.ReadOnly = true;
            this.RT_Col_ExNet.Width = 106;
            // 
            // RT_Col_AS
            // 
            this.RT_Col_AS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RT_Col_AS.HeaderText = "Admin State";
            this.RT_Col_AS.Name = "RT_Col_AS";
            this.RT_Col_AS.ReadOnly = true;
            this.RT_Col_AS.Width = 82;
            // 
            // RT_Col_AZ
            // 
            this.RT_Col_AZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RT_Col_AZ.HeaderText = "Availability Zones";
            this.RT_Col_AZ.Name = "RT_Col_AZ";
            this.RT_Col_AZ.ReadOnly = true;
            this.RT_Col_AZ.Width = 105;
            // 
            // P_B_Cr_Del_Routers
            // 
            this.P_B_Cr_Del_Routers.Controls.Add(this.B_Del_Routers);
            this.P_B_Cr_Del_Routers.Controls.Add(this.B_Cr_Routers);
            this.P_B_Cr_Del_Routers.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_B_Cr_Del_Routers.Location = new System.Drawing.Point(3, 78);
            this.P_B_Cr_Del_Routers.Name = "P_B_Cr_Del_Routers";
            this.P_B_Cr_Del_Routers.Size = new System.Drawing.Size(613, 75);
            this.P_B_Cr_Del_Routers.TabIndex = 4;
            this.P_B_Cr_Del_Routers.Resize += new System.EventHandler(this.P_B_Cr_Del_Routers_Resize);
            // 
            // B_Del_Routers
            // 
            this.B_Del_Routers.Location = new System.Drawing.Point(516, 18);
            this.B_Del_Routers.Name = "B_Del_Routers";
            this.B_Del_Routers.Size = new System.Drawing.Size(80, 35);
            this.B_Del_Routers.TabIndex = 2;
            this.B_Del_Routers.Text = "Delete";
            this.B_Del_Routers.UseVisualStyleBackColor = true;
            this.B_Del_Routers.Click += new System.EventHandler(this.B_Del_Routers_Click);
            // 
            // B_Cr_Routers
            // 
            this.B_Cr_Routers.Location = new System.Drawing.Point(416, 18);
            this.B_Cr_Routers.Name = "B_Cr_Routers";
            this.B_Cr_Routers.Size = new System.Drawing.Size(80, 35);
            this.B_Cr_Routers.TabIndex = 1;
            this.B_Cr_Routers.Text = "Create";
            this.B_Cr_Routers.UseVisualStyleBackColor = true;
            this.B_Cr_Routers.Click += new System.EventHandler(this.B_Cr_Routers_Click);
            // 
            // P_L_Routers
            // 
            this.P_L_Routers.Controls.Add(this.L_Routers);
            this.P_L_Routers.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_Routers.Location = new System.Drawing.Point(3, 3);
            this.P_L_Routers.Name = "P_L_Routers";
            this.P_L_Routers.Size = new System.Drawing.Size(613, 75);
            this.P_L_Routers.TabIndex = 3;
            this.P_L_Routers.Resize += new System.EventHandler(this.P_L_Routers_Resize);
            // 
            // L_Routers
            // 
            this.L_Routers.AutoSize = true;
            this.L_Routers.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Routers.Location = new System.Drawing.Point(229, 18);
            this.L_Routers.Name = "L_Routers";
            this.L_Routers.Size = new System.Drawing.Size(128, 37);
            this.L_Routers.TabIndex = 0;
            this.L_Routers.Text = "Routers";
            // 
            // SecurityGroupPage
            // 
            this.SecurityGroupPage.BackColor = System.Drawing.Color.White;
            this.SecurityGroupPage.Controls.Add(this.P_DGV_SecurityGroup);
            this.SecurityGroupPage.Controls.Add(this.P_B_Cr_Del_SecurityGroup);
            this.SecurityGroupPage.Controls.Add(this.P_L_SecurityGroup);
            this.SecurityGroupPage.Location = new System.Drawing.Point(4, 5);
            this.SecurityGroupPage.Name = "SecurityGroupPage";
            this.SecurityGroupPage.Padding = new System.Windows.Forms.Padding(3);
            this.SecurityGroupPage.Size = new System.Drawing.Size(619, 492);
            this.SecurityGroupPage.TabIndex = 8;
            this.SecurityGroupPage.Text = "tabPage9";
            this.SecurityGroupPage.UseVisualStyleBackColor = true;
            // 
            // P_DGV_SecurityGroup
            // 
            this.P_DGV_SecurityGroup.Controls.Add(this.DGV_SecurityGroup);
            this.P_DGV_SecurityGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_SecurityGroup.Location = new System.Drawing.Point(3, 153);
            this.P_DGV_SecurityGroup.Name = "P_DGV_SecurityGroup";
            this.P_DGV_SecurityGroup.Size = new System.Drawing.Size(613, 336);
            this.P_DGV_SecurityGroup.TabIndex = 5;
            // 
            // DGV_SecurityGroup
            // 
            this.DGV_SecurityGroup.BackgroundColor = System.Drawing.Color.White;
            this.DGV_SecurityGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SecurityGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SG_Col_Select,
            this.SG_Col_Name,
            this.SG_Col_SGID,
            this.SG_Col_Description,
            this.SG_Col_Shared});
            this.DGV_SecurityGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_SecurityGroup.Location = new System.Drawing.Point(0, 0);
            this.DGV_SecurityGroup.Name = "DGV_SecurityGroup";
            this.DGV_SecurityGroup.Size = new System.Drawing.Size(613, 336);
            this.DGV_SecurityGroup.TabIndex = 0;
            this.DGV_SecurityGroup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SecurityGroup_CellContentClick);
            // 
            // SG_Col_Select
            // 
            this.SG_Col_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SG_Col_Select.Frozen = true;
            this.SG_Col_Select.HeaderText = "Select";
            this.SG_Col_Select.Name = "SG_Col_Select";
            this.SG_Col_Select.Width = 43;
            // 
            // SG_Col_Name
            // 
            this.SG_Col_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SG_Col_Name.HeaderText = "Name";
            this.SG_Col_Name.Name = "SG_Col_Name";
            this.SG_Col_Name.ReadOnly = true;
            this.SG_Col_Name.Width = 60;
            // 
            // SG_Col_SGID
            // 
            this.SG_Col_SGID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SG_Col_SGID.HeaderText = "Security Group ID";
            this.SG_Col_SGID.Name = "SG_Col_SGID";
            this.SG_Col_SGID.ReadOnly = true;
            this.SG_Col_SGID.Width = 97;
            // 
            // SG_Col_Description
            // 
            this.SG_Col_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SG_Col_Description.HeaderText = "Description";
            this.SG_Col_Description.Name = "SG_Col_Description";
            this.SG_Col_Description.Width = 85;
            // 
            // SG_Col_Shared
            // 
            this.SG_Col_Shared.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SG_Col_Shared.HeaderText = "Shared";
            this.SG_Col_Shared.Name = "SG_Col_Shared";
            this.SG_Col_Shared.ReadOnly = true;
            this.SG_Col_Shared.Width = 66;
            // 
            // P_B_Cr_Del_SecurityGroup
            // 
            this.P_B_Cr_Del_SecurityGroup.Controls.Add(this.B_Del_SecurityGroup);
            this.P_B_Cr_Del_SecurityGroup.Controls.Add(this.B_Cr_SecurityGroup);
            this.P_B_Cr_Del_SecurityGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_B_Cr_Del_SecurityGroup.Location = new System.Drawing.Point(3, 78);
            this.P_B_Cr_Del_SecurityGroup.Name = "P_B_Cr_Del_SecurityGroup";
            this.P_B_Cr_Del_SecurityGroup.Size = new System.Drawing.Size(613, 75);
            this.P_B_Cr_Del_SecurityGroup.TabIndex = 4;
            this.P_B_Cr_Del_SecurityGroup.Resize += new System.EventHandler(this.P_B_Cr_Del_SecurityGroup_Resize);
            // 
            // B_Del_SecurityGroup
            // 
            this.B_Del_SecurityGroup.Location = new System.Drawing.Point(516, 18);
            this.B_Del_SecurityGroup.Name = "B_Del_SecurityGroup";
            this.B_Del_SecurityGroup.Size = new System.Drawing.Size(80, 35);
            this.B_Del_SecurityGroup.TabIndex = 2;
            this.B_Del_SecurityGroup.Text = "Delete";
            this.B_Del_SecurityGroup.UseVisualStyleBackColor = true;
            this.B_Del_SecurityGroup.Click += new System.EventHandler(this.B_Del_SecurityGroup_Click);
            // 
            // B_Cr_SecurityGroup
            // 
            this.B_Cr_SecurityGroup.Location = new System.Drawing.Point(416, 18);
            this.B_Cr_SecurityGroup.Name = "B_Cr_SecurityGroup";
            this.B_Cr_SecurityGroup.Size = new System.Drawing.Size(80, 35);
            this.B_Cr_SecurityGroup.TabIndex = 1;
            this.B_Cr_SecurityGroup.Text = "Create";
            this.B_Cr_SecurityGroup.UseVisualStyleBackColor = true;
            this.B_Cr_SecurityGroup.Click += new System.EventHandler(this.B_Cr_SecurityGroup_Click);
            // 
            // P_L_SecurityGroup
            // 
            this.P_L_SecurityGroup.Controls.Add(this.L_SecurityGroup);
            this.P_L_SecurityGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_SecurityGroup.Location = new System.Drawing.Point(3, 3);
            this.P_L_SecurityGroup.Name = "P_L_SecurityGroup";
            this.P_L_SecurityGroup.Size = new System.Drawing.Size(613, 75);
            this.P_L_SecurityGroup.TabIndex = 3;
            this.P_L_SecurityGroup.Resize += new System.EventHandler(this.P_L_SecurityGroup_Resize);
            // 
            // L_SecurityGroup
            // 
            this.L_SecurityGroup.AutoSize = true;
            this.L_SecurityGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_SecurityGroup.Location = new System.Drawing.Point(229, 18);
            this.L_SecurityGroup.Name = "L_SecurityGroup";
            this.L_SecurityGroup.Size = new System.Drawing.Size(221, 37);
            this.L_SecurityGroup.TabIndex = 0;
            this.L_SecurityGroup.Text = "SecurityGroup";
            // 
            // FloatingIPPage
            // 
            this.FloatingIPPage.BackColor = System.Drawing.Color.White;
            this.FloatingIPPage.Controls.Add(this.P_DGV_FlIP);
            this.FloatingIPPage.Controls.Add(this.P_B_Al_Re_IP);
            this.FloatingIPPage.Controls.Add(this.P_L_IP);
            this.FloatingIPPage.Location = new System.Drawing.Point(4, 5);
            this.FloatingIPPage.Name = "FloatingIPPage";
            this.FloatingIPPage.Padding = new System.Windows.Forms.Padding(3);
            this.FloatingIPPage.Size = new System.Drawing.Size(619, 492);
            this.FloatingIPPage.TabIndex = 9;
            this.FloatingIPPage.Text = "tabPage10";
            this.FloatingIPPage.UseVisualStyleBackColor = true;
            // 
            // P_DGV_FlIP
            // 
            this.P_DGV_FlIP.Controls.Add(this.DGV_FlIP);
            this.P_DGV_FlIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_FlIP.Location = new System.Drawing.Point(3, 153);
            this.P_DGV_FlIP.Name = "P_DGV_FlIP";
            this.P_DGV_FlIP.Size = new System.Drawing.Size(613, 336);
            this.P_DGV_FlIP.TabIndex = 3;
            // 
            // DGV_FlIP
            // 
            this.DGV_FlIP.BackgroundColor = System.Drawing.Color.White;
            this.DGV_FlIP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_FlIP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FlIP_Col_Select,
            this.FlIP_Col_IPAddress,
            this.FlIP_Col_Description,
            this.FlIP_Col_DNSName,
            this.FlIP_Col_DNSDomain,
            this.FlIP_Col_MapIP,
            this.FlIP_Col_Pool,
            this.FlIP_Col_Status});
            this.DGV_FlIP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_FlIP.Location = new System.Drawing.Point(0, 0);
            this.DGV_FlIP.Name = "DGV_FlIP";
            this.DGV_FlIP.Size = new System.Drawing.Size(613, 336);
            this.DGV_FlIP.TabIndex = 0;
            // 
            // FlIP_Col_Select
            // 
            this.FlIP_Col_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FlIP_Col_Select.HeaderText = "Select";
            this.FlIP_Col_Select.Name = "FlIP_Col_Select";
            this.FlIP_Col_Select.Width = 43;
            // 
            // FlIP_Col_IPAddress
            // 
            this.FlIP_Col_IPAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FlIP_Col_IPAddress.HeaderText = "IP Address";
            this.FlIP_Col_IPAddress.Name = "FlIP_Col_IPAddress";
            this.FlIP_Col_IPAddress.ReadOnly = true;
            this.FlIP_Col_IPAddress.Width = 77;
            // 
            // FlIP_Col_Description
            // 
            this.FlIP_Col_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FlIP_Col_Description.HeaderText = "Description";
            this.FlIP_Col_Description.Name = "FlIP_Col_Description";
            this.FlIP_Col_Description.ReadOnly = true;
            this.FlIP_Col_Description.Width = 85;
            // 
            // FlIP_Col_DNSName
            // 
            this.FlIP_Col_DNSName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FlIP_Col_DNSName.HeaderText = "DNS Name";
            this.FlIP_Col_DNSName.Name = "FlIP_Col_DNSName";
            this.FlIP_Col_DNSName.ReadOnly = true;
            this.FlIP_Col_DNSName.Width = 79;
            // 
            // FlIP_Col_DNSDomain
            // 
            this.FlIP_Col_DNSDomain.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FlIP_Col_DNSDomain.HeaderText = "DNS Domain";
            this.FlIP_Col_DNSDomain.Name = "FlIP_Col_DNSDomain";
            this.FlIP_Col_DNSDomain.ReadOnly = true;
            this.FlIP_Col_DNSDomain.Width = 87;
            // 
            // FlIP_Col_MapIP
            // 
            this.FlIP_Col_MapIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FlIP_Col_MapIP.HeaderText = "Mapped Fixed IP Address";
            this.FlIP_Col_MapIP.Name = "FlIP_Col_MapIP";
            this.FlIP_Col_MapIP.ReadOnly = true;
            this.FlIP_Col_MapIP.Width = 106;
            // 
            // FlIP_Col_Pool
            // 
            this.FlIP_Col_Pool.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FlIP_Col_Pool.HeaderText = "Pool";
            this.FlIP_Col_Pool.Name = "FlIP_Col_Pool";
            this.FlIP_Col_Pool.ReadOnly = true;
            this.FlIP_Col_Pool.Width = 53;
            // 
            // FlIP_Col_Status
            // 
            this.FlIP_Col_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.FlIP_Col_Status.HeaderText = "Status";
            this.FlIP_Col_Status.Name = "FlIP_Col_Status";
            this.FlIP_Col_Status.ReadOnly = true;
            this.FlIP_Col_Status.Width = 62;
            // 
            // P_B_Al_Re_IP
            // 
            this.P_B_Al_Re_IP.Controls.Add(this.B_ReleaseIP);
            this.P_B_Al_Re_IP.Controls.Add(this.B_AllocateIP);
            this.P_B_Al_Re_IP.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_B_Al_Re_IP.Location = new System.Drawing.Point(3, 78);
            this.P_B_Al_Re_IP.Name = "P_B_Al_Re_IP";
            this.P_B_Al_Re_IP.Size = new System.Drawing.Size(613, 75);
            this.P_B_Al_Re_IP.TabIndex = 2;
            this.P_B_Al_Re_IP.Resize += new System.EventHandler(this.P_B_Al_Re_IP_Resize);
            // 
            // B_ReleaseIP
            // 
            this.B_ReleaseIP.Location = new System.Drawing.Point(516, 18);
            this.B_ReleaseIP.Name = "B_ReleaseIP";
            this.B_ReleaseIP.Size = new System.Drawing.Size(80, 35);
            this.B_ReleaseIP.TabIndex = 2;
            this.B_ReleaseIP.Text = "Release";
            this.B_ReleaseIP.UseVisualStyleBackColor = true;
            this.B_ReleaseIP.Click += new System.EventHandler(this.B_ReleaseIP_Click);
            // 
            // B_AllocateIP
            // 
            this.B_AllocateIP.Location = new System.Drawing.Point(416, 18);
            this.B_AllocateIP.Name = "B_AllocateIP";
            this.B_AllocateIP.Size = new System.Drawing.Size(80, 35);
            this.B_AllocateIP.TabIndex = 1;
            this.B_AllocateIP.Text = "Allocate";
            this.B_AllocateIP.UseVisualStyleBackColor = true;
            this.B_AllocateIP.Click += new System.EventHandler(this.B_AllocateIP_Click);
            // 
            // P_L_IP
            // 
            this.P_L_IP.Controls.Add(this.L_FloatingIP);
            this.P_L_IP.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_IP.Location = new System.Drawing.Point(3, 3);
            this.P_L_IP.Name = "P_L_IP";
            this.P_L_IP.Size = new System.Drawing.Size(613, 75);
            this.P_L_IP.TabIndex = 1;
            this.P_L_IP.Resize += new System.EventHandler(this.P_L_IP_Resize);
            // 
            // L_FloatingIP
            // 
            this.L_FloatingIP.AutoSize = true;
            this.L_FloatingIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_FloatingIP.Location = new System.Drawing.Point(229, 18);
            this.L_FloatingIP.Name = "L_FloatingIP";
            this.L_FloatingIP.Size = new System.Drawing.Size(186, 37);
            this.L_FloatingIP.TabIndex = 0;
            this.L_FloatingIP.Text = "Floating IPs";
            // 
            // LoadBalancerPage
            // 
            this.LoadBalancerPage.BackColor = System.Drawing.Color.White;
            this.LoadBalancerPage.Controls.Add(this.P_DGV_LoadBalancer);
            this.LoadBalancerPage.Controls.Add(this.P_B_Cr_Del_LoadBalancer);
            this.LoadBalancerPage.Controls.Add(this.P_L_LoadBalancer);
            this.LoadBalancerPage.Location = new System.Drawing.Point(4, 5);
            this.LoadBalancerPage.Name = "LoadBalancerPage";
            this.LoadBalancerPage.Padding = new System.Windows.Forms.Padding(3);
            this.LoadBalancerPage.Size = new System.Drawing.Size(619, 492);
            this.LoadBalancerPage.TabIndex = 10;
            this.LoadBalancerPage.Text = "tabPage11";
            this.LoadBalancerPage.UseVisualStyleBackColor = true;
            // 
            // P_DGV_LoadBalancer
            // 
            this.P_DGV_LoadBalancer.Controls.Add(this.DGV_LoadBalancer);
            this.P_DGV_LoadBalancer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_LoadBalancer.Location = new System.Drawing.Point(3, 153);
            this.P_DGV_LoadBalancer.Name = "P_DGV_LoadBalancer";
            this.P_DGV_LoadBalancer.Size = new System.Drawing.Size(613, 336);
            this.P_DGV_LoadBalancer.TabIndex = 5;
            // 
            // DGV_LoadBalancer
            // 
            this.DGV_LoadBalancer.BackgroundColor = System.Drawing.Color.White;
            this.DGV_LoadBalancer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_LoadBalancer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LB_Col_Select,
            this.LB_Col_Name,
            this.LB_Col_IP,
            this.LB_Col_AZ,
            this.LB_Col_OS,
            this.LB_Col_PS,
            this.LB_Col_ASU});
            this.DGV_LoadBalancer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_LoadBalancer.Location = new System.Drawing.Point(0, 0);
            this.DGV_LoadBalancer.Name = "DGV_LoadBalancer";
            this.DGV_LoadBalancer.Size = new System.Drawing.Size(613, 336);
            this.DGV_LoadBalancer.TabIndex = 0;
            // 
            // LB_Col_Select
            // 
            this.LB_Col_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LB_Col_Select.Frozen = true;
            this.LB_Col_Select.HeaderText = "Select";
            this.LB_Col_Select.Name = "LB_Col_Select";
            this.LB_Col_Select.Width = 43;
            // 
            // LB_Col_Name
            // 
            this.LB_Col_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LB_Col_Name.HeaderText = "Name";
            this.LB_Col_Name.Name = "LB_Col_Name";
            this.LB_Col_Name.ReadOnly = true;
            this.LB_Col_Name.Width = 60;
            // 
            // LB_Col_IP
            // 
            this.LB_Col_IP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LB_Col_IP.HeaderText = "IP Address";
            this.LB_Col_IP.Name = "LB_Col_IP";
            this.LB_Col_IP.ReadOnly = true;
            this.LB_Col_IP.Width = 77;
            // 
            // LB_Col_AZ
            // 
            this.LB_Col_AZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LB_Col_AZ.HeaderText = "Availability Zones";
            this.LB_Col_AZ.Name = "LB_Col_AZ";
            this.LB_Col_AZ.ReadOnly = true;
            this.LB_Col_AZ.Width = 105;
            // 
            // LB_Col_OS
            // 
            this.LB_Col_OS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LB_Col_OS.HeaderText = "Operating Status";
            this.LB_Col_OS.Name = "LB_Col_OS";
            this.LB_Col_OS.ReadOnly = true;
            this.LB_Col_OS.Width = 102;
            // 
            // LB_Col_PS
            // 
            this.LB_Col_PS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LB_Col_PS.HeaderText = "Provisioning Status";
            this.LB_Col_PS.Name = "LB_Col_PS";
            this.LB_Col_PS.ReadOnly = true;
            this.LB_Col_PS.Width = 112;
            // 
            // LB_Col_ASU
            // 
            this.LB_Col_ASU.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LB_Col_ASU.HeaderText = "Admin State Up";
            this.LB_Col_ASU.Name = "LB_Col_ASU";
            this.LB_Col_ASU.ReadOnly = true;
            this.LB_Col_ASU.Width = 85;
            // 
            // P_B_Cr_Del_LoadBalancer
            // 
            this.P_B_Cr_Del_LoadBalancer.Controls.Add(this.B_Del_LoadBalancer);
            this.P_B_Cr_Del_LoadBalancer.Controls.Add(this.B_Cr_LoadBalancer);
            this.P_B_Cr_Del_LoadBalancer.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_B_Cr_Del_LoadBalancer.Location = new System.Drawing.Point(3, 78);
            this.P_B_Cr_Del_LoadBalancer.Name = "P_B_Cr_Del_LoadBalancer";
            this.P_B_Cr_Del_LoadBalancer.Size = new System.Drawing.Size(613, 75);
            this.P_B_Cr_Del_LoadBalancer.TabIndex = 4;
            this.P_B_Cr_Del_LoadBalancer.Resize += new System.EventHandler(this.P_B_Cr_Del_LoadBalancer_Resize);
            // 
            // B_Del_LoadBalancer
            // 
            this.B_Del_LoadBalancer.Location = new System.Drawing.Point(516, 18);
            this.B_Del_LoadBalancer.Name = "B_Del_LoadBalancer";
            this.B_Del_LoadBalancer.Size = new System.Drawing.Size(80, 35);
            this.B_Del_LoadBalancer.TabIndex = 2;
            this.B_Del_LoadBalancer.Text = "Delete";
            this.B_Del_LoadBalancer.UseVisualStyleBackColor = true;
            this.B_Del_LoadBalancer.Click += new System.EventHandler(this.B_Del_LoadBalancer_Click);
            // 
            // B_Cr_LoadBalancer
            // 
            this.B_Cr_LoadBalancer.Location = new System.Drawing.Point(416, 18);
            this.B_Cr_LoadBalancer.Name = "B_Cr_LoadBalancer";
            this.B_Cr_LoadBalancer.Size = new System.Drawing.Size(80, 35);
            this.B_Cr_LoadBalancer.TabIndex = 1;
            this.B_Cr_LoadBalancer.Text = "Create";
            this.B_Cr_LoadBalancer.UseVisualStyleBackColor = true;
            this.B_Cr_LoadBalancer.Click += new System.EventHandler(this.B_Cr_LoadBalancer_Click);
            // 
            // P_L_LoadBalancer
            // 
            this.P_L_LoadBalancer.Controls.Add(this.L_LoadBalancer);
            this.P_L_LoadBalancer.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_LoadBalancer.Location = new System.Drawing.Point(3, 3);
            this.P_L_LoadBalancer.Name = "P_L_LoadBalancer";
            this.P_L_LoadBalancer.Size = new System.Drawing.Size(613, 75);
            this.P_L_LoadBalancer.TabIndex = 3;
            this.P_L_LoadBalancer.Resize += new System.EventHandler(this.P_L_LoadBalancer_Resize);
            // 
            // L_LoadBalancer
            // 
            this.L_LoadBalancer.AutoSize = true;
            this.L_LoadBalancer.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_LoadBalancer.Location = new System.Drawing.Point(229, 18);
            this.L_LoadBalancer.Name = "L_LoadBalancer";
            this.L_LoadBalancer.Size = new System.Drawing.Size(215, 37);
            this.L_LoadBalancer.TabIndex = 0;
            this.L_LoadBalancer.Text = "LoadBalancer";
            // 
            // Page0
            // 
            this.Page0.BackColor = System.Drawing.Color.White;
            this.Page0.Location = new System.Drawing.Point(4, 5);
            this.Page0.Name = "Page0";
            this.Page0.Padding = new System.Windows.Forms.Padding(3);
            this.Page0.Size = new System.Drawing.Size(619, 492);
            this.Page0.TabIndex = 11;
            this.Page0.Text = "tabPage12";
            this.Page0.UseVisualStyleBackColor = true;
            // 
            // SubnetPage
            // 
            this.SubnetPage.BackColor = System.Drawing.Color.White;
            this.SubnetPage.Controls.Add(this.P_DGV_Subnets);
            this.SubnetPage.Controls.Add(this.P_B_Cr_Del_Subnets);
            this.SubnetPage.Controls.Add(this.P_L_Subnet);
            this.SubnetPage.Controls.Add(this.P_L_Sub_Networks);
            this.SubnetPage.Location = new System.Drawing.Point(4, 5);
            this.SubnetPage.Name = "SubnetPage";
            this.SubnetPage.Padding = new System.Windows.Forms.Padding(3);
            this.SubnetPage.Size = new System.Drawing.Size(619, 492);
            this.SubnetPage.TabIndex = 12;
            this.SubnetPage.Text = "tabPage1";
            // 
            // P_DGV_Subnets
            // 
            this.P_DGV_Subnets.Controls.Add(this.DGV_Subnets);
            this.P_DGV_Subnets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_Subnets.Location = new System.Drawing.Point(3, 228);
            this.P_DGV_Subnets.Name = "P_DGV_Subnets";
            this.P_DGV_Subnets.Size = new System.Drawing.Size(613, 261);
            this.P_DGV_Subnets.TabIndex = 6;
            // 
            // DGV_Subnets
            // 
            this.DGV_Subnets.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Subnets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Subnets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sub_Col_Select,
            this.Sub_Col_Name,
            this.Sub_Col_NetAddress,
            this.Sub_Col_IPver,
            this.Sub_Col_GateIP});
            this.DGV_Subnets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Subnets.Location = new System.Drawing.Point(0, 0);
            this.DGV_Subnets.Name = "DGV_Subnets";
            this.DGV_Subnets.Size = new System.Drawing.Size(613, 261);
            this.DGV_Subnets.TabIndex = 0;
            // 
            // Sub_Col_Select
            // 
            this.Sub_Col_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sub_Col_Select.Frozen = true;
            this.Sub_Col_Select.HeaderText = "Select";
            this.Sub_Col_Select.Name = "Sub_Col_Select";
            this.Sub_Col_Select.Width = 43;
            // 
            // Sub_Col_Name
            // 
            this.Sub_Col_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Sub_Col_Name.DefaultCellStyle = dataGridViewCellStyle2;
            this.Sub_Col_Name.HeaderText = "Name";
            this.Sub_Col_Name.Name = "Sub_Col_Name";
            this.Sub_Col_Name.ReadOnly = true;
            this.Sub_Col_Name.Width = 60;
            // 
            // Sub_Col_NetAddress
            // 
            this.Sub_Col_NetAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sub_Col_NetAddress.HeaderText = "Network Address";
            this.Sub_Col_NetAddress.Name = "Sub_Col_NetAddress";
            this.Sub_Col_NetAddress.ReadOnly = true;
            this.Sub_Col_NetAddress.Width = 104;
            // 
            // Sub_Col_IPver
            // 
            this.Sub_Col_IPver.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sub_Col_IPver.HeaderText = "Ip Version";
            this.Sub_Col_IPver.Name = "Sub_Col_IPver";
            this.Sub_Col_IPver.ReadOnly = true;
            this.Sub_Col_IPver.Width = 73;
            // 
            // Sub_Col_GateIP
            // 
            this.Sub_Col_GateIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sub_Col_GateIP.HeaderText = "Gateway IP";
            this.Sub_Col_GateIP.Name = "Sub_Col_GateIP";
            this.Sub_Col_GateIP.ReadOnly = true;
            this.Sub_Col_GateIP.Width = 80;
            // 
            // P_B_Cr_Del_Subnets
            // 
            this.P_B_Cr_Del_Subnets.Controls.Add(this.B_Del_Subnets);
            this.P_B_Cr_Del_Subnets.Controls.Add(this.B_Cr_Subnets);
            this.P_B_Cr_Del_Subnets.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_B_Cr_Del_Subnets.Location = new System.Drawing.Point(3, 153);
            this.P_B_Cr_Del_Subnets.Name = "P_B_Cr_Del_Subnets";
            this.P_B_Cr_Del_Subnets.Size = new System.Drawing.Size(613, 75);
            this.P_B_Cr_Del_Subnets.TabIndex = 5;
            this.P_B_Cr_Del_Subnets.Resize += new System.EventHandler(this.P_B_Cr_Del_Subnets_Resize);
            // 
            // B_Del_Subnets
            // 
            this.B_Del_Subnets.Location = new System.Drawing.Point(516, 18);
            this.B_Del_Subnets.Name = "B_Del_Subnets";
            this.B_Del_Subnets.Size = new System.Drawing.Size(80, 35);
            this.B_Del_Subnets.TabIndex = 2;
            this.B_Del_Subnets.Text = "Delete";
            this.B_Del_Subnets.UseVisualStyleBackColor = true;
            this.B_Del_Subnets.Click += new System.EventHandler(this.B_Del_Subnets_Click);
            // 
            // B_Cr_Subnets
            // 
            this.B_Cr_Subnets.Location = new System.Drawing.Point(416, 18);
            this.B_Cr_Subnets.Name = "B_Cr_Subnets";
            this.B_Cr_Subnets.Size = new System.Drawing.Size(80, 35);
            this.B_Cr_Subnets.TabIndex = 1;
            this.B_Cr_Subnets.Text = "Create";
            this.B_Cr_Subnets.UseVisualStyleBackColor = true;
            this.B_Cr_Subnets.Click += new System.EventHandler(this.B_Cr_Subnets_Click);
            // 
            // P_L_Subnet
            // 
            this.P_L_Subnet.Controls.Add(this.L_Subnet);
            this.P_L_Subnet.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_Subnet.Location = new System.Drawing.Point(3, 78);
            this.P_L_Subnet.Name = "P_L_Subnet";
            this.P_L_Subnet.Size = new System.Drawing.Size(613, 75);
            this.P_L_Subnet.TabIndex = 4;
            this.P_L_Subnet.Resize += new System.EventHandler(this.P_L_Subnet_Resize);
            // 
            // L_Subnet
            // 
            this.L_Subnet.AutoSize = true;
            this.L_Subnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Subnet.Location = new System.Drawing.Point(229, 18);
            this.L_Subnet.Name = "L_Subnet";
            this.L_Subnet.Size = new System.Drawing.Size(134, 37);
            this.L_Subnet.TabIndex = 0;
            this.L_Subnet.Text = "Subnets";
            // 
            // P_L_Sub_Networks
            // 
            this.P_L_Sub_Networks.Controls.Add(this.L_Sub_Networks);
            this.P_L_Sub_Networks.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_Sub_Networks.Location = new System.Drawing.Point(3, 3);
            this.P_L_Sub_Networks.Name = "P_L_Sub_Networks";
            this.P_L_Sub_Networks.Size = new System.Drawing.Size(613, 75);
            this.P_L_Sub_Networks.TabIndex = 3;
            this.P_L_Sub_Networks.Resize += new System.EventHandler(this.P_L_Sub_Networks_Resize);
            // 
            // L_Sub_Networks
            // 
            this.L_Sub_Networks.AutoSize = true;
            this.L_Sub_Networks.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Sub_Networks.Location = new System.Drawing.Point(229, 18);
            this.L_Sub_Networks.Name = "L_Sub_Networks";
            this.L_Sub_Networks.Size = new System.Drawing.Size(135, 37);
            this.L_Sub_Networks.TabIndex = 0;
            this.L_Sub_Networks.Text = "Network";
            // 
            // RouterInterfacePage
            // 
            this.RouterInterfacePage.BackColor = System.Drawing.Color.White;
            this.RouterInterfacePage.Controls.Add(this.P_DGV_Interface);
            this.RouterInterfacePage.Controls.Add(this.P_B_Cr_Del_Interface);
            this.RouterInterfacePage.Controls.Add(this.P_L_Interface);
            this.RouterInterfacePage.Controls.Add(this.P_L_In_Router);
            this.RouterInterfacePage.Location = new System.Drawing.Point(4, 5);
            this.RouterInterfacePage.Name = "RouterInterfacePage";
            this.RouterInterfacePage.Padding = new System.Windows.Forms.Padding(3);
            this.RouterInterfacePage.Size = new System.Drawing.Size(619, 492);
            this.RouterInterfacePage.TabIndex = 13;
            this.RouterInterfacePage.Text = "tabPage1";
            // 
            // P_DGV_Interface
            // 
            this.P_DGV_Interface.Controls.Add(this.DGV_Interface);
            this.P_DGV_Interface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_Interface.Location = new System.Drawing.Point(3, 228);
            this.P_DGV_Interface.Name = "P_DGV_Interface";
            this.P_DGV_Interface.Size = new System.Drawing.Size(613, 261);
            this.P_DGV_Interface.TabIndex = 7;
            // 
            // DGV_Interface
            // 
            this.DGV_Interface.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Interface.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Interface.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RI_Col_Select,
            this.RI_Col_Name,
            this.RI_Col_FixIP,
            this.RI_Col_Status,
            this.RI_Col_Type,
            this.RI_Col_AS});
            this.DGV_Interface.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Interface.Location = new System.Drawing.Point(0, 0);
            this.DGV_Interface.Name = "DGV_Interface";
            this.DGV_Interface.Size = new System.Drawing.Size(613, 261);
            this.DGV_Interface.TabIndex = 0;
            // 
            // RI_Col_Select
            // 
            this.RI_Col_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RI_Col_Select.Frozen = true;
            this.RI_Col_Select.HeaderText = "Select";
            this.RI_Col_Select.Name = "RI_Col_Select";
            this.RI_Col_Select.Width = 43;
            // 
            // RI_Col_Name
            // 
            this.RI_Col_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.RI_Col_Name.DefaultCellStyle = dataGridViewCellStyle3;
            this.RI_Col_Name.HeaderText = "Name";
            this.RI_Col_Name.Name = "RI_Col_Name";
            this.RI_Col_Name.ReadOnly = true;
            this.RI_Col_Name.Width = 60;
            // 
            // RI_Col_FixIP
            // 
            this.RI_Col_FixIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RI_Col_FixIP.HeaderText = "Fixed IPs";
            this.RI_Col_FixIP.Name = "RI_Col_FixIP";
            this.RI_Col_FixIP.ReadOnly = true;
            this.RI_Col_FixIP.Width = 75;
            // 
            // RI_Col_Status
            // 
            this.RI_Col_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RI_Col_Status.HeaderText = "Status";
            this.RI_Col_Status.Name = "RI_Col_Status";
            this.RI_Col_Status.ReadOnly = true;
            this.RI_Col_Status.Width = 62;
            // 
            // RI_Col_Type
            // 
            this.RI_Col_Type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RI_Col_Type.HeaderText = "Type";
            this.RI_Col_Type.Name = "RI_Col_Type";
            this.RI_Col_Type.ReadOnly = true;
            this.RI_Col_Type.Width = 56;
            // 
            // RI_Col_AS
            // 
            this.RI_Col_AS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RI_Col_AS.HeaderText = "Admin State";
            this.RI_Col_AS.Name = "RI_Col_AS";
            this.RI_Col_AS.Width = 89;
            // 
            // P_B_Cr_Del_Interface
            // 
            this.P_B_Cr_Del_Interface.Controls.Add(this.B_Del_Interface);
            this.P_B_Cr_Del_Interface.Controls.Add(this.B_Cr_Interface);
            this.P_B_Cr_Del_Interface.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_B_Cr_Del_Interface.Location = new System.Drawing.Point(3, 153);
            this.P_B_Cr_Del_Interface.Name = "P_B_Cr_Del_Interface";
            this.P_B_Cr_Del_Interface.Size = new System.Drawing.Size(613, 75);
            this.P_B_Cr_Del_Interface.TabIndex = 6;
            this.P_B_Cr_Del_Interface.Resize += new System.EventHandler(this.P_B_Cr_Del_Interface_Resize);
            // 
            // B_Del_Interface
            // 
            this.B_Del_Interface.Location = new System.Drawing.Point(516, 18);
            this.B_Del_Interface.Name = "B_Del_Interface";
            this.B_Del_Interface.Size = new System.Drawing.Size(80, 35);
            this.B_Del_Interface.TabIndex = 2;
            this.B_Del_Interface.Text = "Delete";
            this.B_Del_Interface.UseVisualStyleBackColor = true;
            this.B_Del_Interface.Click += new System.EventHandler(this.B_Del_Interface_Click);
            // 
            // B_Cr_Interface
            // 
            this.B_Cr_Interface.Location = new System.Drawing.Point(416, 18);
            this.B_Cr_Interface.Name = "B_Cr_Interface";
            this.B_Cr_Interface.Size = new System.Drawing.Size(80, 35);
            this.B_Cr_Interface.TabIndex = 1;
            this.B_Cr_Interface.Text = "Create";
            this.B_Cr_Interface.UseVisualStyleBackColor = true;
            this.B_Cr_Interface.Click += new System.EventHandler(this.B_Cr_Interface_Click);
            // 
            // P_L_Interface
            // 
            this.P_L_Interface.Controls.Add(this.L_Interface);
            this.P_L_Interface.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_Interface.Location = new System.Drawing.Point(3, 78);
            this.P_L_Interface.Name = "P_L_Interface";
            this.P_L_Interface.Size = new System.Drawing.Size(613, 75);
            this.P_L_Interface.TabIndex = 5;
            this.P_L_Interface.Resize += new System.EventHandler(this.P_L_Interface_Resize);
            // 
            // L_Interface
            // 
            this.L_Interface.AutoSize = true;
            this.L_Interface.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_Interface.Location = new System.Drawing.Point(229, 18);
            this.L_Interface.Name = "L_Interface";
            this.L_Interface.Size = new System.Drawing.Size(140, 37);
            this.L_Interface.TabIndex = 0;
            this.L_Interface.Text = "Interface";
            // 
            // P_L_In_Router
            // 
            this.P_L_In_Router.Controls.Add(this.L_In_Router);
            this.P_L_In_Router.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_In_Router.Location = new System.Drawing.Point(3, 3);
            this.P_L_In_Router.Name = "P_L_In_Router";
            this.P_L_In_Router.Size = new System.Drawing.Size(613, 75);
            this.P_L_In_Router.TabIndex = 4;
            this.P_L_In_Router.Resize += new System.EventHandler(this.P_L_In_Router_Resize);
            // 
            // L_In_Router
            // 
            this.L_In_Router.AutoSize = true;
            this.L_In_Router.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.L_In_Router.Location = new System.Drawing.Point(229, 18);
            this.L_In_Router.Name = "L_In_Router";
            this.L_In_Router.Size = new System.Drawing.Size(112, 37);
            this.L_In_Router.TabIndex = 0;
            this.L_In_Router.Text = "Router";
            // 
            // RulePage
            // 
            this.RulePage.Controls.Add(this.P_DGV_Rule);
            this.RulePage.Controls.Add(this.P_B_Cr_Del_Rule);
            this.RulePage.Controls.Add(this.P_L_Rule);
            this.RulePage.Location = new System.Drawing.Point(4, 5);
            this.RulePage.Name = "RulePage";
            this.RulePage.Padding = new System.Windows.Forms.Padding(3);
            this.RulePage.Size = new System.Drawing.Size(619, 492);
            this.RulePage.TabIndex = 14;
            this.RulePage.Text = "tabPage1";
            this.RulePage.UseVisualStyleBackColor = true;
            // 
            // P_DGV_Rule
            // 
            this.P_DGV_Rule.Controls.Add(this.DGV_Rule);
            this.P_DGV_Rule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.P_DGV_Rule.Location = new System.Drawing.Point(3, 153);
            this.P_DGV_Rule.Name = "P_DGV_Rule";
            this.P_DGV_Rule.Size = new System.Drawing.Size(613, 336);
            this.P_DGV_Rule.TabIndex = 8;
            // 
            // DGV_Rule
            // 
            this.DGV_Rule.BackgroundColor = System.Drawing.Color.White;
            this.DGV_Rule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Rule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Ru_Col_Select,
            this.Ru_Col_Direction,
            this.Ru_Col_Etype,
            this.Ru_Col_Protocol,
            this.Ru_Col_PR,
            this.Ru_Col_RIPP,
            this.Ru_Col_RSG,
            this.Ru_Col_Description});
            this.DGV_Rule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Rule.Location = new System.Drawing.Point(0, 0);
            this.DGV_Rule.Name = "DGV_Rule";
            this.DGV_Rule.Size = new System.Drawing.Size(613, 336);
            this.DGV_Rule.TabIndex = 0;
            // 
            // Ru_Col_Select
            // 
            this.Ru_Col_Select.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ru_Col_Select.Frozen = true;
            this.Ru_Col_Select.HeaderText = "Select";
            this.Ru_Col_Select.Name = "Ru_Col_Select";
            this.Ru_Col_Select.Width = 43;
            // 
            // Ru_Col_Direction
            // 
            this.Ru_Col_Direction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Ru_Col_Direction.DefaultCellStyle = dataGridViewCellStyle4;
            this.Ru_Col_Direction.HeaderText = "Direction";
            this.Ru_Col_Direction.Name = "Ru_Col_Direction";
            this.Ru_Col_Direction.ReadOnly = true;
            this.Ru_Col_Direction.Width = 74;
            // 
            // Ru_Col_Etype
            // 
            this.Ru_Col_Etype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ru_Col_Etype.HeaderText = "Ether Type";
            this.Ru_Col_Etype.Name = "Ru_Col_Etype";
            this.Ru_Col_Etype.ReadOnly = true;
            this.Ru_Col_Etype.Width = 78;
            // 
            // Ru_Col_Protocol
            // 
            this.Ru_Col_Protocol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ru_Col_Protocol.HeaderText = "IP Protocol";
            this.Ru_Col_Protocol.Name = "Ru_Col_Protocol";
            this.Ru_Col_Protocol.ReadOnly = true;
            this.Ru_Col_Protocol.Width = 78;
            // 
            // Ru_Col_PR
            // 
            this.Ru_Col_PR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ru_Col_PR.HeaderText = "Port Range";
            this.Ru_Col_PR.Name = "Ru_Col_PR";
            this.Ru_Col_PR.ReadOnly = true;
            this.Ru_Col_PR.Width = 79;
            // 
            // Ru_Col_RIPP
            // 
            this.Ru_Col_RIPP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ru_Col_RIPP.HeaderText = "Remote IP Prefix";
            this.Ru_Col_RIPP.Name = "Ru_Col_RIPP";
            this.Ru_Col_RIPP.Width = 79;
            // 
            // Ru_Col_RSG
            // 
            this.Ru_Col_RSG.HeaderText = "Remote Security Group";
            this.Ru_Col_RSG.Name = "Ru_Col_RSG";
            // 
            // Ru_Col_Description
            // 
            this.Ru_Col_Description.HeaderText = "Description";
            this.Ru_Col_Description.Name = "Ru_Col_Description";
            // 
            // P_B_Cr_Del_Rule
            // 
            this.P_B_Cr_Del_Rule.Controls.Add(this.B_Del_Rule);
            this.P_B_Cr_Del_Rule.Controls.Add(this.B_Cr_Rule);
            this.P_B_Cr_Del_Rule.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_B_Cr_Del_Rule.Location = new System.Drawing.Point(3, 78);
            this.P_B_Cr_Del_Rule.Name = "P_B_Cr_Del_Rule";
            this.P_B_Cr_Del_Rule.Size = new System.Drawing.Size(613, 75);
            this.P_B_Cr_Del_Rule.TabIndex = 7;
            this.P_B_Cr_Del_Rule.Resize += new System.EventHandler(this.P_B_Cr_Del_Rule_Resize);
            // 
            // B_Del_Rule
            // 
            this.B_Del_Rule.Location = new System.Drawing.Point(516, 18);
            this.B_Del_Rule.Name = "B_Del_Rule";
            this.B_Del_Rule.Size = new System.Drawing.Size(80, 35);
            this.B_Del_Rule.TabIndex = 2;
            this.B_Del_Rule.Text = "Delete";
            this.B_Del_Rule.UseVisualStyleBackColor = true;
            this.B_Del_Rule.Click += new System.EventHandler(this.B_Del_Rule_Click);
            // 
            // B_Cr_Rule
            // 
            this.B_Cr_Rule.Location = new System.Drawing.Point(416, 18);
            this.B_Cr_Rule.Name = "B_Cr_Rule";
            this.B_Cr_Rule.Size = new System.Drawing.Size(80, 35);
            this.B_Cr_Rule.TabIndex = 1;
            this.B_Cr_Rule.Text = "Create";
            this.B_Cr_Rule.UseVisualStyleBackColor = true;
            this.B_Cr_Rule.Click += new System.EventHandler(this.B_Cr_Rule_Click);
            // 
            // P_L_Rule
            // 
            this.P_L_Rule.Controls.Add(this.L_Rule);
            this.P_L_Rule.Dock = System.Windows.Forms.DockStyle.Top;
            this.P_L_Rule.Location = new System.Drawing.Point(3, 3);
            this.P_L_Rule.Name = "P_L_Rule";
            this.P_L_Rule.Size = new System.Drawing.Size(613, 75);
            this.P_L_Rule.TabIndex = 5;
            this.P_L_Rule.Resize += new System.EventHandler(this.P_L_Rule_Resize);
            // 
            // L_Rule
            // 
            this.L_Rule.AutoSize = true;
            this.L_Rule.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.L_Rule.Location = new System.Drawing.Point(196, 29);
            this.L_Rule.Name = "L_Rule";
            this.L_Rule.Size = new System.Drawing.Size(226, 20);
            this.L_Rule.TabIndex = 0;
            this.L_Rule.Text = "Manage Security Group Rules:";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.SplitContainer);
            this.Name = "Main";
            this.Text = "Main";
            this.SplitContainer.Panel1.ResumeLayout(false);
            this.SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.PageControl.ResumeLayout(false);
            this.TokenPage.ResumeLayout(false);
            this.P_RTB_Token.ResumeLayout(false);
            this.P_B_Token.ResumeLayout(false);
            this.P_L_Token.ResumeLayout(false);
            this.P_L_Token.PerformLayout();
            this.FlavorPage.ResumeLayout(false);
            this.P_DGV_Flavor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Flavor)).EndInit();
            this.P_L_Flavor.ResumeLayout(false);
            this.P_L_Flavor.PerformLayout();
            this.ImagePage.ResumeLayout(false);
            this.P_DGV_Image.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Image)).EndInit();
            this.P_L_Image.ResumeLayout(false);
            this.P_L_Image.PerformLayout();
            this.InstancePage.ResumeLayout(false);
            this.P_DGV_Instances.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Instances)).EndInit();
            this.P_B_Cr_Del_Instances.ResumeLayout(false);
            this.P_L_Instances.ResumeLayout(false);
            this.P_L_Instances.PerformLayout();
            this.KeyPairPage.ResumeLayout(false);
            this.P_DGV_KeyPair.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_KeyPair)).EndInit();
            this.P_B_Cr_Im_De_KeyPair.ResumeLayout(false);
            this.P_L_KeyPair.ResumeLayout(false);
            this.P_L_KeyPair.PerformLayout();
            this.VolumePage.ResumeLayout(false);
            this.P_DGV_Volume.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Volume)).EndInit();
            this.P_B_Cr_De_Volume.ResumeLayout(false);
            this.P_L_Volume.ResumeLayout(false);
            this.P_L_Volume.PerformLayout();
            this.NetworkPage.ResumeLayout(false);
            this.P_DGV_Net.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Net)).EndInit();
            this.P_B_Cr_Del_Net.ResumeLayout(false);
            this.P_L_Networks.ResumeLayout(false);
            this.P_L_Networks.PerformLayout();
            this.RouterPage.ResumeLayout(false);
            this.P_DGV_Routers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Routers)).EndInit();
            this.P_B_Cr_Del_Routers.ResumeLayout(false);
            this.P_L_Routers.ResumeLayout(false);
            this.P_L_Routers.PerformLayout();
            this.SecurityGroupPage.ResumeLayout(false);
            this.P_DGV_SecurityGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SecurityGroup)).EndInit();
            this.P_B_Cr_Del_SecurityGroup.ResumeLayout(false);
            this.P_L_SecurityGroup.ResumeLayout(false);
            this.P_L_SecurityGroup.PerformLayout();
            this.FloatingIPPage.ResumeLayout(false);
            this.P_DGV_FlIP.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_FlIP)).EndInit();
            this.P_B_Al_Re_IP.ResumeLayout(false);
            this.P_L_IP.ResumeLayout(false);
            this.P_L_IP.PerformLayout();
            this.LoadBalancerPage.ResumeLayout(false);
            this.P_DGV_LoadBalancer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_LoadBalancer)).EndInit();
            this.P_B_Cr_Del_LoadBalancer.ResumeLayout(false);
            this.P_L_LoadBalancer.ResumeLayout(false);
            this.P_L_LoadBalancer.PerformLayout();
            this.SubnetPage.ResumeLayout(false);
            this.P_DGV_Subnets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Subnets)).EndInit();
            this.P_B_Cr_Del_Subnets.ResumeLayout(false);
            this.P_L_Subnet.ResumeLayout(false);
            this.P_L_Subnet.PerformLayout();
            this.P_L_Sub_Networks.ResumeLayout(false);
            this.P_L_Sub_Networks.PerformLayout();
            this.RouterInterfacePage.ResumeLayout(false);
            this.P_DGV_Interface.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Interface)).EndInit();
            this.P_B_Cr_Del_Interface.ResumeLayout(false);
            this.P_L_Interface.ResumeLayout(false);
            this.P_L_Interface.PerformLayout();
            this.P_L_In_Router.ResumeLayout(false);
            this.P_L_In_Router.PerformLayout();
            this.RulePage.ResumeLayout(false);
            this.P_DGV_Rule.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Rule)).EndInit();
            this.P_B_Cr_Del_Rule.ResumeLayout(false);
            this.P_L_Rule.ResumeLayout(false);
            this.P_L_Rule.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.TabControl PageControl;
        private System.Windows.Forms.TabPage TokenPage;
        private System.Windows.Forms.TabPage FlavorPage;
        private TreeView TrView_Menu;
        private TabPage ImagePage;
        private TabPage InstancePage;
        private TabPage KeyPairPage;
        private TabPage VolumePage;
        private TabPage NetworkPage;
        private TabPage RouterPage;
        private TabPage SecurityGroupPage;
        private TabPage FloatingIPPage;
        private TabPage LoadBalancerPage;
        private Button B_CNToken;
        private RichTextBox RTB_Token;
        private Panel P_RTB_Token;
        private Panel P_B_Token;
        private Panel P_L_Token;
        private Label L_Token;
        private TabPage Page0;
        private Panel P_DGV_Flavor;
        private DataGridView DGV_Flavor;
        private Panel P_L_Flavor;
        private Label L_Flavor;
        private Panel P_DGV_Image;
        private DataGridView DGV_Image;
        private Panel P_L_Image;
        private Label L_Image;
        private Panel P_DGV_KeyPair;
        private DataGridView DGV_KeyPair;
        private Panel P_B_Cr_Im_De_KeyPair;
        private Panel P_L_KeyPair;
        private Button B_Delete_KeyPair;
        private Button B_Import_KeyPair;
        private Button B_Create_KeyPair;
        private Label L_KeyPair;
        private Panel P_DGV_Volume;
        private DataGridView DGV_Volume;
        private Panel P_B_Cr_De_Volume;
        private Button B_Delete_Volume;
        private Button B_Create_Volume;
        private Panel P_L_Volume;
        private Label L_Volume;
        private Panel P_DGV_FlIP;
        private DataGridView DGV_FlIP;
        private Panel P_B_Al_Re_IP;
        private Button B_ReleaseIP;
        private Button B_AllocateIP;
        private Panel P_L_IP;
        private Label L_FloatingIP;
        private DataGridViewCheckBoxColumn FlIP_Col_Select;
        private DataGridViewTextBoxColumn FlIP_Col_IPAddress;
        private DataGridViewTextBoxColumn FlIP_Col_Description;
        private DataGridViewTextBoxColumn FlIP_Col_DNSName;
        private DataGridViewTextBoxColumn FlIP_Col_DNSDomain;
        private DataGridViewTextBoxColumn FlIP_Col_MapIP;
        private DataGridViewTextBoxColumn FlIP_Col_Pool;
        private DataGridViewTextBoxColumn FlIP_Col_Status;
        private Panel P_DGV_Net;
        private DataGridView DGV_Net;
        private Panel P_B_Cr_Del_Net;
        private Button B_Del_Net;
        private Button B_Cr_Net;
        private Panel P_L_Networks;
        private Label L_Networks;
        private Panel P_DGV_Instances;
        private DataGridView DGV_Instances;
        private Panel P_B_Cr_Del_Instances;
        private Button B_Del_Instances;
        private Button B_Cr_Instances;
        private Panel P_L_Instances;
        private Label L_Instances;
        private Panel P_DGV_Routers;
        private DataGridView DGV_Routers;
        private Panel P_B_Cr_Del_Routers;
        private Button B_Del_Routers;
        private Button B_Cr_Routers;
        private Panel P_L_Routers;
        private Label L_Routers;
        private Panel P_DGV_SecurityGroup;
        private DataGridView DGV_SecurityGroup;
        private Panel P_B_Cr_Del_SecurityGroup;
        private Button B_Del_SecurityGroup;
        private Button B_Cr_SecurityGroup;
        private Panel P_L_SecurityGroup;
        private Label L_SecurityGroup;
        private Panel P_DGV_LoadBalancer;
        private DataGridView DGV_LoadBalancer;
        private Panel P_B_Cr_Del_LoadBalancer;
        private Button B_Del_LoadBalancer;
        private Button B_Cr_LoadBalancer;
        private Panel P_L_LoadBalancer;
        private Label L_LoadBalancer;
        private DataGridViewCheckBoxColumn Net_Col_Select;
        private DataGridViewTextBoxColumn Net_Col_Name;
        private DataGridViewTextBoxColumn Net_Col_SubnetsAssociated;
        private DataGridViewTextBoxColumn Net_Col_Shared;
        private DataGridViewTextBoxColumn Net_Col_External;
        private DataGridViewTextBoxColumn Net_Col_Status;
        private DataGridViewTextBoxColumn Net_Col_AdminState;
        private DataGridViewTextBoxColumn Net_Col_AvailabilityZones;
        private TabPage SubnetPage;
        private Panel P_DGV_Subnets;
        private DataGridView DGV_Subnets;
        private Panel P_B_Cr_Del_Subnets;
        private Button B_Del_Subnets;
        private Button B_Cr_Subnets;
        private Panel P_L_Subnet;
        private Label L_Subnet;
        private Panel P_L_Sub_Networks;
        private Label L_Sub_Networks;
        private DataGridViewTextBoxColumn Fl_Col_Name;
        private DataGridViewTextBoxColumn Fl_Col_RAM;
        private DataGridViewTextBoxColumn Fl_Col_Disk;
        private DataGridViewTextBoxColumn Fl_Col_VCPU;
        private DataGridViewTextBoxColumn Im_Col_Name;
        private DataGridViewTextBoxColumn Im_Col_Status;
        private DataGridViewTextBoxColumn Im_Col_MinRAM;
        private DataGridViewTextBoxColumn Im_Col_MinDisk;
        private DataGridViewTextBoxColumn Im_Col_Visibility;
        private DataGridViewTextBoxColumn Im_Col_Protected;
        private DataGridViewTextBoxColumn Im_Col_Checksum;
        private DataGridViewTextBoxColumn Im_Col_Size;
        private DataGridViewTextBoxColumn Im_Col_DiskFormat;
        private DataGridViewTextBoxColumn Im_Col_ContainerFormat;
        private DataGridViewTextBoxColumn Im_Col_Owner;
        private DataGridViewTextBoxColumn Im_Col_Description;
        private DataGridViewCheckBoxColumn In_Col_Select;
        private DataGridViewTextBoxColumn In_Col_Inname;
        private DataGridViewTextBoxColumn In_Col_Imname;
        private DataGridViewTextBoxColumn In_Col_IP;
        private DataGridViewTextBoxColumn In_Col_Flavor;
        private DataGridViewTextBoxColumn In_Col_KeyPair;
        private DataGridViewTextBoxColumn In_Col_Status;
        private DataGridViewTextBoxColumn In_Col_AZ;
        private DataGridViewTextBoxColumn In_Col_Task;
        private DataGridViewTextBoxColumn In_Col_PS;
        private DataGridViewTextBoxColumn In_Col_Age;
        private DataGridViewCheckBoxColumn KP_Col_Select;
        private DataGridViewTextBoxColumn KP_Col_Name;
        private DataGridViewTextBoxColumn KP_Col_Type;
        private DataGridViewTextBoxColumn KP_Col_FP;
        private DataGridViewCheckBoxColumn VL_Col_Select;
        private DataGridViewTextBoxColumn VL_Col_Name;
        private DataGridViewTextBoxColumn VL_Col_Description;
        private DataGridViewTextBoxColumn VL_Col_Size;
        private DataGridViewTextBoxColumn VL_Col_Status;
        private DataGridViewTextBoxColumn VL_Col_Group;
        private DataGridViewTextBoxColumn VL_Col_Type;
        private DataGridViewTextBoxColumn VL_Col_AT;
        private DataGridViewTextBoxColumn VL_Col_AZ;
        private DataGridViewTextBoxColumn VL_Col_Boot;
        private DataGridViewTextBoxColumn VL_Col_En;
        private DataGridViewCheckBoxColumn RT_Col_Select;
        private DataGridViewTextBoxColumn RT_Col_Name;
        private DataGridViewTextBoxColumn RT_Col_Status;
        private DataGridViewTextBoxColumn RT_Col_ExNet;
        private DataGridViewTextBoxColumn RT_Col_AS;
        private DataGridViewTextBoxColumn RT_Col_AZ;
        private DataGridViewCheckBoxColumn SG_Col_Select;
        private DataGridViewTextBoxColumn SG_Col_Name;
        private DataGridViewTextBoxColumn SG_Col_SGID;
        private DataGridViewTextBoxColumn SG_Col_Description;
        private DataGridViewTextBoxColumn SG_Col_Shared;
        private DataGridViewCheckBoxColumn LB_Col_Select;
        private DataGridViewTextBoxColumn LB_Col_Name;
        private DataGridViewTextBoxColumn LB_Col_IP;
        private DataGridViewTextBoxColumn LB_Col_AZ;
        private DataGridViewTextBoxColumn LB_Col_OS;
        private DataGridViewTextBoxColumn LB_Col_PS;
        private DataGridViewTextBoxColumn LB_Col_ASU;
        private DataGridViewCheckBoxColumn Sub_Col_Select;
        private DataGridViewTextBoxColumn Sub_Col_Name;
        private DataGridViewTextBoxColumn Sub_Col_NetAddress;
        private DataGridViewTextBoxColumn Sub_Col_IPver;
        private DataGridViewTextBoxColumn Sub_Col_GateIP;
        private TabPage RouterInterfacePage;
        private Panel P_DGV_Interface;
        private DataGridView DGV_Interface;
        private DataGridViewCheckBoxColumn RI_Col_Select;
        private DataGridViewTextBoxColumn RI_Col_Name;
        private DataGridViewTextBoxColumn RI_Col_FixIP;
        private DataGridViewTextBoxColumn RI_Col_Status;
        private DataGridViewTextBoxColumn RI_Col_Type;
        private DataGridViewTextBoxColumn RI_Col_AS;
        private Panel P_B_Cr_Del_Interface;
        private Button B_Del_Interface;
        private Button B_Cr_Interface;
        private Panel P_L_Interface;
        private Label L_Interface;
        private Panel P_L_In_Router;
        private Label L_In_Router;
        private TabPage RulePage;
        private Panel P_DGV_Rule;
        private DataGridView DGV_Rule;
        private Panel P_B_Cr_Del_Rule;
        private Button B_Del_Rule;
        private Button B_Cr_Rule;
        private Panel P_L_Rule;
        private Label L_Rule;
        private DataGridViewCheckBoxColumn Ru_Col_Select;
        private DataGridViewTextBoxColumn Ru_Col_Direction;
        private DataGridViewTextBoxColumn Ru_Col_Etype;
        private DataGridViewTextBoxColumn Ru_Col_Protocol;
        private DataGridViewTextBoxColumn Ru_Col_PR;
        private DataGridViewTextBoxColumn Ru_Col_RIPP;
        private DataGridViewTextBoxColumn Ru_Col_RSG;
        private DataGridViewTextBoxColumn Ru_Col_Description;
    }
}