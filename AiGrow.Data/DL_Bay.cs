using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_Bay
    {
        public bool doesBayExist(string bay)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@bay_id", bay);

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `bay` WHERE bay_unique_id = @bay_id", para).Rows.Count;
            return count >= 1;
        }
        public bool insert(Model.ML_Bay bay)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@bay_unique_id", bay.bay_unique_id);
            para[1] = new MySqlParameter("@greenhouse_id", bay.greenhouse_id);
           
            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO bay (bay_unique_id, greenhouse_id) VALUES (@bay_unique_id, @greenhouse_id);", para) != -1;
        }

        public DataTable selectAllBays()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT bay_unique_id, bay_id FROM bay");
        }
    }
}
