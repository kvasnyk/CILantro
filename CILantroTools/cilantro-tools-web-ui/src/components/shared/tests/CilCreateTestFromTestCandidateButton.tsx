import React, { StatelessComponent } from 'react';

import { IconButton } from '@material-ui/core';
import AddIcon from '@material-ui/icons/AddRounded';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestCandidate from '../../../api/models/tests/TestCandidate';

interface CilCreateTestFromTestCandidateButtonProps {
  testCandidate: TestCandidate;
}

const CilCreateTestFromTestCandidateButton: StatelessComponent<
  CilCreateTestFromTestCandidateButtonProps
> = props => {
  const testsApiClient = new TestsApiClient();

  const handleClick = async () => {
    await testsApiClient.createTestFromCandidate({
      testCandidateName: props.testCandidate.name,
      testCandidatePath: props.testCandidate.path
    });
  };

  return (
    <IconButton onClick={handleClick}>
      <AddIcon />
    </IconButton>
  );
};

export default CilCreateTestFromTestCandidateButton;
