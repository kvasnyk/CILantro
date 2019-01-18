import React, { StatelessComponent, useState } from 'react';

import CilPage, { PageState } from '../base/CilPage';

const CilFindTestsPage: StatelessComponent = props => {
  const [pageState] = useState<PageState>('loading');

  return <CilPage state={pageState}>CilFindTestsPage</CilPage>;
};

export default CilFindTestsPage;
