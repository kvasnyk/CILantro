import RunStatus from '../../enums/RunStatus';
import RunType from '../../enums/RunType';

interface RunReadModel {
	id: string;
	intId: number;
	type: RunType;
	status: RunStatus;
	createdOn: Date;
	allTestsCount: number;
	processedTestsCount: number;
	processedForSeconds: number;
}

export default RunReadModel;
