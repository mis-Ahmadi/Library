using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.API.DB
{
    public class LibraryDB : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        public LibraryDB(DbContextOptions options)
        :base(options)
        {
            
        }
        
    }
}