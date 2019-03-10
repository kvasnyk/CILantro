import InputOutput from '../../models/tests/input-output/InputOutput';
import CategoryReadModel from '../categories/CategoryReadModel';
import SubcategoryReadModel from '../categories/SubcategoryReadModel';
import TestIoExampleReadModel from './TestIoExampleReadModel';

interface TestReadModel {
	id: string;
	intId: number;
	name: string;
	path: string;
	categoryId?: string;
	category: CategoryReadModel;
	subcategoryId?: string;
	subcategory: SubcategoryReadModel;
	mainIlSourcePath: string;
	mainIlSource: string;
	exePath: string;
	generateExeOutput: string;
	hasEmptyInput: boolean;
	output?: InputOutput;
	ioExamples: TestIoExampleReadModel[];
	hasCategory: boolean;
	hasSubcategory: boolean;
	hasIlSources: boolean;
	hasExe: boolean;
	hasInput: boolean;
	hasOutput: boolean;
	hasIoExample: boolean;
	isReady: boolean;
}

export default TestReadModel;
