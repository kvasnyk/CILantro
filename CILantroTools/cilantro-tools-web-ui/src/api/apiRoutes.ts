const apiRoutes = {
	categories: {
		addCategory: '/categories/add',
		addSubcategory: '/categories/add-subcategory',
		searchCategories: '/categories/search'
	},

	tests: {
		createFromCandidate: '/tests/create-from-candidate',
		findTests: '/tests/find',
		getTest: (testId: string) => `/tests/${testId}`,
		searchTests: '/tests/search'
	}
};

export default apiRoutes;
