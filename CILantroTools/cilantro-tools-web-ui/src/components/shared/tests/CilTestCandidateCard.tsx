import React, { FunctionComponent } from 'react';

import { Card, CardActions, CardContent, Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import TestCandidate from '../../../api/models/tests/TestCandidate';
import CilCreateTestFromTestCandidateButton from './CilCreateTestFromTestCandidateButton';

const useStyles = makeStyles((theme: Theme) => ({
	cardActions: {
		justifyContent: 'flex-end'
	}
}));

interface CilTestCandidateCardProps {
	testCandidate: TestCandidate;
	onTestCreated: () => void;
}

const CilTestCandidateCard: FunctionComponent<CilTestCandidateCardProps> = props => {
	const classes = useStyles();

	return (
		<Card>
			<CardContent>
				<Typography variant="h2">{props.testCandidate.name}</Typography>
				<Typography variant="subtitle1">...{props.testCandidate.path}</Typography>
			</CardContent>
			<CardActions className={classes.cardActions}>
				<CilCreateTestFromTestCandidateButton testCandidate={props.testCandidate} onTestCreated={props.onTestCreated} />
			</CardActions>
		</Card>
	);
};

export default CilTestCandidateCard;
