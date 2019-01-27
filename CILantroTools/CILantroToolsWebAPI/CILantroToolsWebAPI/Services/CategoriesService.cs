using CILantroToolsWebAPI.ReadModels.Categories;
using CILantroToolsWebAPI.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CILantroToolsWebAPI.Services
{
    public class CategoriesService
    {
        public async Task<SearchResult<CategoryReadModel>> SearchCategoriesAsync(SearchParameter searchParameter)
        {
            return new SearchResult<CategoryReadModel>
            {
                Data = new List<CategoryReadModel>()
            };
        }
    }
}