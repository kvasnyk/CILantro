import AxiosStatic, { AxiosInstance } from 'axios';

const axiosInstance = AxiosStatic.create({
  baseURL: 'http://localhost:56473/api',
  timeout: 300000
});

abstract class ApiClientBase {
  private axiosInstance: AxiosInstance = axiosInstance;

  protected get<TData, TResult>(url: string, data: TData) {
    return this.axiosInstance.get<TResult>(url, {
      data
    });
  }

  protected post<TData, TResult>(url: string, data: TData) {
    return this.axiosInstance.post<TResult>(url, data);
  }
}

export default ApiClientBase;
