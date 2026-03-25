using NT533.Q21._1_Lab2.Compute;
using NT533.Q21._1_Lab2.Network;
using NT533.Q21._1_Lab2.Volume;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NT533.Q21._1_Lab2.Compute.FlavorService;
using static NT533.Q21._1_Lab2.Compute.ImageService;
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
        public bool Result { get; private set; }
        public CreateInstance()
        {
            InitializeComponent();
            B_Detail_Click(null, null);
            LoadAllowUserToAddRows();
            cB_SelectSource.SelectedIndex = 0;
        }
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
        }
        private void B_LaunchInstance_Click(object sender, EventArgs e)
        {

        }

        private async void B_Detail_Click(object sender, EventArgs e)
        {
            cB_AZ.Items.Clear();
            PageControl.SelectedTab = DetailPage;
            AvailabilityZoneService availabilityZoneService = new AvailabilityZoneService();
            var azres = await availabilityZoneService.GetAvailabilityZoneAsync(Main._token);
            if(azres.Item1)
            {
                var azdata = Newtonsoft.Json.JsonConvert.DeserializeObject<AvailabilityZoneResponse>(azres.Item2);
                foreach (var availabilityZone in azdata.availabilityZoneInfo)
                {
                    if(availabilityZone.zoneState.available == true)
                    {
                        cB_AZ.Items.Add(availabilityZone.zoneName);
                    }
                }
                cB_AZ.SelectedIndex = 0;
            }

        }

        private void B_Source_Click(object sender, EventArgs e)
        {
            PageControl.SelectedTab = SourcePage;
        }

        private async  void B_Flavour_Click(object sender, EventArgs e)
        {
            DGV_Choose_Flavour.Rows.Clear();
            PageControl.SelectedTab = FlavourPage;
            FlavorService flavorService = new FlavorService();
            var flavorres = await flavorService.GetFlavorAsync(Main._token);
            if (flavorres.Item1)
            {
                var flavordata = Newtonsoft.Json.JsonConvert.DeserializeObject<FlavorResponse>(flavorres.Item2);
                foreach(var flavor in flavordata.flavors)
                {
                    DGV_Choose_Flavour.Rows.Add(
                        flavor.id,
                        flavor.name,
                        flavor.vcpus,
                        flavor.ram/1024,
                        flavor.disk,
                        flavor.disk,
                        flavor.ephemeral,
                        flavor.ispublic?"Yes":"No"
                    );
                    
                }
            }
        }

        private async void B_Network_Click(object sender, EventArgs e)
        {
            DGV_Choose_Network.Rows.Clear();
            PageControl.SelectedTab = NetworkPage;
            NetworkService networkservice = new NetworkService();
            var netres = await networkservice.GetNetworkAsync(Main._token);
            if (netres.Item1)
            {
                var netdata = Newtonsoft.Json.JsonConvert.DeserializeObject<NetworkResponse>(netres.Item2);
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
                    if(data.external!= "true")
                    DGV_Choose_Network.Rows.Add(
                        data.id,
                        data.name,
                        subnetass,
                        data.shared,
                        data.admin_state_up,
                        data.status
                        );
                }
            }
        }

        private void B_SecGroup_Click(object sender, EventArgs e)
        {
            PageControl.SelectedTab = SecGroupPage;
        }

        private void B_KeyPair_Click(object sender, EventArgs e)
        {
            PageControl.SelectedTab = KeyPairPage;
        }

        private void B_Configuration_Click(object sender, EventArgs e)
        {
            PageControl.SelectedTab = ConfigurationPage;
        }

        private void B_LoadBalancer_Click(object sender, EventArgs e)
        {
            PageControl.SelectedTab = LoadBalancerPage;
        }

        private void B_CancelCrInstance_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DGV_Choose_Flavour_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_Flavour.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_Flavour.Rows[e.RowIndex];

                // Nếu đã có dòng ở trên
                if (DGV_Choosed_Flavour.Rows.Count > 0)
                {
                    DataGridViewRow oldRow = DGV_Choosed_Flavour.Rows[0];

                    // 🔥 chỉ lấy data, bỏ button
                    int colCount = DGV_Choose_Flavour.Columns.Count - 1;
                    object[] oldData = new object[colCount];

                    for (int i = 0; i < colCount; i++)
                    {
                        oldData[i] = oldRow.Cells[i].Value;
                    }

                    // Xóa bảng trên
                    DGV_Choosed_Flavour.Rows.Clear();

                    // Thêm dòng mới lên trên
                    DGV_Choosed_Flavour.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value,
                        selectedRow.Cells[7].Value
                    );

                    // Xóa dòng đã chọn dưới
                    DGV_Choose_Flavour.Rows.RemoveAt(e.RowIndex);

                    // Thêm lại dòng cũ xuống dưới
                    int index = DGV_Choose_Flavour.Rows.Add(oldData);

                    // Set lại button
                    DGV_Choose_Flavour.Rows[index].Cells[colCount].Value = "Choose";
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
                        selectedRow.Cells[7].Value
                    );

                    // Xóa dưới
                    DGV_Choose_Flavour.Rows.RemoveAt(e.RowIndex); 
                }
            }
        }

        private void DGV_Choosed_Flavour_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra click đúng button
            if (e.RowIndex >= 0 && DGV_Choosed_Flavour.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_Flavour.Rows[e.RowIndex];

                DGV_Choosed_Flavour.Rows.Clear();

                // Copy dữ liệu sang bảng trên
                DGV_Choose_Flavour.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value,
                        selectedRow.Cells[7].Value
                );
            }
        }

        private void DGV_Choose_Network_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_Network.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_Network.Rows[e.RowIndex];

                // Nếu đã có dòng ở trên
                if (DGV_Choosed_Network.Rows.Count > 0)
                {
                    DataGridViewRow oldRow = DGV_Choosed_Network.Rows[0];

                    // 🔥 chỉ lấy data, bỏ button
                    int colCount = DGV_Choose_Network.Columns.Count - 1;
                    object[] oldData = new object[colCount];

                    for (int i = 0; i < colCount; i++)
                    {
                        oldData[i] = oldRow.Cells[i].Value;
                    }

                    // Xóa bảng trên
                    DGV_Choosed_Network.Rows.Clear();

                    // Thêm dòng mới lên trên
                    DGV_Choosed_Network.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value
                    );

                    // Xóa dòng đã chọn dưới
                    DGV_Choose_Network.Rows.RemoveAt(e.RowIndex);

                    // Thêm lại dòng cũ xuống dưới
                    int index = DGV_Choose_Network.Rows.Add(oldData);

                    // Set lại button
                    DGV_Choose_Network.Rows[index].Cells[colCount].Value = "Choose";
                }
                else
                {
                    // Thêm lên trên
                    DGV_Choosed_Network.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value
                    );

                    // Xóa dưới
                    DGV_Choose_Network.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void DGV_Choosed_Network_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra click đúng button
            if (e.RowIndex >= 0 && DGV_Choosed_Network.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_Network.Rows[e.RowIndex];

                DGV_Choosed_Network.Rows.Clear();

                // Copy dữ liệu sang bảng trên
                DGV_Choose_Network.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value
                );
            }
        }

        private async void cB_SelectSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cB_SelectSource.SelectedIndex;
            if(index == 0)
            {
                DGVSourceControl.SelectedTab = ImageSourcePage;
                ImageService imageservice = new ImageService();
                var imageres = await imageservice.GetImageAsync(Main._token);
                if(imageres.Item1)
                {
                    var imagedata = Newtonsoft.Json.JsonConvert.DeserializeObject<ImageResponse>(imageres.Item2);
                    foreach (var image in imagedata.images.OrderBy(x => x.name))
                    {
                        DateTime Datetime = image.updated_at;
                        string Updated = Datetime.ToString("M/d/yy h:mm tt");
                        long size = image.size;
                        double sizeMB = size / (1024.0 * 1024.0);
                        string formatted = sizeMB.ToString("0.00") + " MB";

                        DGV_Choose_ImageSource.Rows.Add(
                        image.id,
                        image.name,
                        image.min_disk,
                        Updated,
                        formatted,
                        image.disk_format,
                        image.visibility
                        );
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
                    foreach(var volume in volumedata.volumes)
                    {
                        if (volume.attachments.Count != 0) continue;
                        if (volume.volume_image_metadata == null) continue;
                        DGV_Choose_VolSource.Rows.Add(
                        volume.id,
                        string.IsNullOrEmpty(volume.name) ? volume.id : volume.name,
                        string.IsNullOrEmpty(volume.description) ? "-" : volume.description,
                        volume.size,
                        volume.volume_image_metadata.disk_format,
                        volume.availability_zone
                        );
                    }
                }
            }
        }

        private void B_DelVol_Yes_Click(object sender, EventArgs e)
        {
            B_DelVol_Yes.BackColor = Color.Silver;
            B_DelVol_No.BackColor = Color.White;
        }

        private void B_DelVol_No_Click(object sender, EventArgs e)
        {
            B_DelVol_Yes.BackColor = Color.White;
            B_DelVol_No.BackColor = Color.Silver;
        }

        private void DGV_Choosed_ImageSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra click đúng button
            if (e.RowIndex >= 0 && DGV_Choosed_ImageSource.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_ImageSource.Rows[e.RowIndex];

                DGV_Choosed_ImageSource.Rows.Clear();

                // Copy dữ liệu sang bảng trên
                DGV_Choose_ImageSource.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value
                );
            }
        }

        private void DGV_Choose_ImageSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_ImageSource.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_ImageSource.Rows[e.RowIndex];

                // Nếu đã có dòng ở trên
                if (DGV_Choosed_ImageSource.Rows.Count > 0)
                {
                    DataGridViewRow oldRow = DGV_Choosed_ImageSource.Rows[0];

                    // 🔥 chỉ lấy data, bỏ button
                    int colCount = DGV_Choose_ImageSource.Columns.Count - 1;
                    object[] oldData = new object[colCount];

                    for (int i = 0; i < colCount; i++)
                    {
                        oldData[i] = oldRow.Cells[i].Value;
                    }

                    // Xóa bảng trên
                    DGV_Choosed_ImageSource.Rows.Clear();

                    // Thêm dòng mới lên trên
                    DGV_Choosed_ImageSource.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value,
                        selectedRow.Cells[6].Value
                    );
                    int cursize = int.Parse(tB_VolSize.Text);
                    int newsize = selectedRow.Cells[2].Value.ToString() == "0" ? 1 : int.Parse(selectedRow.Cells[2].Value.ToString());
                    if (newsize > cursize)
                        tB_VolSize.Text = newsize.ToString();
                    // Xóa dòng đã chọn dưới
                    DGV_Choose_ImageSource.Rows.RemoveAt(e.RowIndex);

                    // Thêm lại dòng cũ xuống dưới
                    int index = DGV_Choose_ImageSource.Rows.Add(oldData);

                    // Set lại button
                    DGV_Choose_ImageSource.Rows[index].Cells[colCount].Value = "Choose";
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
                        selectedRow.Cells[6].Value
                    );
                    int cursize = int.Parse(tB_VolSize.Text);
                    int newsize = selectedRow.Cells[2].Value.ToString() == "0" ? 1 : int.Parse(selectedRow.Cells[2].Value.ToString());
                    if(newsize > cursize)
                    tB_VolSize.Text = newsize.ToString();
                    // Xóa dưới
                    DGV_Choose_ImageSource.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void DGV_Choosed_VolSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra click đúng button
            if (e.RowIndex >= 0 && DGV_Choosed_VolSource.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choosed_VolSource.Rows[e.RowIndex];

                DGV_Choosed_VolSource.Rows.Clear();

                // Copy dữ liệu sang bảng trên
                DGV_Choose_VolSource.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value
                );
            }
        }

        private void DGV_Choose_VolSource_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGV_Choose_VolSource.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                DataGridViewRow selectedRow = DGV_Choose_VolSource.Rows[e.RowIndex];

                // Nếu đã có dòng ở trên
                if (DGV_Choosed_VolSource.Rows.Count > 0)
                {
                    DataGridViewRow oldRow = DGV_Choosed_VolSource.Rows[0];

                    // 🔥 chỉ lấy data, bỏ button
                    int colCount = DGV_Choose_VolSource.Columns.Count - 1;
                    object[] oldData = new object[colCount];

                    for (int i = 0; i < colCount; i++)
                    {
                        oldData[i] = oldRow.Cells[i].Value;
                    }

                    // Xóa bảng trên
                    DGV_Choosed_VolSource.Rows.Clear();

                    // Thêm dòng mới lên trên
                    DGV_Choosed_VolSource.Rows.Add(
                        selectedRow.Cells[0].Value,
                        selectedRow.Cells[1].Value,
                        selectedRow.Cells[2].Value,
                        selectedRow.Cells[3].Value,
                        selectedRow.Cells[4].Value,
                        selectedRow.Cells[5].Value
                    );
                    
                    // Xóa dòng đã chọn dưới
                    DGV_Choose_VolSource.Rows.RemoveAt(e.RowIndex);

                    // Thêm lại dòng cũ xuống dưới
                    int index = DGV_Choose_VolSource.Rows.Add(oldData);

                    // Set lại button
                    DGV_Choose_VolSource.Rows[index].Cells[colCount].Value = "Choose";
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
                        selectedRow.Cells[5].Value
                    );
                    
                    // Xóa dưới
                    DGV_Choose_VolSource.Rows.RemoveAt(e.RowIndex);
                }
            }
        }
    }
}
