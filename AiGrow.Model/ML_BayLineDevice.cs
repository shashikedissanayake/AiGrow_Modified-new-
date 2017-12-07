﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Model
{
    public class ML_BayLineDevice
    {
        public string bay_line_device_unique_id { get; set; }
        public string bay_line_device_name { get; set; }
        public string device_type { get; set; }
        public string io_type { get; set; }
        public string default_unit { get; set; }
        public string status { get; set; }
        public int device_id { get; set; }
        public int bay_line_id { get; set; }

    }
}
