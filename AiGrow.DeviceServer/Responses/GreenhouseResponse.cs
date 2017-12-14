using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class GreenhouseResponse : BaseResponse
    {
        public string greenhouse_unique_id { get; set; }
        public string greenhouse_name { get; set; }
        public string created_date_time { get; set; }
        public string last_updated_date { get; set; }
        public string greenhouse_id { get; set; }
        public string owner_user_id { get; set; }
        public string location_unique_id { get; set; }
        public string location_name { get; set; }
        public string location_address { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string location_id { get; set; }
        public string pic_url { get; set; }
    }
}