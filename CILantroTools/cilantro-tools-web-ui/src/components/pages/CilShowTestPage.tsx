import React, { FunctionComponent, useEffect, useState } from 'react';

import { Typography } from '@material-ui/core';

import TestsApiClient from '../../api/clients/TestsApiClient';
import TestReadModel from '../../api/read-models/tests/TestReadModel';
import CilPage, { PageState } from '../base/CilPage';
import CilTestChecklist from '../shared/tests/CilTestChecklist';

interface CilShowTestPageProps {
	testId: string;
}

const CilShowTestPage: FunctionComponent<CilShowTestPageProps> = props => {
	const testsApiClient = new TestsApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');
	const [test, setTest] = useState<TestReadModel | undefined>(undefined);

	const refreshTest = async () => {
		try {
			const getTestResponse = await testsApiClient.getTest(props.testId);
			setTest(getTestResponse.data);
			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	};

	useEffect(() => {
		refreshTest();
	}, []);

	return (
		<CilPage state={pageState}>
			{test ? (
				<>
					<Typography variant="h1">{test.name}</Typography>
					<Typography variant="subtitle1">{test.path}</Typography>

					{!test.isReady ? <CilTestChecklist test={test} /> : null}
				</>
			) : null}
		</CilPage>
	);
};

export default CilShowTestPage;
