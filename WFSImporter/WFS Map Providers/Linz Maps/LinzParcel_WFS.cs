using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFSImporter
{
    class LinzParcel_WFS : WFS_Provider
    {
        private LinzParcel_WFS instance;
        public LinzParcel_WFS GetInstance()
        {
            if(instance == null)
            {
                instance = new LinzParcel_WFS();
            }
                return instance;
        }
        public static string apiKey = WFSImporter.Properties.Settings.Default.userLinzApiKey;
        public override string ApiKey
        {
            get
            {
                return apiKey;
            }
        }
        static readonly string serverUrl = "http://data.linz.govt.nz/services";
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
    }
}
