using LibrarySystem.BusinessRule;
using LibrarySystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.Service
{
    public class BookService
    {
        BookBusinessRule _bookBusinessRule;
        protected BookBusinessRule BookDataAccess
        {
            get
            {
                if (_bookBusinessRule == null)
                    _bookBusinessRule = new BookBusinessRule();

                return _bookBusinessRule;
            }
        }

        public IList<Book> GetAllBooks()
        {
            return BookDataAccess.GetAllBooks();
        }
        public IList<Book> GetBookByFilter(string searchText, string gender)
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