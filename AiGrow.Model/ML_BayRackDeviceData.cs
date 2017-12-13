using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Model
{
    public class ML_BayRackDeviceData
    {
        public string data { get; set; }
        public string data_unit { get; set; }
        public string received_server_time { get; set; }
        public string collected_time { get; set; }
        public int data_id { get; set; }
        public int device_id { get; set; }
        public string device_unique_id { get; set; }
    }
}
