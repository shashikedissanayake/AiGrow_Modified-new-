using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_Bay
    {
        public bool doesBayExist(string bay)
        {
            return new DL_Bay().doesBayExist(bay);
        }
        public bool insert(AiGrow.Model.ML_Bay bay)
        {
            return new DL_Bay().insert(bay);
        }
    }
}
