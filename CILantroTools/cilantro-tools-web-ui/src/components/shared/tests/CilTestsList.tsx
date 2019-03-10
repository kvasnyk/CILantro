import React, { FunctionComponent } from 'react';

import { Typography } from '@material-ui/core';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import translations from '../../../translations/translations';
import CilGridLayout from '../../layouts/CilGridLayout';
import CiLTestCard from './CilTestCard';

interface CilTestsListProps {
	tests: TestReadModel[];
}

const CilTestsList: FunctionComponent<CilTestsListProps> = props => {
	return props.tests.length > 0 ? (
		<CilGridLayout columns={3}>
			{props.tests.map(test => (
				<CiLTestCard key={test.id} test={test} />
			))}
		</CilGridLayout>
	) : (
		<Typography variant="h2" align="center">
			{translations.tests.noTests}
		</Typography>
	);
};

export default CilTestsList;
