import React, { FunctionComponent } from 'react';

import BuildIcon from '@material-ui/icons/BuildRounded';
import RefreshIcon from '@material-ui/icons/RefreshRounded';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilIconButton from '../../utils/CilIconButton';

interface CilGenerateTestExeButtonProps {
	test: TestReadModel;
	onExeGenerated: () => void;
}

const CilGenerateTestExeButton: FunctionComponent<CilGenerateTestExeButtonProps> = props => {
	const testsApiClient = new TestsApiClient();

	const notistack = useNotistack();

	const handleClick = async () => {
		try {
			await testsApiClient.generateExe(props.test.id);
			notistack.enqueueSuccess(translations.tests.exeHasBeenGenerated);
			props.onExeGenerated();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileGeneratingExe, error);
		}
	};

	return props.test.hasIlSources ? (
		<CilIconButton onClick={handleClick}>
			{props.test.hasExe ? <RefreshIcon fontSize="small" /> : <BuildIcon fontSize="small" />}
		</CilIconButton>
	) : null;
};

export default CilGenerateTestExeButton;
