using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_GreenhouseDeviceData
    {
        public bool insert(Model.ML_GreenhouseDeviceData data)
        {
            var para = new MySqlParameter[4];
            para[1] = new MySqlParameter("@data", data.data);
            para[0] = new MySqlParameter("@unique_id", data.device_unique_id);
            para[2] = new MySqlParameter("@time", data.collected_time);
            para[3] = new MySqlParameter("@unit", data.data_unit);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO greenhouse_device_data (device_unique_id, received_server_time, collected_time, data, data_unit) VALUES (@unique_id, NOW(), @time, @data, @unit)", para) != -1;
        }

        public DataTable selectDataSet(string device,string from,string to)
        {
            var para = new MySqlParameter[3];
            para[0] = new MySqlParameter("@device_id", device);
            para[1] = new MySqlParameter("@fromDate", from);
            para[2] = new MySqlParameter("@toDate", to);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT gdd.collected_time, gdd.data FROM greenhouse_device_data gdd WHERE gdd.device_unique_id = @device_id AND (gdd.collected_time BETWEEN @fromDate AND @toDate)", para);
        }
        public DataTable getLatestData(string greenhouse_id) {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@greenhouse_id", greenhouse_id);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT * FROM latest_greenhouse_device_data lgdd WHERE lgdd.greenhouse_id = @greenhouse_id", para);
        }
        public DataTable getLatestDataForAdmin(string greenhouse_id)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@greenhouse_id", greenhouse_id);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT * FROM latest_greenhouse_device_data lgdd WHERE lgdd.greenhouse_id = @greenhouse_id", para);
        }

        public DataTable selectDeviceDataSetByType(string greenhouseID, int dataType, string from, string to)
        {
            var para = new MySqlParameter[4];
            para[0] = new MySqlParameter("@greenhouse_id", greenhouseID);
            para[1] = new MySqlParameter("@dataType", dataType);
            para[2] = new MySqlParameter("@from", from);
            para[3] = new MySqlParameter("@to", to);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT gdd.collected_time, gdd.data FROM greenhouse_device_data gdd WHERE gdd.device_unique_id = (SELECT gd.greenhouse_device_unique_id FROM greenhouse_device gd WHERE (gd.device_type = @dataType AND gd.greenhouse_id = @greenhouse_id) LIMIT 1) AND (gdd.collected_time BETWEEN @from AND @to)", para);
        }
    }
}
