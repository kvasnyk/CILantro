import React, { ChangeEvent, FormEvent, FunctionComponent, useState } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import parseInputOutputElement from '../../logic/input-output/parseInputOutputElement';

const useStyles = makeStyles((theme: Theme) => ({
	input: {
		padding: '5px',
		backgroundColor: 'transparent',
		fontSize: '1rem',
		fontFamily: 'Consolas',
		outline: 'none',
		border: 'none'
	},
	submitButton: {
		visibility: 'hidden'
	}
}));

interface CilInputOutputElementInputProps {
	onElementAdded: (element: AbstractInputOutputElement) => void;
}

const CilInputOutputElementInput: FunctionComponent<CilInputOutputElementInputProps> = props => {
	const parser = parseInputOutputElement;

	const classes = useStyles();

	const [inputValue, setInputValue] = useState<string>('');

	const handleInputChange = (e: ChangeEvent<HTMLInputElement>) => {
		setInputValue(e.target.value);
	};

	const handleFormSubmit = (e: FormEvent) => {
		e.preventDefault();

		try {
			const element = parser(inputValue);
			setInputValue('');
			props.onElementAdded(element);
		} catch (error) {
			alert(error);
		}
	};

	return (
		<>
			<form onSubmit={handleFormSubmit}>
				<input type="text" autoFocus={true} value={inputValue} onChange={handleInputChange} className={classes.input} />
				<button type="submit" className={classes.submitButton} />
			</form>
		</>
	);
};

export default CilInputOutputElementInput;
