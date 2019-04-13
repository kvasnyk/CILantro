import classNames from 'classnames';
import React, { FunctionComponent, useEffect, useState } from 'react';

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
import CheckIcon from '@material-ui/icons/CheckRounded';
import ExpandMoreIcon from '@material-ui/icons/ExpandMoreRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import NoIcon from '@material-ui/icons/RemoveRounded';
import { makeStyles } from '@material-ui/styles';

import RunsApiClient from '../../../api/clients/RunsApiClient';
import RunOutcome from '../../../api/enums/RunOutcome';
import TestRunStep from '../../../api/enums/TestRunStep';
import TestRunFullReadModel from '../../../api/read-models/runs/TestRunFullReadModel';
import TestRunReadModel from '../../../api/read-models/runs/TestRunReadModel';
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
	}
}));

interface CilTestRunCardProps {
	testRun: TestRunReadModel;
}

const CilTestRunCard: FunctionComponent<CilTestRunCardProps> = props => {
	const classes = useStyles();

	const runsApiClient = new RunsApiClient();

	const [isExpanded, setIsExpanded] = useState<boolean>(false);
	const [testRun, setTestRun] = useState<TestRunFullReadModel | undefined>(undefined);

	const handleExpandButtonClick = () => {
		setIsExpanded(prev => !prev);
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
		[classes.cardExpanded]: isExpanded
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
			if (isExpanded && !testRun) {
				refreshTestRun();
			}
		},
		[isExpanded]
	);

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
					compareOutcome: compareOutputsStep ? compareOutputsStep.outcome : undefined
				};
			});

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
				<Collapse in={isExpanded} timeout="auto" unmountOnExit={false}>
					{testRun && testRunItems ? (
						<Paper className={classes.tablePaper}>
							<Table>
								<TableBody>
									{testRunItems.map(item => (
										<TableRow key={item.itemName}>
											<TableCell>{item.itemName}</TableCell>
											<TableCell>{getIcon(item.inputsOutcome)}</TableCell>
											<TableCell>{getIcon(item.exeOutputsOutcome)}</TableCell>
											<TableCell>{getIcon(item.antroOutputsOutcome)}</TableCell>
											<TableCell>{getIcon(item.compareOutcome)}</TableCell>
											<TableCell>{getIcon(item.compareOutcome, 'default')}</TableCell>
										</TableRow>
									))}
								</TableBody>
							</Table>
						</Paper>
					) : null}
				</Collapse>
			</CardContent>
			<CardActions className={classes.cardActions}>
				<CilShowTestButton testId={props.testRun.testId} iconClassName={colorClassName} />
				<IconButton
					className={classNames(classes.expand, colorClassName, {
						[classes.expandOpen]: isExpanded
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
