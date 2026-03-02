using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TaskManager.DAO
{
    public class Conexao
    {
        private static string connectionString = "Server=localhost;Database=TaskManagerDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            SqlConnection conn = null;

            conn = new SqlConnection(connectionString);
            conn.Open();

            return conn;
        }
    }
}
