using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfBookShop.Model
{
    public interface IBook
    {
        /// <summary>
        /// Получить весь список книг из базы данных
        /// </summary>
        /// <returns></returns>
        IEnumerable<Book> GetBooks();
        /// <summary>
        /// Добавление книги
        /// </summary>
        /// <param name="book"></param>
        void AddBook(Book book);
        /// <summary>
        /// Удаление книги
        /// </summary>
        /// <param name="book"></param>
        void DeleteBook(int? id);
        /// <summary>
        /// Редактирование книги
        /// </summary>
        /// <param name="book"></param>
        void EditeBook(Book book);
        /// <summary>
        /// Поиск книги по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Book GetBookOnId(int? id);
    }
}
