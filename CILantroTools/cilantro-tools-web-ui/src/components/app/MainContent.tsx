import * as React from 'react';
import { Route, Switch } from 'react-router';

import { Divider, StyledComponentProps, StyleRulesCallback, withStyles } from '@material-ui/core';

import { Routes } from '../../routes/Routes';
import CategoriesPage from '../pages/categories/CategoriesPage';
import FindTestsPage from '../pages/FindTestsPage';
import RootPage from '../pages/RootPage';
import TestsPage from '../pages/TestsPage';

const styles: StyleRulesCallback = theme => ({
    actions: {
        height: theme.spacing.unit * 8
    },
    content: {
        backgroundColor: theme.palette.background.default,
        flexGrow: 1,
        minWidth: 0
    },
    contentContent: {
        height: `calc(100vh - ${theme.spacing.unit * 3 * 2}px - 64px - ${theme.spacing.unit * 9}px)`,
        overflow: 'auto',
        padding: theme.spacing.unit * 3,
        paddingBottom: theme.spacing.unit
    },
    toolbar: theme.mixins.toolbar,
});

const MainContent: React.StatelessComponent<StyledComponentProps> = (props) => {
    return (
        <main className={props.classes!.content}>
            <div className={props.classes!.toolbar} />
            <div className={props.classes!.contentContent}>
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
            </div>
            <Divider />
            <div className={props.classes!.actions} />
        </main>
    );
};

export default withStyles(styles)(MainContent);