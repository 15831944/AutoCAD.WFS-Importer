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


namespace WFSImporter
{
    public partial class MainUI : Form
    {
        public MainUI()
        {
            InitializeComponent();
            apiKeyTxtBox.Text = WFSImporter.Properties.Settings.Default.userLinzApiKey;
            chchApiKeyTxtBx.Text = WFSImporter.Properties.Settings.Default.userChchApiKey;
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
                LoadProvider(latD, lngD, sizeD);
                MessageBox.Show("Completed");
                AutoCAD_Methods.ZoomExtents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR: " + ex.Message);
            }
        }

        private void LoadProvider(double lat, double lng, double size)
        {
            if(layerListCmboBx.SelectedItem.ToString() == "Linz Parcel")
            {
                LinzParcel_WFS linzParcel = new LinzParcel_WFS();
                linzParcel.DrawXmlData(lat, lng, size);
            }
            if (layerListCmboBx.SelectedItem.ToString() == "Canterburry Contours")
            {
                double latNztm = new double();
                double LngNztm = new double();
                NZGD2000_NZTM.geod_nztm(AngleConvertion.Deg2Rad(lat), AngleConvertion.Deg2Rad(lng), ref latNztm, ref LngNztm);
                Cantebury_Maps.ChCh7671_WFS chch7671 = new Cantebury_Maps.ChCh7671_WFS();
                chch7671.DrawXmlData(latNztm, LngNztm, size);
                //Cantebury_Maps.ChCh7675_WFS chch7675 = new Cantebury_Maps.ChCh7675_WFS();
                //chch7675.DrawXmlData(lat, lng, size);
                Cantebury_Maps.ChCh7676_WFS chch7676 = new Cantebury_Maps.ChCh7676_WFS();
                chch7676.DrawXmlData(latNztm, LngNztm, size);
                Cantebury_Maps.ChCh7677_WFS chch7677 = new Cantebury_Maps.ChCh7677_WFS();
                chch7677.DrawXmlData(latNztm, LngNztm, size);
                Cantebury_Maps.ChCh7678_WFS chch7678 = new Cantebury_Maps.ChCh7678_WFS();
                chch7678.DrawXmlData(latNztm, LngNztm, size);
                Cantebury_Maps.ChCh7682_WFS chch7682 = new Cantebury_Maps.ChCh7682_WFS();
                chch7682.DrawXmlData(latNztm, LngNztm, size);
                Cantebury_Maps.ChCh8165_WFS chch8165 = new Cantebury_Maps.ChCh8165_WFS();
                chch8165.DrawXmlData(latNztm, LngNztm, size);
            }

        }
        private void getApiLink_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"http://www.linz.govt.nz/data/linz-data-service/guides-and-documentation/creating-an-api-key");       
        }

        private void MainUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            WFSImporter.Properties.Settings.Default.userLinzApiKey = apiKeyTxtBox.Text;
            WFSImporter.Properties.Settings.Default.Save();
        }

        private void apiKeyTxtBox_TextChanged(object sender, EventArgs e)
        {
            WFSImporter.Properties.Settings.Default.userLinzApiKey = apiKeyTxtBox.Text;
        }

        private void chchApiLabel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://id.koordinates.com/register/?scope=user_id&state=eyJjc3JmdG9rZW4iOiIxcFJLMmtPQXhqQWJydHR5d2llRGhkQXRGMFJQYnVmTyIsIndhcmVob3VzZV9pZCI6NzQsIm5leHQiOiIvc2VhcmNoLz9xPWFwaSJ9%3A1b1rdk%3A9NbZAUbe7AGd1v34dj6lVowCTJs&redirect_uri=https%3A%2F%2Fdata.canterburymaps.govt.nz%2Flogin%2Foauth%2Fcallback%2F&response_type=code&client_id=ce0d6d9f08728a89d9092b1fe52921");
        }

        private void chchApiKeyTxtBx_TextChanged(object sender, EventArgs e)
        {
            WFSImporter.Properties.Settings.Default.userChchApiKey = chchApiKeyTxtBx.Text;
        }
    }
}
