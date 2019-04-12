import RunOutcome from '../../enums/RunOutcome';
import RunStatus from '../../enums/RunStatus';
import RunType from '../../enums/RunType';
import TestRunReadModel from './TestRunReadModel';

interface RunReadModel {
	id: string;
	type: RunType;
	status: RunStatus;
	outcome: RunOutcome;
	createdOn: Date;
	allTestsCount: number;
	processedTestsCount: number;
	processedForMilliseconds: number;
	testRuns: TestRunReadModel[];
}

export default RunReadModel;
