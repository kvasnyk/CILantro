using CILantroToolsWebAPI.Db;
using CILantroToolsWebAPI.DbModels;
using CILantroToolsWebAPI.ReadModels.Categories;
using CILantroToolsWebAPI.Search;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Services
{
    public class CategoriesService
    {
        private readonly AppKeyRepository<Category> _categoriesRepository;

        public CategoriesService(AppKeyRepository<Category> categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<SearchResult<CategoryReadModel>> SearchCategoriesAsync(SearchParameter searchParameter)
        {
            return await _categoriesRepository.Search<CategoryReadModel>(searchParameter);
        }
    }
}