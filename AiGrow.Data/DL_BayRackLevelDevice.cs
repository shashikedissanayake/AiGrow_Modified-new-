using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayRackLevelDevice
    {
        public bool insert(Model.ML_BayRackLevelDevice device)
        {
            var para = new MySqlParameter[7];
            para[0] = new MySqlParameter("@device_unique_id", device.level_device_unique_id);
            para[2] = new MySqlParameter("@device_type", device.device_type);
            para[3] = new MySqlParameter("@io_type", device.io_type);
            para[4] = new MySqlParameter("@rack_level_id", device.level_id);
            para[5] = new MySqlParameter("@status", device.status);
            para[1] = new MySqlParameter("@units", device.default_unit);
            para[6] = new MySqlParameter("@NAME", device.level_device_name);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO level_device (level_device_unique_id, device_type, io_type, level_id, default_unit, status, level_device_name) VALUES (@device_unique_id, @device_type, @io_type, @rack_level_id, @units, @status, @name);", para) != -1;
        }
        public bool doesDeviceExist(string device)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@device_id", device);

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `devices` WHERE device_unique_id = @device_id", para).Rows.Count;
            return count >= 1;
        }

        public System.Data.DataTable selectAllDevices(string id)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@level_id", id);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT level_device_unique_id AS device_unique_id FROM level_device ld WHERE ld.level_id = @level_id AND ld.io_type = 'in'", para);
        }
    }
}
