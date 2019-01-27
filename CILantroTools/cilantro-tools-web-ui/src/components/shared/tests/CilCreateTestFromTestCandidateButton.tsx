import React, { StatelessComponent } from 'react';

import { IconButton } from '@material-ui/core';
import AddIcon from '@material-ui/icons/AddRounded';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestCandidate from '../../../api/models/tests/TestCandidate';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';

interface CilCreateTestFromTestCandidateButtonProps {
  testCandidate: TestCandidate;
  onTestCreated: () => void;
}

const CilCreateTestFromTestCandidateButton: StatelessComponent<
  CilCreateTestFromTestCandidateButtonProps
> = props => {
  const testsApiClient = new TestsApiClient();

  const notistack = useNotistack();

  const handleClick = async () => {
    try {
      await testsApiClient.createTestFromCandidate({
        testCandidateName: props.testCandidate.name,
        testCandidatePath: props.testCandidate.path
      });
      notistack.enqueueSnackbar(translations.tests.testHasBeenAdded, {
        variant: 'success'
      });
      props.onTestCreated();
    } catch (error) {
      notistack.enqueueSnackbar(
        translations.tests.errorOccurredWhileAddingTest,
        {
          variant: 'error'
        }
      );
    }
  };

  return (
    <IconButton onClick={handleClick}>
      <AddIcon />
    </IconButton>
  );
};

export default CilCreateTestFromTestCandidateButton;
