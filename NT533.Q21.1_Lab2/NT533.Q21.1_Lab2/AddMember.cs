using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Compute;
using NT533.Q21._1_Lab2.HttpHelper;
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
using static NT533.Q21._1_Lab2.Compute.InstanceService;
using static NT533.Q21._1_Lab2.Compute.PortService;
using static NT533.Q21._1_Lab2.Network.SubnetService;

namespace NT533.Q21._1_Lab2
{
    public partial class AddMember : Form
    {
        public bool Result { get; private set; }
        private List<string> _ipaddress = new List<string>();
        private string _poolid = "";
        private string _lbid ="";
        private List<PoolMem> _lbpoolmem = new List<PoolMem>();
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

        public AddMember(List<string>ipaddress,string poolid,string lbid)
        {
            _ipaddress = ipaddress;
            _poolid = poolid;
            _lbid = lbid;
            InitializeComponent();
            B_Pool_Mem_Click(null, null);
            LoadAllowUserToAddRows();
        }
        //SavePage
        #region SavePage
        private void SavePage()
        {
            SavePoolMemPage();
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
        private async void B_Pool_Mem_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = Pool_Mem_Page;

            DGV_Choosed_PoolMem.Rows.Clear();
            DGV_Choose_PoolMem.Rows.Clear(); DGV_Choosed_PoolMem.Rows.Clear();
            DGV_Choosed_PoolMem.CellValueChanged -= DGV_Choosed_PoolMem_CellValueChanged;
            DGV_Choosed_PoolMem.CurrentCellDirtyStateChanged -= DGV_Choosed_PoolMem_CurrentCellDirtyStateChanged;
            DGV_Choosed_PoolMem.CellValueChanged += DGV_Choosed_PoolMem_CellValueChanged;
            DGV_Choosed_PoolMem.CurrentCellDirtyStateChanged += DGV_Choosed_PoolMem_CurrentCellDirtyStateChanged;

            InstanceService instanceService = new InstanceService();
            var insres = await instanceService.GetInstanceAsync(Main._token);

            if (insres.Item1)
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
                            if (ip.type == "floating") continue;
                            ipList.Add(ip.addr);
                        }
                    }

                    cb2.DataSource = ipList;
                    cb2.Value = ipList[0];
                    row.Cells[2] = cb2;
                    row.Cells[3].Value = ipList[0] + (ipList.Count > 1 ? "..." : "");
                    var ports = await portService.GetPorts(Main._token, ins.id);

                    string subnetId = GetSubnetIdFromIP(ins.id, ipList[0], ports);
                    var subnets = await subnetService.GetSubnetAsync(Main._token, subnetId);
                    var subdata = Newtonsoft.Json.JsonConvert.DeserializeObject<SubnetResponse>(subnets.Item2);
                    row.Cells[4].Value = subdata.subnet.name;
                    row.Cells[5].Value = subnetId;

                    row.Cells[6].Value = "80";
                    row.Cells[7].Value = "1";
                    row.Cells[8].Value = i++;
                }
            }
            LoadPoolMemPage();
        }

        private async void B_Add_Mem_Click(object sender, EventArgs e)
        {
            SavePage();
            var result = await CreateFullLoadBalancerAsync();

            if (result.Item1)
            {
                MessageBox.Show("Add member mới thành công!");
                Result = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Lỗi: " + result.Item2);
            }
        }


        private void B_Cancel_Mem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
        //Các hàm phụ trợ
        #region HamPhuTro
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
                if (item.IpList != null)
                {
                    DataGridViewComboBoxCell cb = new DataGridViewComboBoxCell();
                    cb.DataSource = item.IpList;
                    cb.Value = item.SelectedIP;

                    row.Cells[2] = cb;
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
        private async Task<(bool, string)> CreateFullLoadBalancerAsync()
        {
            try
            {
                // =====================
                // VALIDATE DUPLICATE MEMBER IP (TRONG LIST)
                // =====================
                var duplicateIPs = _lbpoolmem
                    .Where(m => !string.IsNullOrEmpty(m.SelectedIP))
                    .GroupBy(m => m.SelectedIP)
                    .Where(g => g.Count() > 1)
                    .Select(g => g.Key)
                    .ToList();

                if (duplicateIPs.Any())
                {
                    string msg = "IP bị trùng (trong danh sách member): " + string.Join(", ", duplicateIPs);
                    return (false, msg);
                }

                // =====================
                // VALIDATE TRÙNG VỚI LIST _ipaddress
                // =====================
                var conflictIPs = _lbpoolmem
                    .Where(m => !string.IsNullOrEmpty(m.SelectedIP))
                    .Select(m => m.SelectedIP)
                    .Where(ip => _ipaddress.Contains(ip))
                    .Distinct()
                    .ToList();

                if (conflictIPs.Any())
                {
                    string msg = "IP bị trùng với danh sách có sẵn: " + string.Join(", ", conflictIPs);
                    return (false, msg);
                }

                string token = Main._token;
                var http = new HttpHelperService();
                var lbService = new LoadBalancerService();


                // =====================
                // 4. ADD MEMBERS
                // =====================
                foreach (var mem in _lbpoolmem)
                {
                    if (string.IsNullOrEmpty(mem.SelectedIP)) continue;
                    PoolMemberService poolService = new PoolMemberService();
                    var add = await poolService.AddMemberToPool(
                        token,
                        _poolid,
                        mem.SelectedIP,
                        mem.SubId,
                        mem.Name,
                        mem.Weight,
                        int.Parse(mem.Port)
                    );

                    if (!add.Item1)
                        return (false, "Add Member fail: " + add.Item2);

                    // 🔥 QUAN TRỌNG NHẤT
                    var wait1 = await WaitForActive(_lbid);
                    if (!wait1.Item1)
                        return wait1;
                }

                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        private async Task<(bool, string)> WaitForActive(string lbId)
        {
            var lbService = new LoadBalancerService();

            for (int i = 0; i < 20; i++)
            {
                var res = await lbService.GetLoadBalancerAsync(Main._token, lbId);

                if (!res.Item1)
                    return res;

                dynamic data = JsonConvert.DeserializeObject(res.Item2);
                string status = data.loadbalancer.provisioning_status;

                if (status == "ACTIVE")
                    return (true, null);

                if (status == "ERROR")
                    return (false, "LB bị ERROR");

                await Task.Delay(3000);
            }

            return (false, "Timeout chờ ACTIVE");
        }
        #endregion
        //DGV
        #region DGV
        private void DGV_Choosed_PoolMem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choosed_PoolMem.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_PoolMem.Rows[e.RowIndex];
                DGV_Choosed_PoolMem.Rows.RemoveAt(e.RowIndex);
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
                    var ports = await portService.GetPorts(Main._token, instanceId);

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

                    row.Cells[3].Value = ip;
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
        #endregion

    }
}
