import React, { ReactNode } from 'react';

import { Collapse, Paper, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import { UseSearchHookResult } from '../../hooks/useSearch';

const useStyles = makeStyles((theme: Theme) => ({
	paper: {
		margin: '0 20px',
		marginBottom: '20px',
		padding: '20px'
	},
	panel: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'center',
		'&>*': {
			flexGrow: 1,
			flexBasis: 0,
			padding: '10px',
			'&>*': {
				marginBottom: '10px'
			}
		}
	}
}));

interface CilFiltersPanelProps<TReadModel extends {}> {
	search: UseSearchHookResult<TReadModel>;
}

const CilFiltersPanel = <TReadModel extends {}>(props: CilFiltersPanelProps<TReadModel> & { children?: ReactNode }) => {
	const classes = useStyles();

	return (
		<Collapse in={props.search.areFiltersOpen} unmountOnExit={true}>
			<Paper className={classes.paper}>
				<div className={classes.panel}>{props.children}</div>
			</Paper>
		</Collapse>
	);
};

export default CilFiltersPanel;
