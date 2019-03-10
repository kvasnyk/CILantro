import React, { FunctionComponent } from 'react';
import { Link } from 'react-router-dom';

import ShowIcon from '@material-ui/icons/RemoveRedEyeRounded';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import routes from '../../../routing/routes';
import CilIconButton from '../../utils/CilIconButton';

interface CilShowTestButtonProps {
	test: TestReadModel;
}

const CilShowTestButton: FunctionComponent<CilShowTestButtonProps> = props => {
	const handleClick = () => {
		return Promise.resolve();
	};

	return (
		<Link to={routes.tests.test({ testId: props.test.id })}>
			<CilIconButton onClick={handleClick}>
				<ShowIcon />
			</CilIconButton>
		</Link>
	);
};

export default CilShowTestButton;
