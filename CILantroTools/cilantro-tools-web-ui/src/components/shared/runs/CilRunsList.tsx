import React, { FunctionComponent } from 'react';

import { Typography } from '@material-ui/core';

import RunReadModel from '../../../api/read-models/runs/RunReadModel';
import translations from '../../../translations/translations';

interface CilRunsListProps {
	runs: RunReadModel[];
}

const CilRunsList: FunctionComponent<CilRunsListProps> = props => {
	return props.runs.length > 0 ? (
		<div>TUTAJ LISTA</div>
	) : (
		<Typography variant="h2" align="center">
			{translations.runs.noRuns}
		</Typography>
	);
};

export default CilRunsList;
