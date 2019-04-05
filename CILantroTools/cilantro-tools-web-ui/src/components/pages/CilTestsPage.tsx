import React, { FunctionComponent, useEffect, useState } from 'react';

import { TablePagination, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import TestsApiClient from '../../api/clients/TestsApiClient';
import TestReadModel from '../../api/read-models/tests/TestReadModel';
import SearchDirection from '../../api/search/SearchDirection';
import SearchParameter from '../../api/search/SearchParameter';
import SearchResult from '../../api/search/SearchResult';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilTestsList from '../shared/tests/CilTestsList';
import CilPageHeader from '../utils/CilPageHeader';

const useStyles = makeStyles((theme: Theme) => ({
	pageHeaderLeft: {
		flexGrow: 1
	},
	pageHeaderRight: {}
}));

const CilTestsPage: FunctionComponent = props => {
	const classes = useStyles();

	const testsApiClient = new TestsApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');
	const [searchResult, setSearchResult] = useState<SearchResult<TestReadModel>>({ data: [], count: 0 });
	const [searchParameter, setSearchParameter] = useState<SearchParameter<TestReadModel>>({
		orderBy: {
			property: 'name',
			direction: SearchDirection.Asc
		},
		pageSize: 10,
		pageNumber: 1
	});

	const refreshTests = async () => {
		try {
			setPageState('loading');
			const searchTestsResponse = await testsApiClient.searchTests(searchParameter);
			setSearchResult(searchTestsResponse.data);
			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	};

	useEffect(
		() => {
			refreshTests();
		},
		[searchParameter]
	);

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
			<CilPageHeader text={translations.tests.tests}>
				<div className={classes.pageHeaderLeft} />
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
			<CilTestsList tests={searchResult.data} />
		</CilPage>
	);
};

export default CilTestsPage;
