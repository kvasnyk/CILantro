using CILantro.Tools.WebAPI.Entities;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace CILantro.Tools.WebAPI.Database
{
    public class ApplicationDbMigrationsConfiguration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public ApplicationDbMigrationsConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
            CommandTimeout = 1000;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var categoriesCount = 25;
            var subcategoriesCount = 25;

            // categories

            var categories = Enumerable.Range(1, categoriesCount).Select(i => new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = $"Category {i.ToString("00")}",
                Code = $"C{i.ToString("00")}"
            }).ToArray();

            context.Categories.AddOrUpdate(c => c.Name, categories);
            context.SaveChanges();

            // subcategories

            for (int i = 1; i <= categoriesCount; i++)
            {
                var subcategories = Enumerable.Range(1, subcategoriesCount).Select(j => new SubcategoryEntity
                {
                    Id = Guid.NewGuid(),
                    Name = $"Subcategory {i.ToString("00")}-{j.ToString("00")}",
                    Code = $"S{i.ToString("00")}-{j.ToString("00")}",
                    CategoryId = categories[i - 1].Id
                }).ToArray();

                context.Subcategories.AddOrUpdate(s => s.Name, subcategories);
                context.SaveChanges();
            }
        }
    }
}