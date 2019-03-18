import React, { FunctionComponent } from 'react';

import DeleteIcon from '@material-ui/icons/DeleteRounded';

import RunsApiClient from '../../../api/clients/RunsApiClient';
import RunReadModel from '../../../api/read-models/runs/RunReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilIconButton from '../../utils/CilIconButton';

interface CilDeleteRunButtonProps {
	run: RunReadModel;
	onRunDeleted: () => void;
	iconClassName?: string;
}

const CilDeleteRunButton: FunctionComponent<CilDeleteRunButtonProps> = props => {
	const runsApiClient = new RunsApiClient();

	const notistack = useNotistack();

	const handleClick = async () => {
		try {
			await runsApiClient.deleteRun(props.run.id);
			notistack.enqueueSuccess(translations.runs.runHasBeenDeleted);
			props.onRunDeleted();
		} catch (error) {
			notistack.enqueueError(translations.runs.errorOccurredWhileDeletingRun);
		}
	};

	return (
		<CilIconButton onClick={handleClick}>
			<DeleteIcon className={props.iconClassName} />
		</CilIconButton>
	);
};

export default CilDeleteRunButton;
