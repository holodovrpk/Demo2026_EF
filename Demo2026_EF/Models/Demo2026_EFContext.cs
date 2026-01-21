using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2026_EF.Models
{
    public class Demo2026_EFContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Punkt> Punkt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=NEXTOUCH313\SQLEXPRESS;Database=Demo2026;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public Demo2026_EFContext()
        {
            Database.EnsureCreated();
        }
    }
}
