import React, { FunctionComponent } from 'react';
import { Link } from 'react-router-dom';

import ShowIcon from '@material-ui/icons/RemoveRedEyeRounded';

import RunReadModel from '../../../api/read-models/runs/RunReadModel';
import routes from '../../../routing/routes';
import CilIconButton from '../../utils/CilIconButton';

interface CilShowRunButtonProps {
	run: RunReadModel;
	iconClassName?: string;
}

const CilShowRunButton: FunctionComponent<CilShowRunButtonProps> = props => {
	const handleClick = () => {
		return Promise.resolve();
	};

	return (
		<Link to={routes.runs.run({ runId: props.run.id })}>
			<CilIconButton onClick={handleClick}>
				<ShowIcon className={props.iconClassName} />
			</CilIconButton>
		</Link>
	);
};

export default CilShowRunButton;
