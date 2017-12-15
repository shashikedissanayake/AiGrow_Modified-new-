using AiGrow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class GreenhouseListResponse : BaseResponse
    {
        public List<GreenhouseResponse> listOfGreenhouses;
    }
}