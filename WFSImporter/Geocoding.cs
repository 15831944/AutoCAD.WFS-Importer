using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WFSImporter
{
    class Geocoding
    {
        /// <summary>
        /// Gets Geocooding of an address from Google.
        /// </summary>
        /// <param name="address">Any street address</param>
        /// <returns>LatLng(WGS84)</returns>
        public static string GeocodeAddress(string address)
        {
            string latlong = "";
            WebRequest request;
            WebResponse response;
            XDocument xdoc;
            string requestParameter = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));
            try
            {
                request = WebRequest.Create(requestParameter);
                response = request.GetResponse();
                xdoc = XDocument.Load(response.GetResponseStream());
                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                XElement coordinates = result.Element("geometry").Element("location");
                XElement lat = coordinates.Element("lat");
                XElement lng = coordinates.Element("lng");
                latlong = string.Format("{0},{1}", lat.Value, lng.Value);
            }
            catch (Exception e)
            {
            }

            return latlong;
        }
    }
}
