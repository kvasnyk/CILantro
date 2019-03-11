import React, { FunctionComponent, useState } from 'react';

import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilPageHeader from '../utils/CilPageHeader';

const CilRunsPage: FunctionComponent = props => {
	const [pageState] = useState<PageState>('success');

	return (
		<CilPage state={pageState}>
			<CilPageHeader text={translations.runs.runs} />
		</CilPage>
	);
};

export default CilRunsPage;
