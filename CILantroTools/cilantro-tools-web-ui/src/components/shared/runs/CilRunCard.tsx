import classNames from 'classnames';
import moment from 'moment';
import React, { FunctionComponent, ReactNode, useState } from 'react';

import { Avatar, Card, CardActions, CardContent, LinearProgress, Theme, Typography } from '@material-ui/core';
import { green, orange, red } from '@material-ui/core/colors';
import QuickIcon from '@material-ui/icons/DirectionsRunRounded';
import FullIcon from '@material-ui/icons/HourglassEmptyRounded';
import { makeStyles } from '@material-ui/styles';

import RunOutcome from '../../../api/enums/RunOutcome';
import RunStatus from '../../../api/enums/RunStatus';
import RunType from '../../../api/enums/RunType';
import { TestRunStepHelper } from '../../../api/enums/TestRunStep';
import RunData from '../../../api/models/runs/RunData';
import RunReadModel from '../../../api/read-models/runs/RunReadModel';
import useRunningRunHub from '../../../hooks/useRunningRunHub';
import translations from '../../../translations/translations';
import CilTimeSpanDisplayer from '../../utils/CilTimeSpanDisplayer';
import CilDeleteRunButton from './CilDeleteRunButton';
import CilReplayRunButton from './CilReplayRunButton';
import CilShowRunButton from './CilShowRunButton';

const useStyles = makeStyles((theme: Theme) => ({
	intIdTypography: {
		margin: '0 0 0 10px'
	},
	cardContent: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'flex-start',
		justifyContent: 'center'
	},
	cardContentLeft: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center'
	},
	runCreatedOnContainer: {
		display: 'flex',
		flexDirection: 'column'
	},
	cardContentMiddle: {
		minHeight: '142px',
		paddingLeft: '50px',
		paddingRight: '50px',
		flexGrow: 1,
		display: 'flex',
		flexDirection: 'column',
		alignItems: 'center',
		justifyContent: 'center',
		'&>*': {
			width: '100%',
			display: 'flex',
			alignItems: 'center',
			justifyContent: 'center'
		}
	},
	cardContentRight: {
		display: 'flex',
		flexDirection: 'column',
		alignItems: 'center',
		justifyContent: 'center'
	},
	cardActions: {
		minHeight: '64px',
		justifyContent: 'flex-end',
		marginRight: '5px'
	},
	runningColor: {
		color: theme.palette.common.white
	},
	runningBackgroundColor1: {
		backgroundColor: orange[500]
	},
	runningBackgroundColor2: {
		backgroundColor: orange[700]
	},
	cancelledColor: {
		color: theme.palette.common.white
	},
	cancelledBackgroundColor1: {
		backgroundColor: '#aaaaaa'
	},
	cancelledBackgroundColor2: {
		backgroundColor: '#777777'
	},
	okColor: {
		color: theme.palette.common.white
	},
	okBackgroundColor1: {
		backgroundColor: green[500]
	},
	okBackgroundColor2: {
		backgroundColor: green[700]
	},
	wrongColor: {
		color: theme.palette.common.white
	},
	wrongBackgroundColor1: {
		backgroundColor: red[500]
	},
	wrongBackgroundColor2: {
		backgroundColor: red[700]
	},
	linearProgress: {
		backgroundColor: orange[300]
	},
	linearProgressBar: {
		backgroundColor: orange[700]
	},
	testNameTypography: {
		marginBottom: '20px'
	},
	itemsProgress: {
		marginTop: '20px'
	},
	passedFailedTypography: {
		fontSize: '2.5rem'
	}
}));

interface CilRunCardProps {
	run: RunReadModel;
	onRunDeleted: () => void;
	onRunReplayed: () => void;
	onHubConnectionError: () => void;
}

