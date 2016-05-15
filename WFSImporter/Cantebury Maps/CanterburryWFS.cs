using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WFSImporter.Cantebury_Maps
{

    class ChChCont2011_WFS : WFS_Provider
    {
        private ChChCont2011_WFS instance;
        public ChChCont2011_WFS GetInstance()
        {
            if (instance == null)
            {
                instance = new ChChCont2011_WFS();
            }
            return instance;
        }
        public static string apiKey = "f5e94106db284674bd106a10b44c3bf6";
        public override string ApiKey
        {
            get
            {
                return base.ApiKey;
            }
        }
        static readonly string serverUrl = "https://data.canterburymaps.govt.nz/";
        public override string ServerUrl
        {
            get
            {
                return base.ServerUrl;
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
            string id = "";
            string appellation = "";
            string affectedSurvey = "";
            string postString = "";
            List<string> positionlist = new List<string>();
            XNamespace datagovt = "http://data.linz.govt.nz";
            XNamespace gml = "http://www.opengis.net/gml/3.2";
            try
            {
                XElement layerData = element.Element(datagovt + "layer-7678");
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
    }
}
