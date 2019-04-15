import React, { FunctionComponent } from 'react';
import { Link } from 'react-router-dom';

import CodeIcon from '@material-ui/icons/CodeRounded';
import ShowIcon from '@material-ui/icons/RemoveRedEyeRounded';

import routes from '../../../routing/routes';
import CilIconButton from '../../utils/CilIconButton';

interface CilShowTestButtonProps {
	testId: string;
	iconClassName?: string;
	icon: 'show' | 'code';
}

const CilShowTestButton: FunctionComponent<CilShowTestButtonProps> = props => {
	const handleClick = () => {
		return Promise.resolve();
	};

	return (
		<Link to={routes.tests.test({ testId: props.testId })}>
			<CilIconButton onClick={handleClick}>
				{props.icon === 'show' ? (
					<ShowIcon className={props.iconClassName} />
				) : (
					<CodeIcon className={props.iconClassName} />
				)}
			</CilIconButton>
		</Link>
	);
};

export default CilShowTestButton;
