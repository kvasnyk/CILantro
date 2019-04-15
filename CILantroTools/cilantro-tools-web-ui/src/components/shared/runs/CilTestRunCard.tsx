import classNames from 'classnames';
import React, { Fragment, FunctionComponent, useEffect, useState } from 'react';

import {
	Card,
	CardActions,
	CardContent,
	Collapse,
	IconButton,
	Paper,
	Table,
	TableBody,
	TableCell,
	TableRow,
	Theme,
	Typography
} from '@material-ui/core';
import { green, grey, red } from '@material-ui/core/colors';
import AddIcon from '@material-ui/icons/AddRounded';
import CheckIcon from '@material-ui/icons/CheckRounded';
import ExpandMoreIcon from '@material-ui/icons/ExpandMoreRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import NoIcon from '@material-ui/icons/RemoveRounded';
import { makeStyles } from '@material-ui/styles';

import RunsApiClient from '../../../api/clients/RunsApiClient';
import TestsApiClient from '../../../api/clients/TestsApiClient';
import RunOutcome from '../../../api/enums/RunOutcome';
import TestRunStep from '../../../api/enums/TestRunStep';
import TestRunFullReadModel from '../../../api/read-models/runs/TestRunFullReadModel';
import TestRunReadModel from '../../../api/read-models/runs/TestRunReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilCodeEditor from '../../utils/CilCodeEditor';
import CilShowTestButton from '../tests/CilShowTestButton';

const useStyles = makeStyles((theme: Theme) => ({
	tablePaper: {
		marginTop: '20px'
	},
	cardExpanded: {
		width: '160%',
		transform: 'translateX(-18.75%)'
	},
	cardActions: {
		justifyContent: 'flex-end',
		marginRight: '5px'
	},
	expand: {
		marginLeft: 0,
		marginRight: 0,
		transform: 'rotate(0deg)',
		transition: theme.transitions.create('transform', {
			duration: theme.transitions.duration.shortest
		})
	},
	expandOpen: {
		transform: 'rotate(180deg)'
	},
	okBackgroundColor1: {
		backgroundColor: green[500]
	},
	wrongBackgroundColor1: {
		backgroundColor: red[500]
	},
	okColor: {
		color: theme.palette.common.white
	},
	wrongColor: {
		color: theme.palette.common.white
	},
	okIcon: {
		color: green[500]
	},
	wrongIcon: {
		color: red[500]
	},
	noIcon: {
		color: grey[500]
	},
	expandedItemExpandButton: {
		transform: 'rotate(180deg)'
	},
	itemIo: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'space-around',
		'&>*': {
			width: '30%'
		}
	}
}));

interface CilTestRunCardProps {
	testRun: TestRunReadModel;
	isExpanded: boolean;
	onExpandButtonClick: (testRunId: string) => void;
}

const CilTestRunCard: FunctionComponent<CilTestRunCardProps> = props => {
	const classes = useStyles();

	const runsApiClient = new RunsApiClient();
	const testsApiClient = new TestsApiClient();

	const notistack = useNotistack();

	const [testRun, setTestRun] = useState<TestRunFullReadModel | undefined>(undefined);
	const [expandedItem, setExpandedItem] = useState<string | undefined>(undefined);

	const handleExpandButtonClick = () => {
		props.onExpandButtonClick(props.testRun.id);
		setExpandedItem(undefined);
	};

	const backgroundColor1ClassName = classNames({
		[classes.okBackgroundColor1]: props.testRun.outcome === RunOutcome.Ok,
		[classes.wrongBackgroundColor1]: props.testRun.outcome === RunOutcome.Wrong
	});

	const colorClassName = classNames({
		[classes.okColor]: props.testRun.outcome === RunOutcome.Ok,
		[classes.wrongColor]: props.testRun.outcome === RunOutcome.Wrong
	});

	const cardClassName = classNames(backgroundColor1ClassName, colorClassName, {
		[classes.cardExpanded]: props.isExpanded
	});

	const refreshTestRun = async () => {
		try {
			const getRunResponse = await runsApiClient.getFullTestRun(props.testRun.runId, props.testRun.id);
			setTestRun(getRunResponse.data);
		} catch (error) {
			setTestRun(undefined);
		}
	};

	useEffect(
		() => {
			if (props.isExpanded && !testRun) {
				refreshTestRun();
			}
		},
		[props.isExpanded]
	);

	const handleExpandItemButtonClick = (itemName: string) => {
		setExpandedItem(prev => (prev === itemName ? undefined : itemName));
	};

	const testRunItems =
		testRun &&
		testRun.items
			.sort((ia, ib) => ia.itemName.localeCompare(ib.itemName))
			.map(item => {
				const generateInputFilesStep = item.steps.find(s => s.step === TestRunStep.GenerateInputFiles);
				const generateExeOutputsStep = item.steps.find(s => s.step === TestRunStep.GenerateExeOutputFiles);
				const generateAntroOutputsStep = item.steps.find(s => s.step === TestRunStep.GenerateCilAntroOutputFiles);
				const compareOutputsStep = item.steps.find(s => s.step === TestRunStep.CompareOutputFiles);

				const overallOutcome = [
					generateInputFilesStep,
					generateExeOutputsStep,
					generateAntroOutputsStep,
					compareOutputsStep
				].some(s => !s || s.outcome === RunOutcome.Wrong)
					? RunOutcome.Wrong
					: RunOutcome.Ok;

				return {
					itemName: item.itemName,
					overallOutcome,
					inputsOutcome: generateInputFilesStep ? generateInputFilesStep.outcome : undefined,
					exeOutputsOutcome: generateExeOutputsStep ? generateExeOutputsStep.outcome : undefined,
					antroOutputsOutcome: generateAntroOutputsStep ? generateAntroOutputsStep.outcome : undefined,
					compareOutcome: compareOutputsStep ? compareOutputsStep.outcome : undefined,
					input: item.input,
					exeOutput: item.exeOutput,
					antroOutput: item.antroOutput
				};
			});

	const handleAddDifficultExampleButtonClick = async (itemName: string) => {
		try {
			const item = testRunItems!.find(i => i.itemName === itemName)!;
			await testsApiClient.addTestInputOutputExample(props.testRun.testId, {
				name: 'NOT IMPORTANT',
				input: item.input,
				output: item.exeOutput,
				isDifficult: true
			});
			notistack.enqueueSuccess(translations.tests.ioExampleHasBeenAdded);
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileAddingIoExample);
		}
	};

	const okIcon = (fontSize: 'small' | 'large' | 'default') => (
		<CheckIcon fontSize={fontSize} className={classes.okIcon} />
	);
	const wrongIcon = (fontSize: 'small' | 'large' | 'default') => (
		<NotCheckIcon fontSize={fontSize} className={classes.wrongIcon} />
	);
	const noIcon = (fontSize: 'small' | 'large' | 'default') => <NoIcon fontSize={fontSize} className={classes.noIcon} />;

	const getIcon = (outcome?: RunOutcome, fontSize: 'small' | 'large' | 'default' = 'small') => {
		if (outcome === undefined) {
			return noIcon(fontSize);
		}

		return outcome === RunOutcome.Ok ? okIcon(fontSize) : wrongIcon(fontSize);
	};

	return (
		<Card className={cardClassName}>
			<CardContent>
				<Typography variant="h2" className={colorClassName}>
					{props.testRun.testName}
				</Typography>
				<Collapse in={props.isExpanded} timeout="auto" unmountOnExit={false}>
					{testRun && testRunItems ? (
						<Paper className={classes.tablePaper}>
							<Table>
								<TableBody>
									{testRunItems.map(item => (
										<Fragment key={item.itemName}>
											<TableRow>
												<TableCell>{item.itemName}</TableCell>
												<TableCell align="center">{getIcon(item.inputsOutcome)}</TableCell>
												<TableCell align="center">{getIcon(item.exeOutputsOutcome)}</TableCell>
												<TableCell align="center">{getIcon(item.antroOutputsOutcome)}</TableCell>
												<TableCell align="center">{getIcon(item.compareOutcome)}</TableCell>
												<TableCell align="center">{getIcon(item.compareOutcome, 'default')}</TableCell>
												<TableCell align="right">
													<IconButton onClick={() => handleAddDifficultExampleButtonClick(item.itemName)}>
														<AddIcon fontSize="small" />
													</IconButton>
													<IconButton
														onClick={() => handleExpandItemButtonClick(item.itemName)}
														className={expandedItem === item.itemName ? classes.expandedItemExpandButton : undefined}
													>
														<ExpandMoreIcon fontSize="small" />
													</IconButton>
												</TableCell>
											</TableRow>
											{expandedItem === item.itemName ? (
												<TableRow>
													<TableCell colSpan={7}>
														<div className={classes.itemIo}>
															<div>
																<CilCodeEditor code={item.input} />
															</div>
															<div>
																<CilCodeEditor code={item.exeOutput} />
															</div>
															<div>
																<CilCodeEditor code={item.antroOutput} />
															</div>
														</div>
													</TableCell>
												</TableRow>
											) : null}
										</Fragment>
									))}
								</TableBody>
							</Table>
						</Paper>
					) : null}
				</Collapse>
			</CardContent>
			<CardActions className={classes.cardActions}>
				<CilShowTestButton testId={props.testRun.testId} iconClassName={colorClassName} icon="code" />
				<IconButton
					className={classNames(classes.expand, colorClassName, {
						[classes.expandOpen]: props.isExpanded
					})}
					onClick={handleExpandButtonClick}
				>
					<ExpandMoreIcon />
				</IconButton>
			</CardActions>
		</Card>
	);
};

export default CilTestRunCard;
