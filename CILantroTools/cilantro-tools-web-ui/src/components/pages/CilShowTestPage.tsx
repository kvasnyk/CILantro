import React, { ChangeEvent, FunctionComponent, useEffect, useState } from 'react';

import { AppBar, Tab, Tabs, Typography } from '@material-ui/core';

import TestsApiClient from '../../api/clients/TestsApiClient';
import TestReadModel from '../../api/read-models/tests/TestReadModel';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilTestChecklist from '../shared/tests/CilTestChecklist';

interface CilShowTestPageProps {
	testId: string;
}

type TabsValue = 'overview';

const CilShowTestPage: FunctionComponent<CilShowTestPageProps> = props => {
	const testsApiClient = new TestsApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');
	const [test, setTest] = useState<TestReadModel | undefined>(undefined);
	const [tabsValue, setTabsValue] = useState<TabsValue>('overview');

	const refreshTest = async () => {
		try {
			const getTestResponse = await testsApiClient.getTest(props.testId);
			setTest(getTestResponse.data);
			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	};

	const handleTabsValueChange = (event: ChangeEvent<{}>, newValue: TabsValue) => {
		setTabsValue(newValue);
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

					<AppBar position="static">
						<Tabs value={tabsValue} onChange={handleTabsValueChange}>
							<Tab label={translations.tests.testOverview} value="overview" />
						</Tabs>
					</AppBar>
				</>
			) : null}
		</CilPage>
	);
};

export default CilShowTestPage;
