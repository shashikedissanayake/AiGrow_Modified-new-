using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class GraphDataResponse : BaseResponse
    {
        public List<GraphDataPointResponse> listOfDataPoints { get; set; }
    }
}