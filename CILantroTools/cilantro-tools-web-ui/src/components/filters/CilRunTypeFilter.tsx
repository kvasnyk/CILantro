import classNames from 'classnames';
import React, { useEffect, useRef, useState } from 'react';

import { Fab, IconButton, Theme } from '@material-ui/core';
import { green } from '@material-ui/core/colors';
import QuickIcon from '@material-ui/icons/DirectionsRunRounded';
import FullIcon from '@material-ui/icons/HourglassEmptyRounded';
import { makeStyles } from '@material-ui/styles';

import RunType from '../../api/enums/RunType';
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
	fullButton: {
		marginLeft: '20px'
	},
	fab: {
		backgroundColor: green[500],
		color: theme.palette.primary.contrastText,
		'&:hover': {
			backgroundColor: green[700]
		}
	}
}));

interface CilRunTypeFilterProps<TReadModel extends {}> {
	search: UseSearchHookResult<TReadModel>;
	runTypeProperty: keyof TReadModel;
}

const CilRunTypeFilter = <TReadModel extends {}>(props: CilRunTypeFilterProps<TReadModel>) => {
	const classes = useStyles();

	const existingFilter = props.search.parameter.filters.find(f => f.property === props.runTypeProperty);
	const initialValue = existingFilter ? (existingFilter.value === 'Full' ? RunType.Full : RunType.Quick) : undefined;

	const [value, setValue] = useState<RunType | undefined>(initialValue);
	const isInitialMount = useRef(true);

	const handleQuickButtonClick = () => {
		setValue(value === RunType.Quick ? undefined : RunType.Quick);
	};

	const handleFullButtonClick = () => {
		setValue(value === RunType.Full ? undefined : RunType.Full);
	};

	useEffect(
		() => {
			if (isInitialMount.current) {
				isInitialMount.current = false;
				return;
			}

			if (value === undefined) {
				props.search.clearFilter(props.runTypeProperty);
			} else {
				const filter: SearchFilter<TReadModel> = {
					property: props.runTypeProperty,
					type: SearchFilterType.Exact,
					value: value === RunType.Full ? 'Full' : 'Quick'
				};
				props.search.setFilter(filter);
			}
		},
		[value]
	);

	return (
		<div className={classes.root}>
			{value === RunType.Quick ? (
				<Fab size="medium" color="secondary" onClick={handleQuickButtonClick} className={classes.fab}>
					<QuickIcon />
				</Fab>
			) : (
				<IconButton onClick={handleQuickButtonClick}>
					<QuickIcon />
				</IconButton>
			)}

			{value === RunType.Full ? (
				<Fab
					size="medium"
					color="secondary"
					onClick={handleFullButtonClick}
					className={classNames(classes.fab, classes.fullButton)}
				>
					<FullIcon />
				</Fab>
			) : (
				<IconButton onClick={handleFullButtonClick} className={classes.fullButton}>
					<FullIcon />
				</IconButton>
			)}
		</div>
	);
};

export default CilRunTypeFilter;
