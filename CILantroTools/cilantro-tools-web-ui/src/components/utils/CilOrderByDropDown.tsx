import React, { ChangeEvent, ReactNode } from 'react';

import { MenuItem, Select, Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import SearchDirection from '../../api/search/SearchDirection';
import { UseSearchHookResult } from '../../hooks/useSearch';
import translations from '../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
	propertySelect: {
		marginLeft: '20px'
	},
	directionSelect: {
		marginLeft: '20px'
	}
}));

interface CilOrderByDropDownProps<TReadModel> {
	search: UseSearchHookResult<TReadModel>;
}

const CilOrderByDropDown = <TReadModel extends {}>(
	props: CilOrderByDropDownProps<TReadModel> & { children: ReactNode }
) => {
	const classes = useStyles();

	const handlePropertyChange = (e: ChangeEvent<HTMLSelectElement>) => {
		const newProperty = e.target.value as keyof TReadModel;
		props.search.handleOrderByChange({
			property: newProperty,
			direction: props.search.parameter.orderBy.direction
		});
	};

	const handleDirectionChange = (e: ChangeEvent<HTMLSelectElement>) => {
		const newDirection = parseInt(e.target.value, 10) as SearchDirection;
		props.search.handleOrderByChange({
			property: props.search.parameter.orderBy.property,
			direction: newDirection
		});
	};

	return (
		<>
			<Typography variant="caption">{translations.shared.orderBy}</Typography>

			<Select
				className={classes.propertySelect}
				value={props.search.parameter.orderBy.property as string}
				onChange={handlePropertyChange}
			>
				{props.children}
			</Select>

			<Select
				className={classes.directionSelect}
				value={props.search.parameter.orderBy.direction}
				onChange={handleDirectionChange}
			>
				<MenuItem value={SearchDirection.Asc}>{translations.shared.ascending}</MenuItem>
				<MenuItem value={SearchDirection.Desc}>{translations.shared.descending}</MenuItem>
			</Select>
		</>
	);
};

export default CilOrderByDropDown;
