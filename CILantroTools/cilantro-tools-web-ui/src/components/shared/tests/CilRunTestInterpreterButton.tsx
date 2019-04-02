import React, { FunctionComponent, useState } from 'react';

import { Fab, Theme } from '@material-ui/core';
import orange from '@material-ui/core/colors/orange';
import PlayArrowIcon from '@material-ui/icons/PlayArrowRounded';
import { makeStyles } from '@material-ui/styles';

import TestInfo from '../../../api/models/tests/TestInfo';
import CilIconButton from '../../utils/CilIconButton';
import CilExecuteTestDialog from './CilExecuteTestDialog';

const useStyles = makeStyles((theme: Theme) => ({
	button: {
		backgroundColor: orange[500],
		color: theme.palette.common.white,
		'&:hover': {
			backgroundColor: orange[700]
		}
	}
}));

type CilRunTestInterpreterButtonType = 'icon-button' | 'fab';

interface CilRunTestInterpreterButtonProps {
	testInfo: TestInfo;
	type: CilRunTestInterpreterButtonType;
}

const CilRunTestInterpreterButton: FunctionComponent<CilRunTestInterpreterButtonProps> = props => {
	const classes = useStyles();

	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);

	const handleClick = () => {
		setIsDialogOpen(true);
		return Promise.resolve();
	};

	const handleDialogClose = () => {
		setIsDialogOpen(false);
	};

	return props.testInfo.test.hasIlSources ? (
		<>
			{props.type === 'icon-button' ? (
				<CilIconButton onClick={handleClick}>
					<PlayArrowIcon />
				</CilIconButton>
			) : (
				<Fab onClick={handleClick} className={classes.button}>
					<PlayArrowIcon />
				</Fab>
			)}
			{isDialogOpen ? (
				<CilExecuteTestDialog
					executionType="cilantro-interpreter"
					onClose={handleDialogClose}
					testInfo={props.testInfo}
				/>
			) : null}
		</>
	) : null;
};

export default CilRunTestInterpreterButton;
