using LibrarySystem.Database;
using LibrarySystem.Domain;
using LibrarySystem.Helpers;
using LibrarySystem.Utils;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.DataAccess
{
    public class BookDataAccess
    {
        public IList<Book> GetAllBooks()
        {
            DataTable dt = null;
            string queryCommand = "SELECT * FROM Book";
            IList<Book> lst = new List<Book>();

            if (BaseHelper.GetDataBaseType().Equals(Constants.SQLDBTYPE_SQLSERVER))
            {
                dt = SqlServerHelper.ExecuteSqlCommand(queryCommand);
            }
            else if (BaseHelper.GetDataBaseType().Equals(Constants.SQLDBTYPE_SQLSERVER))
            {
                dt = SQLiteHelper.ExecuteSQLiteCommand(queryCommand);
            }

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
            DataTable dt = null;
            string queryCommand = "";
            if (!string.IsNullOrEmpty(gender))
            {
                filterGender = "AND Gender = '" + gender + "'";
            }

            queryCommand = $"SELECT * FROM Book WHERE Description like '%{searchText}%' {filterGender}";

            if (BaseHelper.GetDataBaseType().Equals(Constants.SQLDBTYPE_SQLSERVER))
            {
                dt = SqlServerHelper.ExecuteSqlCommand(queryCommand);
            }
            else if (BaseHelper.GetDataBaseType().Equals(Constants.SQLDBTYPE_SQLite))
            {
                dt = SQLiteHelper.ExecuteSQLiteCommand(queryCommand);
            }

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
            string sqlCommand = "SELECT DISTINCT Gender FROM Book";
            DataTable dt = null;
            IList<string> lst = new List<string>();
            if (BaseHelper.GetDataBaseType().Equals(Constants.SQLDBTYPE_SQLSERVER))
            {
                dt = SqlServerHelper.ExecuteSqlCommand(sqlCommand);
            }
            else if (BaseHelper.GetDataBaseType().Equals(Constants.SQLDBTYPE_SQLite))
            {
                dt = SQLiteHelper.ExecuteSQLiteCommand(sqlCommand);
            }

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
            string queryCommand = $"DELETE FROM Book WHERE Id = { id }";
            if (BaseHelper.GetDataBaseType().Equals(Constants.SQLDBTYPE_SQLSERVER))
            {
                SqlServerHelper.ExecuteSqlCommand(queryCommand);
            }
            else if (BaseHelper.GetDataBaseType().Equals(Constants.SQLDBTYPE_SQLite))
            {
                SQLiteHelper.ExecuteSQLiteCommand(queryCommand);
            }
        }
    }
}