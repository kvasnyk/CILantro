import CategoryReadModel from '../categories/CategoryReadModel';
import SubcategoryReadModel from '../categories/SubcategoryReadModel';

interface TestReadModel {
	id: string;
	name: string;
	path: string;
	categoryId?: string;
	category: CategoryReadModel;
	subcategoryId?: string;
	subcategory: SubcategoryReadModel;
	hasCategory: boolean;
	hasSubcategory: boolean;
	isReady: boolean;
}

export default TestReadModel;
