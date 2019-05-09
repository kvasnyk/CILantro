import React, { FunctionComponent } from 'react';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestInfo from '../../../api/models/tests/TestInfo';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilEditableTextField from '../../utils/CilEditableTextField';

interface CilEditTestDisabledReasonTextFieldProps {
	testInfo: TestInfo;
	onDisabledReasonUpdated: () => void;
}

const CilEditTestDisabledReasonTextField: FunctionComponent<CilEditTestDisabledReasonTextFieldProps> = props => {
	const testsApiClient = new TestsApiClient();

	const notistack = useNotistack();

	const updateDisabledReason = async (disabledReason: string) => {
		try {
			await testsApiClient.editTestDisabledReason(props.testInfo.test.id, {
				disabledReason
			});
			notistack.enqueueSuccess(translations.tests.disabledReasonHasBeenUpdated);
			props.onDisabledReasonUpdated();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileUpdatingDisabledReason, error);
		}
	};

	const handleDisabledReasonValueChange = (newValue: string) => {
		updateDisabledReason(newValue);
	};

	return (
		<CilEditableTextField
			value={props.testInfo.test.disabledReason || ''}
			onValueChange={handleDisabledReasonValueChange}
		/>
	);
};

export default CilEditTestDisabledReasonTextField;
