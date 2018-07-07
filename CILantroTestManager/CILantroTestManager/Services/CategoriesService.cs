using CILantroTestManager.Database;
using CILantroTestManager.Entities;
using CILantroTestManager.Repositories;
using System;
using System.Threading.Tasks;

namespace CILantroTestManager.Services
{
    public class CategoriesService
    {
        private readonly CategoriesRepository _categoriesRepository;

        public CategoriesService()
        {
            _categoriesRepository = new CategoriesRepository(ApplicationDbContext.Create());
        }

        public async Task CreateCategory(string name)
        {
            var newCategory = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = name
            };

            await _categoriesRepository.CreateAsync(newCategory);
        }
    }
}