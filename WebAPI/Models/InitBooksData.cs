using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.DBEntityCon;

namespace WebAPI.Models
{
    public static class InitBooksData
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            if (context.Books.Any()) return;
            var listBooks = new List<Book>()
            {
                    new Book
                    {
                        BookName= "Ведьмак",
                        AuthorName= "Анджей Сапковский",
                        Description= "Оригинальное, масштабное эпическое произведение, одновременно и свободное от влияния извне, и связанное с классической мифологической, легендарной и сказовой традицией.",
                        Img= "/img/Witcher.jpg",
                        Price= 1390
                    },
                    new Book
                    {
                        BookName = "Война и мир",
                        AuthorName = "Лев Толстой",
                        Description = "«Война и мир» – одно из высших достижений художественного гения.",
                        Img = "/img/WarAndPeace.jpg",
                        Price = 1344
                    },
                   new Book
                   {
                       BookName = "Преступление и наказание",
                       AuthorName = "Федор Достоевский",
                       Description = "Преступление и наказание – самый известный роман Ф.М. Достоевского, совершивший мощный переворот общественного сознания.",
                       Img = "/img/CrimeAndPun.jpg",
                       Price = 1600
                   },
                   new Book
                   {
                       BookName = "«1984»",
                       AuthorName = "Джордж Оруэлл",
                       Description = "Что будет, если в правящих кругах распространятся идеи фашизма и диктатуры? " +
                       "Каким станет общественный уклад, если власть потребует неуклонного подчинения? К какой катастрофе приведет подобный режим?",
                       Img = "/img/1984.jpg",
                       Price = 1491
                   }
            };
            using (var trans = context.Database.BeginTransaction())
            {
                foreach (var item in listBooks)
                {
                    context.Books.Add(item);
                }
                context.SaveChanges();
                trans.Commit();
            }
        }
    }
}
