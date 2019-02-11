import React, { FunctionComponent } from 'react';

import { IconButton } from '@material-ui/core';
import BuildIcon from '@material-ui/icons/BuildRounded';
import RefreshIcon from '@material-ui/icons/RefreshRounded';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';

interface CilGenerateTestIlSourcesButtonProps {
	test: TestReadModel;
	onIlSourcesGenerated: () => void;
}

const CilGenerateTestIlSourcesButton: FunctionComponent<CilGenerateTestIlSourcesButtonProps> = props => {
	const testsApiClient = new TestsApiClient();

	const notistack = useNotistack();

	const handleClick = async () => {
		try {
			await testsApiClient.generateIlSources(props.test.id);
			notistack.enqueueSuccess(translations.tests.ilSourcesHasBeenGenerated);
			props.onIlSourcesGenerated();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileGeneratingIlSources);
		}
	};

	return (
		<IconButton onClick={handleClick}>
			{props.test.hasIlSources ? <RefreshIcon fontSize="small" /> : <BuildIcon fontSize="small" />}
		</IconButton>
	);
};

export default CilGenerateTestIlSourcesButton;
