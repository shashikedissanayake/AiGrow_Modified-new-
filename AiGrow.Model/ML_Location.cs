using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Model
{
    
    public class ML_Location
    {
        public string location_unique_id { get; set; }
        public string location_name { get; set; }
        public string location_address { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public int location_id { get; set; }
    }
}
