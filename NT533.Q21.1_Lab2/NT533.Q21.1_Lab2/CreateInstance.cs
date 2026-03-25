using Newtonsoft.Json;
using NT533.Q21._1_Lab2.Compute;
using NT533.Q21._1_Lab2.Network;
using NT533.Q21._1_Lab2.Volume;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NT533.Q21._1_Lab2.Compute.FlavorService;
using static NT533.Q21._1_Lab2.Compute.ImageService;
using static NT533.Q21._1_Lab2.Compute.InstanceService;
using static NT533.Q21._1_Lab2.Compute.KeyPairService;
using static NT533.Q21._1_Lab2.Network.LoadBalancerService;
using static NT533.Q21._1_Lab2.Network.NetworkService;
using static NT533.Q21._1_Lab2.Network.SecurityGroupService;
using static NT533.Q21._1_Lab2.Network.SubnetService;
using static NT533.Q21._1_Lab2.Volume.AvailabilityZoneService;
using static NT533.Q21._1_Lab2.Volume.VolumeService;
using static System.Net.Mime.MediaTypeNames;

namespace NT533.Q21._1_Lab2
{
    public partial class CreateInstance : Form
    {
        #region Fields
        public bool Result { get; private set; }
        private string currentpage;
        private (string insname,string insdes,string insazone,string inscount) _detailpage = (null, null, null, "1");
        private (string imageorvolume ,bool delvoloninsdel, string size, string sourceid) _sourcepage = ("0",false,"1",null);
        private string _flavorid  = null;
        private List<string> _networkids = new List<string>();
        private List<string> _secgroupids = new List<string>();
        private string _keyname = null;
        private string _customscript = null;
        private List<string> _lbids = new List<string>();
        private Main _main;
        #endregion
        public CreateInstance(Main main)
        {
            InitializeComponent();
            B_Detail_Click(null, null);
            LoadAllowUserToAddRows();
            _main = main;
        }
        //SavePage
        #region SavePage
        private void SavePage()
        {
            switch(currentpage)
            {
                case "DetailPage":
                    SaveDetailPage();
                    break;
                case "SourcePage":
                    SaveSourcePage();
                    break;
                case "FlavourPage":
                    SaveFlavourPage();
                    break;
                case "NetworkPage":
                    SaveNetworksPage();
                    break;
                case "SecGroupPage":
                    SaveSecGroupsPage();
                    break;
                case "KeyPairPage":
                    SaveKeyPairPage();
                    break;
                case "ConfigurationPage":
                    SaveConfigurationPage();
                    break;
                case "LoadBalancerPage":
                    SaveLoadBalancerPage();
                    break;
            }
        }
        private void SaveDetailPage()
        {
            string inname = tb_InstanceName.Text;
            string indes = tb_Description.Text;
            string inazone = cB_AZ.Items[cB_AZ.SelectedIndex].ToString();
            string incount = tb_Count.Text;

            _detailpage = (inname, indes, inazone, incount);
        }
        private void SaveSourcePage()
        {
            int index = cB_SelectSource.SelectedIndex;
            _sourcepage.imageorvolume = index.ToString();
            switch(index)
            {
                case 0:
                    _sourcepage.size = tB_VolSize.Text;
                    if(DGV_Choosed_ImageSource.Rows.Count > 0 )
                    {

                        _sourcepage.sourceid = DGV_Choosed_ImageSource.Rows[0].Cells[0].Value.ToString();
                    }
                    else
                    {
                        _sourcepage.sourceid = null;
                    }
                    break;
                case 1:
                    if (DGV_Choosed_VolSource.Rows.Count > 0)
                    {
                        _sourcepage.sourceid = DGV_Choosed_VolSource.Rows[0].Cells[0].Value.ToString();
                    }
                    else
                    {
                        _sourcepage.sourceid = null;
                    }
                    break;
            }
        }
        private void SaveFlavourPage()
        {
            if (DGV_Choosed_Flavour.Rows.Count > 0)
            {

                _flavorid = DGV_Choosed_Flavour.Rows[0].Cells[0].Value.ToString();
            }
            else
            {
                _flavorid = null;
            }
        }
        private void SaveNetworksPage()
        {
            if (DGV_Choosed_Network.Rows.Count > 0)
            {
                _networkids = new List<string>();
                foreach (DataGridViewRow row in DGV_Choosed_Network.Rows)
                {
                    if (!row.IsNewRow && row.Cells[0].Value != null)
                    {
                        _networkids.Add(row.Cells[0].Value.ToString());
                    }
                }
            }
            else
            {
                _networkids = new List<string>();
            }
        }
        private void SaveSecGroupsPage()
        {
            if (DGV_Choosed_SecGroup.Rows.Count > 0)
            {
                _secgroupids = new List<string>();
                foreach (DataGridViewRow row in DGV_Choosed_SecGroup.Rows)
                {
                    if (!row.IsNewRow && row.Cells[0].Value != null)
                    {
                        _secgroupids.Add(row.Cells[0].Value.ToString());
                    }
                }
            }
            else
            {
                _secgroupids = new List<string>();
            }
        }
        private void SaveKeyPairPage()
        {
            if (DGV_Choosed_KeyPair.Rows.Count > 0)
            {

                _keyname = DGV_Choosed_KeyPair.Rows[0].Cells[0].Value.ToString();
            }
            else
            {
                _keyname = null;
            }
        }
        private void SaveConfigurationPage()
        {
            _customscript = rtb_CustomScript.Text;
        }
        private void SaveLoadBalancerPage()
        {
            if (DGV_Choosed_LoadBalancer.Rows.Count > 0)
            {
                _lbids = new List<string>();
                foreach (DataGridViewRow row in DGV_Choosed_LoadBalancer.Rows)
                {
                    if (!row.IsNewRow && row.Cells[0].Value != null)
                    {
                        _lbids.Add(row.Cells[0].Value.ToString());
                    }
                }
            }
            else
            {
                _lbids = new List<string>();
            }
        }
        #endregion
        //SetAllowUserToAddRowsFalse
        #region SetAllowUserToAddRowsFalse
        private void LoadAllowUserToAddRows()
        {
            DGV_Choose_Flavour.AllowUserToAddRows = false;
            DGV_Choosed_Flavour.AllowUserToAddRows = false;
            DGV_Choose_Network.AllowUserToAddRows = false;
            DGV_Choosed_Network.AllowUserToAddRows = false;
            DGV_Choose_ImageSource.AllowUserToAddRows = false;
            DGV_Choosed_ImageSource.AllowUserToAddRows = false;
            DGV_Choose_VolSource.AllowUserToAddRows = false;
            DGV_Choosed_VolSource.AllowUserToAddRows = false;
            DGV_Choosed_SecGroup.AllowUserToAddRows = false;
            DGV_Choose_SecGroup.AllowUserToAddRows = false;
            DGV_Choosed_KeyPair.AllowUserToAddRows = false;
            DGV_Choose_KeyPair.AllowUserToAddRows = false;
            DGV_Choosed_LoadBalancer.AllowUserToAddRows = false;
            DGV_Choose_LoadBalancer.AllowUserToAddRows = false;
        }
        #endregion
        //B_Click
        #region ButtonClick
        private async void B_Detail_Click(object sender, EventArgs e)
        {
            SavePage();
            cB_AZ.Items.Clear();
            PageControl.SelectedTab = DetailPage;
            currentpage = "DetailPage";

            tb_InstanceName.Text = string.IsNullOrEmpty(_detailpage.insname) ? "" : _detailpage.insname;
            tb_Description.Text = string.IsNullOrEmpty(_detailpage.insdes) ? "" : _detailpage.insdes;
            string inazone = string.IsNullOrEmpty(_detailpage.insazone) ? "" : _detailpage.insazone;
            tb_Count.Text = string.IsNullOrEmpty(_detailpage.inscount) ? "1" : _detailpage.inscount;

            AvailabilityZoneService availabilityZoneService = new AvailabilityZoneService();
            var azres = await availabilityZoneService.GetAvailabilityZoneAsync(Main._token);

            if (azres.Item1)
            {
                var azdata = Newtonsoft.Json.JsonConvert.DeserializeObject<AvailabilityZoneResponse>(azres.Item2);

                foreach (var availabilityZone in azdata.availabilityZoneInfo)
                {
                    if (availabilityZone.zoneState.available)
                    {
                        cB_AZ.Items.Add(availabilityZone.zoneName);
                    }
                }

                // 🔥 xử lý chọn item
                if (!string.IsNullOrEmpty(inazone) && cB_AZ.Items.Contains(inazone))
                {
                    cB_AZ.SelectedItem = inazone;
                }
                else if (cB_AZ.Items.Count > 0)
                {
                    cB_AZ.SelectedIndex = 0;
                }
            }
        }
        private async void B_Source_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = SourcePage;
            currentpage = "SourcePage";


            B_DelVol_Yes.BackColor = _sourcepage.delvoloninsdel? Color.Silver: Color.White;
            B_DelVol_No.BackColor = !_sourcepage.delvoloninsdel ? Color.Silver : Color.White;


            DGV_Choosed_ImageSource.Rows.Clear();
            DGV_Choose_ImageSource.Rows.Clear();
            DGV_Choosed_VolSource.Rows.Clear();
            DGV_Choose_VolSource.Rows.Clear();

            int index = int.Parse(_sourcepage.imageorvolume);
            if (index == 0) tB_VolSize.Text = _sourcepage.size;
            if(cB_SelectSource.SelectedIndex == index)
            {
                cB_SelectSource_SelectedIndexChanged(null,null);
            }
            else
            {
                cB_SelectSource.SelectedIndex = index;
            }
        }
        private async  void B_Flavour_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = FlavourPage;
            currentpage = "FlavourPage";

            DGV_Choosed_Flavour.Rows.Clear();
            DGV_Choose_Flavour.Rows.Clear();

            FlavorService flavorService = new FlavorService();
            var flavorres = await flavorService.GetFlavorAsync(Main._token);
            if (flavorres.Item1)
            {
                var flavordata = Newtonsoft.Json.JsonConvert.DeserializeObject<FlavorResponse>(flavorres.Item2);
                int i = 0;
                foreach(var flavor in flavordata.flavors)
                {
                    if (_flavorid != null && flavor.id == _flavorid)
                    {
                        DGV_Choosed_Flavour.Rows.Add(
                        flavor.id,
                        flavor.name,
                        flavor.vcpus,
                        flavor.ram / 1024,
                        flavor.disk,
                        flavor.disk,
                        flavor.ephemeral,
                        flavor.ispublic ? "Yes" : "No",
                        i++
                    );
                    }
                    else
                    {
                        DGV_Choose_Flavour.Rows.Add(
                        flavor.id,
                        flavor.name,
                        flavor.vcpus,
                        flavor.ram / 1024,
                        flavor.disk,
                        flavor.disk,
                        flavor.ephemeral,
                        flavor.ispublic ? "Yes" : "No",
                        i++
                    );
                    }
                }
            }
        }
        private async void B_Network_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = NetworkPage;
            currentpage = "NetworkPage";

            DGV_Choose_Network.Rows.Clear();
            DGV_Choosed_Network.Rows.Clear();

            NetworkService networkservice = new NetworkService();
            var netres = await networkservice.GetNetworkAsync(Main._token);
            if (netres.Item1)
            {
                var netdata = Newtonsoft.Json.JsonConvert.DeserializeObject<NetworkResponse>(netres.Item2);
                int i = 0;
                foreach(var data in netdata.networks)
                {
                    string subnetass = "";
                    foreach (var subnetid in data.subnets)
                    {
                        SubnetService subnetService = new SubnetService();
                        var subres = await subnetService.GetSubnetAsync(subnetass,subnetid);
                        if (subres.Item1)
                        {
                            var subdata = Newtonsoft.Json.JsonConvert.DeserializeObject<SubnetResponse>(subres.Item2);
                            subnetass += subdata.subnet.name + " ";
                        }
                    }
                    if (data.external != "true")
                    {
                        if (_networkids.Count > 0)
                        {
                            if (_networkids.Contains(data.id))
                            {
                                DGV_Choosed_Network.Rows.Add(
                                    data.id,
                                    data.name,
                                    subnetass,
                                    data.shared,
                                    data.admin_state_up,
                                    data.status,
                                    i++
                                );
                            }
                            else
                            {
                                DGV_Choose_Network.Rows.Add(
                                    data.id,
                                    data.name,
                                    subnetass,
                                    data.shared,
                                    data.admin_state_up,
                                    data.status,
                                    i++
                                );
                            }
                        }

                        else
                        {
                            DGV_Choose_Network.Rows.Add(
                                data.id,
                                data.name,
                                subnetass,
                                data.shared,
                                data.admin_state_up,
                                data.status,
                                i++
                            );
                        }
                    }
                }
            }
        }
        private async void B_SecGroup_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = SecGroupPage;
            currentpage = "SecGroupPage";

            DGV_Choosed_SecGroup.Rows.Clear();
            DGV_Choose_SecGroup.Rows.Clear();

            SecurityGroupService securityGroupService = new SecurityGroupService();
            var secres = await securityGroupService.GetSecurityGroupAsync(Main._token);
            if(secres.Item1)
            {
                var secdata = Newtonsoft.Json.JsonConvert.DeserializeObject<SecurityGroupResponse>(secres.Item2);
                int i = 0;
                foreach(var secgr in secdata.security_groups)
                {
                    if (_secgroupids.Count > 0)
                    {
                        if (_secgroupids.Contains(secgr.id))
                        {
                            DGV_Choosed_SecGroup.Rows.Add(
                                secgr.id,
                                secgr.name,
                                secgr.description,
                                i++
                            );
                        }
                        else
                        {
                            DGV_Choose_SecGroup.Rows.Add(
                                secgr.id,
                                secgr.name,
                                secgr.description,
                                i++
                            );
                        }
                    }
                    else
                    {
                        DGV_Choose_SecGroup.Rows.Add(
                            secgr.id,
                            secgr.name,
                            secgr.description,
                            i++
                        );
                    }
                }
            }

        }
        private async void B_KeyPair_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = KeyPairPage;
            currentpage = "KeyPairPage";

            DGV_Choosed_KeyPair.Rows.Clear();
            DGV_Choose_KeyPair.Rows.Clear();

            KeyPairService keyPairService = new KeyPairService();
            var keyres = await keyPairService.GetKeyPairAsync(Main._token);
            if(keyres.Item1)
            {
                var keydata = Newtonsoft.Json.JsonConvert.DeserializeObject<KeyPairResponse>(keyres.Item2);
                int i = 0;
                foreach (var item in keydata.keypairs)
                {
                    if (_keyname != null && item.keypair.name == _keyname)
                    {
                        DGV_Choosed_KeyPair.Rows.Add(
                        item.keypair.name,
                        "ssh",
                        item.keypair.fingerprint,
                        i++
                        );
                    }
                    else
                    {
                        DGV_Choose_KeyPair.Rows.Add(
                        item.keypair.name,
                        "ssh",
                        item.keypair.fingerprint,
                        i++
                        );
                    }   
                }

            }
        }
        private void B_Configuration_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = ConfigurationPage;
            currentpage = "ConfigurationPage";

            rtb_CustomScript.Text = string.IsNullOrEmpty(_customscript) ? "" : _customscript;

        }
        private async void B_LoadBalancer_Click(object sender, EventArgs e)
        {
            SavePage();
            PageControl.SelectedTab = LoadBalancerPage;
            currentpage = "LoadBalancerPage";

            DGV_Choosed_LoadBalancer.Rows.Clear();
            DGV_Choose_LoadBalancer.Rows.Clear();

            LoadBalancerService loadBalancerService = new LoadBalancerService();
            var lbres = await loadBalancerService.GetLoadBalancerAsync(Main._token);
            if(lbres.Item1)
            {
                var lbdata = Newtonsoft.Json.JsonConvert.DeserializeObject<LoadBalancerResponse>(lbres.Item2);
                int i = 0;
                foreach (var item in lbdata.loadbalancers)
                {
                    if (_lbids.Count > 0)
                    {
                        if (_lbids.Contains(item.id))
                        {
                            DGV_Choosed_LoadBalancer.Rows.Add(
                                item.id,
                                item.name,
                                item.vip_address,
                                item.availability_zone == null ? "-":item.availability_zone,
                                item.operating_status,
                                item.provisioning_status,
                                item.admin_state_up,
                                i++
                            );
                        }
                        else
                        {
                            DGV_Choose_LoadBalancer.Rows.Add(
                                item.id,
                                item.name,
                                item.vip_address,
                                item.availability_zone == null ? "-" : item.availability_zone,
                                item.operating_status,
                                item.provisioning_status,
                                item.admin_state_up,
                                i++
                            );
                        }
                    }
                    else
                    {
                        DGV_Choose_LoadBalancer.Rows.Add(
                            item.id,
                            item.name,
                            item.vip_address,
                            item.availability_zone == null ? "-" : item.availability_zone,
                            item.operating_status,
                            item.provisioning_status,
                            item.admin_state_up,
                            i++
                        );
                    }
                }
            }

        }
        private void B_DelVol_Yes_Click(object sender, EventArgs e)
        {
            B_DelVol_Yes.BackColor = Color.Silver;
            B_DelVol_No.BackColor = Color.White;
            _sourcepage.delvoloninsdel = true;
        }
        private void B_DelVol_No_Click(object sender, EventArgs e)
        {
            B_DelVol_Yes.BackColor = Color.White;
            B_DelVol_No.BackColor = Color.Silver;
            _sourcepage.delvoloninsdel = false;
        }
        private void B_Cr_KeyPair_Click(object sender, EventArgs e)
        {
            _main.B_Create_KeyPair_Click(null, null);
            B_KeyPair_Click(null, null);
        }
        private void B_Im_KeyPair_Click(object sender, EventArgs e)
        {
            _main.B_Import_KeyPair_Click(null, null);
            B_KeyPair_Click(null, null);
        }
        private void B_ChooseFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file";
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string text = File.ReadAllText(ofd.FileName);
                        rtb_CustomScript.Text = text;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi đọc file: " + ex.Message);
                    }
                }
            }
        }
        private void B_CancelCrInstance_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private async void B_LaunchInstance_Click(object sender, EventArgs e)
        {
            SavePage();
            try
            {
                if (string.IsNullOrEmpty(_detailpage.insname) ||
                    string.IsNullOrEmpty(_flavorid) ||
                    _networkids.Count == 0)
                {
                    MessageBox.Show("Thiếu thông tin cần thiết!");
                    return;
                }

                string token = Main._token;

                InstanceService service = new InstanceService();

                int count = int.Parse(_detailpage.inscount ?? "1");

                for (int i = 0; i < count; i++)
                {
                    string instanceName = count > 1
                        ? $"{_detailpage.insname}-{i + 1}"
                        : _detailpage.insname;

                    var result = await service.PostInstanceAsync(
                        token,
                        (instanceName, _detailpage.insdes, _detailpage.insazone, _detailpage.inscount),
                        _sourcepage,
                        _flavorid,
                        _networkids,
                        _secgroupids,
                        _keyname,
                        _customscript
                    );

                    if (!result.Item1)
                    {
                        MessageBox.Show($"Tạo instance thất bại: {result.Item2}");
                        return;
                    }
                    // parse instance id
                    var created = JsonConvert.DeserializeObject<InstanceService.InstanceResponse>(result.Item2);
                    string instanceId = created.server.id;

                    // đợi lấy IP
                    string ip = await service.WaitForInstanceIP(token, instanceId);

                    if (ip == null)
                    {
                        MessageBox.Show("Không lấy được IP");
                        return;
                    }
                    string subnetid = "";
                    NetworkService networkService = new NetworkService();
                    var netres = await networkService.GetNetworkAsync(Main._token, _networkids[0]);
                    if(netres.Item1)
                    {
                        var netdata = JsonConvert.DeserializeObject<NetworkResponse>(netres.Item2);
                        subnetid = netdata.network.subnets[0];
                    }

                    foreach (var lbid in _lbids)
                    {
                        LoadBalancerService lbService = new LoadBalancerService();
                        var lbres = await lbService.GetLoadBalancerAsync(token, lbid);
                        if(lbres.Item1)
                        {
                            var lbdata = JsonConvert.DeserializeObject<LoadBalancerResponse>(lbres.Item2);
                            string poolId = lbdata.loadbalancer.pools[0].id;
                            var addResult = await lbService.AddMemberToPool(token, poolId, ip, subnetid, 80);
                            if (!addResult.Item1)
                            {
                                MessageBox.Show($"Add vào LB lỗi: {addResult.Item2}");
                                return;
                            }
                        }
                    }
                }

                Result = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        #endregion
        //Switch Image and Volume Source
        #region SwitchSource
        private async void cB_SelectSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGV_Choosed_ImageSource.Rows.Clear();
            DGV_Choose_ImageSource.Rows.Clear();
            DGV_Choosed_VolSource.Rows.Clear();
            DGV_Choose_VolSource.Rows.Clear();

            int index = cB_SelectSource.SelectedIndex;
            if (index == 0)
            {
                DGVSourceControl.SelectedTab = ImageSourcePage;
                ImageService imageservice = new ImageService();
                var imageres = await imageservice.GetImageAsync(Main._token);
                if (imageres.Item1)
                {
                    var imagedata = Newtonsoft.Json.JsonConvert.DeserializeObject<ImageResponse>(imageres.Item2);
                    int i = 0;
                    foreach (var image in imagedata.images.OrderBy(x => x.name))
                    {
                        DateTime Datetime = image.updated_at;
                        string Updated = Datetime.ToString("M/d/yy h:mm tt");
                        long size = image.size;
                        double sizeMB = size / (1024.0 * 1024.0);
                        string formatted = sizeMB.ToString("0.00") + " MB";

                        if (_sourcepage.sourceid!=null && image.id == _sourcepage.sourceid) {
                            DGV_Choosed_ImageSource.Rows.Add(
                            image.id,
                            image.name,
                            image.min_disk,
                            Updated,
                            formatted,
                            image.disk_format,
                            image.visibility,
                            i++
                            );
                        }
                        else
                        {
                            DGV_Choose_ImageSource.Rows.Add(
                            image.id,
                            image.name,
                            image.min_disk,
                            Updated,
                            formatted,
                            image.disk_format,
                            image.visibility,
                            i++
                            );
                        }
                    }
                }
            }
            else
            {
                DGVSourceControl.SelectedTab = VolumeSourcePage;
                L_VolumeSize.Visible = false;
                tB_VolSize.Visible = false;
                VolumeService volumeService = new VolumeService();
                var volumeres = await volumeService.GetVolumeAsync(Main._token);
                if (volumeres.Item1)
                {
                    var volumedata = Newtonsoft.Json.JsonConvert.DeserializeObject<VolumeResponse>(volumeres.Item2);
                    int i = 0;
                    foreach (var volume in volumedata.volumes)
                    {
                        if (volume.attachments.Count != 0) continue;
                        if (volume.volume_image_metadata == null) continue;
                        if (_sourcepage.sourceid != null && volume.id == _sourcepage.sourceid)
                        {
                            DGV_Choosed_VolSource.Rows.Add(
                        volume.id,
                        string.IsNullOrEmpty(volume.name) ? volume.id : volume.name,
                        string.IsNullOrEmpty(volume.description) ? "-" : volume.description,
                        volume.size,
                        volume.volume_image_metadata.disk_format,
                        volume.availability_zone,
                        i++
                        );
                        }
                        else
                        {
                            DGV_Choose_VolSource.Rows.Add(
                        volume.id,
                        string.IsNullOrEmpty(volume.name) ? volume.id : volume.name,
                        string.IsNullOrEmpty(volume.description) ? "-" : volume.description,
                        volume.size,
                        volume.volume_image_metadata.disk_format,
                        volume.availability_zone,
                        i++
                        );
                        }
                    }
                }
            }
        }
        #endregion
        //DGV
        #region DGV
        private void DGV_Choosed_ImageSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choosed_ImageSource.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_ImageSource.Rows[e.RowIndex];

                DGV_Choosed_ImageSource.Rows.Clear();

                List<DataGridViewRow> allRows = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in DGV_Choose_ImageSource.Rows)
                {
                    if (!row.IsNewRow)
                        allRows.Add(row);
                }

                allRows.Add((DataGridViewRow)selectedRow.Clone());

                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    allRows.Last().Cells[i].Value = selectedRow.Cells[i].Value;
                }

                DGV_Choose_ImageSource.Rows.Clear();

                var sorted = allRows
                    .OrderBy(r =>
                    {
                        int value;
                        return int.TryParse(r.Cells[7].Value?.ToString(), out value) ? value : int.MaxValue;
                    })
                    .ToList();

                foreach (var row in sorted)
                {
                    DGV_Choose_ImageSource.Rows.Add(row);
                }
            }
        }
        private void DGV_Choose_ImageSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_ImageSource.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_ImageSource.Rows[e.RowIndex];

                if (DGV_Choosed_ImageSource.Rows.Count > 0)
                {
                    DataGridViewRow oldRow = DGV_Choosed_ImageSource.Rows[0];

                    DGV_Choosed_ImageSource.Rows.Clear();

                    DGV_Choosed_ImageSource.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value,
                        selectedRow.Cells[7].Value
                    );

                    int cursize = int.Parse(tB_VolSize.Text);
                    int newsize = selectedRow.Cells[2].Value.ToString() == "0" ? 1 : int.Parse(selectedRow.Cells[2].Value.ToString());
                    if (newsize > cursize)
                        tB_VolSize.Text = newsize.ToString();
                    DGV_Choose_ImageSource.Rows.RemoveAt(e.RowIndex);

                    List<DataGridViewRow> allRows = new List<DataGridViewRow>();

                    foreach (DataGridViewRow row in DGV_Choose_ImageSource.Rows)
                    {
                        if (!row.IsNewRow)
                            allRows.Add(row);
                    }

                    allRows.Add((DataGridViewRow)oldRow.Clone());

                    for (int i = 0; i < oldRow.Cells.Count; i++)
                    {
                        allRows.Last().Cells[i].Value = oldRow.Cells[i].Value;
                    }

                    DGV_Choose_ImageSource.Rows.Clear();

                    var sorted = allRows
                        .OrderBy(r =>
                        {
                            int value;
                            return int.TryParse(r.Cells[7].Value?.ToString(), out value) ? value : int.MaxValue;
                        })
                        .ToList();

                    foreach (var row in sorted)
                    {
                        DGV_Choose_ImageSource.Rows.Add(row);
                    }
                }
                else
                {
                    // Thêm lên trên
                    DGV_Choosed_ImageSource.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value,
                        selectedRow.Cells[7].Value
                    );
                    int cursize = int.Parse(tB_VolSize.Text);
                    int newsize = selectedRow.Cells[2].Value.ToString() == "0" ? 1 : int.Parse(selectedRow.Cells[2].Value.ToString());
                    if (newsize > cursize)
                        tB_VolSize.Text = newsize.ToString();
                    // Xóa dưới
                    DGV_Choose_ImageSource.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        private void DGV_Choosed_VolSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choosed_VolSource.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_VolSource.Rows[e.RowIndex];

                DGV_Choosed_VolSource.Rows.Clear();

                List<DataGridViewRow> allRows = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in DGV_Choose_VolSource.Rows)
                {
                    if (!row.IsNewRow)
                        allRows.Add(row);
                }

                allRows.Add((DataGridViewRow)selectedRow.Clone());

                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    allRows.Last().Cells[i].Value = selectedRow.Cells[i].Value;
                }

                DGV_Choose_VolSource.Rows.Clear();

                var sorted = allRows
                    .OrderBy(r =>
                    {
                        int value;
                        return int.TryParse(r.Cells[6].Value?.ToString(), out value) ? value : int.MaxValue;
                    })
                    .ToList();

                foreach (var row in sorted)
                {
                    DGV_Choose_VolSource.Rows.Add(row);
                }
            }
        }
        private void DGV_Choose_VolSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_VolSource.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_VolSource.Rows[e.RowIndex];

                if (DGV_Choosed_VolSource.Rows.Count > 0)
                {
                    DataGridViewRow oldRow = DGV_Choosed_VolSource.Rows[0];

                    DGV_Choosed_VolSource.Rows.Clear();

                    DGV_Choosed_VolSource.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value
                    );

                    DGV_Choose_VolSource.Rows.RemoveAt(e.RowIndex);

                    List<DataGridViewRow> allRows = new List<DataGridViewRow>();

                    foreach (DataGridViewRow row in DGV_Choose_VolSource.Rows)
                    {
                        if (!row.IsNewRow)
                            allRows.Add(row);
                    }

                    allRows.Add((DataGridViewRow)oldRow.Clone());

                    for (int i = 0; i < oldRow.Cells.Count; i++)
                    {
                        allRows.Last().Cells[i].Value = oldRow.Cells[i].Value;
                    }

                    DGV_Choose_VolSource.Rows.Clear();

                    var sorted = allRows
                        .OrderBy(r =>
                        {
                            int value;
                            return int.TryParse(r.Cells[6].Value?.ToString(), out value) ? value : int.MaxValue;
                        })
                        .ToList();

                    foreach (var row in sorted)
                    {
                        DGV_Choose_VolSource.Rows.Add(row);
                    }
                }
                else
                {
                    // Thêm lên trên
                    DGV_Choosed_VolSource.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value
                    );

                    // Xóa dưới
                    DGV_Choose_VolSource.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        private void DGV_Choose_Flavour_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_Flavour.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_Flavour.Rows[e.RowIndex];

                if (DGV_Choosed_Flavour.Rows.Count > 0)
                {
                    DataGridViewRow oldRow = DGV_Choosed_Flavour.Rows[0];

                    DGV_Choosed_Flavour.Rows.Clear();

                    DGV_Choosed_Flavour.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value,
                        selectedRow.Cells[7].Value,
                        selectedRow.Cells[8].Value
                    );

                    DGV_Choose_Flavour.Rows.RemoveAt(e.RowIndex);

                    List<DataGridViewRow> allRows = new List<DataGridViewRow>();

                    foreach (DataGridViewRow row in DGV_Choose_Flavour.Rows)
                    {
                        if (!row.IsNewRow)
                            allRows.Add(row);
                    }

                    allRows.Add((DataGridViewRow)oldRow.Clone());

                    for (int i = 0; i < oldRow.Cells.Count; i++)
                    {
                        allRows.Last().Cells[i].Value = oldRow.Cells[i].Value;
                    }

                    DGV_Choose_Flavour.Rows.Clear();

                    var sorted = allRows
                        .OrderBy(r =>
                        {
                            int value;
                            return int.TryParse(r.Cells[8].Value?.ToString(), out value) ? value : int.MaxValue;
                        })
                        .ToList();

                    foreach (var row in sorted)
                    {
                        DGV_Choose_Flavour.Rows.Add(row);
                    }
                }
                else
                {
                    // Thêm lên trên
                    DGV_Choosed_Flavour.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value,
                        selectedRow.Cells[7].Value,
                        selectedRow.Cells[8].Value
                    );

                    // Xóa dưới
                    DGV_Choose_Flavour.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        private void DGV_Choosed_Flavour_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choosed_Flavour.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_Flavour.Rows[e.RowIndex];

                DGV_Choosed_Flavour.Rows.Clear();

                List<DataGridViewRow> allRows = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in DGV_Choose_Flavour.Rows)
                {
                    if (!row.IsNewRow)
                        allRows.Add(row);
                }

                allRows.Add((DataGridViewRow)selectedRow.Clone());

                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    allRows.Last().Cells[i].Value = selectedRow.Cells[i].Value;
                }

                DGV_Choose_Flavour.Rows.Clear();

                var sorted = allRows
                    .OrderBy(r =>
                    {
                        int value;
                        return int.TryParse(r.Cells[8].Value?.ToString(), out value) ? value : int.MaxValue;
                    })
                    .ToList();

                foreach (var row in sorted)
                {
                    DGV_Choose_Flavour.Rows.Add(row);
                }
            }
        }
        private void DGV_Choose_Network_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_Network.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_Network.Rows[e.RowIndex];

                DGV_Choosed_Network.Rows.Add(
                    selectedRow.Cells[0].Value,
                    selectedRow.Cells[1].Value,
                    selectedRow.Cells[2].Value,
                    selectedRow.Cells[3].Value,
                    selectedRow.Cells[4].Value,
                    selectedRow.Cells[5].Value,
                    selectedRow.Cells[6].Value
                );

                DGV_Choose_Network.Rows.RemoveAt(e.RowIndex);

            }
        }
        private void DGV_Choosed_Network_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choosed_Network.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_Network.Rows[e.RowIndex];

                List<DataGridViewRow> allRows = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in DGV_Choose_Network.Rows)
                {
                    if (!row.IsNewRow)
                        allRows.Add(row);
                }

                allRows.Add((DataGridViewRow)selectedRow.Clone());

                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    allRows.Last().Cells[i].Value = selectedRow.Cells[i].Value;
                }

                DGV_Choose_Network.Rows.Clear();

                var sorted = allRows
                    .OrderBy(r =>
                    {
                        int value;
                        return int.TryParse(r.Cells[6].Value?.ToString(), out value) ? value : int.MaxValue;
                    })
                    .ToList();

                foreach (var row in sorted)
                {
                    DGV_Choose_Network.Rows.Add(row);
                }
                DGV_Choosed_Network.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void DGV_Choosed_SecGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choosed_SecGroup.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_SecGroup.Rows[e.RowIndex];

                List<DataGridViewRow> allRows = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in DGV_Choose_SecGroup.Rows)
                {
                    if (!row.IsNewRow)
                        allRows.Add(row);
                }

                allRows.Add((DataGridViewRow)selectedRow.Clone());

                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    allRows.Last().Cells[i].Value = selectedRow.Cells[i].Value;
                }

                DGV_Choose_SecGroup.Rows.Clear();

                var sorted = allRows
                    .OrderBy(r =>
                    {
                        int value;
                        return int.TryParse(r.Cells[3].Value?.ToString(), out value) ? value : int.MaxValue;
                    })
                    .ToList();

                foreach (var row in sorted)
                {
                    DGV_Choose_SecGroup.Rows.Add(row);
                }
                DGV_Choosed_SecGroup.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void DGV_Choose_SecGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_SecGroup.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_SecGroup.Rows[e.RowIndex];

                DGV_Choosed_SecGroup.Rows.Add(
                    selectedRow.Cells[0].Value,
                    selectedRow.Cells[1].Value,
                    selectedRow.Cells[2].Value,
                    selectedRow.Cells[3].Value
                );

                DGV_Choose_SecGroup.Rows.RemoveAt(e.RowIndex);

            }
        }
        private void DGV_Choosed_KeyPair_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choosed_KeyPair.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_KeyPair.Rows[e.RowIndex];

                DGV_Choosed_KeyPair.Rows.Clear();

                List<DataGridViewRow> allRows = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in DGV_Choose_KeyPair.Rows)
                {
                    if (!row.IsNewRow)
                        allRows.Add(row);
                }

                allRows.Add((DataGridViewRow)selectedRow.Clone());

                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    allRows.Last().Cells[i].Value = selectedRow.Cells[i].Value;
                }

                DGV_Choose_KeyPair.Rows.Clear();

                var sorted = allRows
                    .OrderBy(r =>
                    {
                        int value;
                        return int.TryParse(r.Cells[3].Value?.ToString(), out value) ? value : int.MaxValue;
                    })
                    .ToList();

                foreach (var row in sorted)
                {
                    DGV_Choose_KeyPair.Rows.Add(row);
                }
            }
        }
        private void DGV_Choose_KeyPair_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_KeyPair.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_KeyPair.Rows[e.RowIndex];

                if (DGV_Choosed_KeyPair.Rows.Count > 0)
                {
                    DataGridViewRow oldRow = DGV_Choosed_KeyPair.Rows[0];

                    DGV_Choosed_KeyPair.Rows.Clear();

                    DGV_Choosed_KeyPair.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value
                    );

                    DGV_Choose_KeyPair.Rows.RemoveAt(e.RowIndex);

                    List<DataGridViewRow> allRows = new List<DataGridViewRow>();

                    foreach (DataGridViewRow row in DGV_Choose_KeyPair.Rows)
                    {
                        if (!row.IsNewRow)
                            allRows.Add(row);
                    }

                    allRows.Add((DataGridViewRow)oldRow.Clone());

                    for (int i = 0; i < oldRow.Cells.Count; i++)
                    {
                        allRows.Last().Cells[i].Value = oldRow.Cells[i].Value;
                    }

                    DGV_Choose_KeyPair.Rows.Clear();

                    var sorted = allRows
                        .OrderBy(r =>
                        {
                            int value;
                            return int.TryParse(r.Cells[3].Value?.ToString(), out value) ? value : int.MaxValue;
                        })
                        .ToList();

                    foreach (var row in sorted)
                    {
                        DGV_Choose_KeyPair.Rows.Add(row);
                    }
                }
                else
                {
                    // Thêm lên trên
                    DGV_Choosed_KeyPair.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value
                    );

                    // Xóa dưới
                    DGV_Choose_KeyPair.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
        private void DGV_Choosed_LoadBalancer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choosed_LoadBalancer.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_LoadBalancer.Rows[e.RowIndex];

                List<DataGridViewRow> allRows = new List<DataGridViewRow>();

                foreach (DataGridViewRow row in DGV_Choose_LoadBalancer.Rows)
                {
                    if (!row.IsNewRow)
                        allRows.Add(row);
                }

                allRows.Add((DataGridViewRow)selectedRow.Clone());

                for (int i = 0; i < selectedRow.Cells.Count; i++)
                {
                    allRows.Last().Cells[i].Value = selectedRow.Cells[i].Value;
                }

                DGV_Choose_LoadBalancer.Rows.Clear();

                var sorted = allRows
                    .OrderBy(r =>
                    {
                        int value;
                        return int.TryParse(r.Cells[7].Value?.ToString(), out value) ? value : int.MaxValue;
                    })
                    .ToList();

                foreach (var row in sorted)
                {
                    DGV_Choose_LoadBalancer.Rows.Add(row);
                }
                DGV_Choosed_LoadBalancer.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void DGV_Choose_LoadBalancer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_LoadBalancer.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_LoadBalancer.Rows[e.RowIndex];

                DGV_Choosed_LoadBalancer.Rows.Add(
                    selectedRow.Cells[0].Value,
                    selectedRow.Cells[1].Value,
                    selectedRow.Cells[2].Value,
                    selectedRow.Cells[3].Value,
                    selectedRow.Cells[4].Value,
                    selectedRow.Cells[5].Value,
                    selectedRow.Cells[6].Value,
                    selectedRow.Cells[7].Value
                );

                DGV_Choose_LoadBalancer.Rows.RemoveAt(e.RowIndex);

            }
        }
        #endregion
    }
}
