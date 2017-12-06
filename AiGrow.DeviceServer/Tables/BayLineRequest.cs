using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class BayLineRequest : BaseRequest
    {
        public string bay_line_unique_id { get; set; }
        public int bay_id { get; set; }
        public List<BayLineDeviceRequest> listOfBayLineDevices { get; set; }
    }
}