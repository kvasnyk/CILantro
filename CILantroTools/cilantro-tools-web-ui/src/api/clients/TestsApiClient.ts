import apiRoutes from '../apiRoutes';
import CreateTestFromCandidateBindingModel from '../binding-models/tests/CreateTestFromCandidateBindingModel';
import TestCandidate from '../models/tests/TestCandidate';
import ApiClientBase from './ApiClientBase';

class TestsApiClient extends ApiClientBase {
  public findTests() {
    return this.get<TestCandidate[]>(apiRoutes.tests.findTests);
  }

  public createTestFromCandidate(data: CreateTestFromCandidateBindingModel) {
    return this.post<CreateTestFromCandidateBindingModel, string>(
      apiRoutes.tests.createFromCandidate,
      data
    );
  }
}

export default TestsApiClient;
