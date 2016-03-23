using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebDemoAngular3.Models
{
    public class BookDBContext:DbContext
    {
        public DbSet<Book> book { get; set; }
    }
}