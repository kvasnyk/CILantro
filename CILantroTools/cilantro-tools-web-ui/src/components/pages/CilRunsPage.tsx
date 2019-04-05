import React, { FunctionComponent, useEffect, useState } from 'react';

import { TablePagination, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import RunsApiClient from '../../api/clients/RunsApiClient';
import RunReadModel from '../../api/read-models/runs/RunReadModel';
import SearchDirection from '../../api/search/SearchDirection';
import SearchParameter from '../../api/search/SearchParameter';
import SearchResult from '../../api/search/SearchResult';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilAddRunButton from '../shared/runs/CilAddRunButton';
import CilRunsList from '../shared/runs/CilRunsList';
import CilPageHeader from '../utils/CilPageHeader';

const useStyles = makeStyles((theme: Theme) => ({
	pageHeaderLeft: {
		flexGrow: 1
	},
	pageHeaderRight: {}
}));

const CilRunsPage: FunctionComponent = props => {
	const classes = useStyles();

	const runsApiClient = new RunsApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');
	const [searchResult, setSearchResult] = useState<SearchResult<RunReadModel>>({ data: [], count: 0 });
	const [searchParameter, setSearchParameter] = useState<SearchParameter<RunReadModel>>({
		orderBy: {
			property: 'createdOn',
			direction: SearchDirection.Desc
		},
		pageSize: 10,
		pageNumber: 1
	});

	const refreshRuns = async () => {
		try {
			setPageState('loading');
			const searchRunsResponse = await runsApiClient.searchRuns(searchParameter);
			setSearchResult(searchRunsResponse.data);
			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	};

	useEffect(
		() => {
			refreshRuns();
		},
		[searchParameter]
	);

	const handleRunAdded = () => {
		refreshRuns();
	};

	const handleRunDeleted = () => {
		refreshRuns();
	};

	const handleHubConnectionError = () => {
		setPageState('error');
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
			<CilPageHeader text={translations.runs.runs}>
				<div className={classes.pageHeaderLeft}>
					<CilAddRunButton onRunAdded={handleRunAdded} />
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
			<CilRunsList
				runs={searchResult.data}
				onRunDeleted={handleRunDeleted}
				onHubConnectionError={handleHubConnectionError}
			/>
		</CilPage>
	);
};

export default CilRunsPage;
