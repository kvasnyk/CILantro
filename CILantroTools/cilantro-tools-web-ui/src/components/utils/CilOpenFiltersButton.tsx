import React, { ReactNode } from 'react';

import { IconButton, Theme } from '@material-ui/core';
import FiltersIcon from '@material-ui/icons/FilterListRounded';
import { makeStyles } from '@material-ui/styles';

import { UseSearchHookResult } from '../../hooks/useSearch';

const useStyles = makeStyles((theme: Theme) => ({
	button: {
		marginRight: '10px'
	}
}));

interface CilOpenFiltersButtonProps<TReadModel extends {}> {
	search: UseSearchHookResult<TReadModel>;
}

const CilOpenFiltersButton = <TReadModel extends {}>(
	props: CilOpenFiltersButtonProps<TReadModel> & { children?: ReactNode }
) => {
	const classes = useStyles();

	const handleClick = () => {
		if (props.search.areFiltersOpen) {
			props.search.setParameter(prevParam => ({
				...prevParam,
				filters: []
			}));
			props.search.setFiltersOpen(false);
		} else {
			props.search.setFiltersOpen(true);
		}
	};

	return (
		<IconButton className={classes.button} onClick={handleClick}>
			<FiltersIcon />
		</IconButton>
	);
};

export default CilOpenFiltersButton;
