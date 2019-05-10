import React, { FunctionComponent } from 'react';

import { IconButton, Theme } from '@material-ui/core';
import AddIcon from '@material-ui/icons/AddRounded';
import RepeatIcon from '@material-ui/icons/RepeatRounded';
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
	onRepeatBlockAdded: () => void;
	onElementAdded: (lineIndex: number, element: AbstractInputOutputElement) => void;
	onElementDeleted?: (lineIndex: number, elementIndex: number) => void;
	onElementEdited?: (lineIndex: number, elementIndex: number, element: AbstractInputOutputElement) => void;
	onRepeatBlockLineAdded: (repeatBlockIndex: number) => void;
	onRepeatBlockElementAdded: (repeatBlockIndex: number, lineIndex: number, element: AbstractInputOutputElement) => void;
	onRepeatBlockElementDeleted?: (repeatBlockIndex: number, lineIndex: number, elementIndex: number) => void;
	onRepeatBlockElementEdited?: (
		repeatBlockIndex: number,
		lineIndex: number,
		elementIndex: number,
		element: AbstractInputOutputElement
	) => void;
	isReadonly?: boolean;
	hideAddLineButton?: boolean;
	hideAddRepeatBlockButton?: boolean;
	onRepeatBlockMinChange: (repeatBlockIndex: number, newMin: string) => void;
	onRepeatBlockMaxChange: (repeatBlockIndex: number, newMax: string) => void;
}

const CilInputOutputEditor: FunctionComponent<CilInputOutputEditorProps> = props => {
	const classes = useStyles();

	const handleNewLineButtonClick = () => {
		props.onLineAdded();
	};

	const handleNewRepeatBlockButtonClick = () => {
		props.onRepeatBlockAdded();
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
					onElementEdited={props.onElementEdited}
					onRepeatBlockLineAdded={props.onRepeatBlockLineAdded}
					onRepeatBlockElementAdded={props.onRepeatBlockElementAdded}
					onRepeatBlockElementDeleted={props.onRepeatBlockElementDeleted}
					onRepeatBlockElementEdited={props.onRepeatBlockElementEdited}
					onRepeatBlockMinChange={props.onRepeatBlockMinChange}
					onRepeatBlockMaxChange={props.onRepeatBlockMaxChange}
				/>
			))}
			{!props.isReadonly && !props.hideAddLineButton ? (
				<IconButton className={classes.newLineButton} onClick={handleNewLineButtonClick}>
					<AddIcon fontSize="small" />
				</IconButton>
			) : null}
			{!props.isReadonly && !props.hideAddRepeatBlockButton ? (
				<IconButton className={classes.newLineButton} onClick={handleNewRepeatBlockButtonClick}>
					<RepeatIcon fontSize="small" />
				</IconButton>
			) : null}
		</div>
	);
};

CilInputOutputEditor.defaultProps = {
	isReadonly: false
};

export default CilInputOutputEditor;
