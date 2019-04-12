import classNames from 'classnames';
import React, { FunctionComponent, ReactNode } from 'react';

import { Avatar, Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import CilPageSubheader from './CilPageSubheader';

const useStyles = makeStyles((theme: Theme) => ({
	pageHeader: {
		marginBottom: '1.5rem',
		position: 'sticky',
		top: 0,
		backgroundColor: theme.palette.background.default,
		zIndex: theme.zIndex.appBar
	},
	headerWrapper: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		'&>*': {
			marginRight: '10px'
		}
	},
	textTypography: {
		marginBottom: 0
	}
}));

interface CilPageHeaderProps {
	text: string;
	subtext?: string;
	textClassName?: string;
	avatarIcon?: ReactNode;
}

const CilPageHeader: FunctionComponent<CilPageHeaderProps> = props => {
	const classes = useStyles();

	const textClassName = classNames(classes.textTypography, props.textClassName);

	return (
		<div className={classes.pageHeader}>
			<div className={classes.headerWrapper}>
				{props.avatarIcon ? <Avatar>{props.avatarIcon}</Avatar> : null}
				<Typography variant="h1" className={textClassName}>
					{props.text}
				</Typography>
				{props.children}
			</div>
			{props.subtext ? <CilPageSubheader text={props.subtext} /> : null}
		</div>
	);
};

export default CilPageHeader;
