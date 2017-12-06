using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_BayRack
    {
        public bool doesBayRackExist(string bayRack)
        {
            return new DL_BayRack().doesBayRackExist(bayRack);
        }
        public bool insert(AiGrow.Model.ML_BayRack bayRack)
        {
            return new DL_BayRack().insert(bayRack);
        }
    }
}
