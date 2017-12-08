using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_GreenhouseDevice
    {
        public bool insert(Model.ML_GreenhouseDevice device)
        {
            var para = new MySqlParameter[7];
            para[0] = new MySqlParameter("@device_unique_id", device.greenhouse_device_unique_id);
            para[1] = new MySqlParameter("@device_name", device.greenhouse_device_name);
            para[2] = new MySqlParameter("@device_type", device.device_type);
            para[3] = new MySqlParameter("@io_type", device.io_type);
            para[4] = new MySqlParameter("@greenhouse_id", device.greenhouse_id);
            para[5] = new MySqlParameter("@status", device.status);
            para[6] = new MySqlParameter("@units", device.default_unit);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO greenhouse_device (greenhouse_device_unique_id, greenhouse_device_name, device_type, io_type, greenhouse_id, default_unit, status) VALUES (@device_unique_id, @device_name, @device_type, @io_type, @greenhouse_id, @units, @status);", para) != -1;
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
            para[0] = new MySqlParameter("@greenhouse_id", id);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT greenhouse_device_unique_id AS device_unique_id FROM greenhouse_device gd WHERE gd.greenhouse_id = @greenhouse_id", para);
        }
    }
}
