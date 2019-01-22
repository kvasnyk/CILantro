const apiRoutes = {
  tests: {
    createFromCandidate: '/tests/create-from-candidate',
    findTests: '/tests/find',
    getTest: (testId: string) => `/tests/{testId}`,
    searchTests: '/tests/search'
  }
};

export default apiRoutes;
