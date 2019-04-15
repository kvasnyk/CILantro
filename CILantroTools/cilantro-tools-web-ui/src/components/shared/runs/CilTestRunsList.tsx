import React, { FunctionComponent, useState } from 'react';

import TestRunReadModel from '../../../api/read-models/runs/TestRunReadModel';
import CilCardList from '../../utils/CilCardList';
import CilTestRunCard from './CilTestRunCard';

interface CilTestRunsListProps {
	testRuns: TestRunReadModel[];
}

const CilTestRunsList: FunctionComponent<CilTestRunsListProps> = props => {
	const [openTestRunId, setOpenTestCard] = useState<string | undefined>(undefined);

	const handleExpandButtonClick = (testRunId: string) => {
		setOpenTestCard(prevOpenTestCard => (prevOpenTestCard === testRunId ? undefined : testRunId));
	};

	return (
		<CilCardList>
			{props.testRuns.map(testRun => (
				<CilTestRunCard
					key={testRun.id}
					testRun={testRun}
					onExpandButtonClick={handleExpandButtonClick}
					isExpanded={testRun.id === openTestRunId}
				/>
			))}
		</CilCardList>
	);
};

export default CilTestRunsList;
