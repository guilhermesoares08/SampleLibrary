using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LibrarySystem.Database
{
    public static class SqlServerHelper
    {
        private const string SQLDBTYPE_SQLSERVER = "SQLSERVER";
        private const string SQLDBTYPE_MYSQL = "MYSQL";
        private static SqlConnection sqlConnection;
       
        private static SqlConnection DbConnection()
        {
            sqlConnection = new SqlConnection("Data Source =.\\sqlexpress; Initial Catalog=Library;Integrated Security=true;Trusted_Connection=true");
            sqlConnection.Open();
            return sqlConnection;
        }

        public static string GetDatabaseType()
        {
            return ConfigurationManager.AppSettings["DataBaseType"].ToString().ToUpper();
        }

        public static void ExecuteSqlScript(string sql)
        {
            using (SqlConnection myConnection = DbConnection())
            {
                SqlCommand oCmd = new SqlCommand(sql, myConnection);
                oCmd.ExecuteNonQuery();
                myConnection.Close();
            }
        }

        public static DataTable ExecuteSqlCommand(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection myConnection = DbConnection())
            {
                SqlCommand command = new SqlCommand(sql, myConnection);
                SqlDataAdapter da = new SqlDataAdapter(command);

                da.Fill(dt);
                myConnection.Close();
                da.Dispose();
            }

            return dt;
        }
    }
}