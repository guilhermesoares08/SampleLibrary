using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibrarySystem.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
    }
}