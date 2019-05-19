import BaseLanguage from '../../enums/BaseLanguage';
import SubcategoryReadModel from './SubcategoryReadModel';

interface CategoryReadModel {
	id: string;
	name: string;
	subcategories: SubcategoryReadModel[];
	isAssignedToTest: boolean;
	language?: BaseLanguage;
}

export default CategoryReadModel;
