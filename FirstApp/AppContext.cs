using FirstApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FirstApp
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        // Объекты таблицы Companies
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0HGK8SC;Database=EF;Trusted_Connection=True;");
        }
    }
}
