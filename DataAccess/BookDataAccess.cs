using LibrarySystem.Database;
using LibrarySystem.Domain;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.DataAccess
{
    public class BookDataAccess
    {
        public IList<Book> GetAllBooks()
        {
            DataTable dt = SqlServerHelper.ExecuteSqlCommand("SELECT * FROM Book");
            IList<Book> lst = new List<Book>();

            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Book b = FillBookInfoByDataRow(dr);

                    lst.Add(b);
                }
            }

            return lst;
        }
        public IList<Book> GetBookByFilter(string searchText, string gender)
        {
            string filterGender = "";

            if (!string.IsNullOrEmpty(gender))
            {
                filterGender = "AND Gender = '" + gender + "'";
            }

            DataTable dt = SqlServerHelper.ExecuteSqlCommand($"SELECT * FROM Book WHERE Description like '%{searchText}%' {filterGender}");
            IList<Book> lst = new List<Book>();

            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Book b = FillBookInfoByDataRow(dr);

                    lst.Add(b);
                }
            }

            return lst;
        }
        private Book FillBookInfoByDataRow(DataRow dr)
        {
            return new Book()
            {
                Id = int.Parse(dr["Id"].ToString()),
                Description = dr["Description"].ToString(),
                Gender = dr["Gender"].ToString()
            };
        }
        public IList<string> GetAllGenders()
        {
            DataTable dt = SqlServerHelper.ExecuteSqlCommand("SELECT DISTINCT Gender FROM Book");
            IList<string> lst = new List<string>();

            if (dt != null && dt.Rows != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lst.Add(dr["Gender"].ToString());
                }
            }

            return lst;
        }

        public void DeleteBook(int id)
        {
            SqlServerHelper.ExecuteSqlScript($"DELETE FROM Book WHERE Id = { id }");
        }
    }
}