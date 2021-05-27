using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public interface IBook
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// Название книги
        /// </summary>
        string BookName { get; set; }
        /// <summary>
        /// Имя и Фамилия автора
        /// </summary>
        string AuthorName { get; set; }
        /// <summary>
        /// Описание книги
        /// </summary>
        string Description { get; set; }
        /// <summary>
        /// Картинка
        /// </summary>
        string Img { get; set; }
        /// <summary>
        /// Цена
        /// </summary>
        uint Price { get; set; }
    }
}
