using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class NullBook : IBook
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
        public uint Price { get; set; }
        private NullBook()
        {
            this.Id = 0;
            this.BookName = "Неопределенно";
            this.AuthorName = "Неопределенно";
            this.Description = "Неопределенно";
            this.Img = "Неопределенно";
            this.Price = 0;
        }
        static public NullBook Create()
        {
            return new NullBook();
        }
    }
}
