import * as React from 'react';

import { StyledComponentProps, StyleRulesCallback, withStyles } from '@material-ui/core';

import MainAppBar from './MainAppBar';
import MainAppMenu from './MainAppMenu';
import MainConsole from './MainConsole';
import MainContent from './MainContent';

const styles: StyleRulesCallback = theme => ({
  root: {
    display: 'flex',
    flexGrow: 1,
    height: '100vh',
    overflow: 'hidden',
    position: 'relative',
    zIndex: 1
  }
});

const App: React.StatelessComponent<StyledComponentProps> = (props) => {
  return (
    <div className={props.classes!.root}>
      <MainAppBar />
      <MainAppMenu />
      <MainContent />
      <MainConsole />
    </div>
  );
};

export default withStyles(styles)(App);