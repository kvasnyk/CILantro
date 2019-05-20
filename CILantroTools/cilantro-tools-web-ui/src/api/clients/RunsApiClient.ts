import apiRoutes from '../apiRoutes';
import AddRunBindingModel from '../binding-models/runs/AddRunBindingModel';
import AddSingleTestRunBindingModel from '../binding-models/runs/AddSingleTestRunBindingModel';
import RunReadModel from '../read-models/runs/RunReadModel';
import TestRunFullReadModel from '../read-models/runs/TestRunFullReadModel';
import TestRunReadModel from '../read-models/runs/TestRunReadModel';
import SearchParameter from '../search/SearchParameter';
import SearchResult from '../search/SearchResult';
import ApiClientBase from './ApiClientBase';

class RunsApiClient extends ApiClientBase {
	public addRun(data: AddRunBindingModel) {
		return this.post<AddRunBindingModel, string>(apiRoutes.runs.addRun, data);
	}

	public addSingleTestRun(data: AddSingleTestRunBindingModel) {
		return this.post<AddSingleTestRunBindingModel, string>(apiRoutes.runs.addSingleTestRun, data);
	}

	public searchRuns(searchParameter: SearchParameter<RunReadModel>) {
		return this.post<SearchParameter<RunReadModel>, SearchResult<RunReadModel>>(
			apiRoutes.runs.searchRuns,
			searchParameter
		);
	}

	public searchTestRuns(runId: string, searchParameter: SearchParameter<TestRunReadModel>) {
		return this.post<SearchParameter<TestRunReadModel>, SearchResult<TestRunReadModel>>(
			apiRoutes.runs.searchTestRuns(runId),
			searchParameter
		);
	}

	public deleteRun(runId: string) {
		return this.delete<{}>(apiRoutes.runs.deleteRun(runId), {});
	}

	public replayRun(runId: string) {
		return this.post<{}, {}>(apiRoutes.runs.replayRun(runId), {});
	}

	public getRun(runId: string) {
		return this.get<{}, RunReadModel>(apiRoutes.runs.getRun(runId), {});
	}

	public getFullTestRun(runId: string, testRunId: string) {
		return this.get<{}, TestRunFullReadModel>(apiRoutes.runs.getFullTestRun(runId, testRunId), {});
	}
}

export default RunsApiClient;
