import classNames from 'classnames';
import React, { StatelessComponent } from 'react';

import { Card, CardContent, Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';

interface CilTestCardProps {
	test: TestReadModel;
}

const useStyles = makeStyles((theme: Theme) => ({
	notReadyCard: {
		backgroundColor: theme.palette.secondary.main,
		color: theme.palette.secondary.contrastText
	},
	notReadyTypography: {
		color: theme.palette.secondary.contrastText
	},
	cardActions: {
		justifyContent: 'flex-end'
	}
}));

const CiLTestCard: StatelessComponent<CilTestCardProps> = props => {
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
					{props.test.name}
				</Typography>
				<Typography variant="subtitle1" className={typographyClassName}>
					{props.test.path}
				</Typography>
			</CardContent>
		</Card>
	);
};

export default CiLTestCard;
