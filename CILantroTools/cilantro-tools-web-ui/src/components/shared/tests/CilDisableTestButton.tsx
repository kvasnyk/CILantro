import React, { FunctionComponent } from 'react';

import { Fab } from '@material-ui/core';
import DisableIcon from '@material-ui/icons/PowerOffRounded';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestInfo from '../../../api/models/tests/TestInfo';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';

interface CilDisableTestButtonProps {
	testInfo: TestInfo;
	onTestDisabled: () => void;
}

const CilDisableTestButton: FunctionComponent<CilDisableTestButtonProps> = props => {
	const testsApiClient = new TestsApiClient();

	const notistack = useNotistack();

	const handleClick = async () => {
		try {
			await testsApiClient.disableTest(props.testInfo.test.id);
			notistack.enqueueSuccess(translations.tests.testHasBeenDisabled);
			props.onTestDisabled();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileDisablingTest, error);
		}
	};

	return (
		<Fab color="secondary" onClick={handleClick}>
			<DisableIcon />
		</Fab>
	);
};

export default CilDisableTestButton;
