using Labrary.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Labrary.Model
{
    public class BookReposirory : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public BookReposirory()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0HGK8SC;Database=EF;Trusted_Connection=True;");
        }
    }
}
