import { useEffect, useState } from 'react';

import * as SignalR from '@aspnet/signalr';

const appSettings = require('appSettings');

export type TestExecutionType = 'exe' | 'cilantro-interpreter';

interface ExecuteTestHubConfig {
	executionType: TestExecutionType;
	testId: string;
	onConnectionStart: () => void;
	onConnectionError: () => void;
	onExecutionStart: () => void;
	onExecutionEnd: () => void;
	onExecutionOutput: (line: string) => void;
	onExecutionError: (line: string) => void;
}

interface ExecuteTestHub {
	input: (line: string) => Promise<void>;
}

const useExecuteTestHub = (hubConfig: ExecuteTestHubConfig) => {
	const [, setConnection] = useState<SignalR.HubConnection | undefined>(undefined);
	const [hub, setHub] = useState<ExecuteTestHub | undefined>(undefined);

	useEffect(() => {
		const hubConnection = new SignalR.HubConnectionBuilder().withUrl(appSettings.hubsBaseUrl + '/execute-test').build();

		hubConnection.on('start', () => {
			hubConfig.onExecutionStart();
		});

		hubConnection.on('end', () => {
			hubConfig.onExecutionEnd();
		});

		hubConnection.on('output', line => {
			hubConfig.onExecutionOutput(line);
		});

		hubConnection.on('error', line => {
			hubConfig.onExecutionError(line);
		});

		hubConnection
			.start()
			.then(() => {
				setConnection(hubConnection);

				const connectedHub = {
					input: async (line: string) => {
						try {
							return await hubConnection.send('input', line);
						} catch (error) {
							hubConfig.onConnectionError();
						}
					}
				};

				setHub(connectedHub);

				hubConfig.onConnectionStart();

				if (hubConfig.executionType === 'exe') {
					hubConnection.send('runExe', hubConfig.testId);
				} else if (hubConfig.executionType === 'cilantro-interpreter') {
					hubConnection.send('runInterpreter', hubConfig.testId);
				}
			})
			.catch(error => {
				hubConfig.onConnectionError();
			});

		return () => {
			if (hubConnection) {
				hubConnection.stop();
				setConnection(undefined);
			}
		};
	}, []);

	return hub;
};

export default useExecuteTestHub;
