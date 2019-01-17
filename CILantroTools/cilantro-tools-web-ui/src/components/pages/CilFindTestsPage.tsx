import React, { StatelessComponent } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import CilLoading from '../shared/utils/CilLoading';

const useStyles = makeStyles((theme: Theme) => ({
  page: {
    position: 'relative',
    width: '100%'
  }
}));

const CilFindTestsPage: StatelessComponent = props => {
  const classes = useStyles();

  return (
    <div className={classes.page}>
      <CilLoading />
    </div>
  );
};

export default CilFindTestsPage;
