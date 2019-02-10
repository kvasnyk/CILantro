import CategoryReadModel from '../categories/CategoryReadModel';
import SubcategoryReadModel from '../categories/SubcategoryReadModel';

interface TestReadModel {
	id: string;
	name: string;
	path: string;
	category: CategoryReadModel;
	subcategory: SubcategoryReadModel;
	hasCategory: boolean;
	hasSubcategory: boolean;
	isReady: boolean;
}

export default TestReadModel;
