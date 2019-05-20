import classNames from 'classnames';
import React, { ChangeEvent, FormEvent, FunctionComponent, useEffect, useRef, useState } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

export interface CilConsoleLine {
	type: 'start' | 'end' | 'input' | 'output' | 'error';
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
	consoleLine: {
		wordBreak: 'break-all',
		whiteSpace: 'pre'
	},
	consoleInLine: {
		color: 'white'
	},
	consoleOutLine: {
		color: 'deepskyblue'
	},
	consoleErrorLine: {
		color: '#ff2020'
	},
	consoleStartLine: {
		color: 'lightgrey',
		textAlign: 'center',
		fontStyle: 'italic',
		marginBottom: '10px'
	},
	consoleEndLine: {
		color: 'lightgrey',
		textAlign: 'center',
		fontStyle: 'italic',
		marginTop: '10px'
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
		padding: 0,
		cursor: 'default'
	},
	button: {
		visibility: 'hidden'
	}
}));

interface CilConsoleProps {
	title: string;
	lines: CilConsoleLine[];
	onLineAdded: (newLine: string) => void;
	isInputEnabled?: boolean;
	className?: string;
	autoFocus?: boolean;
	overrideInputLine?: string;
	onInputLineChange?: (newInputLine: string) => void;
}

const CilConsole: FunctionComponent<CilConsoleProps> = props => {
	const classes = useStyles();

	const [inputLine, setInputLine] = useState<string>('');
	const [inputWidth, setInputWidth] = useState<string>('0px');
	const [isInputFocused, setInputFocused] = useState<boolean>(false);

	const inputElem = useRef<HTMLInputElement>(null);

	const resizeInput = (currentValueLength: number) => {
		const newValueLength = currentValueLength;
		const newInputWidth = newValueLength * 0.66 + 'rem';
		setInputWidth(newInputWidth);
	};

	const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
		setInputLine(e.target.value);
		resizeInput(e.target.value.length);

		if (props.onInputLineChange) {
			props.onInputLineChange(e.target.value);
		}
	};

	const handleSubmit = (e: FormEvent) => {
		e.preventDefault();
		props.onLineAdded(inputLine);
		setInputLine('');
		resizeInput(0);
	};

	const handleConsoleClick = () => {
		if (inputElem.current) {
			inputElem.current.focus();
		}
	};

	const handleInputFocus = () => {
		setInputFocused(true);
	};

	const handleInputBlur = () => {
		setInputFocused(false);
	};

	useEffect(
		() => {
			const len = props.overrideInputLine ? props.overrideInputLine.length : 0;
			resizeInput(len);
		},
		[props.overrideInputLine]
	);

	const consoleClassName = classNames(classes.console, props.className);

	const inLineClassName = classNames(classes.consoleLine, classes.consoleInLine);
	const outLineClassName = classNames(classes.consoleLine, classes.consoleOutLine);
	const startLineClassName = classNames(classes.consoleLine, classes.consoleStartLine);
	const endLineClassName = classNames(classes.consoleLine, classes.consoleEndLine);
	const errorLineClassName = classNames(classes.consoleLine, classes.consoleErrorLine);

	return (
		<div className={consoleClassName} onClick={handleConsoleClick}>
			<div className={classes.consoleTitle}>{props.title}</div>
			<div className={classes.content}>
				{props.lines.map((line, index) => (
					<React.Fragment key={index}>
						{line.type === 'input' ? <div className={inLineClassName}>{line.content}</div> : null}
						{line.type === 'output' ? <div className={outLineClassName}>{line.content}</div> : null}
						{line.type === 'start' ? <div className={startLineClassName}>{line.content}</div> : null}
						{line.type === 'end' ? <div className={endLineClassName}>{line.content}</div> : null}
						{line.type === 'error' ? <div className={errorLineClassName}>{line.content}</div> : null}
					</React.Fragment>
				))}

				{props.isInputEnabled ? (
					<form onSubmit={handleSubmit} className={classes.form}>
						<input
							type="text"
							value={props.overrideInputLine || inputLine}
							onChange={handleChange}
							autoFocus={props.autoFocus}
							className={classes.input}
							style={{ width: inputWidth }}
							ref={inputElem}
							onFocus={handleInputFocus}
							onBlur={handleInputBlur}
						/>
						{(isInputFocused || props.overrideInputLine || props.overrideInputLine === '') && props.isInputEnabled ? (
							<div className={classes.caret} />
						) : null}
						<button type="submit" className={classes.button} />
					</form>
				) : null}
			</div>
		</div>
	);
};

CilConsole.defaultProps = {
	isInputEnabled: true,
	autoFocus: true
};

export default CilConsole;
