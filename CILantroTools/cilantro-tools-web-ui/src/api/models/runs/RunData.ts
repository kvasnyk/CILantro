import RunOutcome from '../../enums/RunOutcome';
import RunStatus from '../../enums/RunStatus';
import TestRunStep from '../../enums/TestRunStep';

interface RunData {
	status: RunStatus;
	outcome: RunOutcome;
	processedTestsCount: number;
	processedForMilliseconds?: number;
	currentTestName?: string;
	currentTestStep?: TestRunStep;
	currentTestStepIndex?: number;
	testStepsCount: number;
	currentItemIndex?: number;
	currentItemName?: string;
	allItemsCount?: number;
}

export default RunData;
