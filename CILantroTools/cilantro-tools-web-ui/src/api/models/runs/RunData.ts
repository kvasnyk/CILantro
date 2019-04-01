import RunStatus from '../../enums/RunStatus';
import TestRunStep from '../../enums/TestRunStep';

interface RunData {
	status: RunStatus;
	processedTestsCount: number;
	processedForSeconds?: number;
	currentTestIntId?: number;
	currentTestName?: string;
	currentTestStep?: TestRunStep;
	currentTestStepIndex?: number;
}

export default RunData;