const CilRunCard: FunctionComponent<CilRunCardProps> = props => {
	const classes = useStyles();

	const [runData, setRunData] = useState<RunData>({
		status: props.run.status,
		outcome: props.run.outcome,
		processedTestsCount: props.run.processedTestsCount,
		processedForMilliseconds: props.run.processedForMilliseconds,
		testStepsCount: 0,
		okTestsCount: props.run.okTestsCount,
		wrongTestsCount: props.run.wrongTestsCount
	});

	useRunningRunHub({
		connect: props.run.status === RunStatus.Running,
		onConnectionStart: () => {
			return;
		},
		onConnectionError: props.onHubConnectionError,
		onRunDataUpdated: (newRunData: RunData) => {
			setRunData(newRunData);
		}
	});

	const isRunning = runData.status === RunStatus.Running;
	const isCancelled = runData.status === RunStatus.Cancelled;
	const isOk = runData.status === RunStatus.Finished && runData.outcome === RunOutcome.Ok;
	const isWrong = runData.status === RunStatus.Finished && runData.outcome === RunOutcome.Wrong;

	let runTypeIcon: ReactNode;
	if (props.run.type === RunType.Full) {
		runTypeIcon = <FullIcon />;
	} else if (props.run.type === RunType.Quick) {
		runTypeIcon = <QuickIcon />;
	}

	const colorClassName = classNames({
		[classes.runningColor]: isRunning,
		[classes.cancelledColor]: isCancelled,
		[classes.okColor]: isOk,
		[classes.wrongColor]: isWrong
	});

	const backgroundColor1ClassName = classNames({
		[classes.runningBackgroundColor1]: isRunning,
		[classes.cancelledBackgroundColor1]: isCancelled,
		[classes.okBackgroundColor1]: isOk,
		[classes.wrongBackgroundColor1]: isWrong
	});

	const backgroundColor2ClassName = classNames({
		[classes.runningBackgroundColor2]: isRunning,
		[classes.cancelledBackgroundColor2]: isCancelled,
		[classes.okBackgroundColor2]: isOk,
		[classes.wrongBackgroundColor2]: isWrong
	});

	const cardClassName = classNames(backgroundColor1ClassName);

	const runTypeAvatarClassName = classNames(colorClassName, backgroundColor2ClassName);

	const typographyClassName = classNames(colorClassName);

	const iconClassName = classNames(colorClassName);

	const intIdTypographyClassName = classNames(classes.intIdTypography, typographyClassName);

	const testNameTypographyClassName = classNames(typographyClassName, classes.testNameTypography);

	const passedFailedTypographyClassName = classNames(typographyClassName, classes.passedFailedTypography);

	return (
		<Card className={cardClassName}>
			<CardContent className={classes.cardContent}>
				<div className={classes.cardContentLeft}>
					<Avatar className={runTypeAvatarClassName}>{runTypeIcon}</Avatar>
					<div className={classes.runCreatedOnContainer}>
						<Typography variant="h2" className={intIdTypographyClassName}>
							{moment(props.run.createdOn).format('YYYY-MM-DD')}
						</Typography>
						<Typography variant="h2" className={intIdTypographyClassName}>
							{moment(props.run.createdOn).format('HH:mm:ss')}
						</Typography>
					</div>
				</div>

				<div className={classes.cardContentMiddle}>
					{runData.currentTestName ? (
						<Typography variant="h6" className={testNameTypographyClassName}>
							{runData.currentTestName}
						</Typography>
					) : null}

					{(runData.currentTestStep || runData.currentTestStep === 0) &&
					(runData.currentTestStepIndex || runData.currentTestStepIndex === 0) ? (
						<>
							<Typography className={typographyClassName} variant="overline">
								{translations.runs.step + ' ' + (runData.currentTestStepIndex + 1) + ' / ' + runData.testStepsCount}
								{' - '}
								{TestRunStepHelper.getName(runData.currentTestStep)}
							</Typography>

							<LinearProgress
								className={classes.linearProgress}
								classes={{
									bar: classes.linearProgressBar
								}}
								value={((runData.currentTestStepIndex + 1) / runData.testStepsCount) * 100.0}
								variant="determinate"
							/>
						</>
					) : null}

					{(runData.currentItemIndex || runData.currentItemIndex === 0) &&
					runData.currentItemName &&
					runData.allItemsCount ? (
						<>
							<Typography className={classNames(typographyClassName, classes.itemsProgress)} variant="overline">
								{translations.runs.item + ' ' + (runData.currentItemIndex + 1) + ' / ' + runData.allItemsCount}
								{' - '}
								{runData.currentItemName}
							</Typography>

							<LinearProgress
								className={classes.linearProgress}
								classes={{
									bar: classes.linearProgressBar
								}}
								value={((runData.currentItemIndex + 1) / runData.allItemsCount) * 100.0}
								variant="determinate"
							/>
						</>
					) : null}

					{runData.status === RunStatus.Finished && runData.outcome === RunOutcome.Wrong ? (
						<>
							<Typography className={passedFailedTypographyClassName}>
								{runData.okTestsCount} {translations.runs.passed}
							</Typography>
							<Typography className={passedFailedTypographyClassName}>
								{runData.wrongTestsCount} {translations.runs.failed}
							</Typography>
						</>
					) : null}
				</div>

				<div className={classes.cardContentRight}>
					<div>
						<Typography variant="h6" className={typographyClassName}>
							{runData.processedTestsCount} / {props.run.allTestsCount}
						</Typography>
					</div>
					<div>
						<Typography variant="h6" className={typographyClassName}>
							{runData.processedForMilliseconds ? (
								<CilTimeSpanDisplayer milliseconds={runData.processedForMilliseconds} precision="milliseconds" />
							) : null}
						</Typography>
					</div>
				</div>
			</CardContent>
			<CardActions className={classes.cardActions}>
				{runData.status !== RunStatus.Running ? (
					<CilReplayRunButton run={props.run} iconClassName={iconClassName} onRunReplayed={props.onRunReplayed} />
				) : null}
				{runData.status !== RunStatus.Finished ? (
					<CilDeleteRunButton run={props.run} iconClassName={iconClassName} onRunDeleted={props.onRunDeleted} />
				) : null}
				{runData.status === RunStatus.Finished ? (
					<CilShowRunButton run={props.run} iconClassName={iconClassName} />
				) : null}
			</CardActions>
		</Card>
	);
};

export default CilRunCard;
