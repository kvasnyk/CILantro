import classNames from 'classnames';
import React, { ChangeEvent, FunctionComponent, useEffect, useState } from 'react';
import { RouteComponentProps, withRouter } from 'react-router-dom';

import { AppBar, Divider, Tab, Tabs, Theme } from '@material-ui/core';
import { green, red } from '@material-ui/core/colors';
import CheckIcon from '@material-ui/icons/CheckRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import { makeStyles } from '@material-ui/styles';

import CategoriesApiClient from '../../api/clients/CategoriesApiClient';
import TestsApiClient from '../../api/clients/TestsApiClient';
import RunOutcome from '../../api/enums/RunOutcome';
import RunType from '../../api/enums/RunType';
import TestInfo from '../../api/models/tests/TestInfo';
import CategoryReadModel from '../../api/read-models/categories/CategoryReadModel';
import SearchDirection from '../../api/search/SearchDirection';
import routes from '../../routing/routes';
import translations from '../../translations/translations';
import CilPage, { PageState } from '../base/CilPage';
import CilAddRunButton from '../shared/runs/CilAddRunButton';
import CilDisableTestButton from '../shared/tests/CilDisableTestButton';
import CilEditTestCategorySelect from '../shared/tests/CilEditTestCategorySelect';
import CilEditTestDisabledReasonTextField from '../shared/tests/CilEditTestDisabledReasonTextField';
import CilEditTestSubcategorySelect from '../shared/tests/CilEditTestSubcategorySelect';
import CilEnableTestButton from '../shared/tests/CilEnableTestButton';
import CilGenerateTestExeButton from '../shared/tests/CilGenerateTestExeButton';
import CilGenerateTestIlSourcesButton from '../shared/tests/CilGenerateTestIlSourcesButton';
import CilRunTestBothButton from '../shared/tests/CilRunTestBothButton';
import CilRunTestExeButton from '../shared/tests/CilRunTestExeButton';
import CilRunTestInterpreterButton from '../shared/tests/CilRunTestInterpreterButton';
import CilShowIlSourcesButton from '../shared/tests/CilShowIlSourcesButton';
import CilTestChecklist from '../shared/tests/CilTestChecklist';
import CilTestInputEditor from '../shared/tests/CilTestInputEditor';
import CilTestInputOutputExamplesEditor from '../shared/tests/CilTestInputOutputExamplesEditor';
import CilCodeEditor from '../utils/CilCodeEditor';
import CilDetailsRow from '../utils/CilDetailsRow';
import CilDetailsValue from '../utils/CilDetailsValue';
import CilPageHeader from '../utils/CilPageHeader';

