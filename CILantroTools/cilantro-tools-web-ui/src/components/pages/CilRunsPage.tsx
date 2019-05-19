import React, { FunctionComponent, useEffect, useState } from 'react';

import { MenuItem, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import RunsApiClient from '../../api/clients/RunsApiClient';
import RunType from '../../api/enums/RunType';
import RunReadModel from '../../api/read-models/runs/RunReadModel';
import SearchDirection from '../../api/search/SearchDirection';
import useSearch from '../../hooks/useSearch';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilRunOutcomeFilter from '../filters/CilRunOutcomeFilter';
import CilAddRunButton from '../shared/runs/CilAddRunButton';
import CilRunsList from '../shared/runs/CilRunsList';
import CilFiltersPanel from '../utils/CilFiltersPanel';
import CilOpenFiltersButton from '../utils/CilOpenFiltersButton';
import CilOrderByDropDown from '../utils/CilOrderByDropDown';
import CilPageHeader from '../utils/CilPageHeader';
import CilPagination from '../utils/CilPagination';

const useStyles = makeStyles((theme: Theme) => ({
	pageHeaderLeft: {
		flexGrow: 1,
		'&>*': {
			marginRight: '10px'
		}
	},
	pageHeaderRight: {
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center'
	}
}));

const CilRunsPage: FunctionComponent = props => {
	const classes = useStyles();

	const runsApiClient = new RunsApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');

	const search = useSearch<RunReadModel>({
		orderBy: {
			property: 'createdOn',
			direction: SearchDirection.Desc
		},
		pageSize: 10,
		pageNumber: 1,
		filters: []
	});

	const refreshRuns = async () => {
		try {
			setPageState('loading');
			const searchRunsResponse = await runsApiClient.searchRuns(search.parameter);
			search.setResult(searchRunsResponse.data);
			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	};

	useEffect(
		() => {
			refreshRuns();
		},
		[search.parameter]
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

	const centerChildren = search.result.data.length <= 0;

	return (
		<CilPage state={pageState} centerChildren={centerChildren}>
			<CilPageHeader text={translations.runs.runs}>
				<div className={classes.pageHeaderLeft}>
					<CilAddRunButton type={RunType.Quick} onRunAdded={handleRunAdded} />
					<CilAddRunButton type={RunType.Full} onRunAdded={handleRunAdded} />
				</div>
				<div className={classes.pageHeaderRight}>
					<CilOpenFiltersButton search={search} />
					<CilOrderByDropDown search={search}>
						<MenuItem value="createdOn">{translations.runs.createdOn}</MenuItem>
					</CilOrderByDropDown>
					<CilPagination search={search} />
				</div>
			</CilPageHeader>
			<CilFiltersPanel search={search}>
				<div>
					<CilRunOutcomeFilter<RunReadModel> search={search} runOutcomeProperty="outcome" hideNotRun={true} />
				</div>
			</CilFiltersPanel>
			<CilRunsList
				runs={search.result.data}
				onRunDeleted={handleRunDeleted}
				onHubConnectionError={handleHubConnectionError}
			/>
		</CilPage>
	);
};

export default CilRunsPage;
