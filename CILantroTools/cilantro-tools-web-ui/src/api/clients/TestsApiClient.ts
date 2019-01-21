import apiRoutes from '../apiRoutes';
import TestCandidate from '../models/tests/TestCandidate';
import ApiClientBase from './ApiClientBase';

class TestsApiClient extends ApiClientBase {
  public findTests() {
    return this.get<TestCandidate[]>(apiRoutes.tests.findTests);
  }
}

export default TestsApiClient;
