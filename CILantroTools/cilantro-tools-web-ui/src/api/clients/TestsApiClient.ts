import apiRoutes from '../apiRoutes';
import AddTestInputOutputExampleBindingModel from '../binding-models/tests/AddTestInputOutputExampleBindingModel';
import CopyTestInputBindingModel from '../binding-models/tests/CopyTestInputBindingModel';
import CreateTestFromCandidateBindingModel from '../binding-models/tests/CreateTestFromCandidateBindingModel';
import EditTestCategoryBindingModel from '../binding-models/tests/EditTestCategoryBindingModel';
import EditTestHasEmptyInputBindingModel from '../binding-models/tests/EditTestHasEmptyInputBindingModel';
import EditTestInputBindingModel from '../binding-models/tests/EditTestInputBindingModel';
import EditTestOutputBindingModel from '../binding-models/tests/EditTestOutputBindingModel';
import EditTestSubcategoryBindingModel from '../binding-models/tests/EditTestSubcategoryBindingModel';
import GenerateOutputBindingModel from '../binding-models/tests/GenerateOutputBindingModel';
import TestCandidate from '../models/tests/TestCandidate';
import TestInfo from '../models/tests/TestInfo';
import TestsCheck from '../models/tests/TestsCheck';
import TestReadModel from '../read-models/tests/TestReadModel';
import SearchParameter from '../search/SearchParameter';
import SearchResult from '../search/SearchResult';
import ApiClientBase from './ApiClientBase';

class TestsApiClient extends ApiClientBase {
	public findTests() {
		return this.get<{}, TestCandidate[]>(apiRoutes.tests.findTests, {});
	}

	public checkTests() {
		return this.get<{}, TestsCheck>(apiRoutes.tests.checkTests, {});
	}

	public createTestFromCandidate(data: CreateTestFromCandidateBindingModel) {
		return this.post<CreateTestFromCandidateBindingModel, string>(apiRoutes.tests.createFromCandidate, data);
	}

	public getTestInfo(testId: string) {
		return this.get<{}, TestInfo>(apiRoutes.tests.getTest(testId), {});
	}

	public searchTests(searchParameter: SearchParameter<TestReadModel>) {
		return this.post<SearchParameter<TestReadModel>, SearchResult<TestReadModel>>(
			apiRoutes.tests.searchTests,
			searchParameter
		);
	}

	public editTestCategory(testId: string, data: EditTestCategoryBindingModel) {
		return this.put<EditTestCategoryBindingModel, {}>(apiRoutes.tests.editTestCategory(testId), data);
	}

	public editTestSubcategory(testId: string, data: EditTestSubcategoryBindingModel) {
		return this.put<EditTestSubcategoryBindingModel, {}>(apiRoutes.tests.editTestSubcategory(testId), data);
	}

	public editTestHasEmptyInput(testId: string, data: EditTestHasEmptyInputBindingModel) {
		return this.put<EditTestHasEmptyInputBindingModel, {}>(apiRoutes.tests.editTestHasEmptyInput(testId), data);
	}

	public editTestInput(testId: string, data: EditTestInputBindingModel) {
		return this.put<EditTestInputBindingModel, {}>(apiRoutes.tests.editTestInput(testId), data);
	}

	public editTestOutput(testId: string, data: EditTestOutputBindingModel) {
		return this.put<EditTestOutputBindingModel, {}>(apiRoutes.tests.editTestOutput(testId), data);
	}

	public copyTestInput(testId: string, data: CopyTestInputBindingModel) {
		return this.post<CopyTestInputBindingModel, {}>(apiRoutes.tests.copyTestInput(testId), data);
	}

	public generateIlSources(testId: string) {
		return this.post<{}, {}>(apiRoutes.tests.generateIlSources(testId), {});
	}

	public generateExe(testId: string) {
		return this.post<{}, {}>(apiRoutes.tests.generateExe(testId), {});
	}

	public generateOutput(testId: string, data: GenerateOutputBindingModel) {
		return this.post<GenerateOutputBindingModel, string>(apiRoutes.tests.generateOutput(testId), data);
	}

	public addTestInputOutputExample(testId: string, data: AddTestInputOutputExampleBindingModel) {
		return this.post<AddTestInputOutputExampleBindingModel, {}>(
			apiRoutes.tests.addTestInputOutputExample(testId),
			data
		);
	}
}

export default TestsApiClient;
