﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AiGrow.DeviceServer
{
    public class DataResponse
    {
        public string device_unique_id { get; set; }
        public string data { get; set; }
        public string data_unit { get; set; }
        public string collected_time { get; set; }
        public string device_type { get; set; }
    }
}