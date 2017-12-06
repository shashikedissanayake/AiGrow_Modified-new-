using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace AiGrow
{
    public class DBConnection
    {
        public static string connectionString = "datasource=localhost;port=3306;database=greenhouse;username=root;password=";
        //public static string connectionStringVegadev = "datasource=localhost;port=3306;database=vegadev;username=root;password=";
       // public static string connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
      //  public static string connectionStringVegadev = ConfigurationManager.ConnectionStrings["connectionStringVegadev"].ConnectionString;
        public MySql.Data.MySqlClient.MySqlConnection getConnection(String connectionString)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            return connection;
        }

        public void openConnection(ref MySqlConnection connection)
        {
            if (!connection.State.Equals(System.Data.ConnectionState.Open))
            {
                connection.Open();
            }
        }

        public void closeConnection(ref MySqlConnection connection)
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}