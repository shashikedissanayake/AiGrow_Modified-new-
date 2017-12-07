using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayLine
    {
        public bool doesBayLineExist(string bayLine)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@bayLine_id", bayLine);

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `bay_line` WHERE bay_line_unique_id = @bayLine_id", para).Rows.Count;
            return count >= 1;
        }
        public bool insert(Model.ML_BayLine bayLine)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@bayLine_unique_id", bayLine.bay_line_unique_id);
            para[1] = new MySqlParameter("@bay_id", bayLine.bay_id);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO bay_line (bay_line_unique_id, bay_id) VALUES (@bayLine_unique_id, @bay_id);", para) != -1;
        }

        public DataTable selectAllBayLines()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT bay_line_unique_id AS unique_id, bay_line_id AS id FROM bay_line");
        }
    }
}
