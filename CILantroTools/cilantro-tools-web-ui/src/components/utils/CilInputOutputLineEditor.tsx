import React, { FunctionComponent, useState } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import InputOutputLine from '../../api/models/tests/input-output/InputOutputLine';
import CilInputOutputElement from './CilInputOutputElement';
import CilInputOutputElementInput from './CilInputOutputElementInput';

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
	index: number;
	onLineEdited: (index: number, newLine: InputOutputLine) => void;
}

const CilInputOutputLineEditor: FunctionComponent<CilInputOutputLineEditorProps> = props => {
	const classes = useStyles();

	const [line, setLine] = useState<InputOutputLine>({
		elements: []
	});

	const handleElementAdded = (element: AbstractInputOutputElement) => {
		const newLine = {
			...line,
			elements: [...line.elements, element]
		};
		setLine(newLine);
		props.onLineEdited(props.index, newLine);
	};

	return (
		<div className={classes.inputOutputLine}>
			{line.elements.map((element, index) => (
				<CilInputOutputElement key={index} element={element} />
			))}
			<CilInputOutputElementInput onElementAdded={handleElementAdded} />
		</div>
	);
};

export default CilInputOutputLineEditor;
