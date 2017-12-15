using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Model
{
    public class ML_Greenhouse
    {
        public string greenhouse_unique_id { get; set; }
        public string greenhouse_name { get; set; }
        public string created_date_time { get; set; }
        public string last_updated_date { get; set; }
        public int greenhouse_id { get; set; }
        public int owner_user_id { get; set; }
        public int location_id { get; set; }
        public string pic_url { get; set; }
    }
}
