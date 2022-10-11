﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
