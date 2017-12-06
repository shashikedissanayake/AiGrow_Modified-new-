using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class BayRequest : BaseRequest
    {
        public string bay_unique_id { get; set; }
        public int greenhouse_id { get; set; }
        public List<BayDeviceRequest> listOfBayDevices { get; set; }
        public List<BayLineRequest> listOfBayLines { get; set; }
        public List<BayRackRequest> listOfBayRacks { get; set; }

    }
}