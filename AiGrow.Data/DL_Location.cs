﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_Location
    {
        public bool insert(Model.ML_Location location)
        {
            var para = new MySqlParameter[5];
            para[0] = new MySqlParameter("@location", location.location_name);
            para[1] = new MySqlParameter("@longitude", location.longitude);
            para[2] = new MySqlParameter("@location_address", location.location_address);
            para[3] = new MySqlParameter("@latitude", location.latitude);
            para[4] = new MySqlParameter("@unique_id", location.location_unique_id);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO location ( location_name ,location_address ,longitude ,latitude, location_unique_id ) VALUES ( @location ,@location_address ,@longitude ,@latitude, @unique_id )", para) != -1;
        }

        public bool delete(Model.ML_Location location)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@unique_id", location.location_unique_id);
            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "DELETE FROM location WHERE location_unique_id = @unique_id", para) != -1;
        }

        public int update(Model.ML_Location location)
        {
            var para = new MySqlParameter[5];
            para[0] = new MySqlParameter("@location", location.location_name);
            para[1] = new MySqlParameter("@longitude", location.longitude);
            para[2] = new MySqlParameter("@location_address", location.location_address);
            para[3] = new MySqlParameter("@latitude", location.latitude);
            para[4] = new MySqlParameter("@unique_id", location.location_unique_id);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE `location` SET location_name =  COALESCE(@location, location_name), location_address = COALESCE(@location_address, location_address), longitude = COALESCE(@longitude, longitude), latitude = COALESCE(@latitude, latitude), location_unique_id = COALESCE(@unique_id, location_unique_id)  where location_unique_id = @unique_id", para);
        }
    }
}
