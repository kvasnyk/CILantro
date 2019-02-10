import React, { FunctionComponent } from 'react';
import { Link } from 'react-router-dom';

import { IconButton } from '@material-ui/core';
import ShowIcon from '@material-ui/icons/RemoveRedEyeRounded';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import routes from '../../../routing/routes';

interface CilShowTestButtonProps {
	test: TestReadModel;
}

const CilShowTestButton: FunctionComponent<CilShowTestButtonProps> = props => {
	return (
		<Link to={routes.tests.test({ testId: props.test.id })}>
			<IconButton>
				<ShowIcon />
			</IconButton>
		</Link>
	);
};

export default CilShowTestButton;
