import apiRoutes from '../apiRoutes';
import CreateTestFromCandidateBindingModel from '../binding-models/tests/CreateTestFromCandidateBindingModel';
import EditTestCategoryBindingModel from '../binding-models/tests/EditTestCategoryBindingModel';
import EditTestSubcategoryBindingModel from '../binding-models/tests/EditTestSubcategoryBindingModel';
import TestCandidate from '../models/tests/TestCandidate';
import TestReadModel from '../read-models/tests/TestReadModel';
import SearchParameter from '../search/SearchParameter';
import SearchResult from '../search/SearchResult';
import ApiClientBase from './ApiClientBase';

class TestsApiClient extends ApiClientBase {
	public findTests() {
		return this.get<{}, TestCandidate[]>(apiRoutes.tests.findTests, {});
	}

	public createTestFromCandidate(data: CreateTestFromCandidateBindingModel) {
		return this.post<CreateTestFromCandidateBindingModel, string>(apiRoutes.tests.createFromCandidate, data);
	}

	public getTest(testId: string) {
		return this.get<{}, TestReadModel>(apiRoutes.tests.getTest(testId), {});
	}

	public searchTests(searchParameter: SearchParameter) {
		return this.get<SearchParameter, SearchResult<TestReadModel>>(apiRoutes.tests.searchTests, searchParameter);
	}

	public editTestCategory(testId: string, data: EditTestCategoryBindingModel) {
		return this.put<EditTestCategoryBindingModel, {}>(apiRoutes.tests.editTestCategory(testId), data);
	}

	public editTestSubcategory(testId: string, data: EditTestSubcategoryBindingModel) {
		return this.put<EditTestSubcategoryBindingModel, {}>(apiRoutes.tests.editTestSubcategory(testId), data);
	}
}

export default TestsApiClient;
