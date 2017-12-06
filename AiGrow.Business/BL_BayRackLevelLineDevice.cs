using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_BayRackLevelLineDevice
    {
        public bool insert(AiGrow.Model.ML_BayRackLevelLineDevice device)
        {
            return new DL_BayRackLevelLineDevice().insert(device);
        }

        public bool doesDeviceExist(string device)
        {
            return new DL_BayRackLevelLineDevice().doesDeviceExist(device);
        }
    }
}
