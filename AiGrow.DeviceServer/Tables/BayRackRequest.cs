using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class BayRackRequest : BaseRequest
    {
        public string bay_rack_unique_id { get; set; }
        public int bay_id { get; set; }
        public List<BayRackDeviceRequest> listOfRackDevices { get; set; }

    }
}