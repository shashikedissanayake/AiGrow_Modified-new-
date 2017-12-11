using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class BayRackLevelLineDeviceRequest : BaseRequest
    {
        public string device_unique_id { get; set; }
        public string level_device_name { get; set; }
        public string device_type { get; set; }
        public string io_type { get; set; }
        public string default_unit { get; set; }
        public string status { get; set; }
        public int line_id { get; set; }
    }
}