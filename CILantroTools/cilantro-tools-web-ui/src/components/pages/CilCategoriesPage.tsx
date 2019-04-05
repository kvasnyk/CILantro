import React, { FunctionComponent, useEffect, useState } from 'react';

import { MenuItem, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import CategoriesApiClient from '../../api/clients/CategoriesApiClient';
import CategoryReadModel from '../../api/read-models/categories/CategoryReadModel';
import SearchDirection from '../../api/search/SearchDirection';
import useSearch from '../../hooks/useSearch';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilAddCategoryButton from '../shared/categories/CilAddCategoryButton';
import CilCategoriesList from '../shared/categories/CilCategoriesList';
import CilOrderByDropDown from '../utils/CilOrderByDropDown';
import CilPageHeader from '../utils/CilPageHeader';
import CilPagination from '../utils/CilPagination';

const useStyles = makeStyles((theme: Theme) => ({
	pageHeaderLeft: {
		flexGrow: 1
	},
	pageHeaderRight: {
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center'
	}
}));

const CilCategoriesPage: FunctionComponent = props => {
	const classes = useStyles();

	const categoriesApiClient = new CategoriesApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');

	const search = useSearch<CategoryReadModel>({
		orderBy: {
			property: 'name',
			direction: SearchDirection.Asc
		},
		orderBy2: {
			property: 'name',
			direction: SearchDirection.Asc
		},
		pageSize: 10,
		pageNumber: 1
	});

	const refreshCategories = async () => {
		try {
			setPageState('loading');
			const searchCategoriesResponse = await categoriesApiClient.searchCategories(search.parameter);
			search.setResult(searchCategoriesResponse.data);
			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	};

	useEffect(
		() => {
			refreshCategories();
		},
		[search.parameter]
	);

	const handleCategoryAdded = () => {
		refreshCategories();
	};

	const handleCategoryDeleted = () => {
		refreshCategories();
	};

	const handleSubcategoryAdded = () => {
		refreshCategories();
	};

	const handleSubcategoryDeleted = () => {
		refreshCategories();
	};

	const centerChildren = search.result.data.length <= 0;

	return (
		<CilPage state={pageState} centerChildren={centerChildren}>
			<CilPageHeader text={translations.categories.categories}>
				<div className={classes.pageHeaderLeft}>
					<CilAddCategoryButton onCategoryAdded={handleCategoryAdded} />
				</div>
				<div className={classes.pageHeaderRight}>
					<CilOrderByDropDown search={search}>
						<MenuItem value="name">{translations.categories.name}</MenuItem>
					</CilOrderByDropDown>
					<CilPagination search={search} />
				</div>
			</CilPageHeader>
			<CilCategoriesList
				categories={search.result.data}
				onSubcategoryAdded={handleSubcategoryAdded}
				onCategoryDeleted={handleCategoryDeleted}
				onSubcategoryDeleted={handleSubcategoryDeleted}
			/>
		</CilPage>
	);
};

export default CilCategoriesPage;
