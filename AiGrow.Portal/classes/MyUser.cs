
using AiGrow.Business;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;

namespace AiGrow
{
    public class MyUser
    {
        String firstName;

        public String FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        String lastName;

        public String LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        String password;

        public String Password
        {
            get { return password; }
            set { password = value; }
        }
        String organizationName;

        public String OrganizationName
        {
            get { return organizationName; }
            set { organizationName = value; }
        }
        String organizationAddress;

        public String OrganizationAddress
        {
            get { return organizationAddress; }
            set { organizationAddress = value; }
        }
        String username;

        public String Username
        {
            get { return username; }
            set { username = value; }
        }
        String mobile;

        public String Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }
        String telephone;

        public String Telephone
        {
            get { return telephone; }
            set { telephone = value; }
        }
        String title;

        public int userID { get; set; }

        public String Title
        {
            get { return title; }
            set { title = value; }
        }
        String country;

        public String Country
        {
            get { return country; }
            set { country = value; }
        }
        String address;

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        String gender;

        public String Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public MyUser()
        {

        }

        public static bool getBooleanFromString(string value)
        {
            if (value == "1" || value == "True")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updateUser()
        {
            MySqlConnection connection = null;
            string updateUserQuery = "UPDATE `user` SET `title` = @title , `gender` = @gender, `first_name` = @firstName, `last_name` = @lastName, `address` = @address, `email` = @email, `telephone` = @telephone, `mobile` = @mobile, `country` = @country, `organization_name` = @organizationName, `organization_address` = @organizationAddress WHERE `username`=@username;";
            MySqlTransaction myTransaction = null;
            try
            {
                using (connection = new MySqlConnection(DBConnection.connectionString))
                {
                    connection.Open();

                    using (myTransaction = connection.BeginTransaction())
                    {
                        using (MySqlCommand myCommandUser = new MySqlCommand(updateUserQuery, connection))
                        {
                            myCommandUser.Parameters.AddWithValue("@title", this.title);
                            myCommandUser.Parameters.AddWithValue("@gender", this.gender);
                            myCommandUser.Parameters.AddWithValue("@firstName", this.firstName);
                            myCommandUser.Parameters.AddWithValue("@lastName", this.lastName);
                            myCommandUser.Parameters.AddWithValue("@address", this.address);
                            myCommandUser.Parameters.AddWithValue("@telephone", this.telephone);
                            myCommandUser.Parameters.AddWithValue("@email", this.email);
                            myCommandUser.Parameters.AddWithValue("@organizationAddress", this.organizationAddress);
                            myCommandUser.Parameters.AddWithValue("@username", this.username);
                            myCommandUser.Parameters.AddWithValue("@organizationName", this.organizationName);
                            myCommandUser.Parameters.AddWithValue("@mobile", this.mobile);
                            myCommandUser.Parameters.AddWithValue("@country", this.country);

                            myCommandUser.ExecuteNonQuery();

                            myTransaction.Commit();
                        }
                    }

                }
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                myTransaction.Rollback();
                connection.Close();
                HttpContext.Current.Response.Write(ex.Message.ToString());
                return false;
            }
        }
        public bool resetPassword()
        {
            string queryResetPassword = "UPDATE `user` SET `password` = @password WHERE `username`=@username AND `email`=@email";
            try
            {
                using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionString))
                {
                    connection.Open();
                    using (MySqlCommand myCommandChgCustomer = new MySqlCommand(queryResetPassword, connection))
                    {
                        myCommandChgCustomer.Parameters.AddWithValue("@password", this.password);
                        myCommandChgCustomer.Parameters.AddWithValue("@username", this.username);
                        myCommandChgCustomer.Parameters.AddWithValue("@email", this.email);
                        myCommandChgCustomer.ExecuteNonQuery();
                    }
                    connection.Close();
                }
            }
            catch (MySqlException mySQLEx)
            {
                Console.Write(mySQLEx.StackTrace + mySQLEx.Message.ToString());
                return false;
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace + ex.Message.ToString());
                return false;
            }
            return true;
        }
        public static Boolean validateUser(String username, String password)
        {
            Boolean userValid = false;
            try
            {
                string sqlQuery = string.Format("SELECT `password` FROM `user` WHERE `username`='{0}'", username);

                DBConnection myConnectionObject = new DBConnection();
                MySqlConnection connection = myConnectionObject.getConnection(DBConnection.connectionString);
                myConnectionObject.openConnection(ref connection);
                MySqlCommand commandValidateUser = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader myReader = commandValidateUser.ExecuteReader();
                String passwordReturn = "";
                while (myReader.Read())
                {
                    passwordReturn = myReader.GetString("password");
                }
                MD5 md5Hash = MD5.Create();
                String encryptedString = Encryption.createMd5(md5Hash, password);

                if (encryptedString != passwordReturn)
                {
                    userValid = false;
                }
                else
                {
                    userValid = true;
                }
                myConnectionObject.closeConnection(ref connection);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return userValid;
        }

        public static LoginResponse validateUserIS(String username, String password)
        {
            RequestHandler post = new RequestHandler();
            post.Url = Constants.CHECK_LOGIN_POST_JSON;
            Portal.ApplicationUtilities.writeMsg(post.Url);
            post.PostItems.Add("UserName", username);
            post.PostItems.Add("Password", password);
            post.PostItems.Add("token", Encryption.createSHA1(username + password));
            post.PostItems.Add("loginMode", Constants.WEB);
            post.Type = RequestHandler.PostTypeEnum.Post;
            string result = post.Post();

            LoginResponse login = new JavaScriptSerializer().Deserialize<LoginResponse>(result);

            return login;
        }

        public static LoginResponse validateUserLogout(String login_id, String token)
        {
            RequestHandler post = new RequestHandler();
            post.Url = Constants.CHECK_LOGOUT_POST_JSON;
            post.PostItems.Add("loginID", login_id);
            post.PostItems.Add("token", token);
            post.Type = RequestHandler.PostTypeEnum.Post;
            string result = post.Post();

            LoginResponse login = new JavaScriptSerializer().Deserialize<LoginResponse>(result);

            return login;
        }

        public static string getValidString(ref MySqlDataReader myReader, string columnName)
        {
            string returnString = "";
            if (myReader.IsDBNull(myReader.GetOrdinal(columnName)))
            {

            }
            else
            {
                returnString = myReader.GetString(myReader.GetOrdinal(columnName));
            }

            return returnString;
        }
        /*public static string getValidString2(this MySqlDataReader myReader)
        {
            string columnName = "";
            string returnString = "";
            if (myReader.IsDBNull(myReader.GetOrdinal(columnName)))
            {

            }
            else
            {
                returnString = myReader.GetString(myReader.GetOrdinal(columnName));
            }

            return returnString;
        }
         * */
        public static String getUserType(String username)
        {
            String roleReturn = "";
            try
            {
                string sqlQuery = string.Format("SELECT `role_name` FROM `role`, `user` WHERE `username`='{0}' AND `role`.`idrole`=`user`.`role_idrole`", username);

                DBConnection myConnectionObject = new DBConnection();
                MySqlConnection connection = myConnectionObject.getConnection(DBConnection.connectionString);
                myConnectionObject.openConnection(ref connection);
                MySqlCommand commandValidateUser = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader myReader = commandValidateUser.ExecuteReader();

                while (myReader.Read())
                {
                    roleReturn = myReader.GetString("role_name");
                }

                myConnectionObject.closeConnection(ref connection);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return roleReturn;
        }

        public static string getProfileImageURL()
        {
            string profile_pic_url = new BL_User().select(SessionHandler.getLoggedInUsername()).Rows[0]["profile_picture_url"].ToString();
            return (profile_pic_url == string.Empty || profile_pic_url == null) ? AppFunction.ReadSetting("DefaultProPicURL") : profile_pic_url;           
        }

        
        public static String getProfileImageURLByUserName(string userName)
        {
            String profileImagePhysicalURL = string.Format("{0}{1}.jpg", HttpContext.Current.Server.MapPath("/Dashboards/dist/img/"), userName);
            String profileImageURL = AiGrow.Constants.PROFILE_IMAGE_PATH;
            if (File.Exists(profileImagePhysicalURL))
            {
                profileImageURL = string.Format("{0}{1}.jpg", profileImageURL, userName);
            }
            else
            {
                profileImageURL = profileImageURL + "avatar.jpg";
            }
            return profileImageURL;
        }

        public static String getTimeStamp()
        {
            String currentTimeStamp = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            return currentTimeStamp;
        }

        public static string getEmailFromUsername(string username)
        {
            String email = null;
            try
            {
                string sqlQuery = string.Format("SELECT `email` FROM `user` WHERE `username`='{0}'", username);

                DBConnection myConnectionObject = new DBConnection();
                MySqlConnection connection = myConnectionObject.getConnection(DBConnection.connectionString);
                myConnectionObject.openConnection(ref connection);
                MySqlCommand commandGetEmail = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader myReader = commandGetEmail.ExecuteReader();

                while (myReader.Read())
                {
                    email = myReader["email"].ToString();
                }

                myConnectionObject.closeConnection(ref connection);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return email;
        }

        public static string getUserIDFromUsername(string username)
        {
            String userID = null;
            try
            {
                string sqlQuery = string.Format("SELECT `id_user` FROM `user` WHERE `username`='{0}'", username);

                DBConnection myConnectionObject = new DBConnection();
                MySqlConnection connection = myConnectionObject.getConnection(DBConnection.connectionString);
                myConnectionObject.openConnection(ref connection);
                MySqlCommand commandGetEmail = new MySqlCommand(sqlQuery, connection);
                MySqlDataReader myReader = commandGetEmail.ExecuteReader();

                while (myReader.Read())
                {
                    userID = myReader["id_user"].ToString();
                }

                myConnectionObject.closeConnection(ref connection);

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            return userID;
        }
    }
}