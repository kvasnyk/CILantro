import React, { FunctionComponent, useState } from 'react';

import { Fab } from '@material-ui/core';
import PlayArrowIcon from '@material-ui/icons/PlayArrowRounded';

import TestInfo from '../../../api/models/tests/TestInfo';
import CilIconButton from '../../utils/CilIconButton';
import CilExecuteTestDialog from './CilExecuteTestDialog';

type CilRunTestExeButtonType = 'icon-button' | 'fab';

interface CilRunTestExeButtonProps {
	testInfo: TestInfo;
	type: CilRunTestExeButtonType;
}

const CilRunTestExeButton: FunctionComponent<CilRunTestExeButtonProps> = props => {
	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);

	const handleClick = () => {
		setIsDialogOpen(true);
		return Promise.resolve();
	};

	const handleDialogClose = () => {
		setIsDialogOpen(false);
	};

	return props.testInfo.test.hasExe ? (
		<>
			{props.type === 'icon-button' ? (
				<CilIconButton onClick={handleClick}>
					<PlayArrowIcon />
				</CilIconButton>
			) : (
				<Fab onClick={handleClick} color="primary">
					<PlayArrowIcon />
				</Fab>
			)}
			{isDialogOpen ? (
				<CilExecuteTestDialog executionType="exe" onClose={handleDialogClose} testInfo={props.testInfo} />
			) : null}
		</>
	) : null;
};

export default CilRunTestExeButton;
