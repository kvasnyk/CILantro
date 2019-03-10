import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

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
	}
}));

interface CilPageProps {
	state: PageState;
	centerChildren?: boolean;
	className?: string;
}

const CilPage: FunctionComponent<CilPageProps> = props => {
	const classes = useStyles();

	const pageClassName = classNames(classes.page, props.className);

	const pageContentClassName = classNames(classes.pageContent, {
		[classes.centerContainer]: props.centerChildren
	});

	return (
		<div className={pageClassName}>
			{props.state === 'loading' ? <CilLoading /> : undefined}

			{props.state === 'success' ? (
				<>
					<div className={pageContentClassName}>{props.children}</div>
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
