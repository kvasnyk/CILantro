import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import ConstStringElement from '../../api/models/tests/input-output/elements/ConstStringElement';

const useStyles = makeStyles((theme: Theme) => ({
	element: {
		padding: '5px 10px',
		marginRight: '5px',
		borderRadius: '5px',
		fontFamily: 'Consolas',
		textAlign: 'center'
	},
	constElement: {
		backgroundColor: 'lightgrey',
		fontStyle: 'italic'
	}
}));

interface CilInputOutputElementProps {
	element: AbstractInputOutputElement;
}

const CilInputOutputElement: FunctionComponent<CilInputOutputElementProps> = props => {
	const classes = useStyles();

	const isConstStringElement = props.element instanceof ConstStringElement;
	const constStringElement = isConstStringElement ? (props.element as ConstStringElement) : null;

	const elementClassName = classNames(classes.element, {
		[classes.constElement]: isConstStringElement
	});

	return <div className={elementClassName}>{constStringElement ? <span>{constStringElement.value}</span> : null}</div>;
};

export default CilInputOutputElement;
