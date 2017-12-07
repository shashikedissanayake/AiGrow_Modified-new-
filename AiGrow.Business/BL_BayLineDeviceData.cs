using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_BayLineDeviceData
    {
        public bool insert(AiGrow.Model.ML_BayLineDeviceData device)
        {
            return new DL_BayLineDeviceData().insert(device);
        }

        public bool doesDeviceExist(string device)
        {
            return new DL_BayLineDevice().doesDeviceExist(device);
        }

        public System.Data.DataTable selectDataSet(string device)
        {
            throw new NotImplementedException();
        }
    }
}
