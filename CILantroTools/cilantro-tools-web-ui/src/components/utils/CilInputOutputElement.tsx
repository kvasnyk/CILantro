import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import { Theme } from '@material-ui/core';
import { blue } from '@material-ui/core/colors';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import ConstStringElement from '../../api/models/tests/input-output/elements/ConstStringElement';
import StringElement from '../../api/models/tests/input-output/elements/StringElement';

const useStyles = makeStyles((theme: Theme) => ({
	element: {
		padding: '5px 10px',
		marginRight: '5px',
		borderRadius: '5px',
		fontFamily: 'Consolas',
		textAlign: 'center',
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center',
		minHeight: '34px'
	},
	arguments: {
		fontSize: '0.5rem'
	},
	constElement: {
		backgroundColor: 'lightgrey',
		whiteSpace: 'pre'
	},
	stringElement: {
		backgroundColor: blue[500]
	}
}));

interface CilInputOutputElementProps {
	element: AbstractInputOutputElement;
}

const CilInputOutputElement: FunctionComponent<CilInputOutputElementProps> = props => {
	const classes = useStyles();

	const isConstStringElement = props.element.type === 'ConstString';
	const constStringElement = isConstStringElement ? (props.element as ConstStringElement) : null;

	const isStringElement = props.element.type === 'String';
	const stringElement = isStringElement ? (props.element as StringElement) : null;

	const elementClassName = classNames(classes.element, {
		[classes.constElement]: isConstStringElement,
		[classes.stringElement]: isStringElement
	});

	return (
		<div className={elementClassName}>
			{constStringElement ? <span>{constStringElement.value}</span> : null}

			{stringElement ? (
				<>
					<span>{stringElement.name}</span>
				</>
			) : null}
		</div>
	);
};

export default CilInputOutputElement;
