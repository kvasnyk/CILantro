import React, { StatelessComponent, useEffect, useState } from 'react';

import TestsApiClient from '../../api/clients/TestsApiClient';
import TestReadModel from '../../api/read-models/tests/TestReadModel';
import SearchResult from '../../api/search/SearchResult';
import CilPage, { PageState } from '../base/CilPage';
import CilTestsList from '../shared/tests/CilTestsList';

const CilTestsPage: StatelessComponent = props => {
  const testsApiClient = new TestsApiClient();

  const [pageState, setPageState] = useState<PageState>('loading');
  const [searchResult, setSearchResult] = useState<SearchResult<TestReadModel>>(
    { data: [] }
  );

  const refreshTests = async () => {
    try {
      const searchTestsResponse = await testsApiClient.searchTests({});
      setSearchResult(searchTestsResponse.data);
      setPageState('success');
    } catch (error) {
      alert(error);
      setPageState('error');
    }
  };

  useEffect(() => {
    refreshTests();
  }, []);

  return (
    <CilPage state={pageState}>
      <CilTestsList tests={searchResult.data} />
    </CilPage>
  );
};

export default CilTestsPage;
