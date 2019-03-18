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
	content1: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center'
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
			<CardContent>
				<div className={classes.content1}>
					<Avatar className={classes.runTypeAvatarRunning}>{runTypeIcon}</Avatar>
					<Typography variant="h2" className={classes.intIdTypographyRunning}>
						{('000000' + props.run.intId).slice(-6)}
					</Typography>
				</div>
			</CardContent>
		</Card>
	);
};

export default CilRunCard;
