import { SnackbarProvider } from 'notistack';
import React, { FunctionComponent } from 'react';

import { createMuiTheme, Theme } from '@material-ui/core';
import { makeStyles, ThemeProvider } from '@material-ui/styles';

import CilAppBar from './CilAppBar';
import CilAppContent from './CilAppContent';
import CilMenu from './CilMenu';

const appTheme = createMuiTheme({
	typography: {
		useNextVariants: true,
		h1: {
			fontSize: '3rem',
			fontWeight: 400,
			marginBottom: '10px'
		},
		h2: {
			fontSize: '2rem',
			fontWeight: 400,
			wordBreak: 'break-all',
			marginBottom: '10px'
		},
		h3: {
			fontSize: '1.5rem'
		},
		h4: {
			fontSize: '1rem'
		},
		subtitle1: {
			fontSize: '0.8rem',
			fontStyle: 'italic',
			wordBreak: 'break-all'
		}
	},
	zIndex: {
		appBar: 1200,
		drawer: 1100
	}
});

const useStyles = makeStyles((theme: Theme) => ({
	root: {
		display: 'flex',
		height: '100vh',
		margin: 0,
		padding: 0,
		overflow: 'hidden'
	}
}));

const CilApp: FunctionComponent = props => {
	const classes = useStyles();

	return (
		<ThemeProvider theme={appTheme}>
			<SnackbarProvider maxSnack={10} anchorOrigin={{ horizontal: 'right', vertical: 'bottom' }}>
				<div className={classes.root}>
					<CilAppBar />
					<CilMenu />
					<CilAppContent />
				</div>
			</SnackbarProvider>
		</ThemeProvider>
	);
};

export default CilApp;
