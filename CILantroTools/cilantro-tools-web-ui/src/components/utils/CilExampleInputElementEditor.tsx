import React, { ChangeEvent, FunctionComponent, useEffect, useState } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import CilInputOutputElement from './CilInputOutputElement';

const useStyles = makeStyles((theme: Theme) => ({
	elementInput: {
		color: theme.palette.common.white,
		fontSize: '0.8rem',
		background: 'inherit',
		border: 'none',
		outline: 'none',
		width: '100px'
	}
}));

interface CilExampleInputElementEditorProps {
	element: AbstractInputOutputElement;
	index: number;
	onValueChange: (index: number, newValue: string) => void;
	autoFocus: boolean;
}

const CilExampleInputElementEditor: FunctionComponent<CilExampleInputElementEditorProps> = props => {
	const classes = useStyles();

	const [value, setValue] = useState<string>(props.element.type === 'ConstString' ? props.element.value : '');

	const handleValueChange = (e: ChangeEvent<HTMLInputElement>) => {
		const newValue = e.target.value;
		setValue(newValue);
	};

	useEffect(
		() => {
			props.onValueChange(props.index, value);
		},
		[value]
	);

	return (
		<CilInputOutputElement variant="custom" element={props.element}>
			<input
				type="text"
				className={classes.elementInput}
				value={value}
				onChange={handleValueChange}
				autoFocus={props.autoFocus}
			/>
		</CilInputOutputElement>
	);
};

export default CilExampleInputElementEditor;
