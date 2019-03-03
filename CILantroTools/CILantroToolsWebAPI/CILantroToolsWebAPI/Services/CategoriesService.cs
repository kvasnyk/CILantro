using CILantroToolsWebAPI.BindingModels.Categories;
using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.Exceptions;
using CILantroToolsWebAPI.ReadModels.Categories;
using CILantroToolsWebAPI.Search;
using System;
using System.Linq;
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
            if (string.IsNullOrEmpty(model.Name))
                throw new ToolsException("Category name cannot be empty.");

            var existingCategory = _categoriesRepository.Read<CategoryReadModel>().FirstOrDefault(c => c.Name == model.Name);
            if (existingCategory != null)
                throw new ToolsException("Category with the same name already exists.");

            var newCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = model.Name
            };

            return await _categoriesRepository.CreateAsync(newCategory);
        }

        public async Task<Guid> AddSubcategoryAsync(AddSubcategoryBindingModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new ToolsException("Subcategory name cannot be empty.");

            var existingSubcategory = _subcategoriesRepository.Read<SubcategoryReadModel>()
                .FirstOrDefault(s => s.Name == model.Name && s.CategoryId == model.CategoryId);
            if (existingSubcategory != null)
                throw new ToolsException("Subcategory with the same name already exists.");

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