using CILantro.Tools.WebAPI.Entities;
using System.Data.Entity;

namespace CILantro.Tools.WebAPI.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<SubcategoryEntity> Subcategories { get; set; }

        static ApplicationDbContext()
        {
            System.Data.Entity.Database.SetInitializer(new ApplicationDbInitializer(true));
        }

        public ApplicationDbContext()
            : base("DefaultConnection")
        {
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