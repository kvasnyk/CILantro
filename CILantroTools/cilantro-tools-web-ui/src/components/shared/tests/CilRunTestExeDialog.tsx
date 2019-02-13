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

	let connection: SignalR.HubConnection | undefined;

	const sendInLine = (newLine: string) => {
		if (connection) {
			connection.send('in', newLine).catch(error => {
				alert(error);
			});
		}
	};

	const [consoleLines, setConsoleLines] = useState<CilConsoleLine[]>([]);

	const handleCloseButtonClick = () => {
		props.onClose();
	};

	const handleDialogClose = () => {
		props.onClose();
	};

	const handleLineAdded = (newLine: string) => {
		setConsoleLines([
			...consoleLines,
			{
				type: 'in',
				content: newLine
			}
		]);

		sendInLine(newLine);
	};

	useEffect(() => {
		connection = new SignalR.HubConnectionBuilder().withUrl(appSettings.hubsBaseUrl + '/run-exe-hub').build();
		connection
			.start()
			.then(() => {
				connection!
					.send('runExe', props.test.id)

					.catch(error => {
						alert(error);
					});
			})
			.catch(error => {
				alert(error);
			});

		connection.on('start', () => {
			setConsoleLines([
				...consoleLines,
				{
					type: 'start',
					content: translations.tests.exeProcessStarted
				}
			]);
		});

		connection.on('end', () => {
			// setConsoleLines([
			// 	...consoleLines,
			// 	{
			// 		type: 'end',
			// 		content: translations.tests.exeProcessEnded
			// 	}
			// ]);
			consoleLines.push({
				type: 'end',
				content: translations.tests.exeProcessEnded
			});
		});

		connection.on('out', line => {
			alert(line);
			setConsoleLines([
				...consoleLines,
				{
					type: 'out',
					content: line
				}
			]);
		});

		return () => {
			connection!.stop();
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
