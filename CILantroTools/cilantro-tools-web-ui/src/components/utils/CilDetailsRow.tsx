import React, { FunctionComponent } from 'react';

import { Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

const useStyles = makeStyles((theme: Theme) => ({
	detailsRow: {
		width: '100%',
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'center',
		height: '50px'
	},
	detailsLabel: {
		width: '200px',
		flexBasis: 'auto'
	},
	detailsLabelTypography: {
		fontSize: '1rem',
		fontWeight: 500
	},
	detailsContent: {
		flexGrow: 1,
		flexBasis: 0,
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center'
	}
}));

interface CilDetailsRowProps {
	label: string;
}

const CilDetailsRow: FunctionComponent<CilDetailsRowProps> = props => {
	const classes = useStyles();

	return (
		<div className={classes.detailsRow}>
			<div className={classes.detailsLabel}>
				<Typography className={classes.detailsLabelTypography}>{props.label}</Typography>
			</div>
			<div className={classes.detailsContent}>{props.children}</div>
		</div>
	);
};

export default CilDetailsRow;
