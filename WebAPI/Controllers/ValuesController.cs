using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Data.DBEntityCon;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        DataContext db;
        public ValuesController(DataContext _db)
        {
            db = _db;
        }
        [HttpGet]
        public IEnumerable<IBook> Get()
        {
            return db.Books;
        }
        [HttpGet("{id}")]
        public IBook GetBookById(int id)
        {
            Book book = db.Books.FirstOrDefault(p => p.Id == id);
            return book;
        }

        [HttpPost]
        public void Post([FromBody] Book value)
        {
            db.Books.Add(value);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Book bk =db.Books.FirstOrDefault(p => p.Id == id);
            if (bk != null)
            {
                db.Books.Remove(bk);
                db.SaveChanges();
            }
        }
        [HttpPut]
        public void Put([FromBody] Book value)
        {
            db.Books.Update(value);
            db.SaveChanges();
        }
    }
}
