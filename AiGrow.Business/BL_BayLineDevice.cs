using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_BayLineDevice
    {
        public bool insert(AiGrow.Model.ML_BayLineDevice device)
        {
            return new DL_BayLineDevice().insert(device);
        }

        public bool doesDeviceExist(string device)
        {
            return new DL_BayLineDevice().doesDeviceExist(device);
        }

        public System.Data.DataTable selectAllDevices(string id)
        {
            return new DL_BayLineDevice().selectAllDevices(id);
        }
    }
}
