using LibrarySystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.DataAccess
{
    public interface IBookDataAccess
    {
        IList<Book> GetAllBooks();
        IList<Book> GetBookByFilter(string searchText, string gender);
        IList<string> GetAllGenders();
        void DeleteBook(int id);
    }
}
