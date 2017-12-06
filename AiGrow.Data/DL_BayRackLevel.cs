using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_BayRackLevel
    {
        public System.Data.DataTable selectAllLevels()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT level_unique_id FROM level");
        }
    }
}
