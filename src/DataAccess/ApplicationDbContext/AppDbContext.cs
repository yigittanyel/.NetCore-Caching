using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.ApplicationDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            
            modelBuilder.Entity<Product>()
                .HasData(new Product { Id = 1, Name = "Product 1", Description = "Description 1", Price = 10.00m },
                         new Product { Id = 2, Name = "Product 2", Description = "Description 2", Price = 20.00m },
                         new Product { Id = 3, Name = "Product 3", Description = "Description 3", Price = 30.00m },
                         new Product { Id = 4, Name = "Product 4", Description = "Description 4", Price = 40.00m },
                         new Product { Id = 5, Name = "Product 5", Description = "Description 5", Price = 50.00m });
        }
    }
}
