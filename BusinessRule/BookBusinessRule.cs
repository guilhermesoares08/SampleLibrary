using LibrarySystem.DataAccess;
using LibrarySystem.Domain;
using System.Collections.Generic;

namespace LibrarySystem.BusinessRule
{
    public class BookBusinessRule
    {
        IBookDataAccess _bookDataAccess;
        protected IBookDataAccess BookDataAccess
        {
            get
            {
                if (_bookDataAccess == null)
                    _bookDataAccess = new BookDataAccess();

                return _bookDataAccess;
            }
        }

        public IList<Domain.Book> GetAllBooks()
        {
            return BookDataAccess.GetAllBooks();
        }

        public IList<Domain.Book> GetBookByFilter(string searchText, string gender)
        {
            return BookDataAccess.GetBookByFilter(searchText, gender);
        }

        public IList<string> GetAllGenders()
        {
            return BookDataAccess.GetAllGenders();
        }

        public void DeleteBook(int id)
        {
            BookDataAccess.DeleteBook(id);
        }
    }
}