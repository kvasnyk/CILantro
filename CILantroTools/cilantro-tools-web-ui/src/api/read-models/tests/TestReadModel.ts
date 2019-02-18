import InputOutput from '../../models/tests/input-output/InputOutput';
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
	exePath: string;
	hasEmptyInput: boolean;
	output: InputOutput;
	hasCategory: boolean;
	hasSubcategory: boolean;
	hasIlSources: boolean;
	hasExe: boolean;
	hasInput: boolean;
	isReady: boolean;
}

export default TestReadModel;
