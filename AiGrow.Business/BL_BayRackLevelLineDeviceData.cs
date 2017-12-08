using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Business
{
    public class BL_BayRackLevelLineDeviceData
    {
    
            public bool insert(AiGrow.Model.ML_BayRackLevelLineDeviceData data)
            {
                return new DL_BayRackLevelLineDeviceData().insert(data);
            }

            public bool doesDeviceExist(string device)
            {
                return new DL_BayRackLevelLineDevice().doesDeviceExist(device);
            }


            public System.Data.DataTable selectDataSet(string device)
            {
                return new DL_BayRackLevelLineDeviceData().selectDataSet(device);
            }
    }
}
