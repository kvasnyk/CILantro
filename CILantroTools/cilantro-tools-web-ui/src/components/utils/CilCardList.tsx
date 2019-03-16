import React, { Children, FunctionComponent } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

const useStyles = makeStyles((theme: Theme) => ({
	cardList: {
		margin: '0 auto',
		maxWidth: '900px'
	},
	childWrapper: {
		marginBottom: '20px'
	}
}));

const CilCardList: FunctionComponent = props => {
	const classes = useStyles();

	return (
		<div className={classes.cardList}>
			{Children.map(props.children, child => (
				<div className={classes.childWrapper}>{child}</div>
			))}
		</div>
	);
};

export default CilCardList;
