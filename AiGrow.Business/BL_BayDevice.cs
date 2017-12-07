using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_BayDevice
    {
        public bool insert(AiGrow.Model.ML_BayDevice device)
        {
            return new DL_BayDevice().insert(device);
        }

        public bool doesDeviceExist(string device)
        {
            return new DL_BayDevice().doesDeviceExist(device);
        }

        public System.Data.DataTable selectAllDevices(string id)
        {
            throw new NotImplementedException();
        }
    }
}
