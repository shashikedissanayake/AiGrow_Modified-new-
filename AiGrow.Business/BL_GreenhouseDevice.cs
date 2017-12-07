using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_GreenhouseDevice
    {
        public bool insert(AiGrow.Model.ML_GreenhouseDevice device)
        {
            return new DL_GreenhouseDevice().insert(device);
        }

        public bool doesDeviceExist(string device)
        {
            return new DL_GreenhouseDevice().doesDeviceExist(device);
        }

        public System.Data.DataTable selectAllDevices(string id)
        {
            return new DL_GreenhouseDevice().selectAllDevices(id);
        }
    }
}
