import React, { StatelessComponent } from 'react';

import { Card, CardContent, Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import TestCandidate from '../../../api/models/tests/TestCandidate';

const useStyles = makeStyles((theme: Theme) => ({
  card: {}
}));

interface CilTestCandidateCardProps {
  testCandidate: TestCandidate;
}

const CilTestCandidateCard: StatelessComponent<
  CilTestCandidateCardProps
> = props => {
  const classes = useStyles();

  return (
    <Card className={classes.card}>
      <CardContent>
        <Typography variant="h6">{props.testCandidate.name}</Typography>
      </CardContent>
    </Card>
  );
};

export default CilTestCandidateCard;
