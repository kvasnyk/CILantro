import classNames from 'classnames';
import React, { FunctionComponent, ReactNode } from 'react';

import { Avatar, Card, CardContent, Theme, Typography } from '@material-ui/core';
import { orange } from '@material-ui/core/colors';
import QuickIcon from '@material-ui/icons/DirectionsRunRounded';
import FullIcon from '@material-ui/icons/HourglassEmptyRounded';
import { makeStyles } from '@material-ui/styles';

import RunStatus from '../../../api/enums/RunStatus';
import RunType from '../../../api/enums/RunType';
import RunReadModel from '../../../api/read-models/runs/RunReadModel';

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
		flexGrow: 1,
		display: 'flex',
		flexDirection: 'column',
		alignItems: 'flex-end',
		justifyContent: 'center'
	},
	processedTestsTypographyRunning: {
		color: theme.palette.common.white
	}
}));

interface CilRunCardProps {
	run: RunReadModel;
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
				</div>
			</CardContent>
		</Card>
	);
};

export default CilRunCard;
