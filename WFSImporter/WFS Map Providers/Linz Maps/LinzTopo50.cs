using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WFSImporter
{
    class LinzTopo50 : WFS_Provider
    {
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
            XmlWfsData data = new XmlWfsData(id, appellation, affectedSurvey,"", positionlist);
            return data;
        }
    }
}
