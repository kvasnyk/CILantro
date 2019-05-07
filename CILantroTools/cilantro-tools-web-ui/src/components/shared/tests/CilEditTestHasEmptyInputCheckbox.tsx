import React, { FunctionComponent } from 'react';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilEditableCheckbox from '../../utils/CilEditableCheckbox';

interface CilEditTestHasEmptyInputCheckboxProps {
	test: TestReadModel;
	onHasEmptyInputUpdated: () => void;
}

const CilEditTestHasEmptyInputCheckbox: FunctionComponent<CilEditTestHasEmptyInputCheckboxProps> = props => {
	const testsApiClient = new TestsApiClient();

	const notistack = useNotistack();

	const editTestHasEmptyInput = async (newValue: boolean) => {
		try {
			await testsApiClient.editTestHasEmptyInput(props.test.id, { hasEmptyInput: newValue });
			notistack.enqueueSuccess(translations.tests.emptyInputHasBeenUpdated);
			props.onHasEmptyInputUpdated();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileUpdatingEmptyInput, error);
		}
	};

	const handleValueChange = (newValue: boolean) => {
		editTestHasEmptyInput(newValue);
	};

	return <CilEditableCheckbox isChecked={props.test.hasEmptyInput} onValueChange={handleValueChange} />;
};

export default CilEditTestHasEmptyInputCheckbox;
