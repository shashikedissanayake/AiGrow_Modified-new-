using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayRackLevelLine
    {
        public System.Data.DataTable selectAllLevellines()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT level_line_unique_id AS unique_id,level_line_id AS id FROM level_line");
        }
    }
}
