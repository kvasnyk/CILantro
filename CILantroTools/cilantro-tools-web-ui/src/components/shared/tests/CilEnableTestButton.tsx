import React, { FunctionComponent } from 'react';

import { Fab } from '@material-ui/core';
import EnableIcon from '@material-ui/icons/PowerRounded';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestInfo from '../../../api/models/tests/TestInfo';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';

interface CilEnableTestButtonProps {
	testInfo: TestInfo;
	onTestEnabled: () => void;
}

const CilEnableTestButton: FunctionComponent<CilEnableTestButtonProps> = props => {
	const testsApiClient = new TestsApiClient();

	const notistack = useNotistack();

	const handleClick = async () => {
		try {
			await testsApiClient.enableTest(props.testInfo.test.id);
			notistack.enqueueSuccess(translations.tests.testHasBeenEnabled);
			props.onTestEnabled();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileDisablingTest, error);
		}
	};

	return (
		<Fab color="secondary" onClick={handleClick}>
			<EnableIcon />
		</Fab>
	);
};

export default CilEnableTestButton;
