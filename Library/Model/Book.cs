using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Model
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
        public DateTime PublishDate { get; set; }

        public List<Person> Authors { get; set; } = new List<Person>();
        public int? BorrowedByUserId { get; set; }
    }
}
