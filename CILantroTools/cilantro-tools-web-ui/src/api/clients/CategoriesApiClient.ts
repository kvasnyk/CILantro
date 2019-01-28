import apiRoutes from '../apiRoutes';
import AddCategoryBindingModel from '../binding-models/categories/AddCategoryBindingModel';
import AddSubcategoryBindingModel from '../binding-models/categories/AddSubcategoryBindingModel';
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

  public addCategory(data: AddCategoryBindingModel) {
    return this.post<AddCategoryBindingModel, string>(
      apiRoutes.categories.addCategory,
      data
    );
  }

  public addSubcategory(data: AddSubcategoryBindingModel) {
    return this.post<AddSubcategoryBindingModel, string>(
      apiRoutes.categories.addSubcategory,
      data
    );
  }
}

export default CategoriesApiClient;
