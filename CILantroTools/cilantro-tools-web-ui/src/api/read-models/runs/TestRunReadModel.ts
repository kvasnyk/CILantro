import RunOutcome from '../../enums/RunOutcome';

interface TestRunReadModel {
	id: string;
	runId: string;
	hasBeenProcessed: boolean;
	testId: string;
	outcome: RunOutcome;
	testName: string;
}

export default TestRunReadModel;
