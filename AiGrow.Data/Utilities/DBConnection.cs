using System.Configuration;

namespace AiGrow.Data
{
    public class DBConnection
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["aigrow"].ConnectionString;
    }
}
