import React, { FunctionComponent, useEffect, useState } from 'react';

import { TablePagination, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import CategoriesApiClient from '../../api/clients/CategoriesApiClient';
import CategoryReadModel from '../../api/read-models/categories/CategoryReadModel';
import SearchDirection from '../../api/search/SearchDirection';
import SearchParameter from '../../api/search/SearchParameter';
import SearchResult from '../../api/search/SearchResult';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilAddCategoryButton from '../shared/categories/CilAddCategoryButton';
import CilCategoriesList from '../shared/categories/CilCategoriesList';
import CilPageHeader from '../utils/CilPageHeader';

const useStyles = makeStyles((theme: Theme) => ({
	pageHeaderLeft: {
		flexGrow: 1
	},
	pageHeaderRight: {}
}));

const CilCategoriesPage: FunctionComponent = props => {
	const classes = useStyles();

	const categoriesApiClient = new CategoriesApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');
	const [searchResult, setSearchResult] = useState<SearchResult<CategoryReadModel>>({ data: [], count: 0 });
	const [searchParameter, setSearchParameter] = useState<SearchParameter<CategoryReadModel>>({
		orderBy: {
			property: 'name',
			direction: SearchDirection.Asc
		},
		pageSize: 10,
		pageNumber: 1
	});

	const refreshCategories = async () => {
		try {
			setPageState('loading');
			const searchCategoriesResponse = await categoriesApiClient.searchCategories(searchParameter);
			setSearchResult(searchCategoriesResponse.data);
			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	};

	useEffect(
		() => {
			refreshCategories();
		},
		[searchParameter]
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

	const handleChangePage = (event: React.MouseEvent<HTMLButtonElement> | null, page: number) => {
		setSearchParameter(prevSearchParameter => ({
			...prevSearchParameter,
			pageNumber: page + 1
		}));
	};

	const handleChangeRowsPerChange: React.ChangeEventHandler<HTMLTextAreaElement | HTMLInputElement> = e => {
		const newPageSize = parseInt(e.target.value, 10);
		setSearchParameter(prevSearchParameter => ({
			...prevSearchParameter,
			pageSize: newPageSize
		}));
	};

	const centerChildren = searchResult.data.length <= 0;

	return (
		<CilPage state={pageState} centerChildren={centerChildren}>
			<CilPageHeader text={translations.categories.categories}>
				<div className={classes.pageHeaderLeft}>
					<CilAddCategoryButton onCategoryAdded={handleCategoryAdded} />
				</div>
				<div className={classes.pageHeaderRight}>
					<TablePagination
						count={searchResult.count}
						page={searchParameter.pageNumber - 1}
						rowsPerPage={searchParameter.pageSize}
						onChangePage={handleChangePage}
						onChangeRowsPerPage={handleChangeRowsPerChange}
						labelRowsPerPage={translations.shared.resultsPerPage}
					/>
				</div>
			</CilPageHeader>
			<CilCategoriesList
				categories={searchResult.data}
				onSubcategoryAdded={handleSubcategoryAdded}
				onCategoryDeleted={handleCategoryDeleted}
				onSubcategoryDeleted={handleSubcategoryDeleted}
			/>
		</CilPage>
	);
};

export default CilCategoriesPage;
