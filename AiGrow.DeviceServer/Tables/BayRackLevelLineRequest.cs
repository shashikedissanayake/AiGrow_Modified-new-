using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class BayRackLevelLineRequest : BaseRequest
    {
        public string level_line_unique_id { get; set; }
        public int level_id { get; set; }
        public List<BayRackLevelLineDeviceRequest> listOfBayRackLevelLineDevices { get; set; }
    }
}