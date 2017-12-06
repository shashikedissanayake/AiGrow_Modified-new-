using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class BayDeviceRequest : BaseRequest
    {
        public string bay_device_unique_id { get; set; }
        public string bay_device_name { get; set; }
        public string device_type { get; set; }
        public string io_type { get; set; }
        public string default_unit { get; set; }
        public string status { get; set; }
        public int bay_id { get; set; }
    }
}