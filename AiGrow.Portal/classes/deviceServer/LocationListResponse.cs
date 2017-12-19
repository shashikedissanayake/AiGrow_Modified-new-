using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.Portal
{
    public class LocationListResponse : BaseResponse
    {
        public List<LocationResponse> listOfLocations { get; set; }
    }
}