import React, { FunctionComponent, useState } from 'react';

import { Fab, Theme } from '@material-ui/core';
import orange from '@material-ui/core/colors/orange';
import PlayArrowIcon from '@material-ui/icons/PlayArrowRounded';
import { makeStyles } from '@material-ui/styles';

import TestInfo from '../../../api/models/tests/TestInfo';
import CilIconButton from '../../utils/CilIconButton';
import CilExecuteTestBothDialog from './CilExecuteTestBothDialog';

type CilRunTestBothButtonType = 'icon-button' | 'fab';

const useStyles = makeStyles((theme: Theme) => ({
	fab: {
		background: `linear-gradient(to right, ${theme.palette.primary.main} 0%, ${theme.palette.primary.main} 50%, ${
			orange[500]
		} 50%, ${orange[500]} 100%)`,
		color: theme.palette.common.white,
		'&:hover': {
			background: `linear-gradient(to right, ${theme.palette.primary.dark} 0%, ${theme.palette.primary.dark} 50%, ${
				orange[700]
			} 50%, ${orange[700]} 100%)`
		}
	}
}));

interface CilRunTestBothButtonProps {
	testInfo: TestInfo;
	type: CilRunTestBothButtonType;
}

const CilRunTestBothButton: FunctionComponent<CilRunTestBothButtonProps> = props => {
	const classes = useStyles();

	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);

	const handleClick = () => {
		setIsDialogOpen(true);
		return Promise.resolve();
	};

	const handleDialogClose = () => {
		setIsDialogOpen(false);
	};

	return props.testInfo.test.hasIlSources && props.testInfo.test.hasExe ? (
		<>
			{props.type === 'icon-button' ? (
				<CilIconButton onClick={handleClick}>
					<PlayArrowIcon />
				</CilIconButton>
			) : (
				<Fab onClick={handleClick} className={classes.fab}>
					<PlayArrowIcon />
				</Fab>
			)}
			{isDialogOpen ? <CilExecuteTestBothDialog onClose={handleDialogClose} testInfo={props.testInfo} /> : null}
		</>
	) : null;
};

export default CilRunTestBothButton;
