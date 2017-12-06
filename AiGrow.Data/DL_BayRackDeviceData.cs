using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayRackDeviceData
    {
        public bool insert(Model.ML_BayRackDeviceData data)
        {
            var para = new MySqlParameter[4];
            para[1] = new MySqlParameter("@data", data.data);
            para[0] = new MySqlParameter("@unique_id", data.device_unique_id);
            para[2] = new MySqlParameter("@time", data.received_time);
            para[3] = new MySqlParameter("@unit", data.data_unit);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO rack_device_data (device_unique_id, received_time, data, data_unit) VALUES (@unique_id, @time, @data, @unit)", para) != -1;
        }
    }
}
