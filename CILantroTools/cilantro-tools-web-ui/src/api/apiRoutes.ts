const apiRoutes = {
	categories: {
		addCategory: '/categories/add',
		addSubcategory: '/categories/add-subcategory',
		deleteCategory: (categoryId: string) => `/categories/${categoryId}/delete`,
		deleteSubcategory: (categoryId: string, subcategoryId: string) =>
			`/categories/${categoryId}/subcategories/${subcategoryId}/delete`,
		searchCategories: '/categories/search'
	},

	tests: {
		createFromCandidate: '/tests/create-from-candidate',
		findTests: '/tests/find',
		checkTests: '/tests/check',
		getTest: (testId: string) => `/tests/${testId}`,
		disableTest: (testId: string) => `/tests/${testId}/disable`,
		enableTest: (testId: string) => `/tests/${testId}/enable`,
		editTestDisabledReason: (testId: string) => `/tests/${testId}/edit-disabled-reason`,
		searchTests: '/tests/search',
		editTestCategory: (testId: string) => `/tests/${testId}/edit-category`,
		editTestSubcategory: (testId: string) => `/tests/${testId}/edit-subcategory`,
		editTestHasEmptyInput: (testId: string) => `/tests/${testId}/edit-has-empty-input`,
		editTestInput: (testId: string) => `/tests/${testId}/edit-input`,
		editTestOutput: (testId: string) => `/tests/${testId}/edit-output`,
		copyTestInput: (testId: string) => `/tests/${testId}/copy-input`,
		generateIlSources: (testId: string) => `/tests/${testId}/generate-il-sources`,
		generateExe: (testId: string) => `/tests/${testId}/generate-exe`,
		generateOutput: (testId: string) => `/tests/${testId}/generate-output`,
		addTestInputOutputExample: (testId: string) => `/tests/${testId}/add-input-output-example`
	},

	runs: {
		addRun: '/runs/add',
		addSingleTestRun: '/runs/add-single',
		searchRuns: '/runs/search',
		deleteRun: (runId: string) => `/runs/${runId}/delete`,
		replayRun: (runId: string) => `/runs/${runId}/replay`,
		getRun: (runId: string) => `/runs/${runId}`,
		searchTestRuns: (runId: string) => `/runs/${runId}/test-runs/search`,
		getFullTestRun: (runId: string, testRunId: string) => `/runs/${runId}/test-runs/${testRunId}`
	}
};

export default apiRoutes;
