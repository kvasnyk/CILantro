import React, { FunctionComponent, useState } from 'react';

import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilAddRunButton from '../shared/runs/CilAddRunButton';
import CilPageHeader from '../utils/CilPageHeader';

const CilRunsPage: FunctionComponent = props => {
	const [pageState] = useState<PageState>('success');

	const handleRunAdded = () => {
		return;
	};

	return (
		<CilPage state={pageState}>
			<CilPageHeader text={translations.runs.runs}>
				<CilAddRunButton onRunAdded={handleRunAdded} />
			</CilPageHeader>
		</CilPage>
	);
};

export default CilRunsPage;
