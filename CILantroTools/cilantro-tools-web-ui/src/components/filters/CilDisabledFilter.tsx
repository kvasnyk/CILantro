import React, { useEffect, useRef, useState } from 'react';

import { Fab, IconButton, Theme } from '@material-ui/core';
import DisableIcon from '@material-ui/icons/PowerOffRounded';
import EnableIcon from '@material-ui/icons/PowerRounded';
import { makeStyles } from '@material-ui/styles';

import SearchFilter from '../../api/search/SearchFilter';
import SearchFilterType from '../../api/search/SearchFilterType';
import { UseSearchHookResult } from '../../hooks/useSearch';

const useStyles = makeStyles((theme: Theme) => ({
	root: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'center'
	},
	disabledButton: {
		marginLeft: '20px'
	}
}));

interface CilDisabledFilterProps<TReadModel extends {}> {
	search: UseSearchHookResult<TReadModel>;
	disabledProperty: keyof TReadModel;
}

const CilDisabledFilter = <TReadModel extends {}>(props: CilDisabledFilterProps<TReadModel>) => {
	const classes = useStyles();

	const existingFilter = props.search.parameter.filters.find(f => f.property === props.disabledProperty);
	const initialValue = existingFilter ? (existingFilter.value === 'True' ? true : false) : undefined;

	const [value, setValue] = useState<boolean | undefined>(initialValue);
	const isInitialMount = useRef(true);

	const handleDisabledButtonClick = () => {
		setValue(value === true ? undefined : true);
	};

	const handleNotDisabledButtonClick = () => {
		setValue(value === false ? undefined : false);
	};

	useEffect(
		() => {
			if (isInitialMount.current) {
				isInitialMount.current = false;
				return;
			}

			if (value === undefined) {
				props.search.clearFilter(props.disabledProperty);
			} else {
				const filter: SearchFilter<TReadModel> = {
					property: props.disabledProperty,
					type: SearchFilterType.Exact,
					value: value === true ? 'True' : 'False'
				};
				props.search.setFilter(filter);
			}
		},
		[value]
	);

	return (
		<div className={classes.root}>
			{value === false ? (
				<Fab size="medium" color="secondary" onClick={handleNotDisabledButtonClick}>
					<EnableIcon />
				</Fab>
			) : (
				<IconButton onClick={handleNotDisabledButtonClick}>
					<EnableIcon />
				</IconButton>
			)}

			{value === true ? (
				<Fab size="medium" color="secondary" onClick={handleDisabledButtonClick} className={classes.disabledButton}>
					<DisableIcon />
				</Fab>
			) : (
				<IconButton onClick={handleDisabledButtonClick} className={classes.disabledButton}>
					<DisableIcon />
				</IconButton>
			)}
		</div>
	);
};

export default CilDisabledFilter;
