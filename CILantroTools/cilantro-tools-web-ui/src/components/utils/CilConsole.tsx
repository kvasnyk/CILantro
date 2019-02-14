import React, { ChangeEvent, FormEvent, FunctionComponent, useState } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

export interface CilConsoleLine {
	type: 'in' | 'out' | 'start' | 'end';
	content: string;
}

const useStyles = makeStyles((theme: Theme) => ({
	console: {
		fontFamily: 'Consolas',
		fontSize: '1.2rem',
		backgroundColor: 'black',
		color: 'white',
		border: '3px solid lightgrey'
	},
	consoleTitle: {
		backgroundColor: 'lightgrey',
		padding: '5px',
		color: 'black'
	},
	content: {
		padding: '10px'
	},
	consoleInLine: {
		color: 'white'
	},
	consoleOutLine: {
		color: 'deepskyblue'
	},
	consoleStartLine: {
		color: 'lightgrey',
		textAlign: 'right',
		fontStyle: 'italic'
	},
	consoleEndLine: {
		color: 'lightgrey',
		textAlign: 'right',
		fontStyle: 'italic'
	},
	form: {
		display: 'flex',
		flexDirection: 'row'
	},
	caret: {
		borderBottom: '3px solid white',
		width: '0.66rem',
		animation: 'caret-animation 1s infinite step-end'
	},
	inputWrapper: {
		overflow: 'hidden'
	},
	input: {
		fontSize: '1.2rem',
		backgroundColor: 'black',
		color: 'white',
		fontFamily: 'Consolas',
		border: 'none',
		outline: 'none',
		width: '100%',
		caretColor: 'transparent',
		margin: 0,
		padding: 0
	},
	button: {
		visibility: 'hidden'
	}
}));

interface CilConsoleProps {
	title: string;
	lines: CilConsoleLine[];
	onLineAdded: (newLine: string) => void;
}

const CilConsole: FunctionComponent<CilConsoleProps> = props => {
	const classes = useStyles();

	const [inputLine, setInputLine] = useState<string>('');
	const [inputWidth, setInputWidth] = useState<string>('0px');

	const resizeInput = (currentValueLength: number) => {
		const newValueLength = currentValueLength;
		const newInputWidth = newValueLength * 0.66 + 'rem';
		setInputWidth(newInputWidth);
	};

	const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
		setInputLine(e.target.value);
		resizeInput(e.target.value.length);
	};

	const handleSubmit = (e: FormEvent) => {
		e.preventDefault();
		props.onLineAdded(inputLine);
		setInputLine('');
		resizeInput(0);
	};

	return (
		<div className={classes.console}>
			<div className={classes.consoleTitle}>{props.title}</div>
			<div className={classes.content}>
				{props.lines.map((line, index) => (
					<React.Fragment key={index}>
						{line.type === 'in' ? <div className={classes.consoleInLine}>{line.content}</div> : null}

						{line.type === 'out' ? <div className={classes.consoleOutLine}>{line.content}</div> : null}

						{line.type === 'start' ? <div className={classes.consoleStartLine}>{line.content}</div> : null}

						{line.type === 'end' ? <div className={classes.consoleEndLine}>{line.content}</div> : null}
					</React.Fragment>
				))}

				<form onSubmit={handleSubmit} className={classes.form}>
					<input
						type="text"
						value={inputLine}
						onChange={handleChange}
						autoFocus={true}
						className={classes.input}
						style={{ width: inputWidth }}
					/>
					<div className={classes.caret} />
					<button type="submit" className={classes.button} />
				</form>
			</div>
		</div>
	);
};

export default CilConsole;
