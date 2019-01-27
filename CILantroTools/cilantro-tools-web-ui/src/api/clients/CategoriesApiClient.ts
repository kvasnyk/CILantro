import apiRoutes from '../apiRoutes';
import CategoryReadModel from '../read-models/categories/CategoryReadModel';
import SearchParameter from '../search/SearchParameter';
import SearchResult from '../search/SearchResult';
import ApiClientBase from './ApiClientBase';

class CategoriesApiClient extends ApiClientBase {
  public searchCategories(searchParameter: SearchParameter) {
    return this.get<SearchParameter, SearchResult<CategoryReadModel>>(
      apiRoutes.categories.searchCategories,
      searchParameter
    );
  }
}

export default CategoriesApiClient;
