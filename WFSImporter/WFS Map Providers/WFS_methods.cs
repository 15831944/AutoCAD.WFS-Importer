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
        public string string1 { get; set; }
        public string string2 { get; set; }
        public string string3 { get; set; }
        public string string4 { get; set; }
        public List<string> PosList { get; set; }
        public XmlWfsData(string a, string b, string c, string d, List<string> poslist )
        {
            string1 = a;
            string2 = b;
            string3 = c;
            string4 = d;
            PosList = poslist;
        }
    }

}
