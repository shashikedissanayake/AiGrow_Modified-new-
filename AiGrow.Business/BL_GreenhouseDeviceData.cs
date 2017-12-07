using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiGrow.Model;

namespace AiGrow.Business
{
    public class BL_GreenhouseDeviceData
    {
        public bool insert(AiGrow.Model.ML_GreenhouseDeviceData data)
        {
            return new DL_GreenhouseDeviceData().insert(data);
        }

        public System.Data.DataTable selectDataSet(string device)
        {
            throw new NotImplementedException();
        }
    }
}
