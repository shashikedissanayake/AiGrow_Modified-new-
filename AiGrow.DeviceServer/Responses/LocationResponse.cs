using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class LocationResponse : BaseResponse
    {
        public string location_unique_id { get; set; }
        public string location_name { get; set; }
        public string location_address { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string location_id { get; set; }
    }
}