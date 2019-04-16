import React, { FunctionComponent } from 'react';

import { IconButton, Theme } from '@material-ui/core';
import AddIcon from '@material-ui/icons/AddRounded';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import InputOutput from '../../api/models/tests/input-output/InputOutput';
import CilInputOutputLineEditor from './CilInputOutputLineEditor';

const useStyles = makeStyles((theme: Theme) => ({
	editor: {},
	newLineButton: {
		marginLeft: '5px'
	}
}));

interface CilInputOutputEditorProps {
	variant: 'input' | 'output';
	inputOutput: InputOutput;
	onLineAdded: () => void;
	onElementAdded: (lineIndex: number, element: AbstractInputOutputElement) => void;
	onElementDeleted?: (lineIndex: number, elementIndex: number) => void;
	isReadonly?: boolean;
}

const CilInputOutputEditor: FunctionComponent<CilInputOutputEditorProps> = props => {
	const classes = useStyles();

	const handleNewLineButtonClick = () => {
		props.onLineAdded();
	};

	return (
		<div className={classes.editor}>
			{props.inputOutput.lines.map((inputOutputLine, index) => (
				<CilInputOutputLineEditor
					key={index}
					variant={props.variant}
					lineIndex={index}
					line={inputOutputLine}
					onElementAdded={props.onElementAdded}
					isReadonly={props.isReadonly}
					onElementDeleted={props.onElementDeleted}
				/>
			))}
			{!props.isReadonly ? (
				<IconButton className={classes.newLineButton} onClick={handleNewLineButtonClick}>
					<AddIcon fontSize="small" />
				</IconButton>
			) : null}
		</div>
	);
};

CilInputOutputEditor.defaultProps = {
	isReadonly: false
};

export default CilInputOutputEditor;
