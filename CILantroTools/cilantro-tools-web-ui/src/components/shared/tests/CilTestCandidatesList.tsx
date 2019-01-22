import React, { StatelessComponent } from 'react';

import TestCandidate from '../../../api/models/tests/TestCandidate';
import CilGridLayout from '../../layouts/CilGridLayout';
import CilTestCandidateCard from './CilTestCandidateCard';

interface CilTestCandidatesListProps {
  testCandidates: TestCandidate[];
  onTestCreated: () => void;
}

const CilTestCandidatesList: StatelessComponent<
  CilTestCandidatesListProps
> = props => {
  return (
    <CilGridLayout columns={3}>
      {props.testCandidates.map(tc => (
        <CilTestCandidateCard
          key={tc.name}
          testCandidate={tc}
          onTestCreated={props.onTestCreated}
        />
      ))}
    </CilGridLayout>
  );
};

export default CilTestCandidatesList;
