import React, { StatelessComponent } from 'react';

import TestCandidate from '../../../api/models/tests/TestCandidate';
import CilTestCandidateCard from './CilTestCandidateCard';

interface CilTestCandidatesListProps {
  testCandidates: TestCandidate[];
}

const CilTestCandidatesList: StatelessComponent<
  CilTestCandidatesListProps
> = props => {
  return (
    <div>
      {props.testCandidates.map(tc => (
        <CilTestCandidateCard key={tc.name} testCandidate={tc} />
      ))}
    </div>
  );
};

export default CilTestCandidatesList;
