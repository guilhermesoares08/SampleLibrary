using System.Collections.Generic;

namespace LibrarySystem.DataAccess
{
    public interface IBookDataAccess
    {
        IList<Domain.Book> GetAllBooks();
        IList<Domain.Book> GetBookByFilter(string searchText, string gender);
        IList<string> GetAllGenders();
        void DeleteBook(int id);
    }
}
