import React, { StatelessComponent } from 'react';
import { Route, Switch } from 'react-router';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import routes from '../../routing/routes';
import CilFindTestsPage from '../pages/CilFindTestsPage';

const useStyles = makeStyles((theme: Theme) => ({
  main: {
    width: '100%',
    backgroundColor: theme.palette.background.default
  },
  content: {
    margin: '10px',
    marginRight: '5px',
    paddingRight: '10px',
    paddingLeft: '5px',
    paddingTop: '5px',
    height: `calc(100vh - 84px)`,
    display: 'flex',
    overflow: 'auto'
  },
  toolbar: theme.mixins.toolbar
}));

const CilAppContent: StatelessComponent = props => {
  const classes = useStyles();
  return (
    <main className={classes.main}>
      <div className={classes.toolbar} />
      <div className={classes.content}>
        <Switch>
          <Route exact={true} path={routes.categories.categories}>
            <div>Categories</div>
          </Route>
          <Route exact={true} path={routes.tests.tests}>
            <div>Tests</div>
          </Route>
          <Route exact={true} path={routes.tests.find}>
            <CilFindTestsPage />
          </Route>
        </Switch>
      </div>
    </main>
  );
};

export default CilAppContent;
