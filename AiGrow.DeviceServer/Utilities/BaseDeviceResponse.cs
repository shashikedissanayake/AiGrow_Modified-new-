using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class BaseDeviceRequest : BaseRequest
    {
        public string data_unit { get; set; }
        public string collected_time { get; set; }
        public string data_id { get; set; }
        //public string device_unique_id { get; set; }
    }
}