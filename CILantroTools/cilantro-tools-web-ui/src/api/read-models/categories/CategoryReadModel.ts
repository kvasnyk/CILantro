import SubcategoryReadModel from './SubcategoryReadModel';

interface CategoryReadModel {
	id: string;
	name: string;
	subcategories: SubcategoryReadModel[];
	isAssignedToTest: boolean;
}

export default CategoryReadModel;
