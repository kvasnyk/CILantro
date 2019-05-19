import React, { useEffect, useRef, useState } from 'react';

import { Button, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import SearchFilter from '../../api/search/SearchFilter';
import SearchFilterType from '../../api/search/SearchFilterType';
import { UseSearchHookResult } from '../../hooks/useSearch';
import translations from '../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
	root: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'center'
	},
	notReadyButton: {
		marginLeft: '20px'
	}
}));

interface CilReadyFilter<TReadModel extends {}> {
	search: UseSearchHookResult<TReadModel>;
	readyProperty: keyof TReadModel;
}

const CilReadyFilter = <TReadModel extends {}>(props: CilReadyFilter<TReadModel>) => {
	const classes = useStyles();

	const existingFilter = props.search.parameter.filters.find(f => f.property === props.readyProperty);
	const initialValue = existingFilter ? (existingFilter.value === 'True' ? true : false) : undefined;

	const [value, setValue] = useState<boolean | undefined>(initialValue);
	const isInitialMount = useRef(true);

	const handleReadyButtonClick = () => {
		setValue(value === true ? undefined : true);
	};

	const handleNotReadyButtonClick = () => {
		setValue(value === false ? undefined : false);
	};

	useEffect(
		() => {
			if (isInitialMount.current) {
				isInitialMount.current = false;
				return;
			}

			if (value === undefined) {
				props.search.clearFilter(props.readyProperty);
			} else {
				const filter: SearchFilter<TReadModel> = {
					property: props.readyProperty,
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
			<Button
				color={value === true ? 'primary' : 'default'}
				variant={value === true ? 'contained' : 'flat'}
				onClick={handleReadyButtonClick}
			>
				{translations.tests.ready}
			</Button>
			<Button
				className={classes.notReadyButton}
				color={value === false ? 'primary' : 'default'}
				variant={value === false ? 'contained' : 'flat'}
				onClick={handleNotReadyButtonClick}
			>
				{translations.tests.notReady}
			</Button>
		</div>
	);
};

export default CilReadyFilter;
