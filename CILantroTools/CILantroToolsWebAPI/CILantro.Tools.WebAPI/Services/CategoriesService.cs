using CILantro.Tools.WebAPI.Database.Repositories;
using CILantro.Tools.WebAPI.Entities;
using System;
using System.Threading.Tasks;

namespace CILantro.Tools.WebAPI.Services
{
    public class CategoriesService
    {
        private readonly CategoriesRepository _categoriesRepository;

        public CategoriesService(CategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task CreateCategoryAsync(string name)
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