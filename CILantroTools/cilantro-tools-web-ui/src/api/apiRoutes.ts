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
		getTest: (testId: string) => `/tests/${testId}`,
		searchTests: '/tests/search',
		editTestCategory: (testId: string) => `/tests/${testId}/edit-category`,
		editTestSubcategory: (testId: string) => `/tests/${testId}/edit-subcategory`,
		editTestHasEmptyInput: (testId: string) => `/tests/${testId}/edit-has-empty-input`,
		editTestInput: (testId: string) => `/tests/${testId}/edit-input`,
		editTestOutput: (testId: string) => `/tests/${testId}/edit-output`,
		generateIlSources: (testId: string) => `/tests/${testId}/generate-il-sources`,
		generateExe: (testId: string) => `/tests/${testId}/generate-exe`,
		generateOutput: (testId: string) => `/tests/${testId}/generate-output`,
		addTestInputOutputExample: (testId: string) => `/tests/${testId}/add-input-output-example`
	},

	runs: {
		addRun: '/runs/add',
		searchRuns: '/runs/search'
	}
};

export default apiRoutes;
