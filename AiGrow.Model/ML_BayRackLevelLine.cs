using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Model
{
    public class ML_BayRackLevelLine
    {
        public string level_line_unique_id { get; set; }
        public int line_id { get; set; }
        public int level_id { get; set; }
        public bool deleted { get; set; }

    }
}
