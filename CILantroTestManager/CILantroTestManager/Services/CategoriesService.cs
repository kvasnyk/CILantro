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
            return _categoriesRepository
                .ReadAll()
                .OrderBy(c => c.Name)
                .ToList();
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