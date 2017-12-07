using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayRackLevelLineDevice
    {
        public System.Data.DataTable selectAllDevices(string id)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@level_line_id", id);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT level_line_device_unique_id AS device_unique_id FROM level_line_device lld WHERE lld.level_line_id = @level_line_id", para);
        }
    }
}
