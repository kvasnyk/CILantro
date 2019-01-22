import React, { StatelessComponent, useEffect, useState } from 'react';

import TestsApiClient from '../../api/clients/TestsApiClient';
import TestCandidate from '../../api/models/tests/TestCandidate';
import CilPage, { PageState } from '../base/CilPage';
import CilTestCandidatesList from '../shared/tests/CilTestCandidatesList';

const CilFindTestsPage: StatelessComponent = props => {
  const testsApiClient = new TestsApiClient();

  const [pageState, setPageState] = useState<PageState>('loading');
  const [testCandidates, setTestCandidates] = useState<TestCandidate[]>([]);

  const refreshTestCandidates = async () => {
    try {
      const findTestsResponse = await testsApiClient.findTests();
      setTestCandidates(findTestsResponse.data);
      setPageState('success');
    } catch (error) {
      alert(error);
      setPageState('error');
    }
  };

  const handleTestCreated = () => {
    refreshTestCandidates();
  };

  useEffect(() => {
    refreshTestCandidates();
  }, []);

  return (
    <CilPage state={pageState}>
      <CilTestCandidatesList
        testCandidates={testCandidates}
        onTestCreated={handleTestCreated}
      />
    </CilPage>
  );
};

export default CilFindTestsPage;
