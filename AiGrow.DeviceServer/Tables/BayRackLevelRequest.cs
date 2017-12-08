using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class BayRackLevelRequest : BaseRequest
    {
        public string bay_rack_level_unique_id { get; set; }
        public int rack_id { get; set; }
        public List<BayRackLevelDeviceRequest> listOfLevelDevices { get; set; }
        public List<BayRackLevelLineRequest> listOfLevelLines { get; set; }
    }
}

