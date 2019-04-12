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
