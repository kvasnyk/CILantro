import React, { FunctionComponent, useEffect, useState } from 'react';

import { MenuItem, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import TestsApiClient from '../../api/clients/TestsApiClient';
import TestReadModel from '../../api/read-models/tests/TestReadModel';
import SearchDirection from '../../api/search/SearchDirection';
import useSearch from '../../hooks/useSearch';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilTestsList from '../shared/tests/CilTestsList';
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

const CilTestsPage: FunctionComponent = props => {
	const classes = useStyles();

	const testsApiClient = new TestsApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');

	const search = useSearch<TestReadModel>({
		orderBy: {
			property: 'lastOpenedOn',
			direction: SearchDirection.Desc
		},
		orderBy2: {
			property: 'name',
			direction: SearchDirection.Asc
		},
		pageSize: 10,
		pageNumber: 1
	});

	const refreshTests = async () => {
		try {
			setPageState('loading');
			const searchTestsResponse = await testsApiClient.searchTests(search.parameter);
			search.setResult(searchTestsResponse.data);
			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	};

	useEffect(
		() => {
			refreshTests();
		},
		[search.parameter]
	);

	const centerChildren = search.result.data.length <= 0;

	return (
		<CilPage state={pageState} centerChildren={centerChildren}>
			<CilPageHeader text={translations.tests.tests}>
				<div className={classes.pageHeaderLeft} />
				<div className={classes.pageHeaderRight}>
					<CilOrderByDropDown search={search}>
						<MenuItem value="createdOn">{translations.tests.createdOn}</MenuItem>
						<MenuItem value="name">{translations.shared.name}</MenuItem>
						<MenuItem value="lastOpenedOn">{translations.tests.lastOpenedOn}</MenuItem>
					</CilOrderByDropDown>
					<CilPagination search={search} />
				</div>
			</CilPageHeader>
			<CilTestsList tests={search.result.data} />
		</CilPage>
	);
};

export default CilTestsPage;
