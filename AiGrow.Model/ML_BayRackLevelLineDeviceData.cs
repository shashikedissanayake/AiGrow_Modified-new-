using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Model
{
    public class ML_BayRackLevelLineDeviceData
    {
        public string data { get; set; }
        public string data_unit { get; set; }
        public string device_unique_id { get; set; }
        public string received_time { get; set; }
        public int data_id { get; set; }
        public bool is_shown { get; set; }
    }
}
