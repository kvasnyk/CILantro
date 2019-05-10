import React, { FunctionComponent, useEffect, useState } from 'react';

import { IconButton, Theme } from '@material-ui/core';
import { grey } from '@material-ui/core/colors';
import AddIcon from '@material-ui/icons/AddRounded';
import { makeStyles } from '@material-ui/styles';

import InputOutput from '../../api/models/tests/input-output/InputOutput';
import InputOutputLine from '../../api/models/tests/input-output/InputOutputLine';
import translations from '../../translations/translations';
import CilExampleInputEditor from './CilExampleInputEditor';
import CilExampleInputElementEditor from './CilExampleInputElementEditor';

const useStyles = makeStyles((theme: Theme) => ({
	exampleInputLine: {
		display: 'flex',
		flexDirection: 'row'
	},
	repeatBlock: {
		display: 'flex',
		flexDirection: 'column',
		width: '100%',
		flexGrow: 1
	},
	repeatBlockHeader: {
		fontSize: '1rem',
		fontFamily: 'monospace',
		textTransform: 'uppercase',
		padding: '10px',
		backgroundColor: grey[500],
		borderRadius: '5px 5px 0 0',
		color: theme.palette.common.white,
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center'
	},
	repeatBlockContent: {
		padding: '10px',
		borderLeft: `3px solid ${grey[500]}`,
		borderRight: `3px solid ${grey[500]}`,
		borderBottom: `3px solid ${grey[500]}`,
		borderRadius: '0 0 5px 5px'
	},
	repeatBlockInput: {
		marginLeft: '10px',
		width: '100px',
		fontSize: '1rem',
		fontFamily: 'monospace',
		color: theme.palette.common.white,
		outline: 'none',
		border: 'none',
		backgroundColor: grey[500],
		borderBottom: `2px solid ${theme.palette.common.white}`
	}
}));

interface CilExampleInputLineEditorProps {
	line: InputOutputLine;
	index: number;
	onValueChange: (lineIndex: number, newValue: string) => void;
	autoFocus: boolean;
}

const CilExampleInputLineEditor: FunctionComponent<CilExampleInputLineEditorProps> = props => {
	const classes = useStyles();

	const [value, setValue] = useState<string>('');
	const [elementValues, setElementValues] = useState<string[]>(Array(props.line.elements.length));

	const [repeatBlockIo, setRepeatBlockIo] = useState<InputOutput>({ lines: [] });
	const [repeatBlockValue, setRepeatBlockValue] = useState<string>('');

	const handleElementValueChange = (elementIndex: number, newValue: string) => {
		setElementValues(prevElementValues => {
			const newElementValues = [...prevElementValues];
			newElementValues[elementIndex] = newValue;
			return newElementValues;
		});
	};

	const handleRepeatBlockValueChange = (newValue: string) => {
		setRepeatBlockValue(newValue);
	};

	const handleAddRepeatBlockLineButtonClick = () => {
		setRepeatBlockIo(prevRepeatBlockIo => {
			const newRepeatBlockIo = { ...prevRepeatBlockIo };
			newRepeatBlockIo.lines.push(...props.line.repeatBlockInputOutput!.lines);
			return newRepeatBlockIo;
		});
	};

	useEffect(
		() => {
			if (elementValues.some(ev => ev !== '')) {
				setValue(elementValues.join(' ') + '\n');
			}
		},
		[elementValues]
	);

	useEffect(
		() => {
			if (repeatBlockValue) {
				setValue(repeatBlockValue);
			}
		},
		[repeatBlockValue]
	);

	useEffect(
		() => {
			props.onValueChange(props.index, value);
		},
		[value]
	);

	if (!props.line.isRepeatBlock) {
		return (
			<div className={classes.exampleInputLine}>
				{props.line.elements.map((element, elementIndex) => (
					<CilExampleInputElementEditor
						element={element}
						index={elementIndex}
						onValueChange={handleElementValueChange}
						autoFocus={props.autoFocus && elementIndex === 0}
					/>
				))}
			</div>
		);
	}

	if (props.line.isRepeatBlock) {
		return (
			<div className={classes.repeatBlock}>
				<div className={classes.repeatBlockHeader}>
					{translations.tests.repeat}
					<input type="text" className={classes.repeatBlockInput} readOnly={true} value={props.line.repeatBlockMin} />
					<input type="text" className={classes.repeatBlockInput} readOnly={true} value={props.line.repeatBlockMax} />
				</div>
				<div className={classes.repeatBlockContent}>
					<CilExampleInputEditor
						hasEmptyInput={false}
						inputOutput={repeatBlockIo}
						onInputChange={handleRepeatBlockValueChange}
					/>
					<IconButton onClick={handleAddRepeatBlockLineButtonClick}>
						<AddIcon fontSize="small" />
					</IconButton>
				</div>
			</div>
		);
	}

	return <div>CilExampleInputLineEditor</div>;
};

export default CilExampleInputLineEditor;
