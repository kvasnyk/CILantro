using CILantro.Tools.WebAPI.Database.Repositories;
using CILantro.Tools.WebAPI.Entities;
using CILantro.Tools.WebAPI.ReadModels;
using CILantro.Tools.WebAPI.Search;
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

        public async Task<SearchResult<CategorySearchReadModel>> SearchCategoriesAsync(SearchParameter searchParam)
        {
            return await _categoriesRepository.Search(searchParam);
        }

        public async Task CreateCategoryAsync(string name, string code)
        {
            var newCategory = new CategoryEntity
            {
                Id = Guid.NewGuid(),
                Name = name,
                Code = code
            };

            await _categoriesRepository.CreateAsync(newCategory);
        }
    }
}