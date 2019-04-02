import translations from '../../translations/translations';

enum TestRunStep {
	GenerateInputFiles = 0,
	GenerateExeOutputFiles = 1,
	GenerateCilAntroOutputFiles = 2,
	CompareOutputFiles = 3
}

export const TestRunStepHelper = {
	getName: (step: TestRunStep) => {
		switch (step) {
			case TestRunStep.GenerateInputFiles:
				return translations.runs.testRunStep_GenerateInputFiles;
			case TestRunStep.GenerateExeOutputFiles:
				return translations.runs.testRunStep_GenerateExeOutputFiles;
			case TestRunStep.GenerateCilAntroOutputFiles:
				return translations.runs.testRunStep_GenerateCilAntroOutputFiles;
			case TestRunStep.CompareOutputFiles:
				return translations.runs.testRunStep_CompareOutputFiles;
		}
	}
};

export default TestRunStep;
