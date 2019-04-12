import React, { FunctionComponent } from 'react';

import TestRunReadModel from '../../../api/read-models/runs/TestRunReadModel';
import CilCardList from '../../utils/CilCardList';
import CilTestRunCard from './CilTestRunCard';

interface CilTestRunsListProps {
	testRuns: TestRunReadModel[];
}

const CilTestRunsList: FunctionComponent<CilTestRunsListProps> = props => {
	return (
		<CilCardList>
			{props.testRuns.map(testRun => (
				<CilTestRunCard key={testRun.id} testRun={testRun} />
			))}
		</CilCardList>
	);
};

export default CilTestRunsList;