const useStyles = makeStyles((theme: Theme) => ({
	lastRunOkIcon: {
		color: green[700],
		fontSize: '4rem'
	},
	lastRunWrongIcon: {
		color: red[700],
		fontSize: '4rem'
	},
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

interface CilShowTestPageOwnProps {
	testId: string;
}

type TabsValue = 'overview' | 'il-sources' | 'exe' | 'io';

type CilShowTestPageProps = CilShowTestPageOwnProps & RouteComponentProps<{}>;

const CilShowTestPage: FunctionComponent<CilShowTestPageProps> = props => {
	const classes = useStyles();

	const testsApiClient = new TestsApiClient();
	const categoriesApiClient = new CategoriesApiClient();

	const [pageState, setPageState] = useState<PageState>('loading');
	const [testInfo, setTestInfo] = useState<TestInfo | undefined>(undefined);
	const [tabsValue, setTabsValue] = useState<TabsValue>('overview');
	const [categories, setCategories] = useState<CategoryReadModel[] | undefined>(undefined);

	const subcategories = testInfo && testInfo.test.category ? testInfo.test.category.subcategories : [];

	const refreshTest = async () => {
		try {
			const getTestResponse = await testsApiClient.getTestInfo(props.testId);
			setTestInfo(getTestResponse.data);
		} catch (error) {
			setPageState('error');
			throw error;
		}
	};

	const refreshCategories = async () => {
		try {
			const searchCategoriesResponse = await categoriesApiClient.searchCategories({
				orderBy: {
					property: 'name',
					direction: SearchDirection.Asc
				},
				pageSize: 1000000,
				pageNumber: 1,
				filters: []
			});
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

	const handleIlSourcesGenerated = () => {
		refreshTest();
	};

	const handleExeGenerated = () => {
		refreshTest();
	};

	const handleIoExampleAdded = () => {
		refreshTest();
	};

	const handleTestDisabled = () => {
		refreshTest();
	};

	const handleTestEnabled = () => {
		refreshTest();
	};

	const handleDisabledReasonUpdated = () => {
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

	const handleRunAdded = () => {
		props.history.push(routes.runs.runs);
	};

	return (
		<CilPage state={pageState}>
			{testInfo && categories ? (
				<>
					<CilPageHeader text={testInfo.test.name} subtext={`...${testInfo.test.path}`}>
						{testInfo.test.lastRunOutcome === RunOutcome.Ok ? <CheckIcon className={classes.lastRunOkIcon} /> : null}
						{testInfo.test.lastRunOutcome === RunOutcome.Wrong ? (
							<NotCheckIcon className={classes.lastRunWrongIcon} />
						) : null}
						<CilRunTestExeButton type="fab" testInfo={testInfo} />
						<CilRunTestBothButton type="fab" testInfo={testInfo} />
						<CilRunTestInterpreterButton type="fab" testInfo={testInfo} />
						{testInfo.test.isReady ? (
							<CilAddRunButton type={RunType.Quick} testId={props.testId} onRunAdded={handleRunAdded} />
						) : null}
						{testInfo.test.isReady ? (
							<CilAddRunButton type={RunType.Full} testId={props.testId} onRunAdded={handleRunAdded} />
						) : null}
						{!testInfo.test.isDisabled ? (
							<CilDisableTestButton testInfo={testInfo} onTestDisabled={handleTestDisabled} />
						) : null}
						{testInfo.test.isDisabled ? (
							<CilEnableTestButton testInfo={testInfo} onTestEnabled={handleTestEnabled} />
						) : null}
					</CilPageHeader>

					{!testInfo.test.isReady && !testInfo.test.isDisabled ? (
						<CilTestChecklist
							test={testInfo.test}
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
									test={testInfo.test}
									onCategoryUpdated={handleCategoryUpdated}
									isEditable={categories.length > 0}
								/>
							</CilDetailsRow>
							<CilDetailsRow label={translations.tests.testSubcategory}>
								<CilEditTestSubcategorySelect
									subcategories={subcategories}
									test={testInfo.test}
									onSubcategoryUpdated={handleSubcategoryUpdated}
									isEditable={subcategories.length > 0}
								/>
							</CilDetailsRow>
							{testInfo.test.isDisabled ? (
								<CilDetailsRow label={translations.tests.disabledReason}>
									<CilEditTestDisabledReasonTextField
										testInfo={testInfo}
										onDisabledReasonUpdated={handleDisabledReasonUpdated}
									/>
								</CilDetailsRow>
							) : null}
						</div>
					) : null}

					{tabsValue === 'il-sources' ? (
						<div className={classes.tabContainer}>
							<CilDetailsRow label={translations.tests.testMainIlSource}>
								{testInfo.test.hasIlSources ? <CilDetailsValue value={testInfo.mainIlSourcePath} prefix="..." /> : null}
								<CilGenerateTestIlSourcesButton test={testInfo.test} onIlSourcesGenerated={handleIlSourcesGenerated} />
								{testInfo.test.hasIlSources ? <CilShowIlSourcesButton testInfo={testInfo} /> : null}
							</CilDetailsRow>
							{testInfo.test.hasIlSources ? <CilCodeEditor code={testInfo.mainIlSource} /> : null}
						</div>
					) : null}

					{tabsValue === 'exe' ? (
						<div className={classes.tabContainer}>
							<CilDetailsRow label={translations.tests.testExe}>
								{testInfo.test.hasExe ? <CilDetailsValue value={testInfo.exePath} prefix="..." /> : null}
								<CilGenerateTestExeButton test={testInfo.test} onExeGenerated={handleExeGenerated} />
								<CilRunTestExeButton type="icon-button" testInfo={testInfo} />
							</CilDetailsRow>
							{testInfo.test.generateExeOutput ? <CilCodeEditor code={testInfo.test.generateExeOutput} /> : null}
						</div>
					) : null}

					{tabsValue === 'io' ? (
						<div className={ioTabContainerClassName}>
							<div className={classes.ioTabIo}>
								<div>
									<CilTestInputEditor test={testInfo.test} onInputUpdated={handleInputUpdated} />
								</div>
							</div>
							{testInfo.test.hasInput && testInfo.test.hasExe ? (
								<>
									<Divider className={classes.ioDivider} />
									<div className={classes.ioTabExamples}>
										<CilTestInputOutputExamplesEditor test={testInfo.test} onExampleAdded={handleIoExampleAdded} />
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

export default withRouter(CilShowTestPage);
