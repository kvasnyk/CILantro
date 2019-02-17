import React, { FunctionComponent, useState } from 'react';

import { Fab, IconButton, Theme } from '@material-ui/core';
import orange from '@material-ui/core/colors/orange';
import PlayArrowIcon from '@material-ui/icons/PlayArrowRounded';
import { makeStyles } from '@material-ui/styles';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
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
	test: TestReadModel;
	type: CilRunTestInterpreterButtonType;
}

const CilRunTestInterpreterButton: FunctionComponent<CilRunTestInterpreterButtonProps> = props => {
	const classes = useStyles();

	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);

	const handleClick = () => {
		setIsDialogOpen(true);
	};

	const handleDialogClose = () => {
		setIsDialogOpen(false);
	};

	return props.test.hasIlSources ? (
		<>
			{props.type === 'icon-button' ? (
				<IconButton onClick={handleClick}>
					<PlayArrowIcon />
				</IconButton>
			) : (
				<Fab onClick={handleClick} className={classes.button}>
					<PlayArrowIcon />
				</Fab>
			)}
			{isDialogOpen ? (
				<CilExecuteTestDialog executionType="cilantro-interpreter" onClose={handleDialogClose} test={props.test} />
			) : null}
		</>
	) : null;
};

export default CilRunTestInterpreterButton;
