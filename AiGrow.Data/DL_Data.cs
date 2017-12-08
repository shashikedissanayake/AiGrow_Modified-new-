using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_Data
    {
        public DataTable getTable(string device)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@device_unique_id", device);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `devices` WHERE device_unique_id = @device_unique_id", para);
        }
    }
}
