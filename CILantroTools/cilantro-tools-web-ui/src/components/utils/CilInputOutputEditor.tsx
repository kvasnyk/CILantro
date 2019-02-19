import React, { FunctionComponent } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import InputOutput from '../../api/models/tests/input-output/InputOutput';
import CilInputOutputLineEditor from './CilInputOutputLineEditor';

const useStyles = makeStyles((theme: Theme) => ({
	editor: {}
}));

interface CilInputOutputEditorProps {
	inputOutput: InputOutput;
	onElementAdded: (lineIndex: number, element: AbstractInputOutputElement) => void;
	isReadonly?: boolean;
}

const CilInputOutputEditor: FunctionComponent<CilInputOutputEditorProps> = props => {
	const classes = useStyles();

	return (
		<div className={classes.editor}>
			{props.inputOutput.lines.map((inputOutputLine, index) => (
				<CilInputOutputLineEditor
					key={index}
					lineIndex={index}
					line={inputOutputLine}
					onElementAdded={props.onElementAdded}
					isReadonly={props.isReadonly}
				/>
			))}
		</div>
	);
};

CilInputOutputEditor.defaultProps = {
	isReadonly: false
};

export default CilInputOutputEditor;