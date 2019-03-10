import classNames from 'classnames';
import React, { ChangeEvent, FunctionComponent, useEffect, useState } from 'react';

import { AppBar, Divider, Tab, Tabs, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import CategoriesApiClient from '../../api/clients/CategoriesApiClient';
import TestsApiClient from '../../api/clients/TestsApiClient';
import CategoryReadModel from '../../api/read-models/categories/CategoryReadModel';
import TestReadModel from '../../api/read-models/tests/TestReadModel';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilEditTestCategorySelect from '../shared/tests/CilEditTestCategorySelect';
import CilEditTestSubcategorySelect from '../shared/tests/CilEditTestSubcategorySelect';
import CilGenerateTestExeButton from '../shared/tests/CilGenerateTestExeButton';
import CilGenerateTestIlSourcesButton from '../shared/tests/CilGenerateTestIlSourcesButton';
import CilRunTestBothButton from '../shared/tests/CilRunTestBothButton';
import CilRunTestExeButton from '../shared/tests/CilRunTestExeButton';
import CilRunTestInterpreterButton from '../shared/tests/CilRunTestInterpreterButton';
import CilTestChecklist from '../shared/tests/CilTestChecklist';
import CilTestInputEditor from '../shared/tests/CilTestInputEditor';
import CilTestInputOutputExamplesEditor from '../shared/tests/CilTestInputOutputExamplesEditor';
import CilTestOutputEditor from '../shared/tests/CilTestOutputEditor';
import CilCodeEditor from '../utils/CilCodeEditor';
import CilDetailsRow from '../utils/CilDetailsRow';
import CilDetailsValue from '../utils/CilDetailsValue';
import CilPageHeader from '../utils/CilPageHeader';

const useStyles = makeStyles((theme: Theme) => ({
	tabsAppBar: {
		marginTop: '20px'
	},
	tabContainer: {
		padding: '20px'
	},
	ioTabContainer: {
		display: 'flex',
		flexDirection: 'column'
	},
	ioTabIo: {
		display: 'flex',
		flexDirection: 'row',
		'&>*': {
			flexGrow: 1,
			flexBasis: 0
		}
	},
	ioTabExamples: {},
	ioDivider: {
		marginTop: '15px',
		marginBottom: '15px'
	}
}));

interface CilShowTestPageProps {
	testId: string;
}

type TabsValue = 'overview' | 'il-sources' | 'exe' | 'io';

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

	const handleGoToCategory = () => {
		setTabsValue('overview');
		return Promise.resolve();
	};

	const handleGoToSubcategory = () => {
		setTabsValue('overview');
		return Promise.resolve();
	};

	const handleGoToIlSources = () => {
		setTabsValue('il-sources');
		return Promise.resolve();
	};

	const handleGoToExe = () => {
		setTabsValue('exe');
		return Promise.resolve();
	};

	const handleGoToInput = () => {
		setTabsValue('io');
		return Promise.resolve();
	};

	const handleGoToOutput = () => {
		setTabsValue('io');
		return Promise.resolve();
	};

	const handleGoToIoExamples = () => {
		setTabsValue('io');
		return Promise.resolve();
	};

	const handleCategoryUpdated = () => {
		refreshTest();
	};

	const handleSubcategoryUpdated = () => {
		refreshTest();
	};

	const handleInputUpdated = () => {
		refreshTest();
	};

	const handleOutputUpdated = () => {
		refreshTest();
	};

	const handleIlSourcesGenerated = () => {
		refreshTest();
	};

	const handleExeGenerated = () => {
		refreshTest();
	};

	const handleIoExampleAdded = () => {
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

	const ioTabContainerClassName = classNames(classes.tabContainer, classes.ioTabContainer);

	return (
		<CilPage state={pageState}>
			{test && categories ? (
				<>
					<CilPageHeader text={`${('00000' + test.intId).slice(-5)} | ${test.name}`} subtext={`...${test.path}`}>
						<CilRunTestExeButton type="fab" test={test} />
						<CilRunTestBothButton type="fab" test={test} />
						<CilRunTestInterpreterButton type="fab" test={test} />
					</CilPageHeader>

					{!test.isReady ? (
						<CilTestChecklist
							test={test}
							onGoToCategory={handleGoToCategory}
							onGoToSubcategory={handleGoToSubcategory}
							onGoToIlSources={handleGoToIlSources}
							onGoToExe={handleGoToExe}
							onGoToInput={handleGoToInput}
							onGoToOutput={handleGoToOutput}
							onGoToIoExamples={handleGoToIoExamples}
						/>
					) : null}

					<AppBar position="static" className={classes.tabsAppBar}>
						<Tabs value={tabsValue} onChange={handleTabsValueChange}>
							<Tab label={translations.tests.testOverview} value="overview" />
							<Tab label={translations.tests.testIlSources} value="il-sources" />
							<Tab label={translations.tests.testExe} value="exe" />
							<Tab label={translations.tests.testIO} value="io" />
						</Tabs>
					</AppBar>

					{tabsValue === 'overview' ? (
						<div className={classes.tabContainer}>
							<CilDetailsRow label={translations.tests.testCategory}>
								<CilEditTestCategorySelect
									categories={categories}
									test={test}
									onCategoryUpdated={handleCategoryUpdated}
									isEditable={categories.length > 0}
								/>
							</CilDetailsRow>
							<CilDetailsRow label={translations.tests.testSubcategory}>
								<CilEditTestSubcategorySelect
									subcategories={subcategories}
									test={test}
									onSubcategoryUpdated={handleSubcategoryUpdated}
									isEditable={subcategories.length > 0}
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
							{test.hasIlSources ? <CilCodeEditor code={test.mainIlSource} /> : null}
						</div>
					) : null}

					{tabsValue === 'exe' ? (
						<div className={classes.tabContainer}>
							<CilDetailsRow label={translations.tests.testExe}>
								<CilDetailsValue value={test.exePath} prefix="..." />
								<CilGenerateTestExeButton test={test} onExeGenerated={handleExeGenerated} />
								<CilRunTestExeButton type="icon-button" test={test} />
							</CilDetailsRow>
							{test.generateExeOutput ? <CilCodeEditor code={test.generateExeOutput} /> : null}
						</div>
					) : null}

					{tabsValue === 'io' ? (
						<div className={ioTabContainerClassName}>
							<div className={classes.ioTabIo}>
								<div>
									<CilTestInputEditor test={test} onInputUpdated={handleInputUpdated} />
								</div>
								<div>
									<CilTestOutputEditor test={test} onOutputUpdated={handleOutputUpdated} />
								</div>
							</div>
							{test.hasInput && test.hasOutput && test.hasExe ? (
								<>
									<Divider className={classes.ioDivider} />
									<div className={classes.ioTabExamples}>
										<CilTestInputOutputExamplesEditor test={test} onExampleAdded={handleIoExampleAdded} />
									</div>
								</>
							) : null}
						</div>
					) : null}
				</>
			) : null}
		</CilPage>
	);
};

export default CilShowTestPage;
