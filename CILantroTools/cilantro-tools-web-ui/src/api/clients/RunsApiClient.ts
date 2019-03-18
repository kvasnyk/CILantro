import apiRoutes from '../apiRoutes';
import AddRunBindingModel from '../binding-models/runs/AddRunBindingModel';
import RunReadModel from '../read-models/runs/RunReadModel';
import SearchParameter from '../search/SearchParameter';
import SearchResult from '../search/SearchResult';
import ApiClientBase from './ApiClientBase';

class RunsApiClient extends ApiClientBase {
	public addRun(data: AddRunBindingModel) {
		return this.post<AddRunBindingModel, string>(apiRoutes.runs.addRun, data);
	}

	public searchRuns(searchParameter: SearchParameter) {
		return this.get<SearchParameter, SearchResult<RunReadModel>>(apiRoutes.runs.searchRuns, searchParameter);
	}

	public deleteRun(runId: string) {
		return this.delete<{}>(apiRoutes.runs.deleteRun(runId), {});
	}
}

export default RunsApiClient;
