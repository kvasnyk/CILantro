import ApiClientBase from '../ApiClientBase';
import { ApiRoutes } from '../ApiRoutes';
import ICreateCategoryBindingModel from '../binding-models/categories/CreateCategoryBindingModel';
import CategorySearchReadModel from '../read-models/CategorySearchReadModel';
import SearchParameter from '../search/SearchParameter';
import SearchResult from '../search/SearchResult';

class CategoriesApiClient extends ApiClientBase {
    public searchCategories = (model: SearchParameter) => this.post<SearchResult<CategorySearchReadModel>>(ApiRoutes.categories.searchCategories, model);

    public createCategory = (model: ICreateCategoryBindingModel) => this.post<{}>(ApiRoutes.categories.createCategory, model);
}

export default CategoriesApiClient;