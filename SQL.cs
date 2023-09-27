using Microsoft.Data.SqlClient;
using System.Configuration;

namespace CRUD
{
    public class SQL
    {
        public static SqlConnection Conn =
            new SqlConnection(ConfigurationManager.ConnectionStrings["ITI"].ToString());



        public static SqlCommand Sql = Conn.CreateCommand();


        public static int SQLOperation(Delegate Operation)
        {

            return 0;
        }
    }
}
