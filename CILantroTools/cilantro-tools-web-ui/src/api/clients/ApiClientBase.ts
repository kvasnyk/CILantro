import AxiosStatic, { AxiosInstance } from 'axios';

const appSettings = require('appSettings');

const axiosInstance = AxiosStatic.create({
	baseURL: appSettings.apiBaseUrl,
	timeout: appSettings.apiTimeout
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

	protected put<TData, TResult>(url: string, data: TData) {
		return this.axiosInstance.put<TResult>(url, data);
	}
}

export default ApiClientBase;
