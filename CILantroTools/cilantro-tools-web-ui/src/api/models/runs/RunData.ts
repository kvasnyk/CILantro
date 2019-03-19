import RunStatus from '../../enums/RunStatus';

interface RunData {
	status: RunStatus;
	processedTestsCount: number;
	processedForSeconds?: number;
	currentTestIntId?: number;
	currentTestName?: string;
}

export default RunData;
