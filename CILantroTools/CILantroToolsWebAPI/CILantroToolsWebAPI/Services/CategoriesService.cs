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
                throw new ToolsException("A category name cannot be empty.");

            var existingCategory = _categoriesRepository.Read<CategoryReadModel>().FirstOrDefault(c => c.Name == model.Name);
            if (existingCategory != null)
                throw new ToolsException("A category with the same name already exists.");

            var newCategory = new Category
            {
                Id = Guid.NewGuid(),
                Name = model.Name
            };

            return await _categoriesRepository.CreateAsync(newCategory);
        }

        public async Task DeleteCategoryAsync(Guid categoryId)
        {
            var categoryReadModel = _categoriesRepository.Read<CategoryReadModel>().SingleOrDefault(c => c.Id == categoryId);

            if (categoryReadModel.IsAssignedToTest)
                throw new ToolsException("The category is assigned to a test.");

            await _categoriesRepository.DeleteAsync(c => c.Id == categoryId);
        }

        public async Task<Guid> AddSubcategoryAsync(AddSubcategoryBindingModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new ToolsException("A subcategory name cannot be empty.");

            var existingSubcategory = _subcategoriesRepository.Read<SubcategoryReadModel>()
                .FirstOrDefault(s => s.Name == model.Name && s.CategoryId == model.CategoryId);
            if (existingSubcategory != null)
                throw new ToolsException("A subcategory with the same name already exists.");

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