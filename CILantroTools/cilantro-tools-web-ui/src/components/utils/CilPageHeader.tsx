import React, { FunctionComponent } from 'react';

import { Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import CilPageSubheader from './CilPageSubheader';

const useStyles = makeStyles((theme: Theme) => ({
	pageHeader: {
		marginBottom: '1.5rem'
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
}

const CilPageHeader: FunctionComponent<CilPageHeaderProps> = props => {
	const classes = useStyles();

	return (
		<div className={classes.pageHeader}>
			<div className={classes.headerWrapper}>
				<Typography variant="h1" className={classes.textTypography}>
					{props.text}
				</Typography>
				{props.children}
			</div>
			{props.subtext ? <CilPageSubheader text={props.subtext} /> : null}
		</div>
	);
};

export default CilPageHeader;
