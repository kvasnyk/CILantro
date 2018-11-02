import ApiClientBase from '../ApiClientBase';
import { ApiRoutes } from '../ApiRoutes';
import ICreateCategoryBindingModel from '../binding-models/categories/CreateCategoryBindingModel';

class CategoriesApiClient extends ApiClientBase {
    public createCategory = (model: ICreateCategoryBindingModel) => this.post<{}>(ApiRoutes.categories.createCategory, model);
}

export default CategoriesApiClient;