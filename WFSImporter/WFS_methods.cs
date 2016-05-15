using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WFSImporter
{
    /// <summary>
    /// Parcel Data Holder
    /// </summary>
    public class XmlWfsData
    {
        public string Id { get; set; }
        public string Appellation { get; set; }
        public string AffectedSurveys { get; set; }
        public List<string> PosList { get; set; }
        public XmlWfsData(string id, string appell, string survey, List<string> poslist )
        {
            Id = id;
            Appellation = appell;
            AffectedSurveys = survey;
            PosList = poslist;
        }
    }

}
