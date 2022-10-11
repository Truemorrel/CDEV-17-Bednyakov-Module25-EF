using System;
using System.Collections.Generic;
using System.Text;

namespace FirstApp.Model
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public string City { get; set; }
        public string Type { get; set; }

        // Навигационное свойство
        public List<User> Users { get; set; } = new List<User>();
    }
}
