using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public static class Repository
    {
        static List<IBook> books;
        static Repository()
        {
            books = new List<IBook>()
            {
                 new Book
                    {
                        Id=0,
                        BookName= "Ведьмак",
                        AuthorName= "Анджей Сапковский",
                        Description= "Оригинальное, масштабное эпическое произведение, одновременно и свободное от влияния извне, и связанное с классической мифологической, легендарной и сказовой традицией.",
                        Img= "/img/Witcher.jpg",
                        Price= 1390
                    },
                    new Book
                    {
                        Id=1,
                        BookName = "Война и мир",
                        AuthorName = "Лев Толстой",
                        Description = "«Война и мир» – одно из высших достижений художественного гения.",
                        Img = "/img/WarAndPeace.jpg",
                        Price = 1344
                    }
            };
        }
        public static void AddBook(IBook book)
        {
            book.Id = books.Count;
            books.Add(book);
        }
        public static void DeleteBook(int id)
        {
            books.Remove(books[id]);
        }
        public static void EditeBook(Book book)
        {
            books[book.Id] = book;
        }
        public static IEnumerable<IBook> GetBooks() => books;
        public static IBook GetBookById(int Id) => Id >= 0 && Id < books.Count ? books[Id] : NullBook.Create();
    }
}
