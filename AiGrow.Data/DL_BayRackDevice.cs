using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayRackDevice
    {
        public bool insert(Model.ML_BayRackDevice device)
        {
            var para = new MySqlParameter[6];
            para[0] = new MySqlParameter("@device_unique_id", device.device_unique_id);
            para[2] = new MySqlParameter("@device_type", device.device_type);
            para[3] = new MySqlParameter("@io_type", device.io_type);
            para[4] = new MySqlParameter("@rack_line_id", device.rack_id);
            para[5] = new MySqlParameter("@status", device.status);
            para[1] = new MySqlParameter("@units", device.default_unit);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO rack_device (rack_device_unique_id, device_type, io_type, rack_id, default_unit, status) VALUES (@device_unique_id, @device_type, @io_type, @rack_line_id, @units, @status);", para) != -1;
        }
        public bool doesDeviceExist(string device)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@device_id", device);

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `rack_device` WHERE rack_device_unique_id = @device_id", para).Rows.Count;
            return count >= 1;
        }

        public DataTable selectAllDevices(string id)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@rack_id", id);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT rack_device_unique_id AS device_unique_id FROM rack_device rd WHERE rd.rack_id = @rack_id", para);
        }
    }
}
