import React, { StatelessComponent } from 'react';

import { IconButton } from '@material-ui/core';
import AddIcon from '@material-ui/icons/AddRounded';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestCandidate from '../../../api/models/tests/TestCandidate';

interface CilCreateTestFromTestCandidateButtonProps {
  testCandidate: TestCandidate;
  onTestCreated: () => void;
}

const CilCreateTestFromTestCandidateButton: StatelessComponent<
  CilCreateTestFromTestCandidateButtonProps
> = props => {
  const testsApiClient = new TestsApiClient();

  const handleClick = async () => {
    try {
      await testsApiClient.createTestFromCandidate({
        testCandidateName: props.testCandidate.name,
        testCandidatePath: props.testCandidate.path
      });
      props.onTestCreated();
    } catch (error) {
      alert('error!');
    }
  };

  return (
    <IconButton onClick={handleClick}>
      <AddIcon />
    </IconButton>
  );
};

export default CilCreateTestFromTestCandidateButton;
