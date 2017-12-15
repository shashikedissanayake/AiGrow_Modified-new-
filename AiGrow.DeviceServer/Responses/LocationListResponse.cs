using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class LocationListResponse : BaseResponse
    {
        public List<LocationResponse> listOfLocations { get; set; }
    }
}