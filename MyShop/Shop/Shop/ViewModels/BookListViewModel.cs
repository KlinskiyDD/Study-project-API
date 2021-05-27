using Shop.Data;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class BookListViewModel
    {
        public IEnumerable<Book> allBooks { get; set; }

        public string currentCategory { get; set; }

    }
}
