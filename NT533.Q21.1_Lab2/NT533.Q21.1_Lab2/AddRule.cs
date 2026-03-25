using NT533.Q21._1_Lab2.Network;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NT533.Q21._1_Lab2.Network.SecurityGroupService;

namespace NT533.Q21._1_Lab2
{
    public partial class AddRule : Form
    {
        List<SecurityGroup> _securityGroups;
        string _securityname;
        string _securityid;
        public bool Result { get; private set; }
        internal AddRule(List<SecurityGroup> securityGroups,string securityname,string securityid)
        {
            _securityGroups = securityGroups;
            _securityname = securityname;
            _securityid = securityid;
            InitializeComponent();
            cB_Rule.SelectedIndex = 0;
            cB_Direction.SelectedIndex = 0;
            cB_EType.SelectedIndex = 0;
            cB_OpenPort.SelectedIndex = 0;
            cB_Remote.SelectedIndex = 0;
            LoadComboBoxSecGroup();
            
        }
        private void LoadComboBoxSecGroup()
        {
            foreach (SecurityGroup securityGroup in _securityGroups)
            {
                cB_SecGroup.Items.Add(securityGroup.name);
            }
            cB_SecGroup.SelectedIndex = 0;
        }

        private void cB_Rule_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cB_Rule.SelectedIndex;
            switch (index)
            {
                case 0:
                    tabControlFullPort.SelectedTab = tabControlAllPort;
                    L_Direction.Visible = true;
                    cB_Direction.Visible = true;
                    break;
                case 1:
                    tabControlFullPort.SelectedTab = tabControlAllPort;
                    L_Direction.Visible = true;
                    cB_Direction.Visible = true;
                    break;
                case 2:
                    tabControlFullPort.SelectedTab = CodePage;
                    L_Direction.Visible = true;
                    cB_Direction.Visible = true;
                    break;
                case 3:
                    tabControlFullPort.SelectedTab = ProtocolPage;
                    L_Direction.Visible = true;
                    cB_Direction.Visible = true;
                    break;
                case 4:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = true;
                    cB_Direction.Visible = true;
                    break;
                case 5:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = true;
                    cB_Direction.Visible = true;
                    break;
                case 6:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = true;
                    cB_Direction.Visible = true;
                    break;
                case 7:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 8:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 9:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 10:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 11:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 12:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 13:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 14:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 15:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 16:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 17:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 18:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 19:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
                case 20:
                    tabControlFullPort.SelectedTab = Page0;
                    L_Direction.Visible = false;
                    cB_Direction.Visible = false;
                    break;
            }
        }

        private void cB_Remote_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cB_Remote.SelectedIndex;
            switch (index)
            {
                case 0:
                    tabControlRemote.SelectedTab= CIDRPage;
                    break;
                case 1:
                    tabControlRemote.SelectedTab = SecGroupPage;
                    break;
            }
        }

        private void cB_OpenPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cB_OpenPort.SelectedIndex;
            switch (index)
            {
                case 0:
                    tabControlPort.SelectedTab = PortPage;
                    break;
                case 1:
                    tabControlPort.SelectedTab = FrToPortPage;
                    break;
                case 2:
                    tabControlPort.SelectedTab = Page1;
                    break;
            }
        }

        private async void B_AddRule_Click(object sender, EventArgs e)
        {
            string direction = "Ingress";
            string protocol = "TCP";
            string ethertype = "IPv4";
            string port_range_max = null;
            string port_range_min = null;
            string description = null;
            string remote_group_id = null;
            string remote_ip_prefix = null;
            int index = cB_Rule.SelectedIndex;
            switch (index)
            {
                case 0:
                    description = rtb_Description.Text;
                    direction = cB_Direction.SelectedItem.ToString();
                    if (cB_OpenPort.SelectedIndex == 0)
                    {
                        if (string.IsNullOrEmpty(tb_Port.Text) || int.Parse(tb_Port.Text) < 1 || int.Parse(tb_Port.Text) > 65535)
                        {
                            MessageBox.Show("Nhập giá trị Port không hợp lệ. Xin vui lòng nhập từ 1 đến 65535");
                            return;
                        }
                        else
                        {
                            port_range_max = port_range_min = tb_Port.Text;
                        }
                    }
                    else if (cB_OpenPort.SelectedIndex == 1)
                    {
                        if (string.IsNullOrEmpty(tb_FromPort.Text) || int.Parse(tb_FromPort.Text) < 1 || int.Parse(tb_FromPort.Text) > 65535)
                        {
                            MessageBox.Show("Nhập giá trị From Port không hợp lệ. Xin vui lòng nhập từ 1 đến 65535");
                            return;
                        }
                        else
                        {
                            port_range_min = tb_FromPort.Text;
                        }
                        if (string.IsNullOrEmpty(tb_ToPort.Text) || int.Parse(tb_ToPort.Text) < 1 || int.Parse(tb_ToPort.Text) > 65535)
                        {
                            MessageBox.Show("Nhập giá trị To Port không hợp lệ. Xin vui lòng nhập từ 1 đến 65535");
                            return;
                        }
                        else
                        {
                            port_range_max = tb_ToPort.Text;
                        }
                    }
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 1:
                    description = rtb_Description.Text;
                    direction = cB_Direction.SelectedItem.ToString();
                    protocol = "UDP";
                    if(cB_OpenPort.SelectedIndex == 0)
                    {
                        if (string.IsNullOrEmpty(tb_Port.Text) || int.Parse(tb_Port.Text) < 1 || int.Parse(tb_Port.Text) > 65535)
                        {
                            MessageBox.Show("Nhập giá trị Port không hợp lệ. Xin vui lòng nhập từ 1 đến 65535");
                            return;
                        }
                        else
                        {
                            port_range_max = port_range_min = tb_Port.Text;
                        }
                    }
                    else if(cB_OpenPort.SelectedIndex ==1)
                    {
                        if (string.IsNullOrEmpty(tb_FromPort.Text) || int.Parse(tb_FromPort.Text) < 1 || int.Parse(tb_FromPort.Text) > 65535)
                        {
                            MessageBox.Show("Nhập giá trị From Port không hợp lệ. Xin vui lòng nhập từ 1 đến 65535");
                            return;
                        }
                        else
                        {
                            port_range_min = tb_FromPort.Text;
                        }
                        if (string.IsNullOrEmpty(tb_ToPort.Text) || int.Parse(tb_ToPort.Text) < 1 || int.Parse(tb_ToPort.Text) > 65535)
                        {
                            MessageBox.Show("Nhập giá trị To Port không hợp lệ. Xin vui lòng nhập từ 1 đến 65535");
                            return;
                        }
                        else
                        {
                            port_range_max = tb_ToPort.Text;
                        }
                    }
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 2:
                    description = rtb_Description.Text;
                    direction = cB_Direction.SelectedItem.ToString();
                    protocol = "ICMP";
                    if (!string.IsNullOrEmpty(tb_Type.Text)&&(int.Parse(tb_Type.Text) < -1 || int.Parse(tb_Type.Text) > 255))
                    {
                        MessageBox.Show("Nhập giá trị Type không hợp lệ. Xin vui lòng nhập từ -1 đến 255");
                        return;
                    }
                    else
                    {
                        port_range_min = tb_Type.Text == "" ? null : tb_Type.Text;
                    }
                    if (!string.IsNullOrEmpty(tb_Code.Text) && (int.Parse(tb_Code.Text) < -1 || int.Parse(tb_Code.Text) > 255))
                    {
                        MessageBox.Show("Nhập giá trị Code không hợp lệ. Xin vui lòng nhập từ -1 đến 255");
                        return;
                    }
                    else
                    {
                        port_range_max = tb_Code.Text == "" ? null : tb_Code.Text;
                    }

                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 3:
                    description = rtb_Description.Text;
                    direction = cB_Direction.SelectedItem.ToString();
                    if(string.IsNullOrEmpty(tb_Protocol.Text)||int.Parse(tb_Protocol.Text)<-1||int.Parse(tb_Protocol.Text)>255)
                    {
                        MessageBox.Show("Nhập giá trị IP Protocol không hợp lệ. Xin vui lòng nhập từ -1 đến 255");
                        return;
                    }
                    else
                    {
                        protocol = tb_Protocol.Text;
                    }
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 4:
                    description = rtb_Description.Text;
                    direction = cB_Direction.SelectedItem.ToString();
                    protocol = "ICMP";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 5:
                    description = rtb_Description.Text;
                    direction = cB_Direction.SelectedItem.ToString();
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 6:
                    description = rtb_Description.Text;
                    direction = cB_Direction.SelectedItem.ToString();
                    protocol = "UDP";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 7:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "53";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id; 
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 8:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "80";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 9:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "443";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 10:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "143";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 11:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "993";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 12:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "389";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 13:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "1433";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 14:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "3306";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 15:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "110";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 16:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "995";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 17:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "3389";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 18:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "25";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 19:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "465";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
                case 20:
                    description = rtb_Description.Text;
                    port_range_max = port_range_min = "22";
                    if (cB_Remote.SelectedIndex == 1)
                    {
                        int selectsecindex = cB_SecGroup.SelectedIndex;
                        remote_group_id = _securityGroups[selectsecindex].id;
                        ethertype = cB_EType.SelectedItem.ToString();
                    }
                    else
                    {
                        remote_ip_prefix = tb_CIDR.Text;
                    }
                    break;
            }
            RuleService ruleService = new RuleService();
            var result = await ruleService.PostRuleAsync(Main._token, _securityid, direction, ethertype, protocol, port_range_min, port_range_max, description, remote_group_id, remote_ip_prefix);
            if (result.Item1)
            {
                Result = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo Rule thất bại!\n" + result.Item2);
            }
        }

        private void B_CancelRule_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
