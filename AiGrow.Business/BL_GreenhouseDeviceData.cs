using AiGrow.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AiGrow.Model;
using System.Data;
using MySql.Data.MySqlClient;

namespace AiGrow.Business
{
    public class BL_GreenhouseDeviceData
    {
        public bool insert(AiGrow.Model.ML_GreenhouseDeviceData data)
        {
            return new DL_GreenhouseDeviceData().insert(data);
        }

        public System.Data.DataTable selectDataSet(string device, string from, string to)
        {
            return new DL_GreenhouseDeviceData().selectDataSet(device,from,to);
        }
        public DataTable getLatestData(string greenhouse_id)
        {
            return new DL_GreenhouseDeviceData().getLatestData(greenhouse_id);
        }
        public DataTable getLatestDataForUsers(string greenhouse_id)
        {
            return new DL_GreenhouseDeviceData().getLatestData(greenhouse_id);
        }
        public DataTable getLatestDataForAdmin(string greenhouse_id)
        {
            return new DL_GreenhouseDeviceData().getLatestDataForAdmin(greenhouse_id);
        }

        public DataTable selectDeviceDataSetByType(string greenhouseID, int dataType, string from, string to)
        {
            return new DL_GreenhouseDeviceData().selectDeviceDataSetByType(greenhouseID,dataType,  from, to);
        }
    }
}
