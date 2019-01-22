import React, { StatelessComponent } from 'react';

import { Card, CardContent, Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';

interface CilTestCardProps {
  test: TestReadModel;
}

const useStyles = makeStyles((theme: Theme) => ({
  cardActions: {
    justifyContent: 'flex-end'
  }
}));

const CiLTestCard: StatelessComponent<CilTestCardProps> = props => {
  useStyles();

  return (
    <Card>
      <CardContent>
        <Typography variant="h2">{props.test.name}</Typography>
        <Typography variant="subtitle1">{props.test.path}</Typography>
      </CardContent>
    </Card>
  );
};

export default CiLTestCard;
