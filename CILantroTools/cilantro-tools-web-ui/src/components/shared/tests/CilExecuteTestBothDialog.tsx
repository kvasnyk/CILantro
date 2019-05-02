import React, { FunctionComponent, useEffect, useState } from 'react';

import { AppBar, Dialog, DialogContent, Theme, Toolbar, Typography } from '@material-ui/core';
import orange from '@material-ui/core/colors/orange';
import CloseIcon from '@material-ui/icons/CloseRounded';
import { makeStyles } from '@material-ui/styles';

import TestInfo from '../../../api/models/tests/TestInfo';
import useExecuteTestHub from '../../../hooks/useExecuteTestHub';
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
		display: 'flex',
		background: `linear-gradient(to right, ${theme.palette.primary.main} 0%, ${theme.palette.primary.main} 50%, ${
			orange[500]
		} 50%, ${orange[500]} 100%)`,
		color: theme.palette.common.white
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
	content: {
		padding: '15px',
		paddingTop: '30px',
		display: 'flex',
		flexDirection: 'row',
		minHeight: 'calc(100% - 45px)'
	},
	exeConsole: {
		marginRight: '20px',
		width: 'calc(50% - 10px)'
	},
	interpreterConsole: {
		width: 'calc(50% - 10px)'
	}
}));

interface CilExecuteTestBothDialogProps {
	testInfo: TestInfo;
	onClose: () => void;
}

const CilExecuteTestBothDialog: FunctionComponent<CilExecuteTestBothDialogProps> = props => {
	const classes = useStyles();

	const [exePageState, setExePageState] = useState<PageState>('loading');
	const [interpreterPageState, setInterpreterPageState] = useState<PageState>('loading');
	const [exeConsoleLines, setExeConsoleLines] = useState<CilConsoleLine[]>([]);
	const [interpreterConsoleLines, setInterpreterConsoleLines] = useState<CilConsoleLine[]>([]);
	const [isExeInputEnabled, setIsExeInputEnabled] = useState<boolean>(false);
	const [isInterpreterInputEnabled, setIsInterpreterInputEnabled] = useState<boolean>(false);
	const [isExeEnded, setIsExeEnded] = useState<boolean>(false);
	const [isInterpreterEnded, setIsInterpreterEnded] = useState<boolean>(false);

	let pageState: PageState = 'loading';
	if (exePageState === 'error' || interpreterPageState === 'error') {
		pageState = 'error';
	}
	if (exePageState === 'success' && interpreterPageState === 'success') {
		pageState = 'success';
	}

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

	const exeHub = useExecuteTestHub({
		executionType: 'exe',
		testId: props.testInfo.test.id,
		onConnectionStart: () => {
			setExePageState('success');
		},
		onConnectionError: () => {
			setExePageState('error');
		},
		onExecutionStart: () => {
			setExeConsoleLines(prevConsoleLines => [
				...prevConsoleLines,
				{
					type: 'start',
					content: translations.tests.exeProcessStarted
				}
			]);
			setIsExeInputEnabled(true);
		},
		onExecutionEnd: () => {
			setExeConsoleLines(prevConsoleLines => [
				...prevConsoleLines,
				{
					type: 'end',
					content: translations.tests.exeProcessEnded
				}
			]);
			setIsExeInputEnabled(false);
			setIsExeEnded(true);
		},
		onExecutionOutput: line => {
			setExeConsoleLines(prevConsoleLines => [...prevConsoleLines, { type: 'output', content: line }]);
		},
		onExecutionError: line => {
			setExeConsoleLines(prevConsoleLines => [...prevConsoleLines, { type: 'error', content: line }]);
		}
	});

	const interpreterHub = useExecuteTestHub({
		executionType: 'cilantro-interpreter',
		testId: props.testInfo.test.id,
		onConnectionStart: () => {
			setInterpreterPageState('success');
		},
		onConnectionError: () => {
			setInterpreterPageState('error');
		},
		onExecutionStart: () => {
			setInterpreterConsoleLines(prevConsoleLines => [
				...prevConsoleLines,
				{
					type: 'start',
					content: translations.tests.exeProcessStarted
				}
			]);
			setIsInterpreterInputEnabled(true);
		},
		onExecutionEnd: () => {
			setInterpreterConsoleLines(prevConsoleLines => [
				...prevConsoleLines,
				{
					type: 'end',
					content: translations.tests.exeProcessEnded
				}
			]);
			setIsInterpreterInputEnabled(false);
			setIsInterpreterEnded(true);
		},
		onExecutionOutput: line => {
			setInterpreterConsoleLines(prevConsoleLines => [...prevConsoleLines, { type: 'output', content: line }]);
		},
		onExecutionError: line => {
			setInterpreterConsoleLines(prevConsoleLines => [...prevConsoleLines, { type: 'error', content: line }]);
		}
	});

	const handleLineAdded = async (newLine: string) => {
		if (!isExeEnded) {
			exeHub!.input(newLine).then(() => {
				setExeConsoleLines(prevConsoleLines => [
					...prevConsoleLines,
					{
						type: 'input',
						content: newLine
					}
				]);
			});
		}

		if (!isInterpreterEnded) {
			interpreterHub!.input(newLine).then(() => {
				setInterpreterConsoleLines(prevConsoleLines => [
					...prevConsoleLines,
					{
						type: 'input',
						content: newLine
					}
				]);
			});
		}
	};

	useEffect(() => {
		window.addEventListener('keyup', handleKeyUp);

		return () => {
			window.removeEventListener('keyup', handleKeyUp);
		};
	}, []);

	return (
		<Dialog open={true} fullScreen={true} onClose={handleDialogClose}>
			<AppBar>
				<Toolbar className={classes.toolbar}>
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
							className={classes.exeConsole}
							lines={exeConsoleLines}
							title={'...' + props.testInfo.exePath}
							onLineAdded={handleLineAdded}
							isInputEnabled={isExeInputEnabled}
							autoFocus={true}
						/>
						<CilConsole
							className={classes.interpreterConsole}
							lines={interpreterConsoleLines}
							title={'...' + props.testInfo.exePath}
							onLineAdded={handleLineAdded}
							isInputEnabled={isInterpreterInputEnabled}
							autoFocus={false}
						/>
					</div>
				</CilPage>
			</DialogContent>
		</Dialog>
	);
};

export default CilExecuteTestBothDialog;
