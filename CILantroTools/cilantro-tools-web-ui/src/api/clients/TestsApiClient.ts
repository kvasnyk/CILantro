import apiRoutes from '../apiRoutes';
import ApiClientBase from './ApiClientBase';

class TestsApiClient extends ApiClientBase {
  public findTests() {
    return this.get<Array<unknown>>(apiRoutes.tests.findTests);
  }
}

export default TestsApiClient;
