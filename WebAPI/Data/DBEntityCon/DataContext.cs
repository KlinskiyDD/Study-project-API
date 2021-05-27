using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data.DBEntityCon
{
    public class DataContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { Database.EnsureCreated(); }
        
    }
}
