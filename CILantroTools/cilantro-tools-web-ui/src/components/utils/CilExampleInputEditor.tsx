import React, { FunctionComponent, useEffect, useState } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import InputOutput from '../../api/models/tests/input-output/InputOutput';
import translations from '../../translations/translations';
import CilExampleInputLineEditor from './CilExampleInputLineEditor';

const useStyles = makeStyles((theme: Theme) => ({
	newExampleEmptyInput: {
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center',
		fontStyle: 'italic'
	},
	exampleInputEditor: {
		'&>*': {
			marginBottom: '5px'
		}
	}
}));

interface CilExampleInputEditorProps {
	hasEmptyInput: boolean;
	inputOutput?: InputOutput;
	onInputChange: (newInput: string) => void;
}

const CilExampleInputEditor: FunctionComponent<CilExampleInputEditorProps> = props => {
	const classes = useStyles();

	const linesLength = props.inputOutput ? props.inputOutput.lines.length : 0;

	const [value, setValue] = useState<string>('');
	const [lineValues, setLineValues] = useState<string[]>(Array(linesLength));

	const handleLineValueChange = (lineIndex: number, newValue: string) => {
		setLineValues(prevLineValues => {
			const newLineValues = [...prevLineValues];
			newLineValues[lineIndex] = newValue;
			return newLineValues;
		});
	};

	useEffect(
		() => {
			setValue(lineValues.join(''));
		},
		[lineValues]
	);

	useEffect(
		() => {
			props.onInputChange(value);
		},
		[value]
	);

	if (props.hasEmptyInput) {
		return <div className={classes.newExampleEmptyInput}>{translations.tests.emptyInput}</div>;
	}

	return (
		<div className={classes.exampleInputEditor}>
			{props.inputOutput!.lines.map((line, lineIndex) => (
				<CilExampleInputLineEditor
					key={lineIndex}
					line={line}
					index={lineIndex}
					onValueChange={handleLineValueChange}
					autoFocus={lineIndex === 0}
				/>
			))}
		</div>
	);
};

export default CilExampleInputEditor;
