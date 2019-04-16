import React, { FunctionComponent, useState } from 'react';

import { AppBar, Dialog, DialogContent, Theme, Toolbar, Typography } from '@material-ui/core';
import CloseIcon from '@material-ui/icons/CloseRounded';
import ShowIcon from '@material-ui/icons/RemoveRedEyeRounded';
import { makeStyles } from '@material-ui/styles';

import TestInfo from '../../../api/models/tests/TestInfo';
import CilCodeEditor from '../../utils/CilCodeEditor';
import CilIconButton from '../../utils/CilIconButton';

const useStyles = makeStyles((theme: Theme) => ({
	appBarIcon: {
		fill: theme.palette.primary.contrastText
	},
	dialogContent: {
		display: 'flex',
		flexDirection: 'column',
		alignItems: 'center',
		justifyContent: 'center'
	},
	toolbar: {
		display: 'flex'
	},
	fakeToolbar: {
		...theme.mixins.toolbar,
		marginBottom: '24px'
	},
	toolbarLeft: {
		flexGrow: 1,
		flexBasis: 0,
		display: 'flex',
		alignItems: 'center'
	},
	toolbarRight: {
		flexGrow: 1,
		flexBasis: 0,
		display: 'flex',
		justifyContent: 'flex-end'
	}
}));

interface CilShowIlSourcesButtonProps {
	testInfo: TestInfo;
}

const CilShowIlSourcesButton: FunctionComponent<CilShowIlSourcesButtonProps> = props => {
	const classes = useStyles();

	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);

	const handleClick = () => {
		setIsDialogOpen(true);
		return Promise.resolve();
	};

	const handleCloseButtonClick = () => {
		setIsDialogOpen(false);
		return Promise.resolve();
	};

	const handleDialogClose = () => {
		setIsDialogOpen(false);
		return Promise.resolve();
	};

	return (
		<>
			<CilIconButton onClick={handleClick}>
				<ShowIcon fontSize="small" />
			</CilIconButton>
			<Dialog open={isDialogOpen} fullScreen={true} onClose={handleDialogClose}>
				<AppBar>
					<Toolbar className={classes.toolbar}>
						<div className={classes.toolbarLeft}>
							<Typography variant="h6" color="inherit">
								{props.testInfo.test.name}
							</Typography>
						</div>
						<div className={classes.toolbarRight}>
							<CilIconButton onClick={handleCloseButtonClick}>
								<CloseIcon className={classes.appBarIcon} />
							</CilIconButton>
						</div>
					</Toolbar>
				</AppBar>
				<DialogContent className={classes.dialogContent}>
					<div className={classes.fakeToolbar} />
					<CilCodeEditor code={props.testInfo.mainIlSource} />
				</DialogContent>
			</Dialog>
		</>
	);
};

export default CilShowIlSourcesButton;
