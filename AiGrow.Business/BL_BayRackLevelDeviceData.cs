using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_BayRackLevelDeviceData
    {
        public bool insert(AiGrow.Model.ML_BayRackLevelDeviceData data)
        {
            return new DL_BayRackLevelDeviceData().insert(data);
        }

        public bool doesDeviceExist(string device)
        {
            return new DL_BayRackLevelDevice().doesDeviceExist(device);
        }
    }
}
