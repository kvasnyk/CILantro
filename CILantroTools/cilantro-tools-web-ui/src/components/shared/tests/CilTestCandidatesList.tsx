import React, { StatelessComponent } from 'react';

import { Typography } from '@material-ui/core';

import TestCandidate from '../../../api/models/tests/TestCandidate';
import translations from '../../../translations/translations';
import CilGridLayout from '../../layouts/CilGridLayout';
import CilTestCandidateCard from './CilTestCandidateCard';

interface CilTestCandidatesListProps {
  testCandidates: TestCandidate[];
  onTestCreated: () => void;
}

const CilTestCandidatesList: StatelessComponent<
  CilTestCandidatesListProps
> = props => {
  return props.testCandidates.length > 0 ? (
    <CilGridLayout columns={3}>
      {props.testCandidates.map(tc => (
        <CilTestCandidateCard
          key={tc.name}
          testCandidate={tc}
          onTestCreated={props.onTestCreated}
        />
      ))}
    </CilGridLayout>
  ) : (
    <Typography variant="h2" align="center">
      {translations.tests.noTestCandidates}
    </Typography>
  );
};

export default CilTestCandidatesList;
