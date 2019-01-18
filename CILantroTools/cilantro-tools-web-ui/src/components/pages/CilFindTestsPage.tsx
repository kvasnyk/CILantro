import React, { StatelessComponent, useEffect, useState } from 'react';

import TestsApiClient from '../../api/clients/TestsApiClient';
import CilPage, { PageState } from '../base/CilPage';

const CilFindTestsPage: StatelessComponent = props => {
  const testsApiClient = new TestsApiClient();

  const [pageState, setPageState] = useState<PageState>('loading');
  const [, setTestCandidates] = useState<Array<unknown>>([]);

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

  useEffect(() => {
    refreshTestCandidates();
  }, []);

  return <CilPage state={pageState}>CilFindTestsPage</CilPage>;
};

export default CilFindTestsPage;
