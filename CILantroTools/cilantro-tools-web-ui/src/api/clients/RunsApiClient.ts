import apiRoutes from '../apiRoutes';
import AddRunBindingModel from '../binding-models/runs/AddRunBindingModel';
import ApiClientBase from './ApiClientBase';

class RunsApiClient extends ApiClientBase {
	public addRun(data: AddRunBindingModel) {
		return this.post<AddRunBindingModel, string>(apiRoutes.runs.addRun, data);
	}
}

export default RunsApiClient;
