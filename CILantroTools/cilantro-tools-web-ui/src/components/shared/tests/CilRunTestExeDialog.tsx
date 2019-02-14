import React, { FunctionComponent, useEffect, useState } from 'react';

import * as SignalR from '@aspnet/signalr';
import { AppBar, Dialog, DialogContent, IconButton, Theme, Toolbar, Typography } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/CloseRounded';
import { makeStyles } from '@material-ui/styles';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import translations from '../../../translations/translations';
import CilConsole, { CilConsoleLine } from '../../utils/CilConsole';

const appSettings = require('appSettings');

const useStyles = makeStyles((theme: Theme) => ({
	appBarIcon: {
		fill: theme.palette.primary.contrastText
	},
	toolbar: {
		display: 'flex'
	},
	fakeToolbar: theme.mixins.toolbar,
	toolbarLeft: {
		flexGrow: 1,
		flexBasis: 0,
		display: 'flex',
		alignItems: 'center'
	},
	toolbarRight: {
		flexGrow: 1,
		flexBasis: 0,
		display: 'flex',
		justifyContent: 'flex-end'
	},
	runningExeTypography: {
		marginLeft: '10px'
	},
	content: {
		padding: '15px',
		paddingTop: '30px'
	}
}));

interface CilRunTestExeDialogProps {
	test: TestReadModel;
	onClose: () => void;
}

const CilRunTestExeDialog: FunctionComponent<CilRunTestExeDialogProps> = props => {
	const classes = useStyles();

	const [connection, setConnection] = useState<SignalR.HubConnection | undefined>(undefined);
	const [consoleLines, setConsoleLines] = useState<CilConsoleLine[]>([]);

	const sendInputLine = (line: string) => {
		if (connection) {
			return connection.send('input', line).catch(error => {
				alert(error);
			});
		}

		return Promise.resolve();
	};

	const handleCloseButtonClick = () => {
		props.onClose();
	};

	const handleDialogClose = () => {
		props.onClose();
	};

	const handleLineAdded = (newLine: string) => {
		sendInputLine(newLine).then(() => {
			setConsoleLines(prevConsoleLines => [
				...prevConsoleLines,
				{
					type: 'in',
					content: newLine
				}
			]);
		});
	};

	useEffect(() => {
		const newConnection = new SignalR.HubConnectionBuilder().withUrl(appSettings.hubsBaseUrl + '/run-exe-hub').build();
		newConnection
			.start()
			.then(() => {
				setConnection(newConnection);

				newConnection
					.send('run', props.test.id)

					.catch(error => {
						alert(error);
					});
			})
			.catch(error => {
				alert(error);
			});

		newConnection.on('start', () => {
			setConsoleLines(prevConsoleLines => [
				...prevConsoleLines,
				{
					type: 'start',
					content: translations.tests.exeProcessStarted
				}
			]);
		});

		newConnection.on('end', () => {
			setConsoleLines(prevConsoleLines => [
				...prevConsoleLines,
				{
					type: 'end',
					content: translations.tests.exeProcessEnded
				}
			]);
		});

		newConnection.on('out', line => {
			setConsoleLines(prevConsoleLines => [
				...prevConsoleLines,
				{
					type: 'out',
					content: line
				}
			]);
		});

		return () => {
			if (newConnection) {
				newConnection.stop();
			}
		};
	}, []);

	return (
		<Dialog open={true} fullScreen={true} onClose={handleDialogClose}>
			<AppBar>
				<Toolbar className={classes.toolbar}>
					<div className={classes.toolbarLeft}>
						<Typography variant="h6" color="inherit">
							{props.test.name}
						</Typography>
						<Typography variant="subtitle1" color="inherit" className={classes.runningExeTypography}>
							{translations.tests.runningExe}
						</Typography>
					</div>
					<div className={classes.toolbarRight}>
						<IconButton onClick={handleCloseButtonClick}>
							<CloseIcon className={classes.appBarIcon} />
						</IconButton>
					</div>
				</Toolbar>
			</AppBar>
			<DialogContent>
				<div className={classes.fakeToolbar} />
				<div className={classes.content}>
					<CilConsole lines={consoleLines} title={'...' + props.test.exePath} onLineAdded={handleLineAdded} />
				</div>
			</DialogContent>
		</Dialog>
	);
};

export default CilRunTestExeDialog;
