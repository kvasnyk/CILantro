import moment from 'moment';
import React, { FunctionComponent, ReactNode, useEffect, useState } from 'react';

import { Theme } from '@material-ui/core';
import { green, red } from '@material-ui/core/colors';
import CheckIcon from '@material-ui/icons/CheckRounded';
import QuickIcon from '@material-ui/icons/DirectionsRunRounded';
import FullIcon from '@material-ui/icons/HourglassEmptyRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import { makeStyles } from '@material-ui/styles';

import RunsApiClient from '../../api/clients/RunsApiClient';
import RunOutcome from '../../api/enums/RunOutcome';
import RunType from '../../api/enums/RunType';
import RunReadModel from '../../api/read-models/runs/RunReadModel';
import TestRunReadModel from '../../api/read-models/runs/TestRunReadModel';
import SearchDirection from '../../api/search/SearchDirection';
import useSearch from '../../hooks/useSearch';
import CilPage, { PageState } from '../base/CilPage';
import CilTestRunsList from '../shared/runs/CilTestRunsList';
import CilPageHeader from '../utils/CilPageHeader';
import CilPagination from '../utils/CilPagination';

const useStyles = makeStyles((theme: Theme) => ({
	okHeaderTypography: {
		color: green[700],
		fontSize: '4em'
	},
	wrongHeaderTypography: {
		color: red[700],
		fontSize: '4em'
	},
	pageHeaderLeft: {
		flexGrow: 1
	},
	pageHeaderRight: {
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center'
	}
}));

interface CilShowRunPageProps {
	runId: string;
}

const CilShowRunPage: FunctionComponent<CilShowRunPageProps> = props => {
	const classes = useStyles();

	const runsApiClient = new RunsApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');
	const [run, setRun] = useState<RunReadModel | undefined>(undefined);

	const testRunsSearch = useSearch<TestRunReadModel>({
		orderBy: {
			property: 'outcome',
			direction: SearchDirection.Desc
		},
		orderBy2: {
			property: 'testName',
			direction: SearchDirection.Asc
		},
		pageSize: 10,
		pageNumber: 1
	});

	const refreshRun = async () => {
		try {
			const getRunResponse = await runsApiClient.getRun(props.runId);
			setRun(getRunResponse.data);
		} catch (error) {
			setPageState('error');
			throw error;
		}
	};

	const refreshTestRuns = async () => {
		try {
			setPageState('loading');
			const searchTestRunsResponse = await runsApiClient.searchTestRuns(props.runId, testRunsSearch.parameter);
			testRunsSearch.setResult(searchTestRunsResponse.data);
		} catch (error) {
			setPageState('error');
			throw error;
		}
	};

	useEffect(() => {
		try {
			refreshRun();
			refreshTestRuns();

			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	}, []);

	useEffect(
		() => {
			try {
				setPageState('loading');

				refreshTestRuns();

				setPageState('success');
			} catch (error) {
				setPageState('error');
			}
		},
		[testRunsSearch.parameter]
	);

	let runTypeIcon: ReactNode;
	if (run && run.type === RunType.Full) {
		runTypeIcon = <FullIcon />;
	} else if (run && run.type === RunType.Quick) {
		runTypeIcon = <QuickIcon />;
	}

	return (
		<CilPage state={pageState}>
			{run ? (
				<>
					<CilPageHeader text={moment(run.createdOn).format('YYYY-MM-DD HH:mm:ss')} avatarIcon={runTypeIcon}>
						<div className={classes.pageHeaderLeft}>
							{run.outcome === RunOutcome.Ok ? <CheckIcon className={classes.okHeaderTypography} /> : null}
							{run.outcome === RunOutcome.Wrong ? <NotCheckIcon className={classes.wrongHeaderTypography} /> : null}
						</div>
						<div className={classes.pageHeaderRight}>
							<CilPagination search={testRunsSearch} />
						</div>
					</CilPageHeader>

					<CilTestRunsList testRuns={testRunsSearch.result.data} />
				</>
			) : null}
		</CilPage>
	);
};

export default CilShowRunPage;
