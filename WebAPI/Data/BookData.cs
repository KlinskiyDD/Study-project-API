using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.DBEntityCon;
using WebAPI.Models;

namespace WebAPI.Data
{
    public static class BookData
    {
        private static DataContext context;

        public static IEnumerable<Book> GetBooks()
        {
            return context.Books;
        }

        public static void AddBook(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
        }

        public static void DeleteBook(int? id)
        {
            Book bk = context.Books.FirstOrDefault(p => p.Id == id);
            if (bk != null)
            {
                context.Books.Remove(bk);
                context.SaveChanges();
            }
        }

        public static void EditeBook(Book book)
        {
            context.Books.Update(book);
            context.SaveChanges();
        }

        public static Book GetBookOnId(int? id)
        {
            Book book = context.Books.FirstOrDefault(p => p.Id == id);
            return book;
        }
    }
}
