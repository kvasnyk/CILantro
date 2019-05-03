import RunOutcome from '../../enums/RunOutcome';
import TestRunStep from '../../enums/TestRunStep';

interface TestRunStepInfoReadModel {
	processedForMilliseconds: number;
	step: TestRunStep;
	outcome: RunOutcome;
}

interface TestRunStepItemInfoReadModel {
	itemName: string;
	steps: TestRunStepInfoReadModel[];
	input: string;
	exeOutput?: string;
	exeError?: string;
	antroOutput?: string;
	antroError?: string;
}

interface TestRunFullReadModel {
	id: string;
	hasBeenProcessed: boolean;
	testId: string;
	outcome: RunOutcome;
	testName: string;
	items: TestRunStepItemInfoReadModel[];
}

export default TestRunFullReadModel;
