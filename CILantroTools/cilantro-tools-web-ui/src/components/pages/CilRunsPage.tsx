import React, { FunctionComponent, useEffect, useState } from 'react';

import RunsApiClient from '../../api/clients/RunsApiClient';
import RunReadModel from '../../api/read-models/runs/RunReadModel';
import SearchResult from '../../api/search/SearchResult';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilAddRunButton from '../shared/runs/CilAddRunButton';
import CilRunsList from '../shared/runs/CilRunsList';
import CilPageHeader from '../utils/CilPageHeader';

const CilRunsPage: FunctionComponent = props => {
	const runsApiClient = new RunsApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');
	const [searchResult, setSearchResult] = useState<SearchResult<RunReadModel>>({ data: [] });

	const refreshRuns = async () => {
		try {
			const searchRunsResponse = await runsApiClient.searchRuns({});
			setSearchResult(searchRunsResponse.data);
			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	};

	useEffect(() => {
		refreshRuns();
	}, []);

	const handleRunAdded = () => {
		refreshRuns();
	};

	const centerChildren = searchResult.data.length <= 0;

	return (
		<CilPage state={pageState} centerChildren={centerChildren}>
			<CilPageHeader text={translations.runs.runs}>
				<CilAddRunButton onRunAdded={handleRunAdded} />
			</CilPageHeader>
			<CilRunsList runs={searchResult.data} />
		</CilPage>
	);
};

export default CilRunsPage;
