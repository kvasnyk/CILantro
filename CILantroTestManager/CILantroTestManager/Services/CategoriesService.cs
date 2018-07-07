using CILantroTestManager.Database;
using CILantroTestManager.Entities;
using CILantroTestManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CILantroTestManager.Services
{
    public class CategoriesService
    {
        private readonly CategoriesRepository _categoriesRepository;
        private readonly SubcategoriesRepository _subcategoriesRepository;

        public CategoriesService()
        {
            var applicationDbContext = ApplicationDbContext.Create();

            _categoriesRepository = new CategoriesRepository(applicationDbContext);
            _subcategoriesRepository = new SubcategoriesRepository(applicationDbContext);
        }

        public void CreateCategory(string name)
        {
            var newCategory = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            _categoriesRepository.Create(newCategory);
        }

        public IEnumerable<CategoryEntity> ReadAllCategories()
        {
            var allCategories = _categoriesRepository
                .ReadAll()
                .OrderBy(c => c.Name)
                .ToList();

            foreach(var category in allCategories)
            {
                category.Subcategories = category.Subcategories.OrderBy(sc => sc.Name).ToList();
            }

            return allCategories;
        }

        public void CreateSubcategory(Guid categoryId, string name)
        {
            var newSubcategory = new SubcategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                CategoryId = categoryId
            };

            _subcategoriesRepository.Create(newSubcategory);
        }
    }
}