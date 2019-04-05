import InputOutput from '../../models/tests/input-output/InputOutput';
import CategoryReadModel from '../categories/CategoryReadModel';
import SubcategoryReadModel from '../categories/SubcategoryReadModel';
import TestIoExampleReadModel from './TestIoExampleReadModel';

interface TestReadModel {
	id: string;
	intId: number;
	name: string;
	path: string;
	createdOn: Date;
	lastOpenedOn: Date;
	categoryId?: string;
	category: CategoryReadModel;
	subcategoryId?: string;
	subcategory: SubcategoryReadModel;
	generateExeOutput: string;
	hasEmptyInput: boolean;
	input?: InputOutput;
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
