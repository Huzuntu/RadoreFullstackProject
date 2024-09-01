using Microsoft.EntityFrameworkCore;
using RadoreProje.Models;

namespace RadoreProje.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=products.db");
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ColorOption> ColorOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Rating)
                .WithOne(r => r.Product)
                .HasForeignKey<Rating>(r => r.ProductId);

            modelBuilder.Entity<Product>()
                .HasMany(p => p.ColorOptions)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId);
        }
    }
}