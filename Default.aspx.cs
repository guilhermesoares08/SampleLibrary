using System;
using System.Web.UI;
using Microsoft.SqlServer;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace LibrarySystem
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var listBooks = GetBooks();
        }


        public List<Book> GetBooks()
        {
            List<Book> lst = new List<Book>();
            using (SqlConnection myConnection = new SqlConnection("Data Source =.\\sqlexpress; Initial Catalog = Library; Integrated Security = true"))
            {
                string oString = "SELECT * FROM Book";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
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
    }
}