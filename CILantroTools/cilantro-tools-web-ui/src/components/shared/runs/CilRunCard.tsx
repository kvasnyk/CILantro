import React, { FunctionComponent, ReactNode } from 'react';

import { Avatar, Card, CardContent, Theme } from '@material-ui/core';
import QuickIcon from '@material-ui/icons/DirectionsRunRounded';
import FullIcon from '@material-ui/icons/HourglassEmptyRounded';
import { makeStyles } from '@material-ui/styles';

import RunType from '../../../api/enums/RunType';
import RunReadModel from '../../../api/read-models/runs/RunReadModel';

const useStyles = makeStyles((theme: Theme) => ({
	runTypeAvatar: {
		backgroundColor: theme.palette.primary.main
	},
	content1: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'center'
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

	return (
		<Card>
			<CardContent>
				<div className={classes.content1}>
					<Avatar className={classes.runTypeAvatar}>{runTypeIcon}</Avatar>
				</div>
			</CardContent>
		</Card>
	);
};

export default CilRunCard;
