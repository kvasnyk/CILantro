import React, { StatelessComponent } from 'react';

import { Theme, Typography } from '@material-ui/core';
import ErrorIcon from '@material-ui/icons/ErrorOutlineOutlined';
import { makeStyles } from '@material-ui/styles';

import translations from '../../translations/translations';
import CilLoading from '../utils/CilLoading';

export type PageState = 'loading' | 'success' | 'error';

const useStyles = makeStyles((theme: Theme) => ({
  page: {
    position: 'relative',
    width: '100%'
  },
  centerContainer: {
    display: 'flex',
    width: '100%',
    height: '100%',
    flexDirection: 'column',
    alignItems: 'center',
    justifyContent: 'center'
  },
  errorIcon: {
    fontSize: '15rem'
  }
}));

interface CilPageProps {
  state: PageState;
  centerChildren?: boolean;
}

const CilPage: StatelessComponent<CilPageProps> = props => {
  const classes = useStyles();

  return (
    <div className={classes.page}>
      {props.state === 'loading' ? <CilLoading /> : undefined}

      {props.state === 'success' ? (
        props.centerChildren ? (
          <div className={classes.centerContainer}>{props.children}</div>
        ) : (
          props.children
        )
      ) : (
        undefined
      )}

      {props.state === 'error' ? (
        <div className={classes.centerContainer}>
          <ErrorIcon color="error" className={classes.errorIcon} />
          <Typography color="error" variant="h2">
            {translations.shared.anErrorOccurred}
          </Typography>
        </div>
      ) : (
        undefined
      )}
    </div>
  );
};

export default CilPage;
