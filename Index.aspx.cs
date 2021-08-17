using LibrarySystem.Domain;
using LibrarySystem.Service;
using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public partial class Index : System.Web.UI.Page
    {
        public IList<Book> lstBooks = new List<Book>();
        public IList<string> lstFilterGender = new List<string>();

        BookService _bookService;
        protected BookService BookService
        {
            get
            {
                if (_bookService == null)
                    _bookService = new BookService();

                return _bookService;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lstBooks = BookService.GetBookByFilter(txtSearch.Value, cbFilterGender.Value);
            if (!IsPostBack)
            {
                lstFilterGender = _bookService.GetAllGenders();
                lstFilterGender.Insert(0, "");
                cbFilterGender.DataSource = lstFilterGender;
                cbFilterGender.DataBind();
            }
            
        }

        protected void DeleteBook(object sender, EventArgs e)
        {
            
            //SqlServerHelper.DeleteBook();
        }
    }
}