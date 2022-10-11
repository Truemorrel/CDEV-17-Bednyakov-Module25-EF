using FirstApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FirstApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                // Пересоздаем базу
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // Заполняем данными
                var company1 = new Company { Name = "SF" };
                var company2 = new Company { Name = "VK" };
                var company3 = new Company { Name = "FB" };
                db.Companies.AddRange(company1, company2, company3);

                var user1 = new User { Name = "Arthur", Role = "Admin", Company = company1 };
                var user2 = new User { Name = "Bob", Role = "Admin", Company = company2 };
                var user3 = new User { Name = "Clark", Role = "User", Company = company2 };
                var user4 = new User { Name = "Dan", Role = "User", Company = company3 };

                db.Users.AddRange(user1, user2, user3, user4);

                db.SaveChanges();
            }
            // Создаем контекст для выбора данных
            using (var db = new AppContext())
            {
                var usersQuery = db.Users.Include(u => u.Company)
                    .Where(u => u.Company.Name == "VK");

                var users = usersQuery.ToList();

                foreach (var user in users)
                {
                    // Вывод Id пользователей
                    Console.WriteLine(user.Id);
                }
            }
            using (var db = new AppContext())
            {
                var query1 = db.Users
                    .ToList()                       // Выполняет запрос
                    .Where(u => u.Role == "Admin"); // Фильтрует

                var query2 = db.Users
                    .Where(u => u.Role == "Admin")  // Фильтрует
                    .ToList();                      // Выполняет запрос
            }
        }
    }
}
