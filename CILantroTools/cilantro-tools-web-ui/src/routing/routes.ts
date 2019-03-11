export interface TestRouteData {
	isTemplate?: boolean;
	testId?: string;
}

const routes = {
	root: '/',
	categories: {
		categories: '/categories'
	},
	tests: {
		find: '/find-tests',
		tests: '/tests',
		test: (data: TestRouteData) => (data.isTemplate ? '/tests/:testId' : `/tests/${data.testId}`)
	},
	runs: {
		runs: '/runs'
	}
};

export default routes;
