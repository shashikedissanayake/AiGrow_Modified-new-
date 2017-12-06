using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_Configurations
    {
        public System.Data.DataTable getConfigValue(string configName)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@configName", configName);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT `value` from configurations WHERE config_name = @configName", para);
        }

        public System.Data.DataTable select()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * from configurations");
        }
    }
}
