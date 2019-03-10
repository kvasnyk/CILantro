import React, { FunctionComponent, useEffect, useState } from 'react';

import TestsApiClient from '../../api/clients/TestsApiClient';
import TestCandidate from '../../api/models/tests/TestCandidate';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilTestCandidatesList from '../shared/tests/CilTestCandidatesList';
import CilPageHeader from '../utils/CilPageHeader';

const CilFindTestsPage: FunctionComponent = props => {
	const testsApiClient = new TestsApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');
	const [testCandidates, setTestCandidates] = useState<TestCandidate[]>([]);

	const refreshTestCandidates = async () => {
		try {
			const findTestsResponse = await testsApiClient.findTests();
			setTestCandidates(findTestsResponse.data);
			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	};

	const handleTestCreated = () => {
		refreshTestCandidates();
	};

	useEffect(() => {
		refreshTestCandidates();
	}, []);

	const centerChildren = testCandidates.length <= 0;

	return (
		<CilPage state={pageState} centerChildren={centerChildren}>
			<CilPageHeader text={translations.tests.findTests} />
			<CilTestCandidatesList testCandidates={testCandidates} onTestCreated={handleTestCreated} />
		</CilPage>
	);
};

export default CilFindTestsPage;
