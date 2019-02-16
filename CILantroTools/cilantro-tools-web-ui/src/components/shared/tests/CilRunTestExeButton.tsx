import React, { FunctionComponent, useState } from 'react';

import { Fab, IconButton } from '@material-ui/core';
import PlayArrowIcon from '@material-ui/icons/PlayArrowRounded';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import CilRunTestExeDialog from './CilRunTestExeDialog';

type CilRunTestExeButtonType = 'icon-button' | 'fab';

interface CilRunTestExeButtonProps {
	test: TestReadModel;
	type: CilRunTestExeButtonType;
}

const CilRunTestExeButton: FunctionComponent<CilRunTestExeButtonProps> = props => {
	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);

	const handleClick = () => {
		setIsDialogOpen(true);
	};

	const handleDialogClose = () => {
		setIsDialogOpen(false);
	};

	return props.test.hasExe ? (
		<>
			{props.type === 'icon-button' ? (
				<IconButton onClick={handleClick}>
					<PlayArrowIcon />
				</IconButton>
			) : (
				<Fab onClick={handleClick} color="primary">
					<PlayArrowIcon />
				</Fab>
			)}
			{isDialogOpen ? <CilRunTestExeDialog onClose={handleDialogClose} test={props.test} /> : null}
		</>
	) : null;
};

export default CilRunTestExeButton;
