
using CILantroTestManager.Entities;
using CILantroTestManager.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CILantroTestManager.Database
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<SubcategoryEntity> Subcategories { get; set; }

        static ApplicationDbContext()
        {
            System.Data.Entity.Database.SetInitializer(new ApplicationDbInitializer(true));
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // categories

            modelBuilder.Entity<CategoryEntity>()
                .ToTable("Categories")
                .HasKey(x => x.Id);

            // subcategories

            modelBuilder.Entity<SubcategoryEntity>()
                .ToTable("Subcategories")
                .HasKey(x => x.Id);

            modelBuilder.Entity<SubcategoryEntity>()
                .HasRequired(x => x.Category)
                .WithMany(x => x.Subcategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}