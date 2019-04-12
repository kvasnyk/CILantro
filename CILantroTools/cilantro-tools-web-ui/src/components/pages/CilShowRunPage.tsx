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
import CilPage, { PageState } from '../base/CilPage';
import CilPageHeader from '../utils/CilPageHeader';

const useStyles = makeStyles((theme: Theme) => ({
	okHeaderTypography: {
		color: green[700],
		fontSize: '4em'
	},
	wrongHeaderTypography: {
		color: red[700],
		fontSize: '4em'
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

	const refreshRun = async () => {
		try {
			const getRunResponse = await runsApiClient.getRun(props.runId);
			setRun(getRunResponse.data);
			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	};

	useEffect(() => {
		refreshRun();
	}, []);

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
				</>
			) : null}
		</CilPage>
	);
};

export default CilShowRunPage;
