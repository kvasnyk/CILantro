import RunType from '../../enums/RunType';

interface RunReadModel {
	id: string;
	type: RunType;
	createdOn: Date;
}

export default RunReadModel;
