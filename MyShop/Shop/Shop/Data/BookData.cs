using Microsoft.EntityFrameworkCore;
using Shop.Data.DBEntityContext;
using Shop.Data.Interface;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class BookData : IBooks
    {
        private readonly DataContext context;
        public BookData(DataContext _context)
        {
            this.context = _context;
        }

        public IEnumerable<Book> GetBooks()
        {
            return context.Books;
        }

        public void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public void DeleteBook(int? id)
        {
            Book bk = context.Books.FirstOrDefault(p => p.Id == id);
            if (bk != null)
            {
                context.Books.Remove(bk);
                context.SaveChanges();
            }
        }

        public void EditeBook(Book book)
        {
            context.Books.Update(book);
            context.SaveChanges();
        }

        public Book GetBookOnId(int? id)
        {
            Book book = context.Books.FirstOrDefault(p => p.Id == id);
            return book;
        }
    }
}
