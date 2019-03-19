import classNames from 'classnames';
import React, { FunctionComponent, ReactNode } from 'react';

import { Avatar, Card, CardActions, CardContent, Theme, Typography } from '@material-ui/core';
import { orange } from '@material-ui/core/colors';
import QuickIcon from '@material-ui/icons/DirectionsRunRounded';
import FullIcon from '@material-ui/icons/HourglassEmptyRounded';
import { makeStyles } from '@material-ui/styles';

import RunStatus from '../../../api/enums/RunStatus';
import RunType from '../../../api/enums/RunType';
import RunReadModel from '../../../api/read-models/runs/RunReadModel';
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
		flexGrow: 1,
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center'
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
}

const CilRunCard: FunctionComponent<CilRunCardProps> = props => {
	const classes = useStyles();

	const isRunning = props.run.status === RunStatus.Running;
	const isCancelled = props.run.status === RunStatus.Cancelled;

	let runTypeIcon: ReactNode;
	if (props.run.type === RunType.Full) {
		runTypeIcon = <FullIcon />;
	} else if (props.run.type === RunType.Quick) {
		runTypeIcon = <QuickIcon />;
	}

	const totalSeconds = props.run.processedForSeconds || 0;
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

	const intIdTypographyClassName = classNames(classes.intIdTypography, colorClassName);

	const processedTestsTypographyClassName = classNames(colorClassName);

	const processingTimeTypographyClassName = classNames(colorClassName);

	const iconClassName = classNames(colorClassName);

	return (
		<Card className={cardClassName}>
			<CardContent className={classes.cardContent}>
				<div className={classes.cardContentLeft}>
					<Avatar className={runTypeAvatarClassName}>{runTypeIcon}</Avatar>
					<Typography variant="h2" className={intIdTypographyClassName}>
						{('000000' + props.run.intId).slice(-6)}
					</Typography>
				</div>
				<div className={classes.cardContentRight}>
					<div>
						<Typography variant="h6" className={processedTestsTypographyClassName}>
							{props.run.processedTestsCount} / {props.run.allTestsCount}
						</Typography>
					</div>
					<div>
						<Typography variant="h6" className={processingTimeTypographyClassName}>
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
