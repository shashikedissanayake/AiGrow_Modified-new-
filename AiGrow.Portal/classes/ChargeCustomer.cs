/*
 Created By: Sidath Gajanayaka
 Date Created: 8-12-2015
 * 4x8x12@gmail.com
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Data;
using AiGrow.Business;
using AiGrow.Model;
using AiGrow.Classes;
using AiGrow;

namespace AiGrow
{

    public class ChargeCustomer : MyUser
    {
        //private string organization_name;
        //private string organization_address;
        public string status { get; set; }
        public string NFCRef { get; set; }
        public float points { get; set; }

        public ChargeCustomer()
        {

        }
        public ChargeCustomer(string firstName, string lastName, string gender, string email, string password, string organization_name, string username, string mobile, string telephone, string title, string country, string address)
        {
            // TODO: Complete member initialization
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Gender = gender;
            this.Password = password;
            this.OrganizationName = organization_name;
            this.Username = username;
            this.Mobile = mobile;
            this.Telephone = telephone;
            this.Title = title;
            this.Country = country;
            this.Address = address;
        }
        public void insertIntoUser()
        {
            try
            {
                string sqlQuery = string.Format("INSERT INTO `chargenet`.`user` (`iduser`, `title`, `gender`, `first_name`, `last_name`, `address`, `email`, `telephone`, `mobile`, `username`, `password`, `country`, `organization_name`, `organization_address`, `role_idrole`) VALUES (NULL, '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', MD5('{9}'), '{10}', '{11}', '{12}', '{13}');", this.Title, this.Gender, this.FirstName, this.LastName, this.Address, this.Email, this.Telephone, this.Mobile, this.Username, this.Password, this.Country, this.OrganizationName, this.OrganizationAddress, getRoleID());
                DBConnection myConnectionObject = new DBConnection();
                MySqlConnection connection = myConnectionObject.getConnection(DBConnection.connectionString);
                myConnectionObject.openConnection(ref connection);
                MySqlCommand commandInsertIntoUser = new MySqlCommand(sqlQuery, connection);
                commandInsertIntoUser.ExecuteNonQuery();
                myConnectionObject.closeConnection(ref connection);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        public bool updateUser()
        {
            MySqlTransaction myTransaction = null;
            try
            {
                string updateCustomer = "UPDATE `user` SET `title` = @title, `gender` = @gender, `first_name` = @firstName, `last_name` = @lastName, `address` = @address, `email` = @email, `telephone` = @telephone, `mobile` = @mobile, `country` = @country, `organization_name` = @organizationName, `organization_address` = @organizationAddress WHERE `username`= @username;";
                using (MySqlConnection connection = new MySqlConnection(DBConnection.connectionString))
                {
                    connection.Open();
                    using (myTransaction = connection.BeginTransaction())
                    {
                        using (MySqlCommand myCommandUpdateCustomer = new MySqlCommand(updateCustomer, connection))
                        {
                            myCommandUpdateCustomer.Parameters.AddWithValue("@firstName", this.FirstName);
                            myCommandUpdateCustomer.Parameters.AddWithValue("@lastName", this.LastName);
                            myCommandUpdateCustomer.Parameters.AddWithValue("@address", this.Address);
                            myCommandUpdateCustomer.Parameters.AddWithValue("@email", this.Email);
                            myCommandUpdateCustomer.Parameters.AddWithValue("@telephone", this.Telephone);
                            myCommandUpdateCustomer.Parameters.AddWithValue("@mobile", this.Mobile);
                            myCommandUpdateCustomer.Parameters.AddWithValue("@country", this.Country);
                            myCommandUpdateCustomer.Parameters.AddWithValue("@organizationName", this.OrganizationName);
                            myCommandUpdateCustomer.Parameters.AddWithValue("@organizationAddress", this.OrganizationAddress);
                            myCommandUpdateCustomer.Parameters.AddWithValue("@username", this.Username);
                            myCommandUpdateCustomer.Parameters.AddWithValue("@gender", this.Gender);
                            myCommandUpdateCustomer.Parameters.AddWithValue("@title", this.Title);
                            myCommandUpdateCustomer.ExecuteNonQuery();
                            myTransaction.Commit();
                        }
                    }
                    connection.Close();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                myTransaction.Rollback();
                HttpContext.Current.Response.Write(ex.Message.ToString());
                return false;
            }
        }

        protected int getRoleID()
        {
            int roleID = -1;
            DBConnection myConnection = new DBConnection();
            MySqlConnection connection = myConnection.getConnection(DBConnection.connectionString);
            myConnection.openConnection(ref connection);
            String queryGetRoleID = "SELECT * FROM `role` WHERE `role_name`='CHG_CUSTOMER'";
            MySqlCommand commandGetRoleID = new MySqlCommand(queryGetRoleID, connection);
            MySqlDataReader reader = commandGetRoleID.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    roleID = reader.GetInt32(reader.GetOrdinal("idrole"));
                }
            }
            myConnection.closeConnection(ref connection);
            return roleID;
        }

        
        public void getCustomerData()
        {
            using (DataTable dt = new BL_User().selectByUserID(new ML_User()
            {
                id_user = SessionHandler.getLoggedInUserID().ToInt()
            }))
            {
                if (dt.Rows.Count == 1)
                {
                    this.Address = dt.Rows[0]["address"].ToString();
                    this.Country = dt.Rows[0]["country"].ToString();
                    this.Email = dt.Rows[0]["email"].ToString();
                    this.Telephone = dt.Rows[0]["telephone"].ToString();
                    this.Mobile = dt.Rows[0]["mobile"].ToString();
                    this.FirstName = dt.Rows[0]["first_name"].ToString();
                    this.LastName = dt.Rows[0]["last_name"].ToString();
                    this.Gender = dt.Rows[0]["gender"].ToString();
                    this.OrganizationName = dt.Rows[0]["organization_name"].ToString();
                    this.Title = dt.Rows[0]["title"].ToString();
                    this.Username = dt.Rows[0]["username"].ToString();
                }
            }
        }

    }
}