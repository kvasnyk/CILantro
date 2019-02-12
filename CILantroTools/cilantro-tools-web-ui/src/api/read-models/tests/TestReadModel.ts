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
	mainIlSourcePath: string;
	mainIlSource: string;
	hasCategory: boolean;
	hasSubcategory: boolean;
	hasIlSources: boolean;
	hasExe: boolean;
	isReady: boolean;
}

export default TestReadModel;
