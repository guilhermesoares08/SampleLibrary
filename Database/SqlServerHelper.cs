using LibrarySystem.Helpers;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace LibrarySystem.Database
{
    public static class SqlServerHelper
    {
        
        private static SqlConnection sqlConnection;

        private static SqlConnection DbConnection()
        {
            sqlConnection = new SqlConnection(BaseHelper.GetSqlServerConnectionString());
            sqlConnection.Open();
            return sqlConnection;
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