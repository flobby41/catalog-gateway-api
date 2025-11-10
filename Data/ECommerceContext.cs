using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Models;

namespace ECommerceAPI.Data
{
    public class ECommerceContext : DbContext
    {
        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship
            modelBuilder.Entity<ProductCategory>()
                .HasKey(pc => new { pc.ProductId, pc.CategoryId });

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Product)
                .WithMany(p => p.ProductCategories)
                .HasForeignKey(pc => pc.ProductId);

            modelBuilder.Entity<ProductCategory>()
                .HasOne(pc => pc.Category)
                .WithMany(c => c.ProductCategories)
                .HasForeignKey(pc => pc.CategoryId);

            // Seed data
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "T-shirts", Image = "/images/t-shirt.png", Slug = "t-shirts" },
                new Category { Id = 2, Name = "Pantalons", Image = "/images/pantalons.png", Slug = "pantalons" }
            );

            modelBuilder.Entity<Product>().HasData(
                new Product 
                { 
                    Id = 1, 
                    Name = "T-Shirt", 
                    Description = "Lorem ipsum dolor", 
                    Price = 199, 
                    Image = "/images/t-shirt.png", 
                    UrlSlug = "t-shirt" 
                },
                new Product 
                { 
                    Id = 2, 
                    Name = "Svart T-Shirt", 
                    Description = "Lorem ipsum dolor", 
                    Price = 199, 
                    Image = "/images/svart-t-shirt.png", 
                    UrlSlug = "svart-t-shirt" 
                }
            );

            modelBuilder.Entity<ProductCategory>().HasData(
                new ProductCategory { ProductId = 1, CategoryId = 1 },
                new ProductCategory { ProductId = 2, CategoryId = 1 }
            );
        }
    }
}

