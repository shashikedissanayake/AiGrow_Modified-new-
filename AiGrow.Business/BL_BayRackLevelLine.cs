using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_BayRackLevelLine
    {
        public bool doesBayRackLevelLineExist(string bayRackLevelLine)
        {
            return new DL_BayRackLevelLine().doesBayRackLevelLineExist(bayRackLevelLine);
        }
        public bool insert(AiGrow.Model.ML_BayRackLevelLine bayRackLevelLine)
        {
            return new DL_BayRackLevelLine().insert(bayRackLevelLine);
        }
    }
}
