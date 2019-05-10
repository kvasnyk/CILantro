import React, { FunctionComponent, useEffect, useState } from 'react';

import { MenuItem, Theme } from '@material-ui/core';
import { red } from '@material-ui/core/colors';
import { makeStyles } from '@material-ui/styles';

import TestsApiClient from '../../api/clients/TestsApiClient';
import TestsCheck from '../../api/models/tests/TestsCheck';
import TestReadModel from '../../api/read-models/tests/TestReadModel';
import SearchDirection from '../../api/search/SearchDirection';
import useSearch from '../../hooks/useSearch';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilCategoryFilter from '../filters/CilCategoryFilter';
import CilTestsList from '../shared/tests/CilTestsList';
import CilFiltersPanel from '../utils/CilFiltersPanel';
import CilOpenFiltersButton from '../utils/CilOpenFiltersButton';
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
	},
	warnings: {
		display: 'flex',
		flexDirection: 'column',
		alignItems: 'center',
		justifyContent: 'center',
		marginBottom: '20px'
	},
	warningTypography: { color: red[700] }
}));

const CilTestsPage: FunctionComponent = props => {
	const classes = useStyles();

	const testsApiClient = new TestsApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');
	const [testsCheck, setTestsCheck] = useState<TestsCheck | undefined>(undefined);

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
		pageNumber: 1,
		filters: []
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

	const refreshTestCheck = async () => {
		try {
			setPageState('loading');
			const checkTestsResponse = await testsApiClient.checkTests();
			setTestsCheck(checkTestsResponse.data);
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

	useEffect(() => {
		refreshTestCheck();
	}, []);

	const centerChildren = search.result.data.length <= 0 && search.parameter.filters.length === 0;

	let testsWarnings = '';
	if (testsCheck && testsCheck.disabledTests > 0) {
		testsWarnings += translations.tests.thereAreDisabledTests(testsCheck.disabledTests);
	}
	if (testsCheck && testsCheck.notReadyTests > 0) {
		testsWarnings += translations.tests.thereAreNotReadyTests(testsCheck.notReadyTests);
	}
	if (testsCheck && testsCheck.notRunTests > 0) {
		testsWarnings += translations.tests.thereAreNotRunTests(testsCheck.notRunTests);
	}
	if (testsCheck && testsCheck.notOkTests > 0) {
		testsWarnings += translations.tests.thereAreNotOkTests(testsCheck.notOkTests);
	}

	return (
		<CilPage state={pageState} centerChildren={centerChildren}>
			<CilPageHeader text={translations.tests.tests} subtext={testsWarnings}>
				<div className={classes.pageHeaderLeft} />
				<div className={classes.pageHeaderRight}>
					<CilOpenFiltersButton search={search} />
					<CilOrderByDropDown search={search}>
						<MenuItem value="createdOn">{translations.tests.createdOn}</MenuItem>
						<MenuItem value="name">{translations.shared.name}</MenuItem>
						<MenuItem value="lastOpenedOn">{translations.tests.lastOpenedOn}</MenuItem>
						<MenuItem value="lastRunOutcome">{translations.tests.lastRunOutcome}</MenuItem>
					</CilOrderByDropDown>
					<CilPagination search={search} />
				</div>
			</CilPageHeader>
			<CilFiltersPanel search={search}>
				<div>
					<CilCategoryFilter<TestReadModel>
						search={search}
						categoryIdProperty="categoryId"
						subcategoryIdProperty="subcategoryId"
					/>
				</div>
				<div />
				<div />
				<div />
				<div />
			</CilFiltersPanel>
			<CilTestsList tests={search.result.data} />
		</CilPage>
	);
};

export default CilTestsPage;
