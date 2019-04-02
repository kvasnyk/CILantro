import RunStatus from '../../enums/RunStatus';
import TestRunStep from '../../enums/TestRunStep';

interface RunData {
	status: RunStatus;
	processedTestsCount: number;
	processedForMilliseconds?: number;
	currentTestIntId?: number;
	currentTestName?: string;
	currentTestStep?: TestRunStep;
	currentTestStepIndex?: number;
	testStepsCount: number;
}

export default RunData;
