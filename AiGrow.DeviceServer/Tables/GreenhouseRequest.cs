using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AiGrow.Model;

namespace AiGrow.DeviceServer
{
    public class GreenhouseRequest : BaseRequest
    {
        public List<BayRequest> listOfBays { get; set; }
        public List<GreenhouseDeviceRequest> listOfDevices { get; set; }

    }
}