import RunStatus from '../../enums/RunStatus';
import RunType from '../../enums/RunType';

interface RunReadModel {
	id: string;
	intId: number;
	type: RunType;
	status: RunStatus;
	createdOn: Date;
}

export default RunReadModel;
