import React, { FunctionComponent } from 'react';

import { Typography } from '@material-ui/core';

import RunReadModel from '../../../api/read-models/runs/RunReadModel';
import translations from '../../../translations/translations';
import CilCardList from '../../utils/CilCardList';
import CilRunCard from './CilRunCard';

interface CilRunsListProps {
	runs: RunReadModel[];
	onRunDeleted: () => void;
}

const CilRunsList: FunctionComponent<CilRunsListProps> = props => {
	return props.runs.length > 0 ? (
		<CilCardList>
			{props.runs.map(run => (
				<CilRunCard key={run.id} run={run} onRunDeleted={props.onRunDeleted} />
			))}
		</CilCardList>
	) : (
		<Typography variant="h2" align="center">
			{translations.runs.noRuns}
		</Typography>
	);
};

export default CilRunsList;
