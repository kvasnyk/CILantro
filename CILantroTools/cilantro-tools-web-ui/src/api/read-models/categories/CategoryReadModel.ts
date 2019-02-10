import SubcategoryReadModel from './SubcategoryReadModel';

interface CategoryReadModel {
	id: string;
	name: string;
	subcategories: SubcategoryReadModel[];
}

export default CategoryReadModel;
