import React, { FunctionComponent, useState } from 'react';

import { IconButton } from '@material-ui/core';
import PlayArrowIcon from '@material-ui/icons/PlayArrowRounded';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import CilRunTestExeDialog from './CilRunTestExeDialog';

interface CilRunTestExeButtonProps {
	test: TestReadModel;
}

const CilRunTestExeButton: FunctionComponent<CilRunTestExeButtonProps> = props => {
	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);

	const handleClick = () => {
		setIsDialogOpen(true);
	};

	const handleDialogClose = () => {
		setIsDialogOpen(false);
	};

	return (
		<>
			<IconButton onClick={handleClick}>
				<PlayArrowIcon />
			</IconButton>
			{isDialogOpen ? <CilRunTestExeDialog onClose={handleDialogClose} test={props.test} /> : null}
		</>
	);
};

export default CilRunTestExeButton;
