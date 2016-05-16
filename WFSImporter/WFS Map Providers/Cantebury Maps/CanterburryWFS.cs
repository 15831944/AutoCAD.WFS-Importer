using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WFSImporter.Cantebury_Maps
{

    class ChCh7678_WFS : WFS_Provider
    {
        private ChCh7678_WFS instance;
        public ChCh7678_WFS GetInstance()
        {
            if (instance == null)
            {
                instance = new ChCh7678_WFS();
            }
            return instance;
        }
        public static string apiKey = WFSImporter.Properties.Settings.Default.userChchApiKey;
        public override string ApiKey
        {
            get
            {
                return apiKey;
            }
        }
        static readonly string serverUrl = "https://data.canterburymaps.govt.nz/services";
        public override string ServerUrl
        {
            get
            {
                return serverUrl;
            }
        }
        static readonly string coordinateSystem = "SRSName=EPSG:2193";
        public override string CoordinateSystem
        {
            get
            {
                return base.CoordinateSystem;
            }
        }
        public override XmlWfsData GetParcelDataFromXml(System.Xml.Linq.XElement element)
        {
            string elevation = "";
            string postString = "";
            List<string> positionlist = new List<string>();
            XNamespace datagovt = "http://data.canterburymaps.govt.nz";
            XNamespace gml = "http://www.opengis.net/gml/3.2";
            try
            {
                XElement layerData = element.Element(datagovt + "layer-7678");
                elevation = layerData.Element(datagovt + "ELEVATION").Value;
                postString = layerData.Element(datagovt + "GEOMETRY")
                                                .Element(gml + "MultiCurve").Element(gml + "curveMember").Element(gml + "LineString").Element(gml + "posList").Value;
                positionlist = postString.Split(' ').ToList();
            }
            catch
            {
            }
            XmlWfsData data = new XmlWfsData(elevation, "", "", "", positionlist);
            return data;
            
        }
        public override void DrawXmlData(double lat, double lng, double size)
        {
            string layer = "layer-7678";
            XmlWfsData parcel;
            string url = WfsRequestUrl(layer, lat, lng, size);
            XDocument xmlData = GetXML(url);
            XNamespace wfs = "http://www.opengis.net/wfs/2.0";
            foreach (XElement element in xmlData.Descendants(wfs + "member"))
            {
                parcel = GetParcelDataFromXml(element);
                AutoCAD_Methods.DrawPlineFrom3PtList("ChchContour", 10, parcel.PosList, Convert.ToDouble(parcel.string1), false);
            }
        }
        public override string WfsRequestUrl(string layer, double lat, double lng, double size)
        {
            List<double> boxpoints = BoundingBoxPoints(lat, lng, size);
            string key = apiKey;
            string syntax = string.Format("{0};key={1}/wfs?REQUEST=GetFeature&typeNames={2}&BBOX={3},{4},{5},{6}",
                                          serverUrl, key, layer, boxpoints[0], boxpoints[1], boxpoints[2], boxpoints[3]);
            return syntax;
        }
        public override List<double> BoundingBoxPoints(double lat, double lng, double size)
        {
            List<double> boxpoints = new List<double>();
            size = (size / 2) * 1; //Converts size to 'WGS84 meters'
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
    }

    class ChCh7676_WFS : ChCh7678_WFS
    {
        static readonly string serverUrl = "https://data.canterburymaps.govt.nz/services";
        public override XmlWfsData GetParcelDataFromXml(System.Xml.Linq.XElement element)
        {
            string elevation = "";
            string postString = "";

            List<string> positionlist = new List<string>();
            XNamespace datagovt = "http://data.canterburymaps.govt.nz";
            XNamespace gml = "http://www.opengis.net/gml/3.2";
            try
            {
                XElement layerData = element.Element(datagovt + "layer-7679");
                elevation = layerData.Element(datagovt + "ELEVATION").Value;
                postString = layerData.Element(datagovt + "GEOMETRY")
                                                .Element(gml + "MultiCurve").Element(gml + "curveMember").Element(gml + "LineString").Element(gml + "posList").Value;
                positionlist = postString.Split(' ').ToList();
            }
            catch
            {
            }
            XmlWfsData data = new XmlWfsData(elevation, "", "", "", positionlist);
            return data;

        }
        public override void DrawXmlData(double lat, double lng, double size)
        {
            string layer = "layer-7679";
            XmlWfsData parcel;
            string url = WfsRequestUrl(layer, lat, lng, size);
            XDocument xmlData = GetXML(url);
            XNamespace wfs = "http://www.opengis.net/wfs/2.0";
            foreach (XElement element in xmlData.Descendants(wfs + "member"))
            {
                parcel = GetParcelDataFromXml(element);
                AutoCAD_Methods.DrawPlineFrom3PtList("ChchContour", 10, parcel.PosList, Convert.ToDouble(parcel.string1), false);
            }
        }
    }
    class ChCh7682_WFS : ChCh7676_WFS
    {
        static readonly string serverUrl = "https://data.canterburymaps.govt.nz/services";
        public override XmlWfsData GetParcelDataFromXml(System.Xml.Linq.XElement element)
        {
            string elevation = "";
            string postString = "";

            List<string> positionlist = new List<string>();
            XNamespace datagovt = "http://data.canterburymaps.govt.nz";
            XNamespace gml = "http://www.opengis.net/gml/3.2";
            try
            {
                XElement layerData = element.Element(datagovt + "layer-7682");
                elevation = layerData.Element(datagovt + "ELEVATION").Value;
                postString = layerData.Element(datagovt + "GEOMETRY")
                                                .Element(gml + "MultiCurve").Element(gml + "curveMember").Element(gml + "LineString").Element(gml + "posList").Value;
                positionlist = postString.Split(' ').ToList();
            }
            catch
            {
            }
            XmlWfsData data = new XmlWfsData(elevation, "", "", "", positionlist);
            return data;

        }
        public override void DrawXmlData(double lat, double lng, double size)
        {
            string layer = "layer-7682";
            XmlWfsData parcel;
            string url = WfsRequestUrl(layer, lat, lng, size);
            XDocument xmlData = GetXML(url);
            XNamespace wfs = "http://www.opengis.net/wfs/2.0";
            foreach (XElement element in xmlData.Descendants(wfs + "member"))
            {
                parcel = GetParcelDataFromXml(element);
                AutoCAD_Methods.DrawPlineFrom3PtList("ChchContour", 10, parcel.PosList, Convert.ToDouble(parcel.string1), false);
            }
        }
    }
    class ChCh7675_WFS : ChCh7676_WFS
    {
        static readonly string serverUrl = "https://data.canterburymaps.govt.nz/services";
        public override XmlWfsData GetParcelDataFromXml(System.Xml.Linq.XElement element)
        {
            string elevation = "";
            string postString = "";

            List<string> positionlist = new List<string>();
            XNamespace datagovt = "http://data.canterburymaps.govt.nz";
            XNamespace gml = "http://www.opengis.net/gml/3.2";
            try
            {
                XElement layerData = element.Element(datagovt + "layer-7675");
                elevation = layerData.Element(datagovt + "ELEVATION").Value;
                postString = layerData.Element(datagovt + "GEOMETRY")
                                                .Element(gml + "MultiCurve").Element(gml + "curveMember").Element(gml + "LineString").Element(gml + "posList").Value;
                positionlist = postString.Split(' ').ToList();
            }
            catch
            {
            }
            XmlWfsData data = new XmlWfsData(elevation, "", "", "", positionlist);
            return data;

        }
        public override void DrawXmlData(double lat, double lng, double size)
        {
            string layer = "layer-7675";
            XmlWfsData parcel;
            string url = WfsRequestUrl(layer, lat, lng, size);
            XDocument xmlData = GetXML(url);
            XNamespace wfs = "http://www.opengis.net/wfs/2.0";
            foreach (XElement element in xmlData.Descendants(wfs + "member"))
            {
                parcel = GetParcelDataFromXml(element);
                AutoCAD_Methods.DrawPlineFrom3PtList("ChchContour", 10, parcel.PosList, Convert.ToDouble(parcel.string1), false);
            }
        }
    }
    class ChCh7677_WFS : ChCh7676_WFS
    {
        static readonly string serverUrl = "https://data.canterburymaps.govt.nz/services";
        public override XmlWfsData GetParcelDataFromXml(System.Xml.Linq.XElement element)
        {
            string elevation = "";
            string postString = "";

            List<string> positionlist = new List<string>();
            XNamespace datagovt = "http://data.canterburymaps.govt.nz";
            XNamespace gml = "http://www.opengis.net/gml/3.2";
            try
            {
                XElement layerData = element.Element(datagovt + "layer-7677");
                elevation = layerData.Element(datagovt + "ELEVATION").Value;
                postString = layerData.Element(datagovt + "GEOMETRY")
                                                .Element(gml + "MultiCurve").Element(gml + "curveMember").Element(gml + "LineString").Element(gml + "posList").Value;
                positionlist = postString.Split(' ').ToList();
            }
            catch
            {
            }
            XmlWfsData data = new XmlWfsData(elevation, "", "", "", positionlist);
            return data;

        }
        public override void DrawXmlData(double lat, double lng, double size)
        {
            string layer = "layer-7677";
            XmlWfsData parcel;
            string url = WfsRequestUrl(layer, lat, lng, size);
            XDocument xmlData = GetXML(url);
            XNamespace wfs = "http://www.opengis.net/wfs/2.0";
            foreach (XElement element in xmlData.Descendants(wfs + "member"))
            {
                parcel = GetParcelDataFromXml(element);
                AutoCAD_Methods.DrawPlineFrom3PtList("ChchContour", 10, parcel.PosList, Convert.ToDouble(parcel.string1), false);
            }
        }
    }
    class ChCh8165_WFS : ChCh7676_WFS
    {
        static readonly string serverUrl = "https://data.canterburymaps.govt.nz/services";
        public override XmlWfsData GetParcelDataFromXml(System.Xml.Linq.XElement element)
        {
            string elevation = "";
            string postString = "";

            List<string> positionlist = new List<string>();
            XNamespace datagovt = "http://data.canterburymaps.govt.nz";
            XNamespace gml = "http://www.opengis.net/gml/3.2";
            try
            {
                XElement layerData = element.Element(datagovt + "layer-7677");
                elevation = layerData.Element(datagovt + "ELEVATION").Value;
                postString = layerData.Element(datagovt + "GEOMETRY")
                                                .Element(gml + "MultiCurve").Element(gml + "curveMember").Element(gml + "LineString").Element(gml + "posList").Value;
                positionlist = postString.Split(' ').ToList();
            }
            catch
            {
            }
            XmlWfsData data = new XmlWfsData(elevation, "", "", "", positionlist);
            return data;

        }
        public override void DrawXmlData(double lat, double lng, double size)
        {
            string layer = "layer-8165";
            XmlWfsData parcel;
            string url = WfsRequestUrl(layer, lat, lng, size);
            XDocument xmlData = GetXML(url);
            XNamespace wfs = "http://www.opengis.net/wfs/2.0";
            foreach (XElement element in xmlData.Descendants(wfs + "member"))
            {
                parcel = GetParcelDataFromXml(element);
                AutoCAD_Methods.DrawPlineFrom3PtList("ChchContour", 10, parcel.PosList, Convert.ToDouble(parcel.string1), false);
            }
        }
    }

    class ChCh7671_WFS : ChCh7676_WFS
    {
        static readonly string serverUrl = "https://data.canterburymaps.govt.nz/services";
        public override XmlWfsData GetParcelDataFromXml(System.Xml.Linq.XElement element)
        {
            string elevation = "";
            string postString = "";

            List<string> positionlist = new List<string>();
            XNamespace datagovt = "http://data.canterburymaps.govt.nz";
            XNamespace gml = "http://www.opengis.net/gml/3.2";
            try
            {
                XElement layerData = element.Element(datagovt + "layer-7671");
                elevation = layerData.Element(datagovt + "ELEVATION").Value;
                postString = layerData.Element(datagovt + "GEOMETRY")
                                                .Element(gml + "MultiCurve").Element(gml + "curveMember").Element(gml + "LineString").Element(gml + "posList").Value;
                positionlist = postString.Split(' ').ToList();
            }
            catch
            {
            }
            XmlWfsData data = new XmlWfsData(elevation, "", "", "", positionlist);
            return data;

        }
        public override void DrawXmlData(double lat, double lng, double size)
        {
            string layer = "layer-7671";
            XmlWfsData parcel;
            string url = WfsRequestUrl(layer, lat, lng, size);
            XDocument xmlData = GetXML(url);
            XNamespace wfs = "http://www.opengis.net/wfs/2.0";
            foreach (XElement element in xmlData.Descendants(wfs + "member"))
            {
                parcel = GetParcelDataFromXml(element);
                AutoCAD_Methods.DrawPlineFrom3PtList("ChchContour", 10, parcel.PosList, Convert.ToDouble(parcel.string1), false);
            }
        }
    }

}
