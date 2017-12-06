using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class BaseRequest
    {
        public string deviceID { get; set; }
        public string command { get; set; }
        public string data { get; set; }
        public string requestID { get; set; }
    }
}