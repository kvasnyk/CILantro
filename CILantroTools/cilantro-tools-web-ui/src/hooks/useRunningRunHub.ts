import { useEffect, useState } from 'react';

import * as SignalR from '@aspnet/signalr';

import RunData from '../api/models/runs/RunData';

const appSettings = require('appSettings');

interface RunningRunHubConfig {
	connect: boolean;
	onRunDataUpdated: (runData: RunData) => void;
	onConnectionStart: () => void;
	onConnectionError: () => void;
}

interface RunningRunHub {}

const useRunningRunHub = (hubConfig: RunningRunHubConfig) => {
	const [, setConnection] = useState<SignalR.HubConnection | undefined>(undefined);
	const [hub, setHub] = useState<RunningRunHub | undefined>(undefined);

	useEffect(() => {
		if (hubConfig.connect) {
			const hubConnection = new SignalR.HubConnectionBuilder()
				.withUrl(appSettings.hubsBaseUrl + '/running-run')
				.build();

			hubConnection.on('update-run-data', (runData: RunData) => {
				hubConfig.onRunDataUpdated(runData);
			});

			hubConnection
				.start()
				.then(() => {
					setConnection(hubConnection);

					const connectedHub = {};

					setHub(connectedHub);

					hubConfig.onConnectionStart();
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
		}

		return () => {
			return;
		};
	}, []);

	return hub;
};

export default useRunningRunHub;
