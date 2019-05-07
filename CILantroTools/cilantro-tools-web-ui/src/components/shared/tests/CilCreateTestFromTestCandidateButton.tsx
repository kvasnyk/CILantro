import React, { FunctionComponent } from 'react';

import AddIcon from '@material-ui/icons/AddRounded';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestCandidate from '../../../api/models/tests/TestCandidate';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilIconButton from '../../utils/CilIconButton';

interface CilCreateTestFromTestCandidateButtonProps {
	testCandidate: TestCandidate;
	onTestCreated: () => void;
}

const CilCreateTestFromTestCandidateButton: FunctionComponent<CilCreateTestFromTestCandidateButtonProps> = props => {
	const testsApiClient = new TestsApiClient();

	const notistack = useNotistack();

	const handleClick = async () => {
		try {
			await testsApiClient.createTestFromCandidate({
				testCandidateName: props.testCandidate.name,
				testCandidatePath: props.testCandidate.path
			});
			notistack.enqueueSuccess(translations.tests.testHasBeenAdded);
			props.onTestCreated();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileAddingTest, error);
		}
	};

	return (
		<CilIconButton onClick={handleClick}>
			<AddIcon />
		</CilIconButton>
	);
};

export default CilCreateTestFromTestCandidateButton;
