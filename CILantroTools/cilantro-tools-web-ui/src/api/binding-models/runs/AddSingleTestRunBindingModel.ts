import RunType from '../../enums/RunType';

interface AddSingleTestRunBindingModel {
	type: RunType;
	testId: string;
}

export default AddSingleTestRunBindingModel;
