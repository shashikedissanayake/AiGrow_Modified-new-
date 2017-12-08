using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayLineDevice
    {
        public bool insert(Model.ML_BayLineDevice device)
        {
            var para = new MySqlParameter[7];
            para[0] = new MySqlParameter("@device_unique_id", device.bay_line_device_unique_id);
            para[1] = new MySqlParameter("@device_name", device.bay_line_device_name);
            para[2] = new MySqlParameter("@device_type", device.device_type);
            para[3] = new MySqlParameter("@io_type", device.io_type);
            para[4] = new MySqlParameter("@bay_line_id", device.bay_line_id);
            para[5] = new MySqlParameter("@status", device.status);
            para[6] = new MySqlParameter("@units", device.default_unit);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO bay_line_device (bay_line_device_unique_id, bay_line_device_name, device_type, io_type, bay_line_id, default_unit, status) VALUES (@device_unique_id, @device_name, @device_type, @io_type, @bay_line_id, @units, @status);", para) != -1;
        }
        public bool doesDeviceExist(string device)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@device_id", device);

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `devices` WHERE device_unique_id = @device_id", para).Rows.Count;
            return count >= 1;
        }

        public DataTable selectAllDevices(string id)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@bay_line_id", id);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT bay_line_device_unique_id AS device_unique_id FROM bay_line_device bld WHERE bld.bay_line_id = @bay_line_id", para);
        }
    }
}
