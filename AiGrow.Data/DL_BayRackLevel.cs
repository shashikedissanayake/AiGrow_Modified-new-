using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayRackLevel
    {
        public bool doesBayRackLevelExist(string bayRackLevel)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@bayRackLevel_id", bayRackLevel);

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `level` WHERE level_unique_id = @bayRackLevel_id", para).Rows.Count;
            return count >= 1;
        }
        public bool insert(Model.ML_BayRackLevel bayRackLevel)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@bayRackLevel_unique_id", bayRackLevel.level_unique_id);
            para[1] = new MySqlParameter("@rack_id", bayRackLevel.rack_id);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO level (level_unique_id, rack_id) VALUES (@bayRackLevel_unique_id, @rack_id);", para) != -1;
        }


        public System.Data.DataTable selectAllLevels()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT level_unique_id AS unique_id,level_id AS id FROM level");
        }
    }
}
