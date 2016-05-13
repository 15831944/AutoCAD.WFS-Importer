using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinzDataGrabber
{
    public class WFS_Provider
    {
        static readonly string apiKey = "b96d858dc1f543bab7926bc3197f75f7";
        public virtual string ApiKey
        {
            get { return apiKey; }
        }
        static readonly string serverUrl = "http://data.linz.govt.nz/services";
        public virtual string ServerUrl
        {
            get { return serverUrl; }
        }
        static readonly string coordinateSystem = "SRSName=EPSG:2193";
        public virtual string CoordinateSystem
        {
            get { return coordinateSystem; }
        }

        /// <summary>
        /// Url creation method
        /// </summary>
        /// <param name="layer">Layer name of the data source</param>
        /// <param name="lat">Latitude(WGS84)</param>
        /// <param name="lng">Longitude(WGS84)</param>
        /// <param name="size">Size of the bounding box(in meters)</param>
        /// <returns>Returns the url for retrieving the XML file that contains </returns>
        public virtual string WfsRequestUrl(string layer, double lat, double lng, double size)
        {
            List<double> boxpoints = BoundingBoxPoints(lat, lng, size);
            string key = apiKey;
            string syntax = string.Format("{0};key={1}/wfs?REQUEST=GetFeature&typeNames={2}&BBOX={3},{4},{5},{6}&{7}",
                                          serverUrl, key, layer, boxpoints[0], boxpoints[1], boxpoints[2], boxpoints[3], coordinateSystem);
            return syntax;
        }
        /// <summary>
        /// Creates bounding box of the selected area based on latlng and size(meters)
        /// </summary>
        /// <param name="lat">latitude</param>
        /// <param name="lng">longitude</param>
        /// <param name="size">Of bounding box(meters)</param>
        /// <returns>List of coordinates of the bounding box in order of x1, y1, x2, y2 </returns>
        public virtual List<double> BoundingBoxPoints(double lat, double lng, double size)
        {
            List<double> boxpoints = new List<double>();
            size = size * 0.00001; //Converts size to 'WGS84 meters'
            double x1 = lat - size;
            double y1 = lng - size;
            double x2 = lat + size;
            double y2 = lng + size;
            boxpoints.Add(x1);
            boxpoints.Add(y1);
            boxpoints.Add(x2);
            boxpoints.Add(y2);
            return boxpoints;
        }
        /// <summary>
        /// Gets a single parcel data into ParcelData obj from the node of the main xml file
        /// </summary>
        /// <param name="element">Parcel node of the main XML file</param>
        /// <returns>ParcelData obj</returns>
        public virtual XmlWfsData GetParcelDataFromXml(System.Xml.Linq.XElement element)
        {
            string id = "";
            string appellation = "";
            string affectedSurvey = "";
            string postString = "";
            List<string> positionlist = new List<string>();
            XNamespace datagovt = "http://data.linz.govt.nz";
            XNamespace gml = "http://www.opengis.net/gml/3.2";
            try
            {
                XElement layerData = element.Element(datagovt + "layer-772");
                id = layerData.Element(datagovt + "id").Value;
                appellation = layerData.Element(datagovt + "appellation").Value;
                affectedSurvey = layerData.Element(datagovt + "affected_surveys").Value;
                postString = layerData.Element(datagovt + "shape")
                                                .Element(gml + "MultiSurface").Element(gml + "surfaceMember").Element(gml + "Polygon")
                                                .Element(gml + "exterior").Element(gml + "LinearRing").Element(gml + "posList").Value;
                positionlist = postString.Split(' ').ToList();
            }
            catch
            {
            }
            XmlWfsData data = new XmlWfsData(id, appellation, affectedSurvey, positionlist);
            return data;
        }
        /// <summary>
        /// Downloads the XML data from the WFS request url
        /// </summary>
        /// <param name="url">Url to get the xml file</param>
        /// <returns>XML file containing the data</returns>
        public virtual XDocument GetXML(string url)
        {
            WebRequest request;
            WebResponse response;
            XDocument xdoc = null;
            try
            {
                request = WebRequest.Create(url);
                response = request.GetResponse();
                xdoc = XDocument.Load(response.GetResponseStream());
            }
            catch (Exception e)
            {
            }
            return xdoc;
        }
        /// <summary>
        /// Generates the data from the address
        /// </summary>
        /// <param name="layer">layer name of the data: </param>
        /// <param name="lat"></param>
        /// <param name="lng"></param>
        /// <param name="size"></param>
        public virtual void DrawXmlData(string layer, double lat, double lng, double size)
        {
            XmlWfsData parcel;
            string url = WfsRequestUrl(layer, lat, lng, size);
            XDocument xmlData = GetXML(url);
            XNamespace wfs = "http://www.opengis.net/wfs/2.0";
            foreach (XElement element in xmlData.Descendants(wfs + "member"))
            {
                parcel = GetParcelDataFromXml(element);
                AutoCAD_Methods.DrawPlineFromList(parcel.PosList);
            }
        }
    }

}
