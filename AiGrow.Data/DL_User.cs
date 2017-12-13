using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiGrow.Data
{
    public class DL_User
    {
        public bool doesUserExist(string userName)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@userName", userName.Trim());

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `user` WHERE username = @userName", para).Rows.Count;
            return count >= 1;
        }
        public DataTable selectByUserName(AiGrow.Model.ML_User user)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@userName", user.username);
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT id_user, email, telephone, mobile, username, role_id, role_name, deleted FROM `user`, role WHERE (username = @userName) AND deleted = 0 AND role.id_role = `user`.role_id ORDER BY id_user ASC", para);

        }

        public DataTable select(string userName)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@userName", userName);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT * FROM `user` WHERE `username` = @userName", para);
        }
        public int validateToken(string loginToken)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@loginToken", loginToken);
            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT * FROM login l WHERE l.login_token=@loginToken", para).Rows.Count;
        }
        public DataTable getUserSalt(AiGrow.Model.ML_User user)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Username", user.username);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT salt FROM user u WHERE u.username = @Username", para);
        }
        public string getUserRole(string user)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@Username", user);

            var x =  MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT role_name FROM user u INNER JOIN role r ON u.role_id = r.id_role WHERE u.username = @Username", para).Rows[0]["role_name"].ToString();
            return x;
        }
        public DataTable checkLoginSecure(AiGrow.Model.ML_User user)
        {

            var para = new MySqlParameter[3];
            para[0] = new MySqlParameter("@Username", user.username);
            para[1] = new MySqlParameter("@Password", user.password);
            para[2] = new MySqlParameter("@Salt", user.salt);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT usr.id_user, usr.first_name, usr.last_name, usr.title, usr.email, usr.mobile, r.role_name FROM `user` usr JOIN role r ON usr.role_id = r.id_role AND usr.deleted = FALSE WHERE usr.username = @Username AND usr.`password` = @Password AND usr.`deleted` = FALSE AND usr.salt = @Salt;", para);
        }
        public int insert(AiGrow.Model.ML_User user)
        {
            var para = new MySqlParameter[16];
            para[0] = new MySqlParameter("@Username", user.username);
            para[1] = new MySqlParameter("@Password", user.password);
            para[2] = new MySqlParameter("@FirstName", user.first_name);
            para[3] = new MySqlParameter("@LastName", user.last_name);
            para[4] = new MySqlParameter("@Address", user.address);
            para[5] = new MySqlParameter("@Email", user.email);
            para[6] = new MySqlParameter("@Telephone", user.telephone);
            para[7] = new MySqlParameter("@Mobile", user.mobile);
            para[8] = new MySqlParameter("@Country", user.country);
            para[9] = new MySqlParameter("@OrganizationName", user.organization_name);
            para[11] = new MySqlParameter("@Role", user.role_id);
            para[12] = new MySqlParameter("@Gender", user.gender);
            para[13] = new MySqlParameter("@Title", user.title);
            para[14] = new MySqlParameter("@Salt", user.salt);
            para[15] = new MySqlParameter("@picURL", user.profile_picture_url);

            var lastInsert = MySQLHelper.ExecuteScalar(DBConnection.connectionString, System.Data.CommandType.Text, "INSERT INTO `user` (id_user, title, gender, first_name, last_name, address, email, telephone, mobile, username, password, salt, country, organization_name, role_id, deleted, created_date, last_modified, profile_picture_url) VALUES (NULL, @Title, @Gender, @FirstName, @LastName, @Address, @Email, @Telephone, @Mobile, @Username, @Password, @Salt, @Country, @OrganizationName, @Role, 0, NOW(), NOW(), @picURL); SELECT LAST_INSERT_ID();", para);

            return System.Convert.ToInt32(lastInsert);
        }
        public DataTable getRoleID(string userType)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@userType", userType);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `role` WHERE `role_name`= @userType", para);
        }
        public string getUserIDByReference(string uniqueID)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@unique_id", uniqueID);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT id_user FROM `user` WHERE user_unique_id = @unique_id", para).Rows[0]["id_user"].ToString();
        }
        public DataTable selectCustomer(AiGrow.Model.ML_User user, string token)
        {
            var para = new MySqlParameter[2];
            para[0] = new MySqlParameter("@userName", user.username);
            para[1] = new MySqlParameter("@token", token);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT u.title, u.gender, u.first_name, u.last_name, u.address, u.email, u.telephone, u.mobile, u.USERNAME, u.country, u.organization_name, u.role_id, u.deleted, u.profile_picture_url FROM `user` u WHERE u.USERNAME = @userName AND u.deleted = FALSE AND (SELECT COUNT(*) FROM login WHERE login_token = @token AND id_user = (SELECT id_user FROM `user` u1 WHERE u1.USERNAME = @userName))", para);
        }
        public int update(AiGrow.Model.ML_User user)
        {
            var para = new MySqlParameter[15];

            para[1] = new MySqlParameter("@title", user.title);
            para[2] = new MySqlParameter("@gender", user.gender);
            para[3] = new MySqlParameter("@firstName", user.first_name);
            para[4] = new MySqlParameter("@lastName", user.last_name);
            para[5] = new MySqlParameter("@address", user.address);
            para[6] = new MySqlParameter("@email", user.email);
            para[7] = new MySqlParameter("@telephone", user.telephone);
            para[8] = new MySqlParameter("@country", user.country);
            para[9] = new MySqlParameter("@organizationName", user.organization_name);
            para[11] = new MySqlParameter("@salt", user.salt);
            para[12] = new MySqlParameter("@password", user.password);
            para[13] = new MySqlParameter("@userID", user.id_user);
            para[14] = new MySqlParameter("@mobile", user.mobile);
            para[0] = new MySqlParameter("@picURL", user.profile_picture_url);

            return MySQLHelper.ExecuteNonQuery(DBConnection.connectionString, CommandType.Text, "UPDATE `user` SET title = @title, gender = @gender ,first_name = @firstName ,last_name = @lastName, address = @address ,email = @email ,telephone = @telephone ,mobile = @mobile ,password = COALESCE(@password, password) ,salt = COALESCE(@salt, salt) ,country = @country ,organization_name = @organizationName ,last_modified = NOW(), profile_picture_url = @picURL WHERE id_user = @userID", para);
        }
        public string getUserIDByUserName(string userName)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@username", userName);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT `id_user` FROM `user` WHERE username = @username", para).Rows[0]["id_user"].ToString();
        }
        public bool doesEmailExist(string email)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@email", email.Trim());

            int count = MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `user` WHERE email = @email", para).Rows.Count;
            return count >= 1;
        }
        public DataTable selectRecordsByEmail(string email)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@email", email.Trim());

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, System.Data.CommandType.Text, "SELECT * FROM `user` WHERE email = @email", para);
        }
        public DataTable selectByUserID(AiGrow.Model.ML_User user)
        {
            var para = new MySqlParameter[1];
            para[0] = new MySqlParameter("@userID", user.id_user);

            return MySQLHelper.ExecuteDataTable(DBConnection.connectionString, CommandType.Text, "SELECT id_user, first_name, last_name, address, email, telephone, mobile, username, role_id, deleted, created_date, last_modified, profile_picture_url, organization_name, country, title, gender FROM `user` WHERE id_user = @userID AND deleted=0;", para);
        }
    }
}
