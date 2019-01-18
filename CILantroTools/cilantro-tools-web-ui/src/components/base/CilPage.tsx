import React, { StatelessComponent } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import CilLoading from '../shared/utils/CilLoading';

export type PageState = 'loading' | 'success' | 'error';

const useStyles = makeStyles((theme: Theme) => ({
  page: {
    position: 'relative',
    width: '100%'
  }
}));

interface CilPageProps {
  state: PageState;
}

const CilPage: StatelessComponent<CilPageProps> = props => {
  const classes = useStyles();

  return (
    <div className={classes.page}>
      {props.state === 'loading' ? <CilLoading /> : undefined}
      {props.state === 'success' ? props.children : undefined}
    </div>
  );
};

export default CilPage;
