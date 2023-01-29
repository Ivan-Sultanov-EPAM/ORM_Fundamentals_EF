using EFDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFDemo
{
    public class EFDemoDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Database = EFDemoDb;" +
                "Integrated Security=True;Persist Security Info=False;Pooling=False;" +
                "MultipleActiveResultSets=False;Connect Timeout=5;Encrypt=False;" +
                "TrustServerCertificate=False");
        }
    }
}