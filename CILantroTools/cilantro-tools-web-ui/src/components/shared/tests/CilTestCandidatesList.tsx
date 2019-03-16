import React, { FunctionComponent } from 'react';

import { Typography } from '@material-ui/core';

import TestCandidate from '../../../api/models/tests/TestCandidate';
import translations from '../../../translations/translations';
import CilCardList from '../../utils/CilCardList';
import CilTestCandidateCard from './CilTestCandidateCard';

interface CilTestCandidatesListProps {
	testCandidates: TestCandidate[];
	onTestCreated: () => void;
}

const CilTestCandidatesList: FunctionComponent<CilTestCandidatesListProps> = props => {
	return props.testCandidates.length > 0 ? (
		<CilCardList>
			{props.testCandidates.map(tc => (
				<CilTestCandidateCard key={tc.name} testCandidate={tc} onTestCreated={props.onTestCreated} />
			))}
		</CilCardList>
	) : (
		<Typography variant="h2" align="center">
			{translations.tests.noTestCandidates}
		</Typography>
	);
};

export default CilTestCandidatesList;
