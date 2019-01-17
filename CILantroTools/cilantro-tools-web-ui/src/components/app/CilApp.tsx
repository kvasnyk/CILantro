import React, { StatelessComponent } from 'react';

import { createMuiTheme, Theme } from '@material-ui/core';
import { makeStyles, ThemeProvider } from '@material-ui/styles';

import CilAppBar from './CilAppBar';
import CilAppContent from './CilAppContent';
import CilMenu from './CilMenu';

const appTheme = createMuiTheme({
  zIndex: {
    appBar: 1200,
    drawer: 1100
  }
});

const useStyles = makeStyles((theme: Theme) => ({
  root: {
    display: 'flex',
    height: '100vh',
    margin: 0,
    padding: 0
  }
}));

const CilApp: StatelessComponent = props => {
  const classes = useStyles();

  return (
    <ThemeProvider theme={appTheme}>
      <div className={classes.root}>
        <CilAppBar />
        <CilMenu />
        <CilAppContent />
      </div>
    </ThemeProvider>
  );
};

export default CilApp;
