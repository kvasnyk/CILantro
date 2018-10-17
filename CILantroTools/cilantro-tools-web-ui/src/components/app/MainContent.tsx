import * as React from 'react';
import { Route, Switch } from 'react-router';

import { StyledComponentProps, StyleRulesCallback, withStyles } from '@material-ui/core';

import { Routes } from '../../routes/Routes';
import CategoriesPage from '../pages/CategoriesPage';
import FindTestsPage from '../pages/FindTestsPage';
import RootPage from '../pages/RootPage';
import TestsPage from '../pages/TestsPage';

const styles: StyleRulesCallback = theme => ({
    content: {
        backgroundColor: theme.palette.background.default,
        flexGrow: 1,
        minWidth: 0,
        padding: theme.spacing.unit * 3
    },
    toolbar: theme.mixins.toolbar,
});

const MainContent: React.StatelessComponent<StyledComponentProps> = (props) => {
    return (
        <main className={props.classes!.content}>
            <div className={props.classes!.toolbar} />
            <Switch>
                <Route exact={true} path={Routes.root}>
                    <RootPage />
                </Route>
                <Route exact={true} path={Routes.tests_find}>
                    <FindTestsPage />
                </Route>
                <Route exact={true} path={Routes.tests}>
                    <TestsPage />
                </Route>
                <Route exact={true} path={Routes.categories}>
                    <CategoriesPage />
                </Route>
            </Switch>
        </main>
    );
};

export default withStyles(styles)(MainContent);