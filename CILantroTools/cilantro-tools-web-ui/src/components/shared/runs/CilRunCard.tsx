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
	cardRunning: {
		backgroundColor: orange[500]
	},
	intIdTypographyRunning: {
		color: theme.palette.common.white,
		margin: '0 0 0 10px'
	},
	runTypeAvatarRunning: {
		backgroundColor: orange[700]
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
	processedTestsTypographyRunning: {
		color: theme.palette.common.white
	},
	cardActions: {
		justifyContent: 'flex-end',
		marginRight: '5px'
	},
	deleteIconRunning: {
		color: theme.palette.common.white
	}
}));

interface CilRunCardProps {
	run: RunReadModel;
	onRunDeleted: () => void;
}

const CilRunCard: FunctionComponent<CilRunCardProps> = props => {
	const classes = useStyles();

	let runTypeIcon: ReactNode;
	if (props.run.type === RunType.Full) {
		runTypeIcon = <FullIcon />;
	} else if (props.run.type === RunType.Quick) {
		runTypeIcon = <QuickIcon />;
	}

	const cardClassName = classNames({
		[classes.cardRunning]: props.run.status === RunStatus.Running
	});

	const totalSeconds = props.run.processedForSeconds || 0;
	const hours = parseInt((totalSeconds / 3600).toString(), 10);
	const minutes = parseInt(((totalSeconds - hours * 3600) / 60).toString(), 10);
	const seconds = totalSeconds - hours * 3600 - minutes * 60;

	return (
		<Card className={cardClassName}>
			<CardContent className={classes.cardContent}>
				<div className={classes.cardContentLeft}>
					<Avatar className={classes.runTypeAvatarRunning}>{runTypeIcon}</Avatar>
					<Typography variant="h2" className={classes.intIdTypographyRunning}>
						{('000000' + props.run.intId).slice(-6)}
					</Typography>
				</div>
				<div className={classes.cardContentRight}>
					<div>
						<Typography variant="h6" className={classes.processedTestsTypographyRunning}>
							{props.run.processedTestsCount} / {props.run.allTestsCount}
						</Typography>
					</div>
					<div>
						<Typography variant="h6" className={classes.processedTestsTypographyRunning}>
							{('00' + hours).slice(-2)}:{('00' + minutes).slice(-2)}:{('00' + seconds).slice(-2)}
						</Typography>
					</div>
				</div>
			</CardContent>
			<CardActions className={classes.cardActions}>
				<CilDeleteRunButton
					run={props.run}
					iconClassName={classes.deleteIconRunning}
					onRunDeleted={props.onRunDeleted}
				/>
			</CardActions>
		</Card>
	);
};

export default CilRunCard;
