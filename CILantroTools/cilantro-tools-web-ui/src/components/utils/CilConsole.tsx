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

	const handleChange = (e: ChangeEvent<HTMLInputElement>) => {
		setInputLine(e.target.value);
	};

	const handleSubmit = (e: FormEvent) => {
		e.preventDefault();
		props.onLineAdded(inputLine);
		setInputLine('');
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

				<form onSubmit={handleSubmit}>
					<input type="text" value={inputLine} onChange={handleChange} />
					<button type="submit" />
				</form>
			</div>
		</div>
	);
};

export default CilConsole;
