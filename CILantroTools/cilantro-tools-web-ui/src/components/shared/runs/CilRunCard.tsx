import classNames from 'classnames';
import React, { FunctionComponent, ReactNode, useState } from 'react';

import { Avatar, Card, CardActions, CardContent, Theme, Typography } from '@material-ui/core';
import { orange } from '@material-ui/core/colors';
import QuickIcon from '@material-ui/icons/DirectionsRunRounded';
import FullIcon from '@material-ui/icons/HourglassEmptyRounded';
import { makeStyles } from '@material-ui/styles';

import RunStatus from '../../../api/enums/RunStatus';
import RunType from '../../../api/enums/RunType';
import RunData from '../../../api/models/runs/RunData';
import RunReadModel from '../../../api/read-models/runs/RunReadModel';
import useRunningRunHub from '../../../hooks/useRunningRunHub';
import CilDeleteRunButton from './CilDeleteRunButton';

const useStyles = makeStyles((theme: Theme) => ({
	intIdTypography: {
		margin: '0 0 0 10px'
	},
	cardContent: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'center'
	},
	cardContentLeft: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center'
	},
	cardContentMiddle: {
		flexGrow: 1,
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center'
	},
	cardContentRight: {
		display: 'flex',
		flexDirection: 'column',
		alignItems: 'center',
		justifyContent: 'center'
	},
	cardActions: {
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
	}
}));

interface CilRunCardProps {
	run: RunReadModel;
	onRunDeleted: () => void;
	onHubConnectionError: () => void;
}

const CilRunCard: FunctionComponent<CilRunCardProps> = props => {
	const classes = useStyles();

	const [runData, setRunData] = useState<RunData>({
		status: props.run.status,
		processedTestsCount: props.run.processedTestsCount,
		processedForSeconds: props.run.processedForSeconds
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

	let runTypeIcon: ReactNode;
	if (props.run.type === RunType.Full) {
		runTypeIcon = <FullIcon />;
	} else if (props.run.type === RunType.Quick) {
		runTypeIcon = <QuickIcon />;
	}

	const totalSeconds = runData.processedForSeconds || 0;
	const hours = parseInt((totalSeconds / 3600).toString(), 10);
	const minutes = parseInt(((totalSeconds - hours * 3600) / 60).toString(), 10);
	const seconds = totalSeconds - hours * 3600 - minutes * 60;

	const colorClassName = classNames({
		[classes.runningColor]: isRunning,
		[classes.cancelledColor]: isCancelled
	});

	const backgroundColor1ClassName = classNames({
		[classes.runningBackgroundColor1]: isRunning,
		[classes.cancelledBackgroundColor1]: isCancelled
	});

	const backgroundColor2ClassName = classNames({
		[classes.runningBackgroundColor2]: isRunning,
		[classes.cancelledBackgroundColor2]: isCancelled
	});

	const cardClassName = classNames(backgroundColor1ClassName);

	const runTypeAvatarClassName = classNames(colorClassName, backgroundColor2ClassName);

	const typographyClassName = classNames(colorClassName);

	const iconClassName = classNames(colorClassName);

	const intIdTypographyClassName = classNames(classes.intIdTypography, typographyClassName);

	return (
		<Card className={cardClassName}>
			<CardContent className={classes.cardContent}>
				<div className={classes.cardContentLeft}>
					<Avatar className={runTypeAvatarClassName}>{runTypeIcon}</Avatar>
					<Typography variant="h2" className={intIdTypographyClassName}>
						{('000000' + props.run.intId).slice(-6)}
					</Typography>
				</div>

				<div className={classes.cardContentMiddle}>
					{runData.currentTestIntId && runData.currentTestName ? (
						<Typography variant="h6" className={typographyClassName}>
							{('000000' + runData.currentTestIntId).slice(-5)} | {runData.currentTestName}
						</Typography>
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
							{('00' + hours).slice(-2)}:{('00' + minutes).slice(-2)}:{('00' + seconds).slice(-2)}
						</Typography>
					</div>
				</div>
			</CardContent>
			<CardActions className={classes.cardActions}>
				<CilDeleteRunButton run={props.run} iconClassName={iconClassName} onRunDeleted={props.onRunDeleted} />
			</CardActions>
		</Card>
	);
};

export default CilRunCard;
