using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labrary.Model
{
    public class UserRepository : DbContext
    {
        public DbSet<User> Users{ get; set; }
        
    }
}
