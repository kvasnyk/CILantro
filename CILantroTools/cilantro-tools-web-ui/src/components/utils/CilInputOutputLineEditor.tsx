import React, { FunctionComponent } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import InputOutputLine from '../../api/models/tests/input-output/InputOutputLine';
import translations from '../../translations/translations';
import CilAddInputOutputElementButton from './CilAddInputOutputElementButton';
import CilInputOutputElement from './CilInputOutputElement';
import CilInputOutputRepeatBlock from './CilInputOutputRepeatBlock';

const useStyles = makeStyles((theme: Theme) => ({
	inputOutputLine: {
		display: 'flex',
		flexDirection: 'row',
		padding: '5px',
		borderRadius: '5px'
	},
	lineIndex: {
		minHeight: '44px',
		minWidth: '70px',
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
	onRepeatBlockMinChange: (repeateBlockIndex: number, newMin: string) => void;
	onRepeatBlockMaxChange: (repeateBlockIndex: number, newMax: string) => void;
	isReadonly?: boolean;
}

const CilInputOutputLineEditor: FunctionComponent<CilInputOutputLineEditorProps> = props => {
	const classes = useStyles();

	const handleElementAdded = (element: AbstractInputOutputElement) => {
		props.onElementAdded(props.lineIndex, element);
	};

	const isNormalLine = !props.line.isRepeatBlock;

	return (
		<div className={classes.inputOutputLine}>
			{isNormalLine ? (
				<>
					{props.line.elements.map((element, index) => (
						<CilInputOutputElement
							key={index}
							variant={props.variant}
							element={element}
							isEditable={!props.isReadonly}
							onElementDeleted={() => props.onElementDeleted && props.onElementDeleted(props.lineIndex, index)}
							onElementEdited={e => props.onElementEdited && props.onElementEdited(props.lineIndex, index, e)}
						/>
					))}

					{props.isReadonly && props.line.elements.length === 0 ? (
						<div className={classes.noElements}>{translations.tests.emptyLine}</div>
					) : null}

					{!props.isReadonly ? (
						<CilAddInputOutputElementButton action="add" variant={props.variant} onElementAdded={handleElementAdded} />
					) : null}
				</>
			) : null}

			{props.line.isRepeatBlock ? (
				<>
					<CilInputOutputRepeatBlock
						repeatBlock={props.line}
						variant={props.variant}
						isReadonly={props.isReadonly}
						onLineAdded={() => props.onRepeatBlockLineAdded(props.lineIndex)}
						onElementAdded={(lineIndex, element) =>
							props.onRepeatBlockElementAdded(props.lineIndex, lineIndex, element)
						}
						onElementEdited={(lineIndex, elementIndex, element) =>
							props.onRepeatBlockElementEdited &&
							props.onRepeatBlockElementEdited(props.lineIndex, lineIndex, elementIndex, element)
						}
						onElementDeleted={(lineIndex, elementIndex) =>
							props.onRepeatBlockElementDeleted &&
							props.onRepeatBlockElementDeleted(props.lineIndex, lineIndex, elementIndex)
						}
						onMinChange={newMin => props.onRepeatBlockMinChange(props.lineIndex, newMin)}
						onMaxChange={newMax => props.onRepeatBlockMaxChange(props.lineIndex, newMax)}
					/>
				</>
			) : null}
		</div>
	);
};

CilInputOutputLineEditor.defaultProps = {
	isReadonly: false
};

export default CilInputOutputLineEditor;
