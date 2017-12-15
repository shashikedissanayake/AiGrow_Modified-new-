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
        public DataTable getLatestData(string user_id)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@user_id", user_id);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT * FROM latest_greenhouse_device_data lgdd WHERE lgdd.device_unique_id IN (SELECT gd.greenhouse_device_unique_id FROM greenhouse g INNER JOIN greenhouse_device gd ON g.greenhouse_id = gd.greenhouse_id WHERE g.greenhouse_id = @user_id)", para);
        }
    }
}
