import React, { StatelessComponent } from 'react';

import TestCandidate from '../../../api/models/tests/TestCandidate';
import CilGridLayout from '../../layouts/CilGridLayout';
import CilTestCandidateCard from './CilTestCandidateCard';

interface CilTestCandidatesListProps {
  testCandidates: TestCandidate[];
}

const CilTestCandidatesList: StatelessComponent<
  CilTestCandidatesListProps
> = props => {
  return (
    <CilGridLayout columns={4}>
      {props.testCandidates.map(tc => (
        <CilTestCandidateCard key={tc.name} testCandidate={tc} />
      ))}
    </CilGridLayout>
  );
};

export default CilTestCandidatesList;
