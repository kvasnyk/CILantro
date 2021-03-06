import React, { FunctionComponent } from 'react';
import { Route, Switch } from 'react-router';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import routes from '../../routing/routes';
import CilCategoriesPage from '../pages/CilCategoriesPage';
import CilFindTestsPage from '../pages/CilFindTestsPage';
import CilRunsPage from '../pages/CilRunsPage';
import CilShowRunPage from '../pages/CilShowRunPage';
import CilShowTestPage from '../pages/CilShowTestPage';
import CilTestsPage from '../pages/CilTestsPage';

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
		height: `calc(100vh - 89px)`,
		display: 'flex',
		overflow: 'auto'
	},
	toolbar: theme.mixins.toolbar
}));

const CilAppContent: FunctionComponent = props => {
	const classes = useStyles();
	return (
		<main className={classes.main}>
			<div className={classes.toolbar} />
			<div className={classes.content}>
				<Switch>
					<Route exact={true} path={routes.categories.categories}>
						<CilCategoriesPage />
					</Route>
					<Route exact={true} path={routes.tests.tests}>
						<CilTestsPage />
					</Route>
					<Route exact={true} path={routes.tests.find}>
						<CilFindTestsPage />
					</Route>
					<Route
						exact={true}
						path={routes.tests.test({ isTemplate: true })}
						render={routeProps => <CilShowTestPage testId={routeProps.match.params.testId} />}
					/>
					<Route exact={true} path={routes.runs.runs}>
						<CilRunsPage />
					</Route>
					<Route
						exact={true}
						path={routes.runs.run({ isTemplate: true })}
						render={routeProps => <CilShowRunPage runId={routeProps.match.params.runId} />}
					/>
				</Switch>
			</div>
		</main>
	);
};

export default CilAppContent;
