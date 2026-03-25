using crypto;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.Devices;
using NT533.Q21._1_Lab2.Auth;
using NT533.Q21._1_Lab2.Compute;
using NT533.Q21._1_Lab2.Dialog;
using NT533.Q21._1_Lab2.Network;
using NT533.Q21._1_Lab2.SSHKey;
using NT533.Q21._1_Lab2.Volume;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NT533.Q21._1_Lab2.Compute.FlavorService;
using static NT533.Q21._1_Lab2.Compute.ImageService;
using static NT533.Q21._1_Lab2.Compute.InstanceService;
using static NT533.Q21._1_Lab2.Compute.KeyPairService;
using static NT533.Q21._1_Lab2.Dialog.CreateKeyPairDialog;
using static NT533.Q21._1_Lab2.Network.InterfaceService;
using static NT533.Q21._1_Lab2.Network.NetworkService;
using static NT533.Q21._1_Lab2.Network.RouterService;
using static NT533.Q21._1_Lab2.Network.RuleService;
using static NT533.Q21._1_Lab2.Network.SecurityGroupService;
using static NT533.Q21._1_Lab2.Network.SubnetService;
using static NT533.Q21._1_Lab2.Volume.VolumeService;

namespace NT533.Q21._1_Lab2
{
    public partial class Main : Form
    {
        #region Fields
        Login _login = null;
        public static string _username = null;
        public static string _password = null;
        public static string _token = null;
        #endregion
        public Main((string,string,string) value, Login login)
        {
            _username = value.Item1;
            _password = value.Item2;
            _token = value.Item3;
            _login = login;
            InitializeComponent();
            LoadEventHandler();
        }
        //LoadEventHandler để gán sự kiện Resize cho các panel chứa label và button ở giữa, giúp căn giữa chúng khi form được resize.
        #region LoadEventHandler
        private void LoadEventHandler()
        {
            P_L_Token_Resize();
            P_B_CNToken_Resize();
            P_L_Flavor_Resize();
            P_L_Image_Resize();
            P_L_Instances_Resize();
            P_B_Cr_Del_Instances_Resize();
            P_L_KeyPair_Resize();
            P_B_Cr_Im_De_KeyPair_Resize();
            P_L_Volume_Resize();
            P_B_Cr_De_Volume_Resize();
            P_L_Networks_Resize();
            P_B_Cr_Del_Net_Resize();
            P_L_Sub_Networks_Resize();
            P_L_Subnet_Resize();
            P_B_Cr_Del_Subnets_Resize();
            P_L_Routers_Resize();
            P_B_Cr_Del_Routers_Resize();
            P_L_In_Router_Resize();
            P_L_Instances_Resize();
            P_B_Cr_Del_Interface_Resize();
            P_L_SecurityGroup_Resize();
            P_B_Cr_Del_SecurityGroup_Resize();
            P_L_IP_Resize();
            P_B_Al_Re_IP_Resize();
            P_L_LoadBalancer_Resize();
            P_B_Cr_Del_LoadBalancer_Resize();
            P_L_Rule_Resize();
            P_B_Cr_Del_Rule_Resize();
        }
        #endregion
        // Các phương thức Resize này sẽ được gọi khi form được resize, đảm bảo rằng các label và button luôn được căn giữa trong panel của chúng.
        #region ResizeEventHandlers
        private void P_L_Token_Resize(object sender = null, EventArgs e = null)
        {
            L_Token.Left = (P_L_Token.Width - L_Token.Width) / 2;
            L_Token.Top = (P_L_Token.Height - L_Token.Height) / 2;
        }
        private void P_B_CNToken_Resize(object sender = null, EventArgs e = null)
        {
            B_CNToken.Left = (P_B_Token.Width - B_CNToken.Width) / 2;
            B_CNToken.Top = (P_B_Token.Height - B_CNToken.Height) / 2;
        }
        private void P_L_Flavor_Resize(object sender = null, EventArgs e = null)
        {
            L_Flavor.Left = (P_L_Flavor.Width - L_Flavor.Width) / 2;
            L_Flavor.Top = (P_L_Flavor.Height - L_Flavor.Height) / 2;
        }
        private void P_L_Image_Resize(object sender = null, EventArgs e = null)
        {
            L_Image.Left = (P_L_Image.Width - L_Image.Width) / 2;
            L_Image.Top = (P_L_Image.Height - L_Image.Height) / 2;
        }
        private void P_L_Instances_Resize(object sender = null, EventArgs e = null)
        {
            L_Instances.Left = (P_L_Instances.Width - L_Instances.Width) / 2;
            L_Instances.Top = (P_L_Instances.Height - L_Instances.Height) / 2;
        }

        private void P_B_Cr_Del_Instances_Resize(object sender = null, EventArgs e = null)
        {
            B_Cr_Instances.Left = (P_B_Cr_Del_Instances.Width - B_Cr_Instances.Width) / 2 - 50;
            B_Cr_Instances.Top = (P_B_Cr_Del_Instances.Height - B_Cr_Instances.Height) / 2;
            B_Del_Instances.Left = (P_B_Cr_Del_Instances.Width - B_Del_Instances.Width) / 2 + 50;
            B_Del_Instances.Top = (P_B_Cr_Del_Instances.Height - B_Del_Instances.Height) / 2;
        }
        private void P_L_KeyPair_Resize(object sender = null, EventArgs e = null)
        {
            L_KeyPair.Left = (P_L_KeyPair.Width - L_KeyPair.Width) / 2;
            L_KeyPair.Top = (P_L_KeyPair.Height - L_KeyPair.Height) / 2;
        }
        private void P_B_Cr_Im_De_KeyPair_Resize(object sender = null, EventArgs e = null)
        {
            B_Create_KeyPair.Left = (P_B_Cr_Im_De_KeyPair.Width - B_Create_KeyPair.Width) / 2 - 100;
            B_Create_KeyPair.Top = (P_B_Cr_Im_De_KeyPair.Height - B_Create_KeyPair.Height) / 2;
            B_Import_KeyPair.Left = (P_B_Cr_Im_De_KeyPair.Width - B_Import_KeyPair.Width) / 2;
            B_Import_KeyPair.Top = (P_B_Cr_Im_De_KeyPair.Height - B_Import_KeyPair.Height) / 2;
            B_Delete_KeyPair.Left = (P_B_Cr_Im_De_KeyPair.Width - B_Delete_KeyPair.Width) / 2 + 100;
            B_Delete_KeyPair.Top = (P_B_Cr_Im_De_KeyPair.Height - B_Delete_KeyPair.Height) / 2;
        }
        private void P_L_Volume_Resize(object sender = null, EventArgs e = null)
        {
            L_Volume.Left = (P_L_Volume.Width - L_Volume.Width) / 2;
            L_Volume.Top = (P_L_Volume.Height - L_Volume.Height) / 2;
        }

        private void P_B_Cr_De_Volume_Resize(object sender = null, EventArgs e = null)
        {
            B_Create_Volume.Left = (P_B_Cr_De_Volume.Width - B_Create_Volume.Width) / 2 - 50;
            B_Create_Volume.Top = (P_B_Cr_De_Volume.Height - B_Create_Volume.Height) / 2;
            B_Delete_Volume.Left = (P_B_Cr_De_Volume.Width - B_Delete_Volume.Width) / 2 + 50;
            B_Delete_Volume.Top = (P_B_Cr_De_Volume.Height - B_Delete_Volume.Height) / 2;
        }
        private void P_L_Networks_Resize(object sender = null, EventArgs e = null)
        {
            L_Networks.Left = (P_L_Networks.Width - L_Networks.Width) / 2;
            L_Networks.Top = (P_L_Networks.Height - L_Networks.Height) / 2;
        }

        private void P_B_Cr_Del_Net_Resize(object sender = null, EventArgs e = null)
        {
            B_Cr_Net.Left = (P_B_Cr_Del_Net.Width - B_Cr_Net.Width) / 2 - 50;
            B_Cr_Net.Top = (P_B_Cr_Del_Net.Height - B_Cr_Net.Height) / 2;
            B_Del_Net.Left = (P_B_Cr_Del_Net.Width - B_Del_Net.Width) / 2 + 50;
            B_Del_Net.Top = (P_B_Cr_Del_Net.Height - B_Del_Net.Height) / 2;
        }
        private void P_L_Sub_Networks_Resize(object sender = null, EventArgs e = null)
        {
            L_Sub_Networks.Left = (P_L_Sub_Networks.Width - L_Sub_Networks.Width) / 2;
            L_Sub_Networks.Top = (P_L_Sub_Networks.Height - L_Sub_Networks.Height) / 2;
        }

        private void P_L_Subnet_Resize(object sender = null, EventArgs e = null)
        {
            L_Subnet.Left = (P_L_Subnet.Width - L_Subnet.Width) / 2;
            L_Subnet.Top = (P_L_Subnet.Height - L_Subnet.Height) / 2;
        }

        private void P_B_Cr_Del_Subnets_Resize(object sender = null, EventArgs e = null)
        {
            B_Cr_Subnets.Left = (P_B_Cr_Del_Subnets.Width - B_Cr_Subnets.Width) / 2 - 50;
            B_Cr_Subnets.Top = (P_B_Cr_Del_Subnets.Height - B_Cr_Subnets.Height) / 2;
            B_Del_Subnets.Left = (P_B_Cr_Del_Subnets.Width - B_Del_Subnets.Width) / 2 + 50;
            B_Del_Subnets.Top = (P_B_Cr_Del_Subnets.Height - B_Del_Subnets.Height) / 2;
        }
        private void P_L_Routers_Resize(object sender = null, EventArgs e = null)
        {
            L_Routers.Left = (P_L_Routers.Width - L_Routers.Width) / 2;
            L_Routers.Top = (P_L_Routers.Height - L_Routers.Height) / 2;
        }

        private void P_B_Cr_Del_Routers_Resize(object sender = null, EventArgs e = null)
        {
            B_Cr_Routers.Left = (P_B_Cr_Del_Routers.Width - B_Cr_Routers.Width) / 2 - 50;
            B_Cr_Routers.Top = (P_B_Cr_Del_Routers.Height - B_Cr_Routers.Height) / 2;
            B_Del_Routers.Left = (P_B_Cr_Del_Routers.Width - B_Del_Routers.Width) / 2 + 50;
            B_Del_Routers.Top = (P_B_Cr_Del_Routers.Height - B_Del_Routers.Height) / 2;
        }

        private void P_L_In_Router_Resize(object sender = null, EventArgs e = null)
        {
            L_In_Router.Left = (P_L_In_Router.Width - L_In_Router.Width) / 2;
            L_In_Router.Top = (P_L_In_Router.Height - L_In_Router.Height) / 2;
        }

        private void P_L_Interface_Resize(object sender = null, EventArgs e = null)
        {
            L_Interface.Left = (P_L_Interface.Width - L_Interface.Width) / 2;
            L_Interface.Top = (P_L_Interface.Height - L_Interface.Height) / 2;
        }

        private void P_B_Cr_Del_Interface_Resize(object sender = null, EventArgs e = null)
        {
            B_Cr_Interface.Left = (P_B_Cr_Del_Interface.Width - B_Cr_Interface.Width) / 2 - 50;
            B_Cr_Interface.Top = (P_B_Cr_Del_Interface.Height - B_Cr_Interface.Height) / 2;
            B_Del_Interface.Left = (P_B_Cr_Del_Interface.Width - B_Del_Interface.Width) / 2 + 50;
            B_Del_Interface.Top = (P_B_Cr_Del_Interface.Height - B_Del_Interface.Height) / 2;
        }
        private void P_L_SecurityGroup_Resize(object sender = null, EventArgs e = null)
        {
            L_SecurityGroup.Left = (P_L_SecurityGroup.Width - L_SecurityGroup.Width) / 2;
            L_SecurityGroup.Top = (P_L_SecurityGroup.Height - L_SecurityGroup.Height) / 2;
        }

        private void P_B_Cr_Del_SecurityGroup_Resize(object sender = null, EventArgs e = null)
        {
            B_Cr_SecurityGroup.Left = (P_B_Cr_Del_SecurityGroup.Width - B_Cr_SecurityGroup.Width) / 2 - 50;
            B_Cr_SecurityGroup.Top = (P_B_Cr_Del_SecurityGroup.Height - B_Cr_SecurityGroup.Height) / 2;
            B_Del_SecurityGroup.Left = (P_B_Cr_Del_SecurityGroup.Width - B_Del_SecurityGroup.Width) / 2 + 50;
            B_Del_SecurityGroup.Top = (P_B_Cr_Del_SecurityGroup.Height - B_Del_SecurityGroup.Height) / 2;
        }
        private void P_L_Rule_Resize(object sender = null, EventArgs e = null)
        {
            L_Rule.Left = (P_L_Rule.Width - L_Rule.Width) / 2;
            L_Rule.Top = (P_L_Rule.Height - L_Rule.Height) / 2;
        }

        private void P_B_Cr_Del_Rule_Resize(object sender = null, EventArgs e = null)
        {
            B_Cr_Rule.Left = (P_B_Cr_Del_Rule.Width - B_Cr_Rule.Width) / 2 - 50;
            B_Cr_Rule.Top = (P_B_Cr_Del_Rule.Height - B_Cr_Rule.Height) / 2;
            B_Del_Rule.Left = (P_B_Cr_Del_Rule.Width - B_Del_Rule.Width) / 2 + 50;
            B_Del_Rule.Top = (P_B_Cr_Del_Rule.Height - B_Del_Rule.Height) / 2;
        }
        private void P_L_IP_Resize(object sender = null, EventArgs e = null)
        {
            L_FloatingIP.Left = (P_L_IP.Width - L_FloatingIP.Width) / 2;
            L_FloatingIP.Top = (P_L_IP.Height - L_FloatingIP.Height) / 2;
        }

        private void P_B_Al_Re_IP_Resize(object sender = null, EventArgs e = null)
        {
            B_AllocateIP.Left = (P_B_Al_Re_IP.Width - B_AllocateIP.Width) / 2 - 50;
            B_AllocateIP.Top = (P_B_Al_Re_IP.Height - B_AllocateIP.Height) / 2;
            B_ReleaseIP.Left = (P_B_Al_Re_IP.Width - B_ReleaseIP.Width) / 2 + 50;
            B_ReleaseIP.Top = (P_B_Al_Re_IP.Height - B_ReleaseIP.Height) / 2;
        }
        private void P_L_LoadBalancer_Resize(object sender = null, EventArgs e = null)
        {
            L_LoadBalancer.Left = (P_L_LoadBalancer.Width - L_LoadBalancer.Width) / 2;
            L_LoadBalancer.Top = (P_L_LoadBalancer.Height - L_LoadBalancer.Height) / 2;
        }

        private void P_B_Cr_Del_LoadBalancer_Resize(object sender = null, EventArgs e = null)
        {
            B_Cr_LoadBalancer.Left = (P_B_Cr_Del_LoadBalancer.Width - B_Cr_LoadBalancer.Width) / 2 - 50;
            B_Cr_LoadBalancer.Top = (P_B_Cr_Del_LoadBalancer.Height - B_Cr_LoadBalancer.Height) / 2;
            B_Del_LoadBalancer.Left = (P_B_Cr_Del_LoadBalancer.Width - B_Del_LoadBalancer.Width) / 2 + 50;
            B_Del_LoadBalancer.Top = (P_B_Cr_Del_LoadBalancer.Height - B_Del_LoadBalancer.Height) / 2;
        }
        #endregion
        //Các phương thức chuyển tab
        #region TabControl
        private void TrView_Menu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Parent == null) return;

            switch (e.Node.Name)
            {
                case "Tokens":
                    UnloadPage();
                    LoadTokenPage();
                    PageControl.SelectedTab = TokenPage;
                    break;

                case "Flavors":
                    UnloadPage();
                    LoadFlavorPage();
                    PageControl.SelectedTab = FlavorPage;
                    break;

                case "Images":
                    UnloadPage();
                    LoadImagePage();
                    PageControl.SelectedTab = ImagePage;
                    break;

                case "Instances":
                    UnloadPage();
                    LoadInstancePage();
                    PageControl.SelectedTab = InstancePage;
                    break;

                case "Key Pairs":
                    UnloadPage();
                    LoadKeyPairPage();
                    PageControl.SelectedTab = KeyPairPage;
                    break;

                case "Volumes":
                    UnloadPage();
                    LoadVolumePage();
                    PageControl.SelectedTab = VolumePage;
                    break;

                case "Networks":
                    UnloadPage();
                    LoadNetworkPage();
                    PageControl.SelectedTab = NetworkPage;
                    break;

                case "Routers":
                    UnloadPage();
                    LoadRouterPage();
                    PageControl.SelectedTab = RouterPage;
                    break;

                case "Security Groups":
                    UnloadPage();
                    LoadSecurityGroupPage();
                    PageControl.SelectedTab = SecurityGroupPage;
                    break;

                case "Floating IPs":
                    UnloadPage();
                    LoadFloatingIPPage();
                    PageControl.SelectedTab = FloatingIPPage;
                    break;

                case "Load Balancers":
                    UnloadPage();
                    LoadLoadBalancerPage();
                    PageControl.SelectedTab = LoadBalancerPage;
                    break;
            }
        }
        private void DGV_Net_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string ColSelected = DGV_Net.Columns[e.ColumnIndex].Name;
            if (ColSelected == "Net_Col_Name")
            {
                string name = DGV_Net.Rows[e.RowIndex].Cells[ColSelected].Value?.ToString();
                string id = DGV_Net.Rows[e.RowIndex].Cells[ColSelected].Tag?.ToString();
                string external = DGV_Net.Rows[e.RowIndex].Cells[4].Value?.ToString();
                string[] subnet = (string[])DGV_Net.Rows[e.RowIndex].Cells[2].Tag;
                (string, string[],string) data;
                data.Item1 = id;
                data.Item2 = subnet;
                data.Item3 = external;
                L_Sub_Networks.Text = name;
                L_Sub_Networks.Tag = data;
                UnloadPage();
                LoadSubnetPage();
                PageControl.SelectedTab = SubnetPage;
            }
        }
        private void DGV_Routers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string ColSelected = DGV_Routers.Columns[e.ColumnIndex].Name;
            if (ColSelected == "RT_Col_Name")
            {
                string name = DGV_Routers.Rows[e.RowIndex].Cells[ColSelected].Value?.ToString();
                string id = DGV_Routers.Rows[e.RowIndex].Cells[ColSelected].Tag?.ToString();
                L_In_Router.Text = name;
                L_In_Router.Tag = id;
                UnloadPage();
                LoadRouterPage();
                PageControl.SelectedTab = RouterInterfacePage;
            }
        }
        private void DGV_SecurityGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string ColSelected = DGV_SecurityGroup.Columns[e.ColumnIndex].Name;
            if (ColSelected == "SG_Col_Name")
            {
                string name = DGV_SecurityGroup.Rows[e.RowIndex].Cells[ColSelected].Value?.ToString();
                string id = DGV_SecurityGroup.Rows[e.RowIndex].Cells[2].Value?.ToString();
                L_Rule.Text = "Manage Security Group Rules: " + name;
                L_Rule.Tag = id;
                UnloadPage();
                PageControl.SelectedTab = RulePage;
                LoadRulePage();
            }
        }
        #endregion
        // Các phương thức Load và Unload dữ liệu cho từng trang khi chuyển tab
        #region LoadUnloadPages

        //Load Identity
        #region LoadIdentity
        private void LoadTokenPage()
        {
            P_L_Token.Resize -= P_L_Token_Resize;
            P_B_Token.Resize -= P_B_CNToken_Resize;
            P_L_Token.Resize += P_L_Token_Resize;
            P_B_Token.Resize += P_B_CNToken_Resize;
            RTB_Token.Text = _token;
        }
        private void UnloadTokenPage()
        {
            P_L_Token.Resize -= P_L_Token_Resize;
            P_B_Token.Resize -= P_B_CNToken_Resize;
            RTB_Token.Text = $"";
        }
        #endregion
        //Load Compute
        #region LoadCompute
        private async void LoadFlavorPage()
        {
            P_L_Flavor.Resize -= P_L_Flavor_Resize;
            P_L_Flavor.Resize += P_L_Flavor_Resize;
            DGV_Flavor.Rows.Clear();
            FlavorService flavorService = new FlavorService();
            var result = await flavorService.GetFlavorAsync(_token);

            if (result.Item1)
            {
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<FlavorResponse>(result.Item2);

                    foreach (var f in data.flavors)
                    {
                        int index = DGV_Flavor.Rows.Add(
                            f.name,
                            f.ram,
                            f.disk,
                            f.vcpus
                        );
                        DGV_Flavor.Rows[index].Cells[0].Tag = f.id;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách Flavors thất bại!\n" + result.Item2);
            }
        }

        private void UnloadFlavorPage()
        {
            P_L_Flavor.Resize -= P_L_Flavor_Resize;
            DGV_Flavor.Rows.Clear();
        }
        private async void LoadImagePage()
        {
            P_L_Image.Resize -= P_L_Image_Resize;
            P_L_Image.Resize += P_L_Image_Resize;
            DGV_Image.Rows.Clear();
            ImageService imageService = new ImageService();
            var result = await imageService.GetImageAsync(_token);

            if (result.Item1)
            {
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ImageResponse>(result.Item2);

                    foreach (var f in data.images.OrderBy(x => x.name))
                    {
                        int index = DGV_Image.Rows.Add(
                            f.name,
                            f.status,
                            f.min_ram,
                            f.min_disk,
                            f.visibility,
                            f.is_protected,
                            f.checksum,
                            f.size,
                            f.disk_format,
                            f.container_format,
                            f.owner,
                            f.description
                        );
                        DGV_Image.Rows[index].Cells[0].Tag = f.id;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách Images thất bại!\n" + result.Item2);
            }
        }
        private void UnloadImagePage()
        {
            P_L_Image.Resize -= P_L_Image_Resize;
            DGV_Image.Rows.Clear();
        }
        private async void LoadInstancePage()
        {
            P_L_Instances.Resize -= P_L_Instances_Resize;
            P_B_Cr_Del_Instances.Resize -= P_B_Cr_Del_Instances_Resize;
            P_L_Instances.Resize += P_L_Instances_Resize;
            P_B_Cr_Del_Instances.Resize += P_B_Cr_Del_Instances_Resize;
            DGV_Instances.Rows.Clear();
            InstanceService instanceService = new InstanceService();
            var instanceresponse = await instanceService.GetInstanceAsync(_token);
            if(instanceresponse.Item1)
            {
                var instancedata = Newtonsoft.Json.JsonConvert.DeserializeObject<InstanceResponse>(instanceresponse.Item2);
                foreach(var server in instancedata.servers)
                {
                    List<string> imagename = new List<string>();
                    foreach(var volume in server.volumes_attached)
                    {
                        VolumeService volumeService = new VolumeService();
                        var volumeresponse = await volumeService.GetVolumeAsync(_token, volume.id);
                        if (volumeresponse.Item1)
                        {
                            var volumedata = Newtonsoft.Json.JsonConvert.DeserializeObject<VolumeResponse>(volumeresponse.Item2);
                            imagename.Add(volumedata.volume.volume_image_metadata.image_name);
                        }
                    }
                    string imagenames = string.Join(",",imagename.ToArray());
                    var ipString = string.Join(", ",
                        server.addresses
                        .SelectMany(x => x.Value)
                        .Select(ip => ip.addr)
                    );
                    string flavorname = "";
                    FlavorService flavor = new FlavorService();
                    var flavorresponse = await flavor.GetFlavorAsync(_token,server.flavor.id);
                    if(flavorresponse.Item1)
                    {
                        var flavordata = Newtonsoft.Json.JsonConvert.DeserializeObject<FlavorResponse>(flavorresponse.Item2);
                        flavorname = flavordata.flavor.name;
                    }
                    string task = server.task_state == null ? "None" : server.task_state;
                    string powerstate = "";
                    switch (server.power_state)
                    {
                        case 1:
                            powerstate = "Running";
                            break;
                        case 3:
                            powerstate = "Paused";
                            break;
                        case 4:
                            powerstate = "Shut Down";
                            break;
                        default:
                            powerstate = "Power off";
                            break;

                    }
                    var age = DateTime.UtcNow - server.created;

                    string ageText;

                    if (age.Days > 0)
                    {
                        ageText = $"{age.Days} days";
                    }
                    else
                    {
                        ageText = $"{age.Hours} hours, {age.Minutes} minutes";
                    }
                    int index = DGV_Instances.Rows.Add(
                        false,
                        server.name,
                        imagenames,
                        ipString,
                        flavorname,
                        server.key_name,
                        server.status,
                        server.availability_zone,
                        task,
                        powerstate,
                        ageText
                    );
                    DGV_Instances.Rows[index].Cells[1].Tag = server.id;
                }
            }
        }
        private void UnloadInstancePage()
        {
            P_L_Instances.Resize -= P_L_Instances_Resize;
            P_B_Cr_Del_Instances.Resize -= P_B_Cr_Del_Instances_Resize;
            DGV_Instances.Rows.Clear();
        }
        private async void LoadKeyPairPage()
        {
            P_L_KeyPair.Resize -= P_L_KeyPair_Resize;
            P_B_Cr_Im_De_KeyPair.Resize -= P_B_Cr_Im_De_KeyPair_Resize;
            P_L_KeyPair.Resize += P_L_KeyPair_Resize;
            P_B_Cr_Im_De_KeyPair.Resize += P_B_Cr_Im_De_KeyPair_Resize;
            DGV_KeyPair.Rows.Clear();
            KeyPairService KeyPairService = new KeyPairService();
            var result = await KeyPairService.GetKeyPairAsync(_token);

            if (result.Item1)
            {
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<KeyPairResponse>(result.Item2);

                    foreach (var f in data.keypairs)
                    {
                        DGV_KeyPair.Rows.Add(
                            false,
                            f.keypair.name,
                            "ssh",
                            f.keypair.fingerprint
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách Key Pairs thất bại!\n" + result.Item2);
            }
        }

        private void UnloadKeyPairPage()
        {
            P_L_KeyPair.Resize -= P_L_KeyPair_Resize;
            P_B_Cr_Im_De_KeyPair.Resize -= P_B_Cr_Im_De_KeyPair_Resize;
            DGV_KeyPair.Rows.Clear();
        }
        #endregion
        //Load Volume
        #region LoadVolume
        private async void LoadVolumePage()
        {
            P_L_Volume.Resize -= P_L_Volume_Resize;
            P_B_Cr_De_Volume.Resize -= P_B_Cr_De_Volume_Resize;
            P_L_Volume.Resize += P_L_Volume_Resize;
            P_B_Cr_De_Volume.Resize += P_B_Cr_De_Volume_Resize;
            VolumeService VolumeService = new VolumeService();
            var result = await VolumeService.GetVolumeAsync(_token);

            if (result.Item1)
            {
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<VolumeResponse>(result.Item2);

                    DGV_Volume.Rows.Clear();

                    foreach (var f in data.volumes)
                    {
                        if (f.attachments.Count != 0)
                        {
                            foreach (var a in f.attachments)
                            {
                                InstanceService instanceService = new InstanceService();
                                var instanceResult = await instanceService.GetInstanceAsync(_token, a.server_id);
                                if (instanceResult.Item1)
                                {
                                    var instanceData = Newtonsoft.Json.JsonConvert.DeserializeObject<InstanceResponse>(instanceResult.Item2);
                                    int rowIndex = DGV_Volume.Rows.Add(
                                    false,
                                    f.name == "" || f.name == null ? f.id : f.name,
                                    f.description,
                                    f.size,
                                    f.status,
                                    "-",
                                    f.volume_type,
                                    a.device + " on " + instanceData.server.name,
                                    f.availability_zone,
                                    f.bootable,
                                    f.encrypted.ToString()
                                    );
                                    DGV_Volume.Rows[rowIndex].Cells[1].Tag = f.id;
                                }
                            }
                        }
                        else
                        {
                            int rowIndex = DGV_Volume.Rows.Add(
                            false,
                            f.name == "" || f.name == null ? f.id : f.name,
                            f.description,
                            f.size,
                            f.status,
                            "-",
                            f.volume_type,
                            "-",
                            f.availability_zone,
                            f.bootable,
                            f.encrypted.ToString()
                            );
                            DGV_Volume.Rows[rowIndex].Cells[1].Tag = f.id;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách Volumes thất bại!\n" + result.Item2);
            }
        }
        private void UnloadVolumePage()
        {
            P_L_Volume.Resize -= P_L_Volume_Resize;
            P_B_Cr_De_Volume.Resize -= P_B_Cr_De_Volume_Resize;
            DGV_Volume.Rows.Clear();
        }
        #endregion
        //Load Network
        #region LoadNetwork
        private async void LoadNetworkPage()
        {
            P_L_Networks.Resize -= P_L_Networks_Resize;
            P_B_Cr_Del_Net.Resize -= P_B_Cr_Del_Net_Resize;
            P_L_Networks.Resize += P_L_Networks_Resize;
            P_B_Cr_Del_Net.Resize += P_B_Cr_Del_Net_Resize;
            DGV_Net.Rows.Clear();
            NetworkService NetworkService = new NetworkService();
            var result = await NetworkService.GetNetworkAsync(_token);

            if (result.Item1)
            {
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<NetworkResponse>(result.Item2);
                    
                    foreach (var f in data.networks)
                    {
                        if (f.subnets.Count() > 0)
                        {
                            string subnetsassociate = "";
                            foreach (var s in f.subnets)
                            {
                                SubnetService subnetService = new SubnetService();
                                var subnetResult = await subnetService.GetSubnetAsync(_token, s);

                                if (subnetResult.Item1)
                                {
                                    var subnetData = Newtonsoft.Json.JsonConvert.DeserializeObject<SubnetResponse>(subnetResult.Item2);
                                    subnetsassociate += subnetData.subnet.name + " " + subnetData.subnet.cidr + " \t\n ";
                                }
                            }
                            
                            int index = DGV_Net.Rows.Add(
                                        false,
                                        f.name,
                                        subnetsassociate,
                                        f.shared,
                                        f.external,
                                        f.status,
                                        f.admin_state_up,
                                        "-"
                            );
                            DGV_Net.Rows[index].Cells[1].Tag = f.id;
                            DGV_Net.Rows[index].Cells[2].Tag = f.subnets;
                            if(f.external=="true")
                                DGV_Net.Rows[index].Cells[0].ReadOnly = true;
                        }
                        else
                        {
                            int index = DGV_Net.Rows.Add(
                                false,
                                f.name,
                                "",
                                f.shared,
                                f.external,
                                f.status,
                                f.admin_state_up,
                                "-"
                            );
                            DGV_Net.Rows[index].Cells[1].Tag = f.id;
                            if(f.external == "true")
                                DGV_Net.Rows[index].Cells[0].ReadOnly = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách Networks thất bại!\n" + result.Item2);
            }
        }

        private void UnloadNetworkPage()
        {
            P_L_Networks.Resize -= P_L_Networks_Resize;
            P_B_Cr_Del_Net.Resize -= P_B_Cr_Del_Net_Resize;
            DGV_Net.Rows.Clear();
        }
        private async void LoadSubnetPage()
        {
            P_L_Sub_Networks.Resize -= P_L_Sub_Networks_Resize;
            P_L_Subnet.Resize -= P_L_Subnet_Resize;
            P_B_Cr_Del_Subnets.Resize -= P_B_Cr_Del_Subnets_Resize;
            P_L_Sub_Networks.Resize += P_L_Sub_Networks_Resize;
            P_L_Subnet.Resize += P_L_Subnet_Resize;
            P_B_Cr_Del_Subnets.Resize += P_B_Cr_Del_Subnets_Resize;
            DGV_Subnets.Rows.Clear();
            SubnetService SubnetService = new SubnetService();
            if (L_Sub_Networks.Tag != null)
            {
                (string networkid, string[] subnetids,string external) data = ((string, string[], string))L_Sub_Networks.Tag;
                if(data.external == "true")
                {
                    B_Cr_Subnets.Visible = false;
                    B_Del_Subnets.Visible = false;
                    DGV_Subnets.Columns[0].Visible = false;
                }
                else
                {
                    B_Cr_Subnets.Visible = true;
                    B_Del_Subnets.Visible = true;
                    DGV_Subnets.Columns[0].Visible = true;
                }
                if (data.subnetids == null) return;
                foreach (var subnetid in data.subnetids)
                {
                    var result = await SubnetService.GetSubnetAsync(_token, subnetid);
                    if (result.Item1)
                    {
                        try
                        {
                            var dataresult = Newtonsoft.Json.JsonConvert.DeserializeObject<SubnetResponse>(result.Item2);

                            int rowIndex = DGV_Subnets.Rows.Add(
                                false,
                                dataresult.subnet.name,
                                dataresult.subnet.cidr,
                                dataresult.subnet.ip_version,
                                dataresult.subnet.gateway_ip
                            );
                            DGV_Subnets.Rows[rowIndex].Cells[1].Tag = dataresult.subnet.id;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Lấy danh sách Subnets thất bại!\n" + result.Item2);
                    }
                }
            }
        }
        private void UnloadSubnetPage()
        {
            P_L_Sub_Networks.Resize -= P_L_Sub_Networks_Resize;
            P_L_Subnet.Resize -= P_L_Subnet_Resize;
            P_B_Cr_Del_Subnets.Resize -= P_B_Cr_Del_Subnets_Resize;
            DGV_Subnets.Rows.Clear();
        }

        private async void LoadRouterPage()
        {
            P_L_Routers.Resize -= P_L_Routers_Resize;
            P_B_Cr_Del_Routers.Resize -= P_B_Cr_Del_Routers_Resize;
            P_L_Routers.Resize += P_L_Routers_Resize;
            P_B_Cr_Del_Routers.Resize += P_B_Cr_Del_Routers_Resize;
            DGV_Routers.Rows.Clear();
            RouterService routerService = new RouterService();
            var routerresponse = await routerService.GetRouterAsync(_token);
            if(routerresponse.Item1)
            {
                var routerdatas = Newtonsoft.Json.JsonConvert.DeserializeObject<RouterResponse>(routerresponse.Item2);
                foreach(var data in routerdatas.routers)
                {
                    NetworkService networkService = new NetworkService();
                    var networkresponse = await networkService.GetNetworkAsync(_token,data.external_gateway_info.network_id);
                    if (networkresponse.Item1) {
                        var networkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<NetworkResponse>(networkresponse.Item2);
                        
                        int rowIndex = DGV_Routers.Rows.Add(
                                                        false,
                                                        data.name,
                                                        data.status,
                                                        networkdata.network.name,
                                                        data.admin_state_up,
                                                        "-"
                                                    );
                        DGV_Routers.Rows[rowIndex].Cells[1].Tag = data.id;
                    }
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách routers thất bại!\n" + routerresponse.Item2);
            }
        }

        private void UnloadRouterPage()
        {
            P_L_Routers.Resize -= P_L_Routers_Resize;
            P_B_Cr_Del_Routers.Resize -= P_B_Cr_Del_Routers_Resize;
            DGV_Routers.Rows.Clear();
        }
        private async void LoadInterfacePage()
        {
            P_L_In_Router.Resize -= P_L_In_Router_Resize;
            P_L_Instances.Resize -= P_L_Instances_Resize;
            P_B_Cr_Del_Instances.Resize -= P_B_Cr_Del_Interface_Resize;
            P_L_In_Router.Resize += P_L_In_Router_Resize;
            P_L_Instances.Resize += P_L_Instances_Resize;
            P_B_Cr_Del_Instances.Resize += P_B_Cr_Del_Interface_Resize;
            DGV_Interface.Rows.Clear();
            InterfaceService interfaceService = new InterfaceService();
            string routerid = (string) L_In_Router.Tag;
            var interfaceresponse = await interfaceService.GetInterfaceAsync(_token, routerid);
            if(interfaceresponse.Item1)
            {
                var interfacedata = Newtonsoft.Json.JsonConvert.DeserializeObject<InterfaceResponse>(interfaceresponse.Item2);
                foreach (var port in interfacedata.ports)
                {

                    int index = DGV_Interface.Rows.Add(
                    false,
                    port.id,
                    port.fixed_ips[0].ip_address,
                    port.status,
                    "Internal Interface",
                    port.admin_state_up
                    );
                    DGV_Interface.Rows[index].Cells[2].Tag = port.fixed_ips[0].subnet_id;
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách interface thất bại!\n" + interfaceresponse.Item2);
            }
        }
        private void UnloadInterfacePage()
        {
            P_L_In_Router.Resize -= P_L_In_Router_Resize;
            P_L_Instances.Resize -= P_L_Instances_Resize;
            P_B_Cr_Del_Instances.Resize -= P_B_Cr_Del_Interface_Resize;
            DGV_Interface.Rows.Clear();
        }
        private async void LoadSecurityGroupPage()
        {
            P_L_SecurityGroup.Resize -= P_L_SecurityGroup_Resize;
            P_B_Cr_Del_SecurityGroup.Resize -= P_B_Cr_Del_SecurityGroup_Resize;
            P_L_SecurityGroup.Resize += P_L_SecurityGroup_Resize;
            P_B_Cr_Del_SecurityGroup.Resize += P_B_Cr_Del_SecurityGroup_Resize;
            DGV_SecurityGroup.Rows.Clear();
            SecurityGroupService securityGroupService = new SecurityGroupService();
            var result = await securityGroupService.GetSecurityGroupAsync(_token);
            if(result.Item1)
            {
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<SecurityGroupResponse>(result.Item2);
                foreach (var securitygroup in data.security_groups)
                {
                    int index = DGV_SecurityGroup.Rows.Add(
                        false,
                        securitygroup.name,
                        securitygroup.id,
                        securitygroup.description,
                        securitygroup.shared
                    );
                    if(securitygroup.id == "aa653a78-9a8c-4d17-9a10-507a8e3f2be2")
                    {
                        DGV_SecurityGroup.Rows[index].Cells[0].ReadOnly = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách SecurityGroup thất bại!\n" + result.Item2);
            }
        }

        private void UnloadSecurityGroupPage()
        {
            P_L_SecurityGroup.Resize -= P_L_SecurityGroup_Resize;
            P_B_Cr_Del_SecurityGroup.Resize -= P_B_Cr_Del_SecurityGroup_Resize;
            DGV_SecurityGroup.Rows.Clear();
        }
        private async void LoadRulePage()
        {
            P_L_Rule.Resize -= P_L_Rule_Resize;
            P_B_Cr_Del_Rule.Resize -= P_B_Cr_Del_Rule_Resize;
            P_L_Rule.Resize += P_L_Rule_Resize;
            P_B_Cr_Del_Rule.Resize += P_B_Cr_Del_Rule_Resize;
            DGV_Rule.Rows.Clear();
            RuleService RuleService = new RuleService();
            string sgroupid = L_Rule.Tag.ToString();
            var result = await RuleService.GetRuleAsync(_token, sgroupid);
            if (result.Item1)
            {
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<RuleResponse>(result.Item2);
                foreach (var rule in data.security_group.security_group_rules)
                {
                    string portrange = "Any";
                    if (!string.IsNullOrEmpty(rule.port_range_min) && !string.IsNullOrEmpty(rule.port_range_max) && rule.port_range_min == rule.port_range_max)
                    {
                        portrange = rule.port_range_max;
                    }
                    else if (rule.port_range_min != rule.port_range_max)
                    {
                        string portmin = string.IsNullOrEmpty(rule.port_range_min) ? "None" : rule.port_range_min;
                        string portmax = string.IsNullOrEmpty(rule.port_range_max) ? "None" : rule.port_range_max;
                        portrange = portmin + " - " + portmax;
                    }
                    else
                    {
                        portrange = "Any";
                    }
                    string RemoteSecurityGroup = "-";
                    if (rule.remote_group_id != null)
                    {
                        SecurityGroupService securityGroupService = new SecurityGroupService();
                        var sgroupresult = await securityGroupService.GetSecurityGroupAsync(_token, rule.remote_group_id);
                        if (sgroupresult.Item1)
                        {
                            var sgroupdata = Newtonsoft.Json.JsonConvert.DeserializeObject<SecurityGroupResponse>(sgroupresult.Item2);
                            RemoteSecurityGroup = sgroupdata.security_group.name;

                        }
                    }
                    string remoteiporefix = "-";
                    if(!string.IsNullOrEmpty(rule.remote_ip_prefix))
                    {
                        remoteiporefix = rule.remote_ip_prefix;
                    }
                    else if(rule.remote_group_id != null)
                    {
                        remoteiporefix = "-";
                    }
                    else
                    {
                        if (rule.ethertype == "IPv4") remoteiporefix = "0.0.0.0/0";
                        else remoteiporefix = "::/0";
                    }
                    int index = DGV_Rule.Rows.Add(
                                false,
                                rule.direction,
                                rule.ethertype,
                                rule.protocol == null ? "Any" : rule.protocol.ToString(),
                                portrange,
                                remoteiporefix,
                                RemoteSecurityGroup,
                                rule.description
                            );
                    DGV_Rule.Rows[index].Cells[1].Tag = rule.id;
                }
            }
        }

        private void UnloadRulePage()
        {
            P_L_Rule.Resize -= P_L_Rule_Resize;
            P_B_Cr_Del_Rule.Resize -= P_B_Cr_Del_Rule_Resize;
            DGV_Rule.Rows.Clear();
        }

        private async void LoadFloatingIPPage()
        {
            P_L_IP.Resize -= P_L_IP_Resize;
            P_B_Al_Re_IP.Resize -= P_B_Al_Re_IP_Resize;
            P_L_IP.Resize += P_L_IP_Resize;
            P_B_Al_Re_IP.Resize += P_B_Al_Re_IP_Resize;
            DGV_FlIP.Rows.Clear();
            FloatingIPService FloatingIPService = new FloatingIPService();
            var result =  await FloatingIPService.GetFloatingIPAsync(_token);
            if(result.Item1)
            {
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<FloatingIPService.FloatingIPResponse>(result.Item2);
                    foreach (var f in data.floatingips)
                    {
                        NetworkService networkService = new NetworkService();
                        var networkResult = await networkService.GetNetworkAsync(_token,f.floating_network_id);
                        if (networkResult.Item1)
                        {
                            var networkData = Newtonsoft.Json.JsonConvert.DeserializeObject<NetworkResponse>(networkResult.Item2);

                            int rowIndex = DGV_FlIP.Rows.Add(
                            false,
                            f.floating_ip_address,
                            f.description,
                            f.dns_name,
                            f.dns_domain,
                            f.fixed_ip_address,
                            networkData.network.name,
                            f.status
                            );
                            DGV_FlIP.Rows[rowIndex].Cells[1].Tag = f.id;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách Floating IPs thất bại!\n" + result.Item2);
            }
        }

        private void UnloadFloatingIPPage()
        {
            P_L_IP.Resize -= P_L_IP_Resize;
            P_B_Al_Re_IP.Resize -= P_B_Al_Re_IP_Resize;
            DGV_FlIP.Rows.Clear();
        }

        private void LoadLoadBalancerPage()
        {
            P_L_LoadBalancer.Resize -= P_L_LoadBalancer_Resize;
            P_B_Cr_Del_LoadBalancer.Resize -= P_B_Cr_Del_LoadBalancer_Resize;
            P_L_LoadBalancer.Resize += P_L_LoadBalancer_Resize;
            P_B_Cr_Del_LoadBalancer.Resize += P_B_Cr_Del_LoadBalancer_Resize;
        }
        private void UnloadLoadBalancerPage()
        {
            P_L_LoadBalancer.Resize -= P_L_LoadBalancer_Resize;
            P_B_Cr_Del_LoadBalancer.Resize -= P_B_Cr_Del_LoadBalancer_Resize;
        }
        #endregion

        // Phương thức UnloadPage sẽ được gọi trước khi chuyển sang tab mới, giúp xóa dữ liệu khỏi tab hiện tại để tránh việc dữ liệu cũ vẫn hiển thị khi quay lại tab đó.
        #region UnloadPage
        private void UnloadPage()
        {
            switch(PageControl.SelectedTab.Name)
            {
                case "TokenPage":
                    UnloadTokenPage();
                    break;
                case "FlavorPage":
                    UnloadFlavorPage();
                    break;
                case "ImagePage":
                    UnloadImagePage();
                    break;
                case "InstancePage":
                    UnloadInstancePage();
                    break;
                case "KeyPairPage":
                    UnloadKeyPairPage();
                    break;
                case "VolumePage":
                    UnloadVolumePage();
                    break;
                case "NetworkPage":
                    UnloadNetworkPage();
                    break;
                case "RouterPage":
                    UnloadRouterPage();
                    break;
                case "SecurityGroupPage":
                    UnloadSecurityGroupPage();
                    break;
                case "FloatingIPPage":
                    UnloadFloatingIPPage();
                    break;
                case "LoadBalancerPage":
                    UnloadLoadBalancerPage();
                    break;
                case "SubnetPage":
                    UnloadSubnetPage();
                    break;
                case "RouterInterfacePage":
                    UnloadInterfacePage();
                    break;
                case "RulePage":
                    UnloadRulePage();
                    break;
            }
        }
        #endregion

        #endregion
        // Các phương thức xử lý sự kiện cho các button trên từng trang
        #region ButtonEventHandlers
        private async void B_CNToken_Click(object sender, EventArgs e)
        {
            TokenService token = new TokenService();

            (bool success, string message) result = await token.GetTokenAsync(_username, _password);

            if (result.success)
            {
                _token = result.message;
                RTB_Token.Text = result.message;
            }
            else
            {
                MessageBox.Show("Cập nhật Token thất bại!\n" + result.message);
            }
        }

        private async void B_Create_KeyPair_Click(object sender, EventArgs e)
        {
            string keyName = Interaction.InputBox(
                "Nhập tên KeyPair:",
                "Create KeyPair",
                "keypair1"
            );
          

            if (string.IsNullOrWhiteSpace(keyName))
            {
                MessageBox.Show("Bạn chưa nhập tên!");
                return;
            }

            var key = SSHKeyGeneratorService.GenerateKeyPair();

            var keyPairService = new KeyPairService();
            var result = await keyPairService.PostKeyPairAsync(_token,keyName,key.publicKey);

            if (result.Item1)
            {
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<KeyPairWrapper>(result.Item2);

                    DGV_KeyPair.Rows.Add(
                        false,
                        data.keypair.name,
                        "ssh",
                        data.keypair.fingerprint,
                        data.keypair.public_key
                    );

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Title = "Chọn nơi lưu Private Key";
                    saveFileDialog.Filter = "PEM files (*.pem)|*.pem|All files (*.*)|*.*";
                    saveFileDialog.FileName = "keypair.pem";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = saveFileDialog.FileName;

                        File.WriteAllText(filePath, key.privateKey);

                        MessageBox.Show($"Đã lưu key tại:\n{filePath}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Tạo Key Pairs thất bại!\n" + result.Item2);
            }
        }

        private async void B_Import_KeyPair_Click(object sender, EventArgs e)
        {
            var input = CreateKeyPairDialog.CreateKeyPairForm();

            if (input == null || string.IsNullOrWhiteSpace(input.Value.keyName))
            {
                MessageBox.Show("Chưa nhập dữ liệu!");
                return;
            }

            string keyName = input.Value.keyName;
            string publicKey = input.Value.publicKey;

            var keyPairService = new KeyPairService();
            var result = await keyPairService.PostKeyPairAsync(_token, keyName, publicKey);

            if (result.Item1)
            {
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<KeyPairWrapper>(result.Item2);

                    DGV_KeyPair.Rows.Add(
                        false,
                        data.keypair.name,
                        "ssh",
                        data.keypair.fingerprint,
                        data.keypair.public_key
                    );
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Tạo Key Pairs thất bại!\n" + result.Item2);
            }
        }

        private async void B_Delete_KeyPair_Click(object sender, EventArgs e)
        {
            var selectedRows = DGV_KeyPair.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells[0].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn key nào!");
                return;
            }

            string[] keyname = selectedRows
                .Select(r => r.Cells[1].Value.ToString())
                .ToArray();

            var keyPairService = new KeyPairService();
            var result = await keyPairService.DeleteKeyPairAsync(_token, keyname);

            if (result.Item1)
            {
                foreach (var row in selectedRows)
                {
                    DGV_KeyPair.Rows.Remove(row);
                }
            }
            else
            {
                LoadKeyPairPage();
                MessageBox.Show("Xóa Key Pairs thất bại!\n" + result.Item2);
            }
        }
        private void B_Create_Volume_Click(object sender, EventArgs e)
        {
            CreateVolume volume = new CreateVolume();

            if (volume.ShowDialog() == DialogResult.OK)
            {
                bool result = volume.Result;
                if (result)
                {
                    LoadVolumePage();
                }
            }
        }
        private async void B_Delete_Volume_Click(object sender, EventArgs e)
        {
            var selectedRows = DGV_Volume.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells[0].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn volume nào!");
                return;
            }

            string[] volids = selectedRows
                .Select(r => r.Cells[1].Tag?.ToString())
                .Where(id => !string.IsNullOrEmpty(id))
                .ToArray();

            var volumeService = new VolumeService();
            var result = await volumeService.DeleteVolumeAsync(_token, volids);

            if (result.Item1)
            {
                foreach (var row in selectedRows)
                {
                    DGV_Volume.Rows.Remove(row);
                }
            }
            else
            {
                LoadVolumePage();
                MessageBox.Show("Xóa Volumes thất bại!\n" + result.Item2);
            }
        }
        
        private void DGV_Volume_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void B_AllocateIP_Click(object sender, EventArgs e)
        {
            NetworkService networkService = new NetworkService();
            var networkResult = await networkService.GetNetworkAsync(_token);
            if (networkResult.Item1)
            {
                var networkData = Newtonsoft.Json.JsonConvert.DeserializeObject<NetworkResponse>(networkResult.Item2);
                var pools = networkData.networks
                .Where(n => n.external == "true")
                .Select(n => new { n.id, n.name })
                .ToList();

                var poolNames = pools.Select(p => p.name).ToList();
                var result = AllocateFloatingIPDialog.AllocateIPForm(poolNames);

                if (result != null)
                {
                    var (pool, ip, desc, dnsDomain, dnsName) = result.Value;


                    var selectedPool = pools.FirstOrDefault(p => p.name == pool);
                    string poolId = selectedPool?.id;
                    
                    FloatingIPService floatingipService = new FloatingIPService();
                    if(!string.IsNullOrEmpty(ip))
                    {
                        var checkIPResult = await floatingipService.PostFloatingIPAsync(_token, poolId, ip);
                        if (!checkIPResult.Item1)
                        {
                            MessageBox.Show("Địa chỉ IP không hợp lệ hoặc đã được sử dụng!\n" + checkIPResult.Item2);
                            return;
                        }
                    }
                    else
                    {
                        var allocateResult = await floatingipService.PostFloatingIPAsync(_token, poolId, null,result?.desc, result?.dnsDomain, result?.dnsName);
                        if (allocateResult.Item1)
                        {
                            MessageBox.Show("Allocate Floating IP thành công!");
                            LoadFloatingIPPage();
                        }
                        else
                        {
                            MessageBox.Show("Allocate Floating IP thất bại!\n" + allocateResult.Item2);
                        }
                    }
                }
            }
        }

        private async void B_ReleaseIP_Click(object sender, EventArgs e)
        {
            var selectedRows = DGV_FlIP.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells[0].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn floating id nào!");
                return;
            }

            string[] ids = selectedRows
                .Select(r => r.Cells[1].Tag?.ToString())
                .Where(id => !string.IsNullOrEmpty(id))
                .ToArray();

            var FloatingipService = new FloatingIPService();
            var result = await FloatingipService.DeleteFloatingIPAsync(_token, ids);

            if (result.Item1)
            {
                foreach (var row in selectedRows)
                {
                    DGV_FlIP.Rows.Remove(row);
                }
            }
            else
            {
                LoadFloatingIPPage();
                MessageBox.Show("Xóa FloatingIP thất bại!\n" + result.Item2);
            }
        }

        private async void B_Cr_Net_Click(object sender, EventArgs e)
        {
            var networkresult = CreateNetworkDialog.CreateNetworkForm();
            if(networkresult != null)
            {
                var inputnetwork = networkresult.Value;
                NetworkService networkservice = new NetworkService();
                var networkresponse = await networkservice.PostNetworkAsync(_token, inputnetwork.networkName, inputnetwork.enableAdmin);
                if (networkresponse.Item1)
                {
                    var networkdata = Newtonsoft.Json.JsonConvert.DeserializeObject<NetworkResponse>(networkresponse.Item2);

                    if (inputnetwork.createSubnet == true)
                    {
                        var subnetresult = CreateSubnetDialog.CreateSubnetForm();
                        if (subnetresult != null)
                        {
                            var inputsubnet = subnetresult.Value;
                            SubnetService subnetservice = new SubnetService();
                            var subnetresponse = await subnetservice.PostSubnetAsync(_token, inputsubnet.subnetName, inputsubnet.networkAddress, networkdata.network.id, inputsubnet.ipVersion, inputsubnet.gateway);
                            if (subnetresponse.Item1)
                            {
                                LoadNetworkPage();
                            }
                            else
                            {
                                MessageBox.Show("Tạo subnet thất bại!\n" + subnetresponse.Item2);
                                LoadNetworkPage();
                            }
                        }
                    }
                    else
                    {
                        LoadNetworkPage();
                    }
                }
                else
                {
                    MessageBox.Show("Tạo network thất bại!\n" + networkresponse.Item2);
                }

            }
        }

        private async void B_Cr_Subnets_Click(object sender, EventArgs e)
        {
            var result = CreateSubnetDialog.CreateSubnetForm();
            if(result!= null)
            {
                (string subname, string cidr, string ipver, string gateway) input = result.Value;
                (string networkid, string[] subnetids, string external) data = ((string, string[], string))L_Sub_Networks.Tag;
                SubnetService subnetService = new SubnetService();
                var subnetresult = await subnetService.PostSubnetAsync(_token, input.subname, input.cidr, data.networkid, input.ipver, input.gateway);
                if (subnetresult.Item1)
                {
                    var resultdata = Newtonsoft.Json.JsonConvert.DeserializeObject<SubnetResponse>(subnetresult.Item2);

                    int rowIndex = DGV_Subnets.Rows.Add(
                                false,
                                resultdata.subnet.name,
                                resultdata.subnet.cidr,
                                resultdata.subnet.ip_version,
                                resultdata.subnet.gateway_ip
                            );
                    DGV_Subnets.Rows[rowIndex].Cells[1].Tag = resultdata.subnet.id;
                }
                else
                {
                    MessageBox.Show("Tạo subnet thất bại!\n" + subnetresult.Item2);
                }
            }
        }
        #endregion

        private async void B_Del_Subnets_Click(object sender, EventArgs e)
        {
            var selectedRows = DGV_Subnets.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells[0].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn subnet nào!");
                return;
            }

            string[] ids = selectedRows
                .Select(r => r.Cells[1].Tag?.ToString())
                .Where(id => !string.IsNullOrEmpty(id))
                .ToArray();

            var SubnetService = new SubnetService();
            var result = await SubnetService.DeleteSubnetAsync(_token, ids);

            if (result.Item1)
            {
                foreach (var row in selectedRows)
                {
                    DGV_Subnets.Rows.Remove(row);
                }
            }
            else
            {
                LoadSubnetPage();
                MessageBox.Show("Xóa subnet thất bại!\n" + result.Item2);
            }
        }

        private async void B_Del_Net_Click(object sender, EventArgs e)
        {
            var selectedRows = DGV_Net.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells[0].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn network nào!");
                return;
            }

            string[] ids = selectedRows
                .Select(r => r.Cells[1].Tag?.ToString())
                .Where(id => !string.IsNullOrEmpty(id))
                .ToArray();

            var NetworkService = new NetworkService();
            var result = await NetworkService.DeleteNetworkAsync(_token, ids);

            if (result.Item1)
            {
                foreach (var row in selectedRows)
                {
                    DGV_Net.Rows.Remove(row);
                }
            }
            else
            {
                LoadSubnetPage();
                MessageBox.Show("Xóa subnet thất bại!\n" + result.Item2);
            }
        }

        private async void B_Cr_Routers_Click(object sender, EventArgs e)
        {
            var result = await CreateRouterDialog.CreateRouterForm(_token);
            if(result!=null)
            {
                var routerdata = result.Value;
                RouterService routerService = new RouterService();
                var routerresponse = await routerService.PostRouterAsync(_token, routerdata.routerName,routerdata.adminState,routerdata.externalNetId);
                if(routerresponse.Item1)
                {
                    LoadRouterPage();
                }
                else
                {
                    MessageBox.Show("Tạo router thất bại!\n" + routerresponse.Item2);
                }
            }
        }

        private async void B_Del_Routers_Click(object sender, EventArgs e)
        {
            var selectedRows = DGV_Routers.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells[0].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn router nào!");
                return;
            }

            string[] ids = selectedRows
                .Select(r => r.Cells[1].Tag?.ToString())
                .Where(id => !string.IsNullOrEmpty(id))
                .ToArray();

            var RouterService = new RouterService();
            var result = await RouterService.DeleteRouterAsync(_token, ids);

            if (result.Item1)
            {
                foreach (var row in selectedRows)
                {
                    DGV_Routers.Rows.Remove(row);
                }
            }
            else
            {
                LoadRouterPage();
                MessageBox.Show("Xóa router thất bại!\n" + result.Item2);
            }
        }

        private async void B_Cr_Interface_Click(object sender, EventArgs e)
        {
            List<(string,string)> combobox= new List<(string, string)>();
            HashSet<string> existingSubnetIds = new HashSet<string>();
            foreach (DataGridViewRow row in DGV_Interface.Rows)
            {
                if (row.Cells[2].Tag != null)
                {
                    existingSubnetIds.Add(row.Cells[2].Tag.ToString());
                }
            }
            NetworkService NetworkService = new NetworkService();
            var result = await NetworkService.GetNetworkAsync(_token);

            if (result.Item1)
            {
                var dataresult = Newtonsoft.Json.JsonConvert.DeserializeObject<NetworkResponse>(result.Item2);

                foreach (var network in dataresult.networks)
                {
                    if (network.external == "true") continue;

                    string netname = network.name;
                    string[] subids = network.subnets;

                    foreach (var subid in subids)
                    {
                        if (existingSubnetIds.Contains(subid))
                        {
                            continue;
                        }

                        SubnetService subnetService = new SubnetService();
                        var result1 = await subnetService.GetSubnetAsync(_token, subid);

                        if (result1.Item1)
                        {
                            var dataresult1 = Newtonsoft.Json.JsonConvert.DeserializeObject<SubnetResponse>(result1.Item2);
                            combobox.Add((dataresult1.subnet.id, netname + ": " + dataresult1.subnet.cidr));
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách Subnets thất bại!\n" + result.Item2);
                return;
            }

            if (combobox.Count == 0)
            {
                MessageBox.Show("Không còn Subnet nào khả dụng để thêm.");
                return;
            }

            var interfaceData = CreateInterfaceDialog.AddInterfaceForm(combobox);

            if (interfaceData != null)
            {
                string selectedsubnetid = interfaceData.Value.selectedSubnetid;
                string ip = interfaceData.Value.ipAddress;
                string routerid = (string)L_In_Router.Tag;
                InterfaceService interfaceService = new InterfaceService();
                var interfaceresult = await interfaceService.PostInterfaceAsync(_token, selectedsubnetid, routerid,ip);
                if (interfaceresult.Item1)
                {
                    var interfacedata = Newtonsoft.Json.JsonConvert.DeserializeObject<InterfaceResponse>(interfaceresult.Item2);
                    LoadInterfacePage();
                }
            }
        }

        private async void B_Del_Interface_Click(object sender, EventArgs e)
        {
            var selectedRows = DGV_Interface.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells[0].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn interface nào!");
                return;
            }

            string[] ids = selectedRows
                .Select(r => r.Cells[2].Tag?.ToString())
                .Where(id => !string.IsNullOrEmpty(id))
                .ToArray();
            
            string routerid = (string)L_In_Router.Tag;

            var InterfaceService = new InterfaceService();
            var result = await InterfaceService.DeleteInterfaceAsync(_token, ids, routerid);

            if (result.Item1)
            {
                foreach (var row in selectedRows)
                {
                    DGV_Interface.Rows.Remove(row);
                }
            }
            else
            {
                LoadInterfacePage();
                MessageBox.Show("Xóa interface thất bại!\n" + result.Item2);
            }
        }

        private async void B_Cr_Rule_Click(object sender, EventArgs e)
        {
            SecurityGroupService securityGroupService = new SecurityGroupService();
            var result = await securityGroupService.GetSecurityGroupAsync(_token);
            if (result.Item1)
            {
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<SecurityGroupResponse>(result.Item2);
                string securityname = L_Rule.Text.Split(':')[1].Trim();
                string securityid = L_Rule.Tag.ToString();
                AddRule addRule = new AddRule(data.security_groups,securityname,securityid);

                if (addRule.ShowDialog() == DialogResult.OK)
                {
                    bool addresult = addRule.Result;
                    if (addresult)
                    {
                        LoadRulePage();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách SecurityGroup thất bại!\n" + result.Item2);
            }

            
        }

        private async void B_Del_Rule_Click(object sender, EventArgs e)
        {
            var selectedRows = DGV_Rule.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells[0].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn rule nào!");
                return;
            }

            string[] ids = selectedRows
                .Select(r => r.Cells[1].Tag?.ToString())
                .Where(id => !string.IsNullOrEmpty(id))
                .ToArray();

            var RuleService = new RuleService();
            var result = await RuleService.DeleteRuleAsync(_token, ids);

            if (result.Item1)
            {
                foreach (var row in selectedRows)
                {
                    DGV_Rule.Rows.Remove(row);
                }
            }
            else
            {
                LoadRulePage();
                MessageBox.Show("Xóa Rule thất bại!\n" + result.Item2);
            }
        }

        private async void B_Cr_SecurityGroup_Click(object sender, EventArgs e)
        {
            var sg = CreateSecurityGroupDialog.CreateSecurityGroupForm();

            if (sg != null)
            {
                var data = sg.Value;
                SecurityGroupService securityGroupService = new SecurityGroupService();
                var response = await securityGroupService.PostSecurityGroupAsync(_token, data.name, data.description);
                if(response.Item1)
                {
                    LoadSecurityGroupPage();
                }
                else
                {
                    MessageBox.Show("Tạo SecurityGroup thất bại!\n" + response.Item2);
                }
            }
        }

        private async void B_Del_SecurityGroup_Click(object sender, EventArgs e)
        {
            var selectedRows = DGV_SecurityGroup.Rows
                .Cast<DataGridViewRow>()
                .Where(r => Convert.ToBoolean(r.Cells[0].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Chưa chọn securitygroup nào!");
                return;
            }

            string[] ids = selectedRows
                .Select(r => r.Cells[2].Value?.ToString())
                .Where(id => !string.IsNullOrEmpty(id))
                .ToArray();

            var SecurityGroupService = new SecurityGroupService();
            var result = await SecurityGroupService.DeleteSecurityGroupAsync(_token, ids);

            if (result.Item1)
            {
                foreach (var row in selectedRows)
                {
                    DGV_SecurityGroup.Rows.Remove(row);
                }
            }
            else
            {
                LoadSecurityGroupPage();
                MessageBox.Show("Xóa SecurityGroup thất bại!\n" + result.Item2);
            }
        }

        private void B_Cr_Instances_Click(object sender, EventArgs e)
        {
            CreateInstance createInstance = new CreateInstance();

            if (createInstance.ShowDialog() == DialogResult.OK)
            {
                bool addresult = createInstance.Result;
                if (addresult)
                {
                    LoadInstancePage();
                }
            }
        }

        private void B_Del_Instances_Click(object sender, EventArgs e)
        {

        }
    }
}
