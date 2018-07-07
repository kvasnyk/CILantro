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

        public CategoriesService()
        {
            _categoriesRepository = new CategoriesRepository(ApplicationDbContext.Create());
        }

        public void CreateCategory(string name)
        {
            var newCategory = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            _categoriesRepository.CreateAsync(newCategory);
        }

        public IEnumerable<CategoryEntity> ReadAllCategories()
        {
            return _categoriesRepository
                .ReadAllAsync()
                .OrderBy(c => c.Name)
                .ToList();
        }
    }
}