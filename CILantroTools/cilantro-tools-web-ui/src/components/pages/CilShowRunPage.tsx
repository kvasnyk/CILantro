import moment from 'moment';
import React, { FunctionComponent, ReactNode, useEffect, useState } from 'react';

import { Theme, Typography } from '@material-ui/core';
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
import translations from '../../translations/translations';
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
	listHeader: {
		display: 'flex',
		flexDirection: 'row'
	},
	listHeaderLeft: {
		flexGrow: 1
	},
	listHeaderRight: {
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center'
	},
	details: {
		display: 'flex',
		flexDirection: 'row',
		'&>*': {
			flexGrow: 1,
			flexBasis: 0,
			padding: '10px',
			display: 'flex',
			flexDirection: 'column',
			alignItems: 'center',
			justifyContent: 'center'
		}
	},
	passedTypography: {
		color: green[700]
	},
	failedTypography: {
		color: red[700]
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
		pageNumber: 1,
		filters: []
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
						{run.outcome === RunOutcome.Ok ? <CheckIcon className={classes.okHeaderTypography} /> : null}
						{run.outcome === RunOutcome.Wrong ? <NotCheckIcon className={classes.wrongHeaderTypography} /> : null}
					</CilPageHeader>

					<div className={classes.details}>
						<div>
							<Typography variant="h2" className={classes.passedTypography}>
								{run.okTestsCount} {translations.runs.testsPassed} (
								{((run.okTestsCount / run.allTestsCount) * 100).toFixed(2)} %)
							</Typography>
							<Typography variant="h2" className={classes.failedTypography}>
								{run.wrongTestsCount} {translations.runs.testsFailed} (
								{((run.wrongTestsCount / run.allTestsCount) * 100).toFixed(2)} %)
							</Typography>
						</div>
					</div>

					<div>
						<div className={classes.listHeader}>
							<div className={classes.listHeaderLeft} />
							<div className={classes.listHeaderRight}>
								<CilPagination search={testRunsSearch} />
							</div>
						</div>
						<CilTestRunsList testRuns={testRunsSearch.result.data} />
					</div>
				</>
			) : null}
		</CilPage>
	);
};

export default CilShowRunPage;
