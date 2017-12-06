using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_RackDeviceData
    {
        public bool insert(AiGrow.Model.ML_BayRackDeviceData device)
        {
            return new DL_BayRackDeviceData().insert(device);
        }

        public bool doesDeviceExist(string device)
        {
            return new DL_BayRackDevice().doesDeviceExist(device);
        }
    }
}
