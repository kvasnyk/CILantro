import React, { useEffect, useRef, useState } from 'react';

import { Button, Fab, IconButton, Theme } from '@material-ui/core';
import CheckIcon from '@material-ui/icons/CheckRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import { makeStyles } from '@material-ui/styles';

import RunOutcome from '../../api/enums/RunOutcome';
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
	wrongButton: {
		marginLeft: '20px'
	}
}));

interface CilRunOutcomeFilterProps<TReadModel extends {}> {
	search: UseSearchHookResult<TReadModel>;
	runOutcomeProperty: keyof TReadModel;
}

const CilRunOutcomeFilter = <TReadModel extends {}>(props: CilRunOutcomeFilterProps<TReadModel>) => {
	const classes = useStyles();

	const existingFilter = props.search.parameter.filters.find(f => f.property === props.runOutcomeProperty);
	const initialValue = existingFilter
		? existingFilter.value === 'Ok'
			? RunOutcome.Ok
			: existingFilter.value === 'Wrong'
			? RunOutcome.Wrong
			: null
		: undefined;

	const [value, setValue] = useState<RunOutcome | undefined | null>(initialValue);
	const isInitialMount = useRef(true);

	const handleOkButtonClick = () => {
		setValue(value === RunOutcome.Ok ? undefined : RunOutcome.Ok);
	};

	const handleWrongButtonClick = () => {
		setValue(value === RunOutcome.Wrong ? undefined : RunOutcome.Wrong);
	};

	const handleNullButtonClick = () => {
		setValue(value === null ? undefined : null);
	};

	useEffect(
		() => {
			if (isInitialMount.current) {
				isInitialMount.current = false;
				return;
			}

			if (value === undefined) {
				props.search.clearFilter(props.runOutcomeProperty);
			} else {
				const filter: SearchFilter<TReadModel> = {
					property: props.runOutcomeProperty,
					type: SearchFilterType.Exact,
					value: value === RunOutcome.Ok ? 'Ok' : value === RunOutcome.Wrong ? 'Wrong' : ''
				};
				props.search.setFilter(filter);
			}
		},
		[value]
	);

	return (
		<div className={classes.root}>
			{value === RunOutcome.Ok ? (
				<Fab size="medium" onClick={handleOkButtonClick} color="primary">
					<CheckIcon />
				</Fab>
			) : (
				<IconButton onClick={handleOkButtonClick}>
					<CheckIcon />
				</IconButton>
			)}

			{value === RunOutcome.Wrong ? (
				<Fab size="medium" className={classes.wrongButton} onClick={handleWrongButtonClick} color="primary">
					<NotCheckIcon />
				</Fab>
			) : (
				<IconButton className={classes.wrongButton} onClick={handleWrongButtonClick}>
					<NotCheckIcon />
				</IconButton>
			)}

			<Button
				className={classes.wrongButton}
				onClick={handleNullButtonClick}
				color={value === null ? 'primary' : 'default'}
				variant={value === null ? 'contained' : 'flat'}
			>
				{translations.tests.notRun}
			</Button>
		</div>
	);
};

export default CilRunOutcomeFilter;
