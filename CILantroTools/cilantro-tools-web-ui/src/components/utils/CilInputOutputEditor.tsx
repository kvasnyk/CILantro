import React, { FunctionComponent, useState } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import InputOutput from '../../api/models/tests/input-output/InputOutput';
import InputOutputLine from '../../api/models/tests/input-output/InputOutputLine';
import CilInputOutputLineEditor from './CilInputOutputLineEditor';

const useStyles = makeStyles((theme: Theme) => ({
	editor: {}
}));

interface CilInputOutputEditorProps {
	initialInputOutput?: InputOutput;
}

const CilInputOutputEditor: FunctionComponent<CilInputOutputEditorProps> = props => {
	const classes = useStyles();

	const [inputOutput, setInputOutput] = useState<InputOutput>({ lines: [{ elements: [] }] });

	const handleLineEdited = (index: number, newLine: InputOutputLine) => {
		const newInputOutput = { ...inputOutput };
		newInputOutput.lines[index] = newLine;
		setInputOutput(newInputOutput);
	};

	return (
		<div className={classes.editor}>
			{inputOutput.lines.map((inputOutputLine, index) => (
				<CilInputOutputLineEditor key={index} index={index} onLineEdited={handleLineEdited} />
			))}
		</div>
	);
};

export default CilInputOutputEditor;
