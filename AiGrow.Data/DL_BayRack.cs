using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayRack
    {
        public bool doesBayRackExist(string bayRack)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@bayRack_id", bayRack);

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `rack` WHERE rack_unique_id = @bayRack_id", para).Rows.Count;
            return count >= 1;
        }
        public bool insert(Model.ML_BayRack bayRack)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@bayRack_unique_id", bayRack.rack_unique_id);
            para[1] = new MySqlParameter("@bay_id", bayRack.bay_id);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO rack (rack_unique_id, bay_id) VALUES (@bayRack_unique_id, @bay_id);", para) != -1;
        }

        public DataTable selectAllRacks()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT rack_unique_id, rack_id FROM rack");
        }
    }
}
