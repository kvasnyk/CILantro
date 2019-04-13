import React, { FunctionComponent } from 'react';
import { Link } from 'react-router-dom';

import ShowIcon from '@material-ui/icons/RemoveRedEyeRounded';

import routes from '../../../routing/routes';
import CilIconButton from '../../utils/CilIconButton';

interface CilShowTestButtonProps {
	testId: string;
	iconClassName?: string;
}

const CilShowTestButton: FunctionComponent<CilShowTestButtonProps> = props => {
	const handleClick = () => {
		return Promise.resolve();
	};

	return (
		<Link to={routes.tests.test({ testId: props.testId })}>
			<CilIconButton onClick={handleClick}>
				<ShowIcon className={props.iconClassName} />
			</CilIconButton>
		</Link>
	);
};

export default CilShowTestButton;
