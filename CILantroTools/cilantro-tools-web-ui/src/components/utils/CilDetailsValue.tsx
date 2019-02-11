import React, { FunctionComponent } from 'react';

import { Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import translations from '../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
	typography: {
		fontSize: '1rem'
	}
}));

interface CilDetailsValueProps {
	value: string;
}

const CilDetailsValue: FunctionComponent<CilDetailsValueProps> = props => {
	const classes = useStyles();

	return (
		<Typography className={classes.typography}>{props.value ? props.value : translations.shared.noInfo}</Typography>
	);
};

export default CilDetailsValue;
