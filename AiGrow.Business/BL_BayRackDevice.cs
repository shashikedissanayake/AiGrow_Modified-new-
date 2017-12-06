using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_BayRackDevice
    {
        public bool insert(AiGrow.Model.ML_BayRackDevice device)
        {
            return new DL_BayRackDevice().insert(device);
        }

        public bool doesDeviceExist(string device)
        {
            return new DL_BayRackDevice().doesDeviceExist(device);
        }
    }
}
