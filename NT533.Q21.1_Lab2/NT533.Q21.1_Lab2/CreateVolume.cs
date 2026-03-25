using Newtonsoft.Json.Linq;
using NT533.Q21._1_Lab2.Compute;
using NT533.Q21._1_Lab2.Volume;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NT533.Q21._1_Lab2.Compute.FlavorService;
using static NT533.Q21._1_Lab2.Compute.ImageService;
using static NT533.Q21._1_Lab2.Compute.InstanceService;
using static NT533.Q21._1_Lab2.Compute.KeyPairService;
using static NT533.Q21._1_Lab2.Volume.AvailabilityZoneService;
using static NT533.Q21._1_Lab2.Volume.VolumeService;

namespace NT533.Q21._1_Lab2
{
    public partial class CreateVolume : Form
    {
        VolumeResponse volumelist = null;
        string selectedVolumeSource = "";
        public bool Result { get; private set; }
        public CreateVolume()
        {
            InitializeComponent();
            LoadVolume();
        }
        private async void LoadVolume()
        {
            GetVolumeList();
            LoadAZone();
        }
        private async void LoadAZone()
        {
            AvailabilityZoneService AvailabilityZoneService = new AvailabilityZoneService();
            var result = await AvailabilityZoneService.GetAvailabilityZoneAsync(Main._token);

            if (result.Item1)
            {
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<AvailabilityZoneResponse>(result.Item2);

                    cB_AZone.Items.Clear();

                    foreach (var f in data.availabilityZoneInfo)
                    {
                        if (f.zoneState.available == true)
                            cB_AZone.Items.Add(f.zoneName);
                    }
                    cB_AZone.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách AvailabilityZone thất bại!\n" + result.Item2);
            }
        }
        private async void GetVolumeList()
        {
            volumelist = new VolumeResponse();
            volumelist.volumes = new List<VolumeService.Volume>();
            VolumeService VolumeService = new VolumeService();
            var result = await VolumeService.GetVolumeAsync(Main._token);

            if (result.Item1)
            {
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<VolumeResponse>(result.Item2);

                    foreach (var f in data.volumes)
                    {
                        if (f.attachments.Count == 0)
                        {
                            volumelist.volumes.Add(f);
                        }
                    }
                    LoadVolumeSource();
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
        private async void LoadVolumeSource()
        {
            cB_VolumeSource.Items.Clear();
            cB_VolumeSource.Items.Add("No source, empty volume");
            cB_VolumeSource.Items.Add("Image");
            if(volumelist != null)
            {
                cB_VolumeSource.Items.Add("Volume");
            }
            cB_VolumeSource.SelectedIndex = 0;
            tB_Size.Text = "1";
            L_SourceType.Visible = false;
            cB_SourceType.Visible = false;
        }
        private async void LoadImageSourceType()
        {
            ImageService imageService = new ImageService();
            var result1 = await imageService.GetImageAsync(Main._token);
            if (result1.Item1)
            {
                try
                {
                    var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ImageResponse>(result1.Item2);

                    cB_SourceType.Items.Clear();
                    cB_SourceType.Items.Add("Choose an image");
                    foreach (var f in data.images.OrderBy(x => x.name))
                    {
                        cB_SourceType.Items.Add(f.name);
                    }
                    cB_SourceType.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Lấy danh sách Images thất bại!\n" + result1.Item2);
            }
        }
        private async void LoadVolumeSourceType()
        {
            cB_SourceType.Items.Clear();
            cB_SourceType.Items.Add("Choose an volume");
            foreach (var f in volumelist.volumes)
            {
                cB_SourceType.Items.Add(f.name == "" || f.name == null ? f.id : f.name);
            }
            cB_SourceType.SelectedIndex = 0;
        }
        private async void B_Cr_CVolume_Click(object sender, EventArgs e)
        {
            string size = null, availability_zone = null, source_volid = null, description = null, name = null, imageRef = null;
            size = tB_Size.Text;
            availability_zone = cB_AZone.SelectedItem.ToString();
            if(rtB_Description.Text != "" && rtB_Description.Text != null) description = rtB_Description.Text;
            if(tB_VoName.Text != "" && tB_VoName.Text != null) name = tB_VoName.Text;
            if(selectedVolumeSource == "Volume")
            {
                int selectindex = cB_SourceType.SelectedIndex;
                if (selectindex != 0)
                {
                    source_volid = volumelist.volumes[selectindex - 1].id;
                }
            }
            if(selectedVolumeSource == "Image")
            {
                int selectindex = cB_SourceType.SelectedIndex;
                if (selectindex != 0)
                {
                    ImageService imageService = new ImageService();
                    var result1 = await imageService.GetImageAsync(Main._token);
                    if (result1.Item1)
                    {
                        try
                        {
                            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ImageResponse>(result1.Item2);
                            foreach (var f in data.images.OrderBy(x => x.name))
                            {
                                if (f.name == cB_SourceType.SelectedItem.ToString())
                                {
                                    imageRef = f.id;
                                    break;
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
                        MessageBox.Show("Lấy danh sách Images thất bại!\n" + result1.Item2);
                    }
                }
            }
            var VolumeService = new VolumeService();
            var result = await VolumeService.PostVolumeAsync(Main._token, size, availability_zone, source_volid, description, name, imageRef);
            if (result.Item1)
            {
                Result = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Tạo Volume thất bại!\n" + result.Item2);
            }
        }
        private void B_C_CVolume_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cB_VolumeSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cB_VolumeSource.SelectedItem.ToString() == "Image")
            {
                selectedVolumeSource = "Image";
                L_SourceType.Visible = true;
                L_SourceType.Text = "Use image as a source";
                cB_SourceType.Visible = true;
                L_AZone.Visible = true;
                cB_AZone.Visible = true;
                LoadImageSourceType();
            }
            else if(cB_VolumeSource.SelectedItem.ToString() == "Volume")
            {
                selectedVolumeSource = "Volume";
                L_SourceType.Visible = true;
                L_SourceType.Text = "Use volume as a source";
                cB_SourceType.Visible = true;
                LoadVolumeSourceType();
                L_AZone.Visible = false;
                cB_AZone.Visible = false;
            }
            else
            {
                selectedVolumeSource = "No source, empty volume";
                L_SourceType.Visible = false;
                cB_SourceType.Visible = false;
                L_AZone.Visible = true;
                cB_AZone.Visible = true;
            }
        }
        private async void cB_SourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedVolumeSource == "Volume")
            {
                int selectindex = cB_SourceType.SelectedIndex;
                if(selectindex==0) return;
                VolumeService.Volume selectedVolume = volumelist.volumes[selectindex - 1];
                if(tB_VoName.Text == "") tB_VoName.Text = selectedVolume.name == "" || selectedVolume.name == null ? selectedVolume.id : selectedVolume.name;
                int size = 0;
                int.TryParse(tB_Size.Text, out size);
                int newsize = selectedVolume.size;
                if (size < newsize) tB_Size.Text = newsize.ToString();
            }
            if (selectedVolumeSource == "Image")
            {
                int selectindex = cB_SourceType.SelectedIndex;
                if (selectindex == 0) return;
                ImageService.Image selectedImage = null;
                ImageService imageService = new ImageService();
                var result1 = await imageService.GetImageAsync(Main._token);
                if (result1.Item1)
                {
                    try
                    {
                        var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ImageResponse>(result1.Item2);
                        foreach (var f in data.images.OrderBy(x => x.name))
                        {
                            if (f.name == cB_SourceType.SelectedItem.ToString())
                            {
                                selectedImage = f;
                                break;
                            }
                        }
                        if (tB_VoName.Text == "") tB_VoName.Text = selectedImage.name == "" || selectedImage.name == null ? selectedImage.id : selectedImage.name;
                        int size = selectedImage.min_disk;
                        if (selectedImage.min_disk==0) size = 1;
                        tB_Size.Text = size.ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi parse JSON: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Lấy danh sách Images thất bại!\n" + result1.Item2);
                }
            }
        }
    }
}
