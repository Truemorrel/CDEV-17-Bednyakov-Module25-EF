using Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Library
{
    public class LibraryRepository : DbContext
    {
        // Объекты таблицы Users
        public DbSet<Person> User { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public LibraryRepository()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0HGK8SC;Database=EF;Trusted_Connection=True;");
        }
        public Person FindUser(string fName, string lName, string sName = null)
        {
            return User.Where(u => (u.FirstName == fName && u.LastName == lName && u.Surname == sName)).FirstOrDefault();
        }
        public Book FindBook(string name)
        {
            return Book.Where(b => b.Name == name).FirstOrDefault();
        }
        public List<Person> AllUsers()
        {
            return User.ToList();
        }
        public List<Book> AllBooks()
        {
            return Book.ToList();
        }
        public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry AddBook(Book book)
        {
            return Book.Add(book);
        }
        public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry AddUser(Person user)
        {
            return User.Add(user);
        }
        public void DeleteBook(Book book)
        {
            Entry(book).State = EntityState.Deleted;
        }
        public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry UpdateBookPubYear(int bookId, int pubYear)
        {
            var book = Book.Where(b => b.Id == bookId).FirstOrDefault();
            book.PublishDate = Convert.ToDateTime(pubYear);
            return Book.Update(book);
        }
        public Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry UpdateUserName(int userId, string fName, string lName, string sName = null)
        {
            var user = User.Where(u => u.Id == userId).FirstOrDefault();
            user.FirstName = fName;
            user.LastName = lName;
            user.Surname = sName;
            return User.Update(user);
        }
        public List<Book> BooksByGenre(string gname, DateTime startYear, DateTime endTime) // 1
        {
            //return Genre.Where(n => n.Name == gname)
            //    .Join(Book.Where(b => b.PublishDate >= startYear && b.PublishDate <= endTime), g => g.Id, b => b.GenreId, (g, b) => b).ToList();
            return Book.Join(Genre, b => b.GenreId, g => g.Id, (b, g) => b).ToList();
        }
        public int NumberBooksByAuthor(string fName, string lName, string sName = null) // 2
        {
            return Book.Where(b => b.Authors.Exists(a => (a.FirstName == fName && a.LastName == lName && a.Surname == sName)))
                .Count();
        }
        public int NumberBooksByGenre(string gname) // 3
        {
            return Genre.Where(g => g.Name == gname).Count();
        }
        public bool IsBookInLibrary(string fName, string lName, string bookName, string sName = null) // 4
        {
            return Book.Where(b => b.Authors.Exists(a => (a.FirstName == fName && a.LastName == lName && a.Surname == sName))).Any();
        }
        public bool IsBookBorrowedByUser(string uName, string bName) // 5
        {
            if (Book.Where(b => b.Name == bName).FirstOrDefault().BorrowedByUserId is null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int BooksNumberByUser(string fName, string lName, string sName = null) // 6
        {
            return User.Where(u => u.FirstName == fName && u.LastName == lName && u.Surname == sName).FirstOrDefault().Books.Count; ;
        }
        public Book LastBook() // 7
        {
            return Book.Where(b => (b.PublishDate == Book.Select(p => p.PublishDate).Max())).FirstOrDefault();
        }
        public List<Book> AllBooksNameAsc() // 8
        {
            return Book.OrderBy(b => b.Name).ToList();
        }
        public List<Book> AllBooksNewFirst() // 9
        {
            return Book.OrderByDescending(b => b.PublishDate).ToList();
        }

    }
}
