import React, { ChangeEvent, useEffect, useState } from 'react';

import { FormControl, InputLabel, MenuItem, Select, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import CategoriesApiClient from '../../api/clients/CategoriesApiClient';
import CategoryReadModel from '../../api/read-models/categories/CategoryReadModel';
import SearchDirection from '../../api/search/SearchDirection';
import SearchFilter from '../../api/search/SearchFilter';
import SearchFilterType from '../../api/search/SearchFilterType';
import { UseSearchHookResult } from '../../hooks/useSearch';
import translations from '../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
	categorySelect: {
		marginBottom: '10px'
	}
}));

interface CilCategoryFilterProps<TReadModel extends {}> {
	search: UseSearchHookResult<TReadModel>;
	categoryIdProperty: keyof TReadModel;
	subcategoryIdProperty: keyof TReadModel;
}

const CilCategoryFilter = <TReadModel extends {}>(props: CilCategoryFilterProps<TReadModel>) => {
	const classes = useStyles();

	const categoriesApiClient = new CategoriesApiClient();

	const existingCategoryFilter = props.search.parameter.filters.find(f => f.property === props.categoryIdProperty);
	const selectedCategoryId = existingCategoryFilter ? existingCategoryFilter.value! : undefined;

	const existingSubcategoryFilter = props.search.parameter.filters.find(
		f => f.property === props.subcategoryIdProperty
	);
	const selectedSubcategoryId = existingSubcategoryFilter ? existingSubcategoryFilter.value! : undefined;

	const [categories, setCategories] = useState<CategoryReadModel[]>([]);

	const selectedCategory = categories.find(c => c.id === selectedCategoryId);
	const subcategories = selectedCategory ? selectedCategory.subcategories : [];

	const refreshCategories = async () => {
		try {
			const searchCategoriesResponse = await categoriesApiClient.searchCategories({
				orderBy: {
					property: 'name',
					direction: SearchDirection.Asc
				},
				pageSize: 1000000,
				pageNumber: 1,
				filters: []
			});
			setCategories(searchCategoriesResponse.data.data);
		} catch (error) {
			alert(error);
		}
	};

	useEffect(() => {
		refreshCategories();
	}, []);

	const handleCategoryIdChange = (e: ChangeEvent<HTMLSelectElement>) => {
		const newValue = e.target.value;
		if (newValue) {
			const newFilter: SearchFilter<TReadModel> = {
				property: props.categoryIdProperty,
				type: SearchFilterType.Exact,
				value: newValue
			};
			props.search.setFilter(newFilter);
			props.search.clearFilter(props.subcategoryIdProperty);
		} else {
			props.search.clearFilter(props.categoryIdProperty);
			props.search.clearFilter(props.subcategoryIdProperty);
		}
	};

	const handleSubcategoryIdChange = (e: ChangeEvent<HTMLSelectElement>) => {
		const newValue = e.target.value;
		if (newValue) {
			const newFilter: SearchFilter<TReadModel> = {
				property: props.subcategoryIdProperty,
				type: SearchFilterType.Exact,
				value: newValue
			};
			props.search.setFilter(newFilter);
		} else {
			props.search.clearFilter(props.subcategoryIdProperty);
		}
	};

	return (
		<div>
			<FormControl fullWidth={true} className={classes.categorySelect}>
				<InputLabel shrink={true}>{translations.tests.testCategory}</InputLabel>
				<Select value={selectedCategoryId || ''} onChange={handleCategoryIdChange} fullWidth={true} displayEmpty={true}>
					<MenuItem value="">{translations.shared.noInfo}</MenuItem>
					{categories.map(c => (
						<MenuItem key={c.id} value={c.id}>
							{c.name}
						</MenuItem>
					))}
				</Select>
			</FormControl>

			<FormControl fullWidth={true}>
				<InputLabel shrink={true}>{translations.tests.testSubcategory}</InputLabel>
				<Select
					value={selectedSubcategoryId || ''}
					onChange={handleSubcategoryIdChange}
					fullWidth={true}
					displayEmpty={true}
				>
					<MenuItem value="">{translations.shared.noInfo}</MenuItem>
					{subcategories.map(s => (
						<MenuItem key={s.id} value={s.id}>
							{s.name}
						</MenuItem>
					))}
				</Select>
			</FormControl>
		</div>
	);
};

export default CilCategoryFilter;
