﻿using MySql.Data.MySqlClient;
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
            var para = new MySqlParameter[6];
            para[0] = new MySqlParameter("@device_unique_id", device.level_device_unique_id);
            para[2] = new MySqlParameter("@device_type", device.device_type);
            para[3] = new MySqlParameter("@io_type", device.io_type);
            para[4] = new MySqlParameter("@rack_level_id", device.level_id);
            para[5] = new MySqlParameter("@status", device.status);
            para[1] = new MySqlParameter("@units", device.default_unit);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO level_device (level_device_unique_id, device_type, io_type, level_id, default_unit, status) VALUES (@device_unique_id, @device_type, @io_type, @rack_level_id, @units, @status);", para) != -1;
        }
        public bool doesDeviceExist(string device)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@device_id", device);

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `level_device` WHERE level_device_unique_id = @device_id", para).Rows.Count;
            return count >= 1;
        }

    }
}
