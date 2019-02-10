using CILantroToolsWebAPI.DbModels;
using Microsoft.EntityFrameworkCore;

namespace CILantroToolsWebAPI.Db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Test> Tests { get; set; }

        public DbSet<Subcategory> Subcategories { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Test
            modelBuilder.Entity<Test>()
                .HasKey(t => t.Id);
            modelBuilder.Entity<Test>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tests)
                .HasForeignKey(t => t.CategoryId);
            modelBuilder.Entity<Test>()
                .HasOne(t => t.Subcategory)
                .WithMany(s => s.Tests)
                .HasForeignKey(t => t.SubcategoryId);

            // Category
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            // Subcategory
            modelBuilder.Entity<Subcategory>()
                .HasKey(s => s.Id);
            modelBuilder.Entity<Subcategory>()
                .HasOne(s => s.Category)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(s => s.CategoryId);
        }
    }
}