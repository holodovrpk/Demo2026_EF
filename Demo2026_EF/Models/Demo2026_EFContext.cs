using Microsoft.EntityFrameworkCore; // Подключение Entity Framework Core
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF.Models
{
    // Класс контекста базы данных
    // Используется Entity Framework для работы с БД Demo2026
    public class Demo2026_EFContext : DbContext
    {
        // Таблица пользователей
        public DbSet<User> Users { get; set; }

        // Таблица заказов
        public DbSet<Order> Orders { get; set; }

        // Таблица товаров
        public DbSet<Product> Products { get; set; }

        // Таблица пунктов выдачи
        public DbSet<Punkt> Punkt { get; set; }

        // Настройка подключения к базе данных
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Строка подключения к SQL Server
            optionsBuilder.UseSqlServer(
                @"Server=NEXTOUCH313\SQLEXPRESS;
                  Database=Demo2026;
                  Trusted_Connection=True;
                  TrustServerCertificate=True;");
        }

        // Конструктор контекста базы данных
        public Demo2026_EFContext()
        {
            // Автоматическое создание базы данных при первом запуске,
            // если она ещё не существует
            Database.EnsureCreated();
        }
    }
}
