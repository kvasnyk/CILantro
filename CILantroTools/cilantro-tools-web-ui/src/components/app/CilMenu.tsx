import React, { FunctionComponent } from 'react';

import { Divider, Drawer, List, Theme } from '@material-ui/core';
import CategoryIcon from '@material-ui/icons/CategoryRounded';
import CodeIcon from '@material-ui/icons/CodeRounded';
import SearchIcon from '@material-ui/icons/SearchRounded';
import { makeStyles } from '@material-ui/styles';

import routes from '../../routing/routes';
import styles from '../../styles/styles';
import translations from '../../translations/translations';
import CilMenuItem from './CilMenuItem';

const useStyles = makeStyles((theme: Theme) => ({
	drawerPaper: {
		position: 'relative',
		width: styles.menuWidth,
		zIndex: theme.zIndex.drawer
	},
	toolbar: theme.mixins.toolbar
}));

const CilMenu: FunctionComponent = props => {
	const classes = useStyles();

	return (
		<Drawer
			variant="permanent"
			classes={{
				paper: classes.drawerPaper
			}}
		>
			<div className={classes.toolbar} />
			<List>
				<CilMenuItem to={routes.tests.find} label={translations.tests.findTests} icon={<SearchIcon />} />
			</List>

			<Divider />

			<List>
				<CilMenuItem to={routes.tests.tests} label={translations.tests.tests} icon={<CodeIcon />} />
				<CilMenuItem
					to={routes.categories.categories}
					label={translations.categories.categories}
					icon={<CategoryIcon />}
				/>
			</List>
		</Drawer>
	);
};

export default CilMenu;
