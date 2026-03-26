using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Compute;
using NT533.Q21._1_Lab2.Network;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NT533.Q21._1_Lab2.Compute.InstanceService;
using static NT533.Q21._1_Lab2.Compute.PortService;
using static NT533.Q21._1_Lab2.Network.NetworkService;
using static NT533.Q21._1_Lab2.Network.SubnetService;
using static NT533.Q21._1_Lab2.Volume.AvailabilityZoneService;

namespace NT533.Q21._1_Lab2
{
    public partial class CreateLoadBalancer : Form
    {
        #region Fields
        public bool Result { get; private set; }
        private string currentpage;
        private List<(string id, string name)> subnets = new List<(string id, string name)>();
        private (string lbname, string lbip, string lbdes, int lbsubnetindex, bool ASUp) _lbdetailpage = (null,null,null,0,true);
        private (bool crlis, string lisname, string lisdes, int lisprotoindex, string lisport, string lisclienttimeout, string listcptimeout, string lismemcontimeout, string lismemtimeout,string lisconlimit, string liscidr,bool lisxforwfor, bool lisxforwport, bool lisxforwforproto,bool lisASUp) _lblispage = (true, null, null, 0, "80", "50000", "0", "5000", "50000","-1","0.0.0.0/0",false,false,false,true);
        private (bool crpool, string poolname, string pooldes, int poolalgorithmindex, int poolsessionindex, string poolcookiename, bool pooltls, bool poolasup) _lbpoolpage = (true, null, null, 0, 0, null, false, true);
        private List<PoolMem> _lbpoolmem = new List<PoolMem>();
        private (bool crmon, string monname, int montypeindex, string monmaxtrydown, string mondelay, string monmaxtry, string montimeout, int monmethodindex, string moncodes, string monurl, bool asup) _lbmonpage = (true,null,0,"3","5","3","5",0,"200","/",true);

        #endregion
        class PoolMem
        {
            public string Id { get; set; }
            public string Name { get; set; }

            public List<string> IpList { get; set; } = new List<string>(); // cho combobox
            public string SelectedIP { get; set; } // IP đang chọn

            public string DisplayIP { get; set; } // cột 3 (ip hiển thị)
            public string Subnet { get; set; }
            public string SubId { get; set; }
            public string Port { get; set; }

            public int Weight { get; set; }
            public int STT { get; set; }
        }
        public CreateLoadBalancer()
        {
            InitializeComponent();
            B_LB_Details_Click(null, null);
            LoadAllowUserToAddRows();
        }
        //SavePage
        #region SavePage
        private void SavePage()
        {
            switch (currentpage)
            {
                case "LBDetailsPage":
                    SaveLBDetailsPage();
                    break;
                case "LisDetailsPage":
                    SaveLisDetailsPage();
                    break;
                case "PoolDetailsPage":
                    SavePoolDetailsPage();
                    break;
                case "PoolMemPage":
                    SavePoolMemPage();
                    break;
                case "MonDetailsPage":
                    SaveMonDetailsPage();
                    break;
            }
        }
        private void SaveLBDetailsPage()
        {
            string lbname = tb_LB_Name.Text;
            string lbipaddress = tb_LB_IP.Text;
            string lbdes = tb_LB_Description.Text;

            int lbsubnetindex = cB_LB_Subnet.SelectedIndex;
            bool asup = B_LB_AS_Yes.BackColor == Color.Silver;

            _lbdetailpage = (lbname,lbipaddress,lbdes, lbsubnetindex,asup);
        }
        private void SaveLisDetailsPage()
        {
            bool crlis = B_Cr_Lis_Yes.BackColor == Color.Silver;
            string lisname = tb_Lis_Name.Text;
            string lisdes = tb_Lis_Des.Text;
            int lisprotoindex = cob_Lis_Proto.SelectedIndex;
            string port = tb_Lis_Port.Text;
            string clienttimeout = tb_Lis_ClientTimeout.Text;
            string tcptimeout = tb_Lis_TCPTimeout.Text;
            string memcontimeout = tb_Lis_Mem_Con_Timeout.Text;
            string memtimeout = tb_Lis_Mem_Timeout.Text;
            string conlimit = tb_Lis_Con_Limit.Text;
            string liscidr = tb_Lis_Allow_cidr.Text;
            bool lisxforwfor = cb_Lis_XForwFor.Checked;
            bool lisxforwport = cb_Lis_XForwPort.Checked;
            bool lisxforwproto = cb_Lis_XForwProto.Checked;
            bool lisasup = B_Lis_ASUp_Yes.BackColor == Color.Silver;

            _lblispage = (crlis, lisname, lisdes,
            lisprotoindex,port,clienttimeout,
            tcptimeout,memcontimeout,memtimeout,
            conlimit,liscidr,lisxforwfor,
            lisxforwport,lisxforwproto,lisasup);

        }
        private void SavePoolDetailsPage()
        {
            bool crpool = B_Cr_Pool_Yes.BackColor == Color.Silver;
            string poolname = tb_Pool_Name.Text;
            string pooldes = tb_Pool_Des.Text;
            int poolalgorithm = cob_Pool_Algorithm.SelectedIndex;
            int poolsession = cob_Pool_Session.SelectedIndex;
            string poolcookiename = tb_Pool_Cookie_Name.Text;
            bool pooltls = B_Pool_TLFEn_Yes.BackColor == Color.Silver;
            bool poolasup = B_Pool_ASUp_Yes.BackColor == Color.Silver;


        }
        private void SavePoolMemPage()
        {
            _lbpoolmem.Clear();

            foreach (DataGridViewRow row in DGV_Choosed_PoolMem.Rows)
            {
                if (row.IsNewRow) continue;

                List<string> ipList = new List<string>();
                string selectedIP = "";

                // Cột 2 là ComboBox
                if (row.Cells[2] is DataGridViewComboBoxCell cb)
                {
                    if (cb.DataSource is List<string> list)
                    {
                        ipList = list;
                    }

                    selectedIP = cb.Value?.ToString();
                }

                var item = new PoolMem
                {
                    Id = row.Cells[0].Value?.ToString(),
                    Name = row.Cells[1].Value?.ToString(),

                    IpList = ipList,
                    SelectedIP = selectedIP,

                    DisplayIP = row.Cells[3].Value?.ToString(),
                    Subnet = row.Cells[4].Value?.ToString(),
                    SubId = row.Cells[5].Value?.ToString(),
                    Port = row.Cells[6].Value?.ToString(),

                    Weight = int.TryParse(row.Cells[7].Value?.ToString(), out int w) ? w : 0,
                    STT = int.TryParse(row.Cells[8].Value?.ToString(), out int s) ? s : 0
                };

                _lbpoolmem.Add(item);
            }
        }
        private void SaveMonDetailsPage()
        {

        }
        #endregion
        //SetAllowUserToAddRowsFalse
        #region SetAllowUserToAddRowsFalse
        private void LoadAllowUserToAddRows()
        {
            DGV_Choosed_PoolMem.AllowUserToAddRows = false;
            DGV_Choose_PoolMem.AllowUserToAddRows = false;
        }

        #endregion
        //B_Click
        #region ButtonClick
        private async void B_LB_Details_Click(object sender, EventArgs e)
        {
            SavePage();
            cB_LB_Subnet.Items.Clear();
            cB_LB_Flavour.Items.Clear();
            cB_LB_AZ.Items.Clear();
            subnets = new List<(string id, string name)>();

            PageControl.SelectedTab = LB_Details_Page;
            currentpage = "LBDetailsPage";

            tb_LB_Name.Text = string.IsNullOrEmpty(_lbdetailpage.lbname) ? "" : _lbdetailpage.lbname;
            tb_LB_IP.Text = string.IsNullOrEmpty(_lbdetailpage.lbip) ? "" : _lbdetailpage.lbip;
            tb_LB_Description.Text = string.IsNullOrEmpty(_lbdetailpage.lbdes) ? "" : _lbdetailpage.lbdes;

            SubnetService subnetService = new SubnetService();
            var subres = await subnetService.GetSubnetAsync(Main._token);
            if(subres.Item1)
            {
                var subdata = Newtonsoft.Json.JsonConvert.DeserializeObject<SubnetResponse>(subres.Item2);
                foreach (var subnet in subdata.subnets)
                {
                    NetworkService networkService = new NetworkService();
                    var netres = await networkService.GetNetworkAsync(Main._token, subnet.network_id);
                    if (netres.Item1)
                    {
                        var netdata = Newtonsoft.Json.JsonConvert.DeserializeObject<NetworkResponse>(netres.Item2);
                        cB_LB_Subnet.Items.Add(netdata.network.name + ": " + subnet.cidr + " (" + subnet.name+")");
                        subnets.Add((subnet.id, subnet.name));
                    }
                }
                cB_LB_Subnet.SelectedIndex = _lbdetailpage.lbsubnetindex;
            }
        }

        private void B_Lis_Details_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = Lis_Details_Page;
            currentpage = "LisDetailsPage";

            if (_lblispage.lisASUp) B_Lis_ASUp_Yes_Click(null, null);
            else B_Lis_ASUp_No_Click(null, null);
            if (_lblispage.crlis) B_Cr_Lis_Yes_Click(null, null);
            else B_Cr_Lis_No_Click(null, null);
            cob_Lis_Proto.SelectedIndex = 0;
            cob_Lis_Proto.SelectedIndex = _lblispage.lisprotoindex;
            tb_Lis_Name.Text = _lblispage.lisname;
            tb_Lis_Des.Text =_lblispage.lisdes;
            tb_Lis_Port.Text = _lblispage.lisport;
            tb_Lis_ClientTimeout.Text = _lblispage.lisclienttimeout;
            tb_Lis_Mem_Con_Timeout.Text = _lblispage.lismemcontimeout;
            tb_Lis_Allow_cidr.Text = _lblispage.liscidr;
            tb_Lis_Con_Limit.Text = _lblispage.lisconlimit;
            tb_Lis_Mem_Timeout.Text = _lblispage.lismemtimeout;
            tb_Lis_TCPTimeout.Text = _lblispage.listcptimeout;
            cb_Lis_XForwFor.Checked = _lblispage.lisxforwfor;
            cb_Lis_XForwPort.Checked = _lblispage.lisxforwport;
            cb_Lis_XForwProto.Checked = _lblispage.lisxforwforproto;
        }

        private void B_Pool_Details_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = Pool_Details_Page;
            currentpage = "PoolDetailsPage";

            if (_lbpoolpage.poolasup) B_Pool_ASUp_Yes_Click(null, null);
            else B_Pool_ASUp_No_Click(null, null);
            if (_lbpoolpage.pooltls) B_Pool_TLFEn_Yes_Click(null, null);
            else B_Pool_TLFEn_No_Click(null, null); 
            if (_lbpoolpage.crpool) B_Cr_Pool_Yes_Click(null, null);
            else B_Cr_Pool_No_Click(null, null);

            tb_Pool_Name.Text = _lbpoolpage.poolname;
            tb_Pool_Des.Text = _lbpoolpage.pooldes;
            tb_Pool_Cookie_Name.Text = _lbpoolpage.poolcookiename;
            cob_Pool_Algorithm.SelectedIndex = 0;
            cob_Pool_Algorithm.SelectedIndex = _lbpoolpage.poolalgorithmindex;
            cob_Pool_Session.SelectedIndex = 0;
            cob_Pool_Session.SelectedIndex = _lbpoolpage.poolsessionindex;
        }

        private async void B_Pool_Mem_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = Pool_Mem_Page;
            currentpage = "PoolMemPage";

            DGV_Choosed_PoolMem.Rows.Clear();
            DGV_Choose_PoolMem.Rows.Clear(); DGV_Choosed_PoolMem.Rows.Clear();
            DGV_Choosed_PoolMem.CellValueChanged -= DGV_Choosed_PoolMem_CellValueChanged;
            DGV_Choosed_PoolMem.CurrentCellDirtyStateChanged -= DGV_Choosed_PoolMem_CurrentCellDirtyStateChanged;
            DGV_Choosed_PoolMem.CellValueChanged += DGV_Choosed_PoolMem_CellValueChanged;
            DGV_Choosed_PoolMem.CurrentCellDirtyStateChanged += DGV_Choosed_PoolMem_CurrentCellDirtyStateChanged;
            
            InstanceService instanceService = new InstanceService();
            var insres = await instanceService.GetInstanceAsync(Main._token);

            if(insres.Item1)
            {
                var insdata = Newtonsoft.Json.JsonConvert.DeserializeObject<InstanceResponse>(insres.Item2);
                int i = 0;

                foreach (var ins in insdata.servers)
                {
                    int rowIndex = DGV_Choose_PoolMem.Rows.Add();
                    DataGridViewRow row = DGV_Choose_PoolMem.Rows[rowIndex];

                    row.Cells[0].Value = ins.id;
                    row.Cells[1].Value = ins.name;

                    PortService portService = new PortService();
                    SubnetService subnetService = new SubnetService();
                    DataGridViewComboBoxCell cb2 = new DataGridViewComboBoxCell();
                    List<string> ipList = new List<string>();

                    foreach (var address in ins.addresses)
                    {
                        foreach (var ip in address.Value)
                        {
                            ipList.Add(ip.addr);
                        }
                    }
                    if (ipList.Count > 1)
                    {
                        cb2.DataSource = ipList;
                        cb2.Value = ipList[0];
                        row.Cells[2] = cb2;
                        row.Cells[3].Value = ipList[0] + "...";

                        var ports = await portService.GetPortsByInstance(Main._token, ins.id);

                        string subnetId = GetSubnetIdFromIP(ins.id, ipList[0], ports);
                        var subnets = await subnetService.GetSubnetAsync(Main._token, subnetId);
                        var subdata = Newtonsoft.Json.JsonConvert.DeserializeObject<SubnetResponse>(subnets.Item2);
                        row.Cells[4].Value = subdata.subnet.name;
                        row.Cells[5].Value = subnetId;
                    }
                    else
                    {
                        row.Cells[2].Value = "";
                        row.Cells[3].Value = ipList[0];
                        var ports = await portService.GetPortsByInstance(Main._token, ins.id);

                        string subnetId = GetSubnetIdFromIP(ins.id, ipList[0], ports);
                        var subnets = await subnetService.GetSubnetAsync(Main._token, subnetId);
                        var subdata = Newtonsoft.Json.JsonConvert.DeserializeObject<SubnetResponse>(subnets.Item2);
                        row.Cells[4].Value = subdata.subnet.name;
                        row.Cells[5].Value = subnetId;
                    }

                    row.Cells[6].Value = "";
                    row.Cells[7].Value = "1";
                    row.Cells[8].Value = i++;
                }
            }
            LoadPoolMemPage();
        }
        private void LoadPoolMemPage()
        {
            DGV_Choosed_PoolMem.Rows.Clear();

            foreach (var item in _lbpoolmem)
            {
                int rowIndex = DGV_Choosed_PoolMem.Rows.Add();
                var row = DGV_Choosed_PoolMem.Rows[rowIndex];

                row.Cells[0].Value = item.Id;
                row.Cells[1].Value = item.Name;

                // 🔥 restore ComboBox
                if (item.IpList != null && item.IpList.Count > 1)
                {
                    DataGridViewComboBoxCell cb = new DataGridViewComboBoxCell();
                    cb.DataSource = item.IpList;
                    cb.Value = item.SelectedIP;

                    row.Cells[2] = cb;
                }
                else
                {
                    row.Cells[2].Value = item.SelectedIP;
                }

                row.Cells[3].Value = item.DisplayIP;
                row.Cells[4].Value = item.Subnet;
                row.Cells[5].Value = item.SubId;
                row.Cells[6].Value = item.Port;
                row.Cells[7].Value = item.Weight;
                row.Cells[8].Value = item.STT;
            }
        }
        string GetSubnetIdFromIP(string instanceId, string ip, List<Port> ports)
        {
            foreach (var port in ports)
            {
                foreach (var fixedip in port.fixed_ips)
                {
                    if (fixedip.ip_address == ip)
                    {
                        return fixedip.subnet_id;
                    }
                }
            }
            return null;
        }

        private void B_Mon_Details_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = Mon_Details_Page;
            currentpage = "MonDetailsPage";
        }
        private void B_Cancel_LB_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void B_Cr_LB_Click(object sender, EventArgs e)
        {
            SavePage();

        }

        #endregion

        private void B_LB_AS_Yes_Click(object sender, EventArgs e)
        {
            B_LB_AS_Yes.BackColor = Color.Silver;
            B_LB_AS_No.BackColor = Color.White;
            _lbdetailpage.ASUp = true;
        }

        private void B_LB_AS_No_Click(object sender, EventArgs e)
        {
            B_LB_AS_Yes.BackColor = Color.White;
            B_LB_AS_No.BackColor = Color.Silver;
            _lbdetailpage.ASUp = false;
        }

        private void B_Cr_Lis_No_Click(object sender, EventArgs e)
        {
            B_Cr_Lis_Yes.BackColor = Color.White;
            B_Cr_Lis_No.BackColor = Color.Silver;
            P_Lis_L_tb_Name_Des.Visible = false;
            P_Lis_Detail_Information.Visible = false;
            P_Lis_L_cb_Insert_Header.Visible = false;
            P_Lis_L_B_ASUp.Visible = false;
            _lblispage.crlis = false;
        }

        private void B_Cr_Lis_Yes_Click(object sender, EventArgs e)
        {
            B_Cr_Lis_Yes.BackColor = Color.Silver;
            B_Cr_Lis_No.BackColor = Color.White;
            P_Lis_L_tb_Name_Des.Visible = true;
            P_Lis_Detail_Information.Visible = true;
            P_Lis_L_cb_Insert_Header.Visible = true;
            P_Lis_L_B_ASUp.Visible = true;
            _lblispage.crlis = true;
        }

        private void B_Lis_ASUp_Yes_Click(object sender, EventArgs e)
        {
            B_Lis_ASUp_Yes.BackColor = Color.Silver;
            B_Lis_ASUp_No.BackColor = Color.White;
            _lblispage.lisASUp = true;
        }

        private void B_Lis_ASUp_No_Click(object sender, EventArgs e)
        {
            B_Lis_ASUp_Yes.BackColor = Color.White;
            B_Lis_ASUp_No.BackColor = Color.Silver;
            _lblispage.lisASUp = false;
        }

        private void cob_Lis_Proto_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cob_Lis_Proto.SelectedIndex)
            {
                case 0:
                    tb_Lis_Port.Text = "80";
                    P_Lis_L_cb_Insert_Header.Visible = true;
                    P_Lis_L_tb_Timeout.Visible = true;
                    break;
                case 1:
                    tb_Lis_Port.Text = "";
                    P_Lis_L_cb_Insert_Header.Visible = false;
                    P_Lis_L_tb_Timeout.Visible = true;
                    break;
                case 2:
                    tb_Lis_Port.Text = "";
                    P_Lis_L_cb_Insert_Header.Visible = false;
                    P_Lis_L_tb_Timeout.Visible = true;
                    break;
                case 3:
                    tb_Lis_Port.Text = "";
                    P_Lis_L_cb_Insert_Header.Visible = false;
                    P_Lis_L_tb_Timeout.Visible = false;
                    break;
                case 4:
                    tb_Lis_Port.Text = "";
                    P_Lis_L_cb_Insert_Header.Visible = false;
                    P_Lis_L_tb_Timeout.Visible = false;
                    break;
            }
        }

        private void B_Cr_Pool_Yes_Click(object sender, EventArgs e)
        {
            B_Cr_Pool_Yes.BackColor = Color.Silver;
            B_Cr_Pool_No.BackColor = Color.White;
            P_Pool_Item.Visible = true;
            _lbpoolpage.crpool = true;
        }

        private void B_Cr_Pool_No_Click(object sender, EventArgs e)
        {
            B_Cr_Pool_Yes.BackColor = Color.White;
            B_Cr_Pool_No.BackColor = Color.Silver;
            P_Pool_Item.Visible = false;
            _lbpoolpage.crpool = false;
        }

        private void B_Pool_TLFEn_Yes_Click(object sender, EventArgs e)
        {
            B_Pool_TLFEn_Yes.BackColor = Color.Silver;
            B_Pool_TLFEn_No.BackColor = Color.White;
            _lbpoolpage.pooltls = true;
        }

        private void B_Pool_TLFEn_No_Click(object sender, EventArgs e)
        {
            B_Pool_TLFEn_Yes.BackColor = Color.White;
            B_Pool_TLFEn_No.BackColor = Color.Silver;
            _lbpoolpage.pooltls = false;
        }

        private void B_Pool_ASUp_Yes_Click(object sender, EventArgs e)
        {
            B_Pool_ASUp_Yes.BackColor = Color.Silver;
            B_Pool_ASUp_No.BackColor = Color.White;
            _lbpoolpage.poolasup = true;
        }

        private void B_Pool_ASUp_No_Click(object sender, EventArgs e)
        {
            B_Pool_ASUp_Yes.BackColor = Color.White;
            B_Pool_ASUp_No.BackColor = Color.Silver;
            _lbpoolpage.poolasup = false;
        }

        private void cob_Pool_Session_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cob_Pool_Session.SelectedIndex == 3)
            {
                L_Pool_Cookie_Name.Visible = true;
                tb_Pool_Cookie_Name.Visible = true;
            }
            else
            {
                L_Pool_Cookie_Name.Visible = false;
                tb_Pool_Cookie_Name.Visible = false;
            }
        }

        private void DGV_Choosed_PoolMem_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGV_Choosed_PoolMem.IsCurrentCellDirty)
            {
                DGV_Choosed_PoolMem.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private async void DGV_Choosed_PoolMem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // chỉ xử lý khi đổi IP (column index 2)
            if (e.RowIndex >= 0 && e.ColumnIndex == 2)
            {
                var row = DGV_Choosed_PoolMem.Rows[e.RowIndex];

                string instanceId = row.Cells[0].Value?.ToString();
                string ip = row.Cells[2].Value?.ToString();

                if (string.IsNullOrEmpty(instanceId) || string.IsNullOrEmpty(ip))
                    return;

                try
                {
                    PortService portService = new PortService();

                    // 🔥 gọi API lấy port
                    var ports = await portService.GetPortsByInstance(Main._token, instanceId);

                    if (ports == null) return;

                    string subnetId = null;

                    foreach (var port in ports)
                    {
                        foreach (var fixedip in port.fixed_ips)
                        {
                            if (fixedip.ip_address == ip)
                            {
                                subnetId = fixedip.subnet_id;
                                break;
                            }
                        }
                        if (subnetId != null) break;
                    }

                    if (subnetId == null) return;

                    row.Cells[3].Value =ip;
                    // 👉 set subnet ID
                    row.Cells[5].Value = subnetId;

                    // 🔥 gọi API lấy subnet name
                    SubnetService subnetService = new SubnetService();
                    var subnetRes = await subnetService.GetSubnetAsync(Main._token, subnetId);

                    if (subnetRes.Item1)
                    {
                        var subdata = Newtonsoft.Json.JsonConvert.DeserializeObject<SubnetResponse>(subnetRes.Item2);

                        row.Cells[4].Value = subdata.subnet.name;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void DGV_Choose_PoolMem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_PoolMem.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_PoolMem.Rows[e.RowIndex];

                int newRowIndex = DGV_Choosed_PoolMem.Rows.Add();
                DataGridViewRow newRow = DGV_Choosed_PoolMem.Rows[newRowIndex];

                // Copy thường
                newRow.Cells[0].Value = selectedRow.Cells[0].Value;
                newRow.Cells[1].Value = selectedRow.Cells[1].Value;

                // 🔥 COPY COMBOBOX
                DataGridViewComboBoxCell sourceCell = (DataGridViewComboBoxCell)selectedRow.Cells[2];

                DataGridViewComboBoxCell newCombo = new DataGridViewComboBoxCell();

                // copy datasource (list IP)
                newCombo.DataSource = sourceCell.DataSource;

                // nếu bạn dùng Display/ValueMember thì copy luôn
                newCombo.DisplayMember = sourceCell.DisplayMember;
                newCombo.ValueMember = sourceCell.ValueMember;

                // giữ IP đang chọn
                newCombo.Value = sourceCell.Value;

                newRow.Cells[2] = newCombo;

                // Copy các cột còn lại
                newRow.Cells[3].Value = selectedRow.Cells[3].Value;
                newRow.Cells[4].Value = selectedRow.Cells[4].Value;
                newRow.Cells[5].Value = selectedRow.Cells[5].Value;
                newRow.Cells[6].Value = selectedRow.Cells[6].Value;
                newRow.Cells[7].Value = selectedRow.Cells[7].Value;
                newRow.Cells[8].Value = selectedRow.Cells[8].Value;
            }
        }

        private void DGV_Choosed_PoolMem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choosed_PoolMem.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_PoolMem.Rows[e.RowIndex];
                DGV_Choosed_PoolMem.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void B_Cr_Mon_Yes_Click(object sender, EventArgs e)
        {
            B_Cr_Mon_Yes.BackColor = Color.Silver;
            B_Cr_Mon_No.BackColor = Color.White;
        }

        private void B_Cr_Mon_No_Click(object sender, EventArgs e)
        {
            B_Cr_Mon_Yes.BackColor = Color.White;
            B_Cr_Mon_No.BackColor = Color.Silver;
        }

        private void B_Mon_ASUp_Yes_Click(object sender, EventArgs e)
        {
            B_Mon_ASUp_Yes.BackColor = Color.Silver;
            B_Mon_ASUp_No.BackColor = Color.White;
        }

        private void B_Mon_ASUp_No_Click(object sender, EventArgs e)
        {
            B_Mon_ASUp_Yes.BackColor = Color.White;
            B_Mon_ASUp_No.BackColor = Color.Silver;
        }

        private void cob_Mon_Type_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
