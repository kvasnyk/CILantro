import classNames from 'classnames';
import React, { StatelessComponent } from 'react';

import { Theme, Typography } from '@material-ui/core';
import ErrorIcon from '@material-ui/icons/ErrorOutlineOutlined';
import { makeStyles } from '@material-ui/styles';

import translations from '../../translations/translations';
import CilLoading from '../utils/CilLoading';

export type PageState = 'loading' | 'success' | 'error';

const useStyles = makeStyles((theme: Theme) => ({
	page: {
		position: 'relative',
		width: '100%',
		display: 'flex',
		flexDirection: 'column'
	},
	pageWithMenu: {
		height: '100%',
		overflow: 'hidden'
	},
	pageContent: {
		height: '100%',
		overflow: 'auto'
	},
	centerContainer: {
		display: 'flex',
		width: '100%',
		height: '100%',
		flexDirection: 'column',
		alignItems: 'center',
		justifyContent: 'center'
	},
	errorIcon: {
		fontSize: '15rem'
	},
	menu: {
		height: theme.spacing.unit * 10,
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'center',
		marginTop: theme.spacing.unit + 2
	}
}));

interface CilPageProps {
	state: PageState;
	centerChildren?: boolean;
	menu?: React.ReactNode;
}

const CilPage: StatelessComponent<CilPageProps> = props => {
	const classes = useStyles();

	const pageContentClassName = classNames(classes.pageContent, {
		[classes.centerContainer]: props.centerChildren
	});

	return (
		<div className={classes.page}>
			{props.state === 'loading' ? <CilLoading /> : undefined}

			{props.state === 'success' ? (
				<>
					<div className={pageContentClassName}>{props.children}</div>

					{props.menu ? <div className={classes.menu}>{props.menu}</div> : undefined}
				</>
			) : (
				undefined
			)}

			{props.state === 'error' ? (
				<div className={classes.centerContainer}>
					<ErrorIcon color="error" className={classes.errorIcon} />
					<Typography color="error" variant="h2">
						{translations.shared.anErrorOccurred}
					</Typography>
				</div>
			) : (
				undefined
			)}
		</div>
	);
};

export default CilPage;
