using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;


namespace LinzDataGrabber
{
    public partial class MainUI : Form
    {
        ProgressBar progressBar;
        public MainUI()
        {
            InitializeComponent();
            GlobalVariables.LinzParcelApiKey = LinzDataGrabber.Properties.Settings.Default.userLinzApiKey;
            apiKeyTxtBox.Text = GlobalVariables.LinzParcelApiKey;
            layerListCmboBx.SelectedIndex = 0;
        }         
        private void address_TxtBx_Leave(object sender, EventArgs e)
        {
            try
            {
                string coordinates = Geocoding.GeocodeAddress(address_TxtBx.Text);
                List<string> latlng = coordinates.Split(',').ToList();
                coordLat_TxtBx.Text = latlng[0];
                coordLng_TxtBx.Text = latlng[1];
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error : Can't get coordinates of the address.");
            }
        }
        private void getData_Btn_Click(object sender, EventArgs e)
        {
            string lat = coordLat_TxtBx.Text;
            string lng = coordLng_TxtBx.Text;
            double latD, lngD, sizeD;                   
            try
            {
                latD = double.Parse(lat);
                lngD = double.Parse(lng);
                sizeD = double.Parse(size_TxtBx.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: Check if coordinate values and bounding box are correct.");
                return;
            }
            try
            {
                latD = double.Parse(lat);
                lngD = double.Parse(lng);
                sizeD = double.Parse(size_TxtBx.Text);
                LinzParcel_WFS linzParcel = new LinzParcel_WFS();
                linzParcel.DrawXmlData("layer-772", latD, lngD, sizeD);
                MessageBox.Show("Completed");
                AutoCAD_Methods.ZoomExtents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }


        private void getApiLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.linz.govt.nz/data/linz-data-service/guides-and-documentation/creating-an-api-key");       
        }

        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            LinzDataGrabber.Properties.Settings.Default.userLinzApiKey = apiKeyTxtBox.Text;
            LinzDataGrabber.Properties.Settings.Default.Save();
        }
    }
}
