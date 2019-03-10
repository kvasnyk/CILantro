import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import { Card, CardActions, CardContent, Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import CilShowTestButton from './CilShowTestButton';
import CilTestChecklist from './CilTestChecklist';

interface CilTestCardProps {
	test: TestReadModel;
}

const useStyles = makeStyles((theme: Theme) => ({
	notReadyCard: {
		backgroundColor: theme.palette.grey[300],
		color: theme.palette.getContrastText(theme.palette.grey[500])
	},
	notReadyTypography: {
		color: theme.palette.getContrastText(theme.palette.grey[500])
	},
	cardActions: {
		justifyContent: 'flex-end'
	}
}));

const CiLTestCard: FunctionComponent<CilTestCardProps> = props => {
	const classes = useStyles();

	const cardClassName = classNames({
		[classes.notReadyCard]: !props.test.isReady
	});

	const typographyClassName = classNames({
		[classes.notReadyTypography]: !props.test.isReady
	});

	return (
		<Card className={cardClassName}>
			<CardContent>
				<Typography variant="h2" className={typographyClassName}>
					{('00000' + props.test.intId).slice(-5)} | {props.test.name}
				</Typography>
				<Typography variant="subtitle1" className={typographyClassName}>
					...{props.test.path}
				</Typography>
				{!props.test.isReady ? <CilTestChecklist test={props.test} /> : null}
			</CardContent>
			<CardActions className={classes.cardActions}>
				<CilShowTestButton test={props.test} />
			</CardActions>
		</Card>
	);
};

export default CiLTestCard;
