import React, { FunctionComponent } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import InputOutputLine from '../../api/models/tests/input-output/InputOutputLine';
import translations from '../../translations/translations';
import CilAddInputOutputElementButton from './CilAddInputOutputElementButton';
import CilInputOutputElement from './CilInputOutputElement';

const useStyles = makeStyles((theme: Theme) => ({
	inputOutputLine: {
		display: 'flex',
		flexDirection: 'row',
		padding: '5px',
		borderRadius: '5px'
	},
	lineIndex: {
		minHeight: '44px',
		minWidth: '44px',
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'center',
		fontSize: '1.5rem',
		fontFamily: 'monospace'
	},
	noElements: {
		minHeight: '44px',
		minWidth: '44px',
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'center',
		fontSize: '1rem',
		fontFamily: 'monospace',
		fontStyle: 'italic'
	}
}));

interface CilInputOutputLineEditorProps {
	variant: 'input' | 'output';
	lineIndex: number;
	line: InputOutputLine;
	onElementAdded: (lineIndex: number, element: AbstractInputOutputElement) => void;
	onElementDeleted?: (lineIndex: number, elementIndex: number) => void;
	isReadonly?: boolean;
}

const CilInputOutputLineEditor: FunctionComponent<CilInputOutputLineEditorProps> = props => {
	const classes = useStyles();

	const handleElementAdded = (element: AbstractInputOutputElement) => {
		props.onElementAdded(props.lineIndex, element);
	};

	return (
		<div className={classes.inputOutputLine}>
			<div className={classes.lineIndex}>{props.lineIndex}</div>
			{props.line.elements.map((element, index) => (
				<CilInputOutputElement
					key={index}
					variant={props.variant}
					element={element}
					isEditable={!props.isReadonly}
					onElementDeleted={() => props.onElementDeleted && props.onElementDeleted(props.lineIndex, index)}
				/>
			))}

			{props.isReadonly && props.line.elements.length === 0 ? (
				<div className={classes.noElements}>{translations.tests.emptyLine}</div>
			) : null}

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
