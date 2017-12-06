using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_BayLine
    {
        public bool doesBayLineExist(string bayLine)
        {
            return new DL_BayLine().doesBayLineExist(bayLine);
        }
        public bool insert(AiGrow.Model.ML_BayLine bayLine)
        {
            return new DL_BayLine().insert(bayLine);
        }
    }
}
