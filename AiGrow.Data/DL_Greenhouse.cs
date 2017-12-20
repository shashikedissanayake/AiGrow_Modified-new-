using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_Greenhouse
    {
        public bool insert(Model.ML_Greenhouse greenhouse)
        {
            var para = new MySqlParameter[5];
            para[0] = new MySqlParameter("@greenhouse_name", greenhouse.greenhouse_name);
            para[1] = new MySqlParameter("@user_id", greenhouse.owner_user_id);
            para[2] = new MySqlParameter("@location_id", greenhouse.location_id);
            para[3] = new MySqlParameter("@unique_id", greenhouse.greenhouse_unique_id);
            para[4] = new MySqlParameter("@pic_url", greenhouse.pic_url);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "INSERT INTO greenhouse ( greenhouse_name ,owner_user_id ,location_id , greenhouse_unique_id, created_date_time, last_updated_date, pic_url) VALUES ( @greenhouse_name ,@user_id ,@location_id ,@unique_id, NOW(), NOW(), @pic_url)", para) != -1;
           
        }
        public bool doesGreenhouseExist(string greenhouse)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@greenhouse_id", greenhouse);

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `greenhouse` WHERE greenhouse_unique_id = @greenhouse_id", para).Rows.Count;
            return count >= 1;
        }
        public bool doesGreenhouseIDExist(string greenhouse, string user_id, string role)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@greenhouse_id", greenhouse);
            para[1] = new MySqlParameter("@user_id", user_id);

            if (role == "1")
            {
                int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `greenhouse` WHERE greenhouse_id = @greenhouse_id", para).Rows.Count;
                return count >= 1;
            }
            else {
                int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `greenhouse` WHERE greenhouse_id = @greenhouse_id AND owner_user_id = @user_id", para).Rows.Count;
                return count >= 1;
            }
        }

        public DataTable select()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT gh.greenhouse_id, gh.greenhouse_unique_id, gh.greenhouse_name ,u.username AS owner,l.location_name,l.location_address,gh.created_date_time AS created_date,gh.last_updated_date, gh.pic_url FROM greenhouse gh INNER JOIN user u ON gh.owner_user_id = u.id_user INNER JOIN location l ON gh.location_id = l.location_id WHERE gh.deleted=0");
        }

        public DataSet selectComponentsByGreenHouseID(string greenhouseID)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@greenhouse_id", greenhouseID);
            return MySQLHelper.ExecuteDataSet(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT DISTINCT b.bay_unique_id, g.greenhouse_unique_id FROM bay b LEFT OUTER JOIN greenhouse g ON b.greenhouse_id=g.greenhouse_id WHERE g.greenhouse_id=@greenhouse_id;SELECT DISTINCT b.bay_unique_id, bl.bay_line_unique_id FROM greenhouse gh LEFT OUTER JOIN bay b ON b.greenhouse_id=gh.greenhouse_id LEFT OUTER JOIN bay_line bl ON bl.bay_id=b.bay_id WHERE gh.greenhouse_id= @greenhouse_id;SELECT DISTINCT b.bay_unique_id, r.rack_unique_id FROM greenhouse gh LEFT OUTER JOIN bay b ON b.greenhouse_id=gh.greenhouse_id LEFT OUTER JOIN bay_line bl ON bl.bay_id=b.bay_id LEFT OUTER JOIN rack r ON b.bay_id = r.bay_id WHERE gh.greenhouse_id= @greenhouse_id;SELECT DISTINCT r.rack_unique_id, l.level_unique_id FROM greenhouse gh LEFT OUTER JOIN bay b ON b.greenhouse_id=gh.greenhouse_id LEFT OUTER JOIN bay_line bl ON bl.bay_id=b.bay_id LEFT OUTER JOIN rack r ON b.bay_id = r.bay_id LEFT OUTER JOIN level l ON r.rack_id = l.rack_id WHERE gh.greenhouse_id= @greenhouse_id;SELECT DISTINCT l.level_unique_id, ll.level_line_unique_id FROM greenhouse gh LEFT OUTER JOIN bay b ON b.greenhouse_id=gh.greenhouse_id LEFT OUTER JOIN bay_line bl ON bl.bay_id=b.bay_id LEFT OUTER JOIN rack r ON b.bay_id = r.bay_id LEFT OUTER JOIN level l ON r.rack_id = l.rack_id LEFT OUTER JOIN level_line ll ON l.level_id = ll.level_id WHERE gh.greenhouse_id= @greenhouse_id;", para);
        }

        public DataTable selectDevicesByTableName(string tableName)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@table_name", tableName);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT bd.bay_device_unique_id AS device_unique_id, bd.bay_device_name AS device_name FROM bay_device bd UNION SELECT bld.bay_line_device_unique_id AS device_unique_id,bld.bay_line_device_name AS device_name FROM bay_line_device bld UNION SELECT gd.greenhouse_device_unique_id AS device_unique_id, gd.greenhouse_device_name AS device_name FROM greenhouse_device gd UNION SELECT ld.level_device_unique_id AS device_unique_id, ld.level_device_name AS device_name FROM level_device ld UNION SELECT lld.level_line_device_unique_id AS device_unique_id, lld.level_line_device_name AS device_name FROM level_line_device lld UNION SELECT rd.device_unique_id AS device_unique_id,rd.rack_device_name AS device_name FROM rack_device rd");
        }

        public DataTable selectAllGreenhouses()
        {
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT greenhouse_unique_id AS unique_id, greenhouse_id AS id FROM greenhouse");
        }

        public DataTable getAllGreenhouses(string user_id)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@user_id", user_id);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT g.greenhouse_id, g.greenhouse_unique_id, g.greenhouse_name, g.created_date_time, g.last_updated_date, g.location_id, g.pic_url, l.location_id, l.location_unique_id, l.location_name, l.location_address, l.longitude, l.latitude FROM (greenhouse g INNER JOIN location l ON g.location_id = l.location_id) WHERE g.owner_user_id = @user_id AND g.deleted = 0", para);
        }
        public DataTable getAllGreenhousesForAdmin(string user_id)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@user_id", user_id);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT g.greenhouse_id, g.greenhouse_unique_id, g.greenhouse_name, g.created_date_time, g.last_updated_date, g.location_id, g.pic_url, l.location_id, l.location_unique_id, l.location_name, l.location_address, l.longitude, l.latitude FROM (greenhouse g INNER JOIN location l ON g.location_id = l.location_id) WHERE g.deleted = 0", para);
        }
    }
}
