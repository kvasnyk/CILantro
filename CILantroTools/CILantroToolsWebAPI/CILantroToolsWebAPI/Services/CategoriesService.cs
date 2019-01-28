using CILantroToolsWebAPI.BindingModels.Categories;
using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.ReadModels.Categories;
using CILantroToolsWebAPI.Search;
using System;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Services
{
    public class CategoriesService
    {
        private readonly AppKeyRepository<Category> _categoriesRepository;
        private readonly AppKeyRepository<Subcategory> _subcategoriesRepository;

        public CategoriesService(
            AppKeyRepository<Category> categoriesRepository,
            AppKeyRepository<Subcategory> subcategoriesRepository
        )
        {
            _categoriesRepository = categoriesRepository;
            _subcategoriesRepository = subcategoriesRepository;
        }

        public async Task<SearchResult<CategoryReadModel>> SearchCategoriesAsync(SearchParameter searchParameter)
        {
            return await _categoriesRepository.Search<CategoryReadModel>(searchParameter);
        }

        public async Task<Guid> AddCategoryAsync(AddCategoryBindingModel model)
        {
            var newCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = model.Name
            };

            return await _categoriesRepository.CreateAsync(newCategory);
        }

        public async Task<Guid> AddSubcategoryAsync(AddSubcategoryBindingModel model)
        {
            var newSubcategory = new Subcategory
            {
                Id = Guid.NewGuid(),
                CategoryId = model.CategoryId,
                Name = model.Name
            };

            return await _subcategoriesRepository.CreateAsync(newSubcategory);
        }
    }
}