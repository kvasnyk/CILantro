import React, { FunctionComponent } from 'react';

import ReplayIcon from '@material-ui/icons/ReplayRounded';

import RunsApiClient from '../../../api/clients/RunsApiClient';
import RunReadModel from '../../../api/read-models/runs/RunReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilIconButton from '../../utils/CilIconButton';

interface CilReplayRunButtonProps {
	run: RunReadModel;
	iconClassName?: string;
	onRunReplayed: () => void;
}

const CilReplayRunButton: FunctionComponent<CilReplayRunButtonProps> = props => {
	const runsApiClient = new RunsApiClient();

	const notistack = useNotistack();

	const handleClick = async () => {
		try {
			await runsApiClient.replayRun(props.run.id);
			notistack.enqueueSuccess(translations.runs.runHasBeenAdded);
			props.onRunReplayed();
		} catch (error) {
			notistack.enqueueError(translations.runs.errorOccurredWhileAddingRun, error);
		}
	};

	return (
		<CilIconButton onClick={handleClick}>
			<ReplayIcon className={props.iconClassName} />
		</CilIconButton>
	);
};

export default CilReplayRunButton;
