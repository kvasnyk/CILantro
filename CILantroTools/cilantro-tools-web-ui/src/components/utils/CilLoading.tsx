import React, { StatelessComponent } from 'react';

import { CircularProgress, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

const useStyles = makeStyles((theme: Theme) => ({
  wrapper: {
    position: 'absolute',
    left: 0,
    top: 0,
    right: 0,
    bottom: 0,
    display: 'flex',
    alignItems: 'center',
    justifyContent: 'center'
  }
}));

const CilLoading: StatelessComponent = props => {
  const classes = useStyles();

  return (
    <div className={classes.wrapper}>
      <CircularProgress />
    </div>
  );
};

export default CilLoading;
