using LibrarySystem.Domain;
using System;
using System.Collections.Generic;
using LibrarySystem.Database;

namespace LibrarySystem
{
    public partial class Index : System.Web.UI.Page
    {
        public IList<Book> lstBooks = new List<Book>();
        public IList<string> lstFilterGender = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
            lstBooks = SqlServerHelper.GetBooks(txtSearch.Value, cbFilterGender.Value);
            if (!IsPostBack)
            {
                lstFilterGender = SqlServerHelper.GetGenders();
                lstFilterGender.Insert(0, "");
                cbFilterGender.DataSource = lstFilterGender;
                cbFilterGender.DataBind();
            }
        }
    }
}