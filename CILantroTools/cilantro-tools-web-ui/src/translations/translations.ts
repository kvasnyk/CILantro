const translations = {
	app: {
		name: 'CILantro Tools'
	},
	categories: {
		addCategory: 'New category',
		addSubcategory: 'New subcategory',
		categoryIsAssingedToTest: 'The category is assigned to a test.',
		subcategoryIsAssignedToTest: 'The subcategory is assigned to a test.',
		categories: 'Categories',
		categoryHasBeenAdded: 'The category has been added.',
		categoryHasBeenDeleted: 'The category has been deleted.',
		errorOccurredWhileAddingCategory: 'An error occurred while adding the category.',
		errorOccurredWhileAddingSubcategory: 'An error occurred while adding the subcategory.',
		errorOccurredWhileDeletingCategory: 'An error occurred while deleting the category.',
		errorOccurredWhileDeletingSubcategory: 'An error occurred while deleting the subcategory.',
		name: 'Name',
		noCategories: 'No categories have been found.',
		subcategoryHasBeenAdded: 'The subcategory has been added.',
		subcategoryName: 'Name',
		subcategoryHasBeenDeleted: 'The subcategory has been deleted.'
	},

	tests: {
		errorOccurredWhileAddingTest: 'An error occurred while adding the test.',
		findTests: 'Find tests',
		noTestCandidates: 'No test candidates have been found.',
		noTests: 'No tests have been found.',
		testHasBeenAdded: 'The test has been added.',
		testOverview: 'Overview',
		tests: 'Tests',
		selectTestCategory: 'Select a category',
		selectTestSubcategory: 'Select a subcategory',
		testCategory: 'Category',
		testSubcategory: 'Subcategory',
		categoryHasBeenUpdated: 'The category has been updated.',
		subcategoryHasBeenUpdated: 'The category has been updated.',
		errorOccurredWhileUpdatingCategory: 'An error occurred while updating the category.',
		errorOccurredWhileUpdatingSubcategory: 'An error occurred while updating the subcategory.',
		generateIlSources: 'Generate IL sources',
		testIlSources: 'IL sources',
		testMainIlSource: 'Main IL source',
		ilSourcesHasBeenGenerated: 'IL sources has been generated.',
		errorOccurredWhileGeneratingIlSources: 'An error occurred while generating IL sources.',
		testExe: 'EXE',
		generateExe: 'Generate EXE',
		exeHasBeenGenerated: 'EXE has been generated.',
		errorOccurredWhileGeneratingExe: 'An error occurred while generating EXE.',
		runningExe: 'EXE',
		exeProcessStarted: 'EXE process started',
		exeProcessEnded: 'EXE process ended',
		testIO: 'I/O',
		testIOExamples: 'Examples',
		configureInput: 'Configure input',
		configureOutput: 'Configure output',
		emptyInput: 'Empty input',
		emptyInputHasBeenUpdated: 'The empty input value has been updated.',
		errorOccurredWhileUpdatingEmptyInput: 'An error occurred while updating the empty input value.',
		testInput: 'Input',
		testOutput: 'Output',
		inputHasBeenUpdated: 'The input has been updated.',
		errorOccurredWhileUpdatingInput: 'An error occurred while updating the input.',
		outputHasBeenUpdated: 'The output has been updated.',
		errorOccurredWhileUpdatingOutput: 'An error occurred while updating the output.',
		outputHasBeenGenerated: 'The output has been generated.',
		errorOccurredWhileGeneratingOutput: 'An error occurred while generating the output.',
		ioExampleHasBeenAdded: 'The example has been added.',
		errorOccurredWhileAddingIoExample: 'An error occurred while adding the example.',
		noOutputGenerated: 'No output has been generated.',
		exampleNameIsEmpty: 'The example\'s name is empty',
		addIoExample: 'Add an I/O example',
		createdOn: 'Created',
		lastOpenedOn: 'Recently opened',
		chars: 'chars'
	},

	runs: {
		runs: 'Test runs',
		newRun: 'New test run',
		full: 'Full',
		quick: 'Quick',
		type: 'Type',
		runHasBeenAdded: 'The run has been added.',
		errorOccurredWhileAddingRun: 'An error occurred while adding the run.',
		noRuns: 'No runs have been found.',
		runHasBeenDeleted: 'The run has been deleted.',
		errorOccurredWhileDeletingRun: 'An error occurred while deleting the run.',
		step: 'Step',
		item: 'Item',
		createdOn: 'Created on',
		testRunStep_GenerateInputFiles: 'Generating input files',
		testRunStep_GenerateExeOutputFiles: 'Generating EXE output files',
		testRunStep_GenerateCilAntroOutputFiles: 'Generating CILantro output files',
		testRunStep_CompareOutputFiles: 'Comparing output files'
	},

	shared: {
		anErrorOccurred: 'An error occurred. Please try again.',
		save: 'Add',
		noInfo: '---',
		type: 'Type',
		value: 'Value',
		minLength: 'Min length',
		maxLength: 'Max length',
		symbols: 'Symbols',
		smallLetters: 'az',
		bigLetters: 'AZ',
		digits: '09',
		name: 'Name',
		resultsPerPage: 'Results per page:',
		ascending: 'Asc',
		descending: 'Desc',
		orderBy: 'Order by:',
		minValue: 'Min value',
		maxValue: 'Max value',
		type_byte: 'byte',
		type_short: 'short',
		type_bool: 'bool',
		type_string: 'string',
		type_const: 'const'
	}
};

export default translations;
