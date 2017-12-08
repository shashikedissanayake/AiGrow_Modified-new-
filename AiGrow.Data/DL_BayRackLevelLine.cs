using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayRackLevelLine
    {
        public bool doesBayRackLevelLineExist(string bayRackLevelLine)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@bayRackLevelLine_id", bayRackLevelLine);

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `level_line` WHERE level_line_unique_id = @bayRackLevelline_id", para).Rows.Count;
            return count >= 1;
        }
        public bool insert(Model.ML_BayRackLevelLine bayRackLevelLine)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@bayRackLevelLine_unique_id", bayRackLevelLine.level_line_unique_id);
            para[1] = new MySqlParameter("@level_id", bayRackLevelLine.level_id);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO level_line (level_line_unique_id, level_id) VALUES (@bayRackLevelLine_unique_id, @level_id);", para) != -1;
        }
        public System.Data.DataTable selectAllLevellines()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT level_line_unique_id AS unique_id, level_line_id AS id FROM level_line");
        }
    }
}
