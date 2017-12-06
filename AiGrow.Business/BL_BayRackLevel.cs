using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_BayRackLevel
    {
        public bool doesBayRackLevelExist(string bayRackLevel)
        {
            return new DL_BayRackLevel().doesBayRackExist(bayRackLevel);
        }
        public bool insert(AiGrow.Model.ML_BayRack bayRackLevel)
        {
            return new DL_BayRackLevel().insert(bayRackLevel);
        }
    }
}
