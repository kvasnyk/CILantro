export interface TestRouteData {
	isTemplate?: boolean;
	testId?: string;
}

export interface RunRouteData {
	isTemplate?: boolean;
	runId?: string;
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
		runs: '/runs',
		run: (data: RunRouteData) => (data.isTemplate ? '/runs/:runId' : `/runs/${data.runId}`)
	}
};

export default routes;
