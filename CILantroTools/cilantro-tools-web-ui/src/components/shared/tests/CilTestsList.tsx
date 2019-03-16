import React, { FunctionComponent } from 'react';

import { Typography } from '@material-ui/core';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import translations from '../../../translations/translations';
import CilCardList from '../../utils/CilCardList';
import CiLTestCard from './CilTestCard';

interface CilTestsListProps {
	tests: TestReadModel[];
}

const CilTestsList: FunctionComponent<CilTestsListProps> = props => {
	return props.tests.length > 0 ? (
		<CilCardList>
			{props.tests.map(test => (
				<CiLTestCard key={test.id} test={test} />
			))}
		</CilCardList>
	) : (
		<Typography variant="h2" align="center">
			{translations.tests.noTests}
		</Typography>
	);
};

export default CilTestsList;
