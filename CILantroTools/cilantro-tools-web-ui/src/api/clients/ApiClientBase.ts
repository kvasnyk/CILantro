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

  protected post<TData, TResult>(url: string, data: TData) {
    return this.axiosInstance.post<TResult>(url, data);
  }
}

export default ApiClientBase;
