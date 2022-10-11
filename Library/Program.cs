using System;
using System.Linq;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LibraryRepository())
            {
                db.Book.Select(b => b)
                    .ToList().
                    ForEach(b => Console.WriteLine(b.Name));
                db.AllBooks().ToList();
            }
        }

    }
}
