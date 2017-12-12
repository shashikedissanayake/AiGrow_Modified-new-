using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiGrow.Data;

namespace AiGrow.Business
{
    public class BL_BayDeviceData
    {
        public bool insert(AiGrow.Model.ML_BayDeviceData data)
        {
            return new DL_BayDeviceData().insert(data);
        }


        public System.Data.DataTable selectDataSet(string device, string from, string to)
        {
            return new DL_BayDeviceData().selectDataSet(device,from,to);
        }
    }
}
