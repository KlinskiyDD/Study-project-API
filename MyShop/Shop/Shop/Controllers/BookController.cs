using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Data.DBEntityContext;
using Shop.Data.Interface;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class BookController : Controller
    {
        private IHostingEnvironment _env;
        private readonly IBooks db;
        public BookController(IHostingEnvironment env, IBooks _bookData)
        {
            _env = env;
            db = _bookData;
        }
        [HttpGet]
        public IActionResult AllView()
        {
            return View(db.GetBooks());
        }
        
        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBook(string bookName, string authorName,
            string description, uint price, IFormFile file)
        {
            var dir = _env.WebRootPath;
            string path = "/img/" + file.FileName;

            using (var fileStream = new FileStream(dir + path, FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
            }

            var book = new Book()
            {
                BookName = bookName,
                AuthorName = authorName,
                Description = description,
                Img = path,
                Price = price
            };

            db.AddBook(book);
            return Redirect("~/");
        }
        
        public IActionResult EditBook(int? id)
        {
            if (id != null)
            {
                return View(db.GetBookOnId(id));
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditBook(Book book)
        {
            db.EditeBook(book);
            return Redirect("AllView");
        }
        public async Task<IActionResult> DeleteBook(int? id)
        {
            if (id != null)
            {
                db.DeleteBook(id);
            }
            return Redirect("AllView");
        }
    }
}
