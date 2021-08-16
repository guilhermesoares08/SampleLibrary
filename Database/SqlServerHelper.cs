using LibrarySystem.Domain;
using LibrarySystem.Helpers;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace LibrarySystem.Database
{
    public static class SqlServerHelper
    {
        private const string SQLDBTYPE_SQLSERVER = "SQLSERVER";
        private const string SQLDBTYPE_MYSQL = "MYSQL";
        private static SqlConnection sqlConnection;
        public static List<Book> GetBooks(string searchText, string gender)
        {
            List<Book> lst = new List<Book>();

            using (SqlConnection myConnection = DbConnection())
            {
                string filterGender = "";

                if (!string.IsNullOrEmpty(gender))
                {
                    filterGender = "AND Gender = '" + gender + "'";
                }

                string oString = $"SELECT * FROM Book WHERE Description like '%{searchText}%' {filterGender}";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        Book b = new Book();
                        b.Id = int.Parse(oReader["Id"].ToString());
                        b.Description = oReader["Description"].ToString();
                        b.Gender = oReader["Gender"].ToString();
                        lst.Add(b);
                    }

                    myConnection.Close();
                }
            }

            return lst;
        }

        public static List<string> GetGenders()
        {
            if (BaseHelper.GetDataBaseType().ToUpper().Equals(SQLDBTYPE_SQLSERVER))
            {

            }
            else if (BaseHelper.GetDataBaseType().ToUpper().Equals(SQLDBTYPE_MYSQL))
            {

            }

            List<string> lst = new List<string>();

            using (SqlConnection myConnection = DbConnection())
            {
                string oString = "SELECT DISTINCT Gender FROM Book";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);

                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        string s = oReader["Gender"].ToString();
                        lst.Add(s);
                    }

                    myConnection.Close();
                }
            }

            return lst;
        }

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
    }
}