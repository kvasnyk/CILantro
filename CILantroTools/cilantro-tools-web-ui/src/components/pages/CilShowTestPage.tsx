import React, { ChangeEvent, FunctionComponent, useEffect, useState } from 'react';

import { AppBar, Tab, Tabs, Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import CategoriesApiClient from '../../api/clients/CategoriesApiClient';
import TestsApiClient from '../../api/clients/TestsApiClient';
import CategoryReadModel from '../../api/read-models/categories/CategoryReadModel';
import TestReadModel from '../../api/read-models/tests/TestReadModel';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilEditTestCategorySelect from '../shared/tests/CilEditTestCategorySelect';
import CilEditTestSubcategorySelect from '../shared/tests/CilEditTestSubcategorySelect';
import CilGenerateTestIlSourcesButton from '../shared/tests/CilGenerateTestIlSourcesButton';
import CilTestChecklist from '../shared/tests/CilTestChecklist';
import CilDetailsRow from '../utils/CilDetailsRow';
import CilDetailsValue from '../utils/CilDetailsValue';

const useStyles = makeStyles((theme: Theme) => ({
	tabsAppBar: {
		marginTop: '20px'
	},
	tabContainer: {
		padding: '20px'
	}
}));

interface CilShowTestPageProps {
	testId: string;
}

type TabsValue = 'overview' | 'il-sources';

const CilShowTestPage: FunctionComponent<CilShowTestPageProps> = props => {
	const classes = useStyles();

	const testsApiClient = new TestsApiClient();
	const categoriesApiClient = new CategoriesApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');
	const [test, setTest] = useState<TestReadModel | undefined>(undefined);
	const [tabsValue, setTabsValue] = useState<TabsValue>('overview');
	const [categories, setCategories] = useState<CategoryReadModel[] | undefined>(undefined);

	const subcategories = test && test.category ? test.category.subcategories : [];

	const refreshTest = async () => {
		try {
			const getTestResponse = await testsApiClient.getTest(props.testId);
			setTest(getTestResponse.data);
		} catch (error) {
			setPageState('error');
			throw error;
		}
	};

	const refreshCategories = async () => {
		try {
			const searchCategoriesResponse = await categoriesApiClient.searchCategories({});
			setCategories(searchCategoriesResponse.data.data);
		} catch (error) {
			setPageState('error');
			throw error;
		}
	};

	const handleTabsValueChange = (event: ChangeEvent<{}>, newValue: TabsValue) => {
		setTabsValue(newValue);
	};

	const handleCategoryUpdated = () => {
		refreshTest();
	};

	const handleSubcategoryUpdated = () => {
		refreshTest();
	};

	const handleIlSourcesGenerated = () => {
		refreshTest();
	};

	useEffect(() => {
		try {
			refreshTest();
			refreshCategories();

			setPageState('success');
		} catch (error) {
			setPageState('error');
		}
	}, []);

	return (
		<CilPage state={pageState}>
			{test && categories ? (
				<>
					<Typography variant="h1">{test.name}</Typography>
					<Typography variant="subtitle1">...{test.path}</Typography>

					{!test.isReady ? <CilTestChecklist test={test} /> : null}

					<AppBar position="static" className={classes.tabsAppBar}>
						<Tabs value={tabsValue} onChange={handleTabsValueChange}>
							<Tab label={translations.tests.testOverview} value="overview" />
							<Tab label={translations.tests.testIlSources} value="il-sources" />
						</Tabs>
					</AppBar>

					{tabsValue === 'overview' ? (
						<div className={classes.tabContainer}>
							<CilDetailsRow label={translations.tests.testCategory}>
								<CilEditTestCategorySelect
									categories={categories}
									test={test}
									onCategoryUpdated={handleCategoryUpdated}
								/>
							</CilDetailsRow>
							<CilDetailsRow label={translations.tests.testSubcategory}>
								<CilEditTestSubcategorySelect
									subcategories={subcategories}
									test={test}
									onSubcategoryUpdated={handleSubcategoryUpdated}
								/>
							</CilDetailsRow>
						</div>
					) : null}

					{tabsValue === 'il-sources' ? (
						<div className={classes.tabContainer}>
							<CilDetailsRow label={translations.tests.testMainIlSource}>
								<CilDetailsValue value={test.mainIlSourcePath} prefix="..." />
								<CilGenerateTestIlSourcesButton test={test} onIlSourcesGenerated={handleIlSourcesGenerated} />
							</CilDetailsRow>
						</div>
					) : null}
				</>
			) : null}
		</CilPage>
	);
};

export default CilShowTestPage;
