using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinzDataGrabber
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
        string apiKey = "b96d858dc1f543bab7926bc3197f75f7";
        public override string ApiKey
        {
            get
            {
                return base.ApiKey;
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
