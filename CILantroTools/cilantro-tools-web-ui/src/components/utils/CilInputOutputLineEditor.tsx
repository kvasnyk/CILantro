import React, { FunctionComponent } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import InputOutputLine from '../../api/models/tests/input-output/InputOutputLine';
import CilAddInputOutputElementButton from './CilAddInputOutputElementButton';
import CilInputOutputElement from './CilInputOutputElement';

const useStyles = makeStyles((theme: Theme) => ({
	inputOutputLine: {
		display: 'flex',
		flexDirection: 'row',
		backgroundColor: '#eaeaea',
		padding: '5px',
		borderRadius: '5px'
	}
}));

interface CilInputOutputLineEditorProps {
	variant: 'input' | 'output';
	lineIndex: number;
	line: InputOutputLine;
	onElementAdded: (lineIndex: number, element: AbstractInputOutputElement) => void;
	isReadonly?: boolean;
}

const CilInputOutputLineEditor: FunctionComponent<CilInputOutputLineEditorProps> = props => {
	const classes = useStyles();

	const handleElementAdded = (element: AbstractInputOutputElement) => {
		props.onElementAdded(props.lineIndex, element);
	};

	return (
		<div className={classes.inputOutputLine}>
			{props.line.elements.map((element, index) => (
				<CilInputOutputElement key={index} variant={props.variant} element={element} />
			))}

			{!props.isReadonly ? (
				<CilAddInputOutputElementButton variant={props.variant} onElementAdded={handleElementAdded} />
			) : null}
		</div>
	);
};

CilInputOutputLineEditor.defaultProps = {
	isReadonly: false
};

export default CilInputOutputLineEditor;
