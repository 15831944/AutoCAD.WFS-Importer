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
        public MainUI()
        {
            InitializeComponent();
            WFS_methods.apiKey = apiKeyTxtBox.Text;
            layerListCmboBx.SelectedIndex = 0;
        }        


        private void address_TxtBx_Leave(object sender, EventArgs e)
        {
            string coordinates = Geocoding.GeocodeAddress(address_TxtBx.Text);
            List<string> latlng = coordinates.Split(',').ToList();
            coordLat_TxtBx.Text = latlng[0];
            coordLng_TxtBx.Text = latlng[1];
        }

        private void getData_Btn_Click(object sender, EventArgs e)
        {
            string lat = coordLat_TxtBx.Text;
            string lng = coordLng_TxtBx.Text;
            
            try
            {
                double latD = double.Parse(lat);
                double lngD = double.Parse(lng);
                double sizeD = double.Parse(size_TxtBx.Text);
                LinzParcel_WFS linzParcel = new LinzParcel_WFS();
                linzParcel.DrawXmlData("layer-772", latD, lngD, sizeD);
                MessageBox.Show("Completed");
                AutoCAD_Methods.ZoomExtents();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: Check if coordinate values and bounding box are correct.");
                MessageBox.Show(ex.Message);
            }
            
        }

        private void getApiLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.linz.govt.nz/data/linz-data-service/guides-and-documentation/creating-an-api-key");       
        }
    }
}
