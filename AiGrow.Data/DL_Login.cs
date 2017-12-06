using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_Login
    {
        public int insert(AiGrow.Model.ML_Login login)
        {
            var para = new MySqlParameter[3];
            para[0] = new MySqlParameter("@userID", login.id_user);
            para[1] = new MySqlParameter("@loginMode", login.login_mode);
            para[2] = new MySqlParameter("@loginToken", login.login_token);


            object returnVal = MySQLHelper.ExecuteScalar(DBConnection.connectionString, System.Data.CommandType.Text, "INSERT INTO greenhouse.login (id_user , logged_in_timestamp , login_mode , login_token) VALUES (@userID, NOW(), @loginMode, @loginToken);SELECT LAST_INSERT_ID();", para);

            return Convert.ToInt32(returnVal);
        }

        public int logOut(AiGrow.Model.ML_Login login)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@loginID", login.id_login);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, System.Data.CommandType.Text, "UPDATE login SET logged_out_timestamp = NOW() WHERE id_login = @loginID", para);
        }
    }
}
