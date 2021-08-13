using LibrarySystem.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace LibrarySystem
{
    public partial class Index : System.Web.UI.Page
    {
        private static SqlConnection sqlConnection;
        public IList<Book> lstBooks = new List<Book>();
        public IList<string> lstFilterGender = new List<string>();
        private const string SQLDBTYPE_SQLSERVER = "SqlServer";
        private const string SQLDBTYPE_MYSQL = "MySql";

        protected void Page_Load(object sender, EventArgs e)
        {
            lstBooks = GetBooks(txtSearch.Value, cbFilterGender.Value);
            if (!IsPostBack)
            {
                lstFilterGender = GetGenders();
                lstFilterGender.Insert(0, "");
                cbFilterGender.DataSource = lstFilterGender;
                cbFilterGender.DataBind();
            }
        }

        public List<Book> GetBooks(string searchText, string gender)
        {
            List<Book> lst = new List<Book>();

            using (SqlConnection myConnection = DbConnection())
            {
                string filterGender = "";

                if(!string.IsNullOrEmpty(gender))
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

        public List<string> GetGenders()
        {
            if (ConfigurationManager.AppSettings["DataBaseType"].ToString().Equals(SQLDBTYPE_SQLSERVER))
            {
                
            }
            else if (ConfigurationManager.AppSettings["DataBaseType"].ToString().Equals(SQLDBTYPE_MYSQL))
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
    }
}