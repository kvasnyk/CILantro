import AxiosStatic, { AxiosInstance } from 'axios';

const axiosInstance = AxiosStatic.create({
  baseURL: 'http://localhost:56473/api',
  timeout: 300000
});

abstract class ApiClientBase {
  private axiosInstance: AxiosInstance = axiosInstance;

  protected get<TResult>(url: string) {
    return this.axiosInstance.get<TResult>(url);
  }
}

export default ApiClientBase;
