import AxiosStatic, { AxiosInstance } from 'axios';
import { AppConfig } from '../config/AppConfig';

const axiosInstance = AxiosStatic.create({
    baseURL: AppConfig.apiBaseUrl,
    timeout: AppConfig.apiTimeout
});

abstract class ApiClientBase {
    private axiosInstance: AxiosInstance = axiosInstance;

    protected get = <TResult>(url: string) => this.axiosInstance.get<TResult>(url);

    protected post = <TResult>(url: string, data: object | string) => this.axiosInstance.post<TResult>(url, data);

    protected put = <TResult>(url: string, data: object | string) => this.axiosInstance.put<TResult>(url, data);

    protected delete = <TResult>(url: string, data: object) => this.axiosInstance.delete(url, {
        data
    });
}

export default ApiClientBase;