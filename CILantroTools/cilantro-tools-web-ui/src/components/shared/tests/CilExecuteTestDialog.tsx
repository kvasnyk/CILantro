import classNames from 'classnames';
import React, { FunctionComponent, useEffect, useState } from 'react';

import { AppBar, Dialog, DialogContent, Theme, Toolbar, Typography } from '@material-ui/core';
import orange from '@material-ui/core/colors/orange';
import CloseIcon from '@material-ui/icons/CloseRounded';
import { makeStyles } from '@material-ui/styles';

import TestInfo from '../../../api/models/tests/TestInfo';
import useExecuteTestHub, { TestExecutionType } from '../../../hooks/useExecuteTestHub';
import translations from '../../../translations/translations';
import CilPage, { PageState } from '../../base/CilPage';
import CilConsole, { CilConsoleLine } from '../../utils/CilConsole';
import CilIconButton from '../../utils/CilIconButton';

const useStyles = makeStyles((theme: Theme) => ({
	appBarIcon: {
		fill: theme.palette.primary.contrastText
	},
	dialogContent: {
		display: 'flex',
		flexDirection: 'column'
	},
	page: {
		height: '100%'
	},
	toolbar: {
		display: 'flex'
	},
	toolbarInterpreter: {
		backgroundColor: orange[500]
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
	executionType: TestExecutionType;
	testInfo: TestInfo;
	onClose: () => void;
}

const CilExecuteTestDialog: FunctionComponent<CilRunTestExeDialogProps> = props => {
	const classes = useStyles();

	const [consoleLines, setConsoleLines] = useState<CilConsoleLine[]>([]);
	const [pageState, setPageState] = useState<PageState>('loading');
	const [isInputEnabled, setIsInputEnabled] = useState<boolean>(false);

	const handleCloseButtonClick = () => {
		props.onClose();
		return Promise.resolve();
	};

	const handleDialogClose = () => {
		props.onClose();
	};

	const handleKeyUp = (event: KeyboardEvent) => {
		if (event.key === 'Escape') {
			handleDialogClose();
		}
	};

	const handleHubConnectionStart = () => {
		setPageState('success');
	};

	const handleHubConnectionError = () => {
		setPageState('error');
	};

	const handleTestExecutionStart = () => {
		setConsoleLines(prevConsoleLines => [
			...prevConsoleLines,
			{
				type: 'start',
				content: translations.tests.exeProcessStarted
			}
		]);
		setIsInputEnabled(true);
	};

	const handleTestExecutionEnd = () => {
		setConsoleLines(prevConsoleLines => [
			...prevConsoleLines,
			{
				type: 'end',
				content: translations.tests.exeProcessEnded
			}
		]);
		setIsInputEnabled(false);
	};

	const handleExecutionOutput = (line: string) => {
		setConsoleLines(prevConsoleLines => [...prevConsoleLines, { type: 'output', content: line }]);
	};

	const handleExecutionError = (line: string) => {
		setConsoleLines(prevConsoleLines => [...prevConsoleLines, { type: 'error', content: line }]);
	};

	const executeTestHub = useExecuteTestHub({
		executionType: props.executionType,
		testId: props.testInfo.test.id,
		onConnectionStart: handleHubConnectionStart,
		onConnectionError: handleHubConnectionError,
		onExecutionStart: handleTestExecutionStart,
		onExecutionEnd: handleTestExecutionEnd,
		onExecutionOutput: handleExecutionOutput,
		onExecutionError: handleExecutionError
	});

	const handleLineAdded = async (newLine: string) => {
		await executeTestHub!.input(newLine).then(() => {
			setConsoleLines(prevConsoleLines => [
				...prevConsoleLines,
				{
					type: 'input',
					content: newLine
				}
			]);
		});
	};

	useEffect(() => {
		window.addEventListener('keyup', handleKeyUp);

		return () => {
			window.removeEventListener('keyup', handleKeyUp);
		};
	}, []);

	const toolbarClassName = classNames(classes.toolbar, {
		[classes.toolbarInterpreter]: props.executionType === 'cilantro-interpreter'
	});

	return (
		<Dialog open={true} fullScreen={true} onClose={handleDialogClose}>
			<AppBar>
				<Toolbar className={toolbarClassName}>
					<div className={classes.toolbarLeft}>
						<Typography variant="h6" color="inherit">
							{props.testInfo.test.name}
						</Typography>
					</div>
					<div className={classes.toolbarRight}>
						<CilIconButton onClick={handleCloseButtonClick}>
							<CloseIcon className={classes.appBarIcon} />
						</CilIconButton>
					</div>
				</Toolbar>
			</AppBar>
			<DialogContent className={classes.dialogContent}>
				<div className={classes.fakeToolbar} />
				<CilPage state={pageState} className={classes.page}>
					<div className={classes.content}>
						<CilConsole
							lines={consoleLines}
							title={'...' + props.testInfo.exePath}
							onLineAdded={handleLineAdded}
							isInputEnabled={isInputEnabled}
						/>
					</div>
				</CilPage>
			</DialogContent>
		</Dialog>
	);
};

export default CilExecuteTestDialog;
