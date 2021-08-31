using LibrarySystem.Domain;
using LibrarySystem.Service;
using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    public partial class Index : System.Web.UI.Page
    {
        public IList<Domain.Book> lstBooks = new List<Domain.Book>();
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
            int q = 0;
            decimal p1 = 4M;
            decimal p2 = 5M;

            List<Domain.Book> lst = new List<Domain.Book>();
            lst.Add(new Domain.Book() { Id = 1, Description = "l1" });
            lst.Add(new Domain.Book() { Id = 2, Description = "l2" });
            lst.Add(new Domain.Book() { Id = 3, Description = "l3" });

            foreach (Domain.Book joirAbi in lst)
            {
                if (joirAbi.Description.Equals("l2"))
                {
                    Console.WriteLine("digite o nome novo");
                    joirAbi.Description = Console.ReadLine();

                }
            }


            
            //lstBooks = BookService.GetBookByFilter(txtSearch.Value, cbFilterGender.Value);
            if (!IsPostBack)
            {
                lstFilterGender = BookService.GetAllGenders();
                lstFilterGender.Insert(0, "Gênero");
                cbFilterGender.DataSource = lstFilterGender;
                cbFilterGender.DataBind();
            }
        }
    }
}