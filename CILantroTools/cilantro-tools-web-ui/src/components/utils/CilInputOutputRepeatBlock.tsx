import React, { ChangeEvent, FunctionComponent } from 'react';

import { Theme } from '@material-ui/core';
import { grey } from '@material-ui/core/colors';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import InputOutputLine from '../../api/models/tests/input-output/InputOutputLine';
import translations from '../../translations/translations';
import CilInputOutputEditor from './CilInputOutputEditor';

const useStyles = makeStyles((theme: Theme) => ({
	repeatBlock: {
		display: 'flex',
		flexDirection: 'column',
		width: '100%',
		flexGrow: 1
	},
	header: {
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
	content: {
		padding: '10px',
		borderLeft: `3px solid ${grey[500]}`,
		borderRight: `3px solid ${grey[500]}`,
		borderBottom: `3px solid ${grey[500]}`,
		borderRadius: '0 0 5px 5px'
	},
	input: {
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

interface CilInputOutputRepeatBlockProps {
	repeatBlock: InputOutputLine;
	variant: 'input' | 'output';
	isReadonly?: boolean;
	onLineAdded: () => void;
	onElementAdded: (lineIndex: number, element: AbstractInputOutputElement) => void;
	onElementDeleted?: (lineIndex: number, elementIndex: number) => void;
	onElementEdited?: (lineIndex: number, elementIndex: number, element: AbstractInputOutputElement) => void;
	onMinChange: (newMin: string) => void;
	onMaxChange: (newMax: string) => void;
}

const CilInputOutputRepeatBlock: FunctionComponent<CilInputOutputRepeatBlockProps> = props => {
	const classes = useStyles();

	const handleMinChange = (e: ChangeEvent<HTMLInputElement>) => {
		props.onMinChange(e.target.value);
	};

	const handleMaxChange = (e: ChangeEvent<HTMLInputElement>) => {
		props.onMaxChange(e.target.value);
	};

	return (
		<div className={classes.repeatBlock}>
			<div className={classes.header}>
				{translations.tests.repeat}
				<input
					type="text"
					className={classes.input}
					value={props.repeatBlock.repeatBlockMin || '0'}
					onChange={handleMinChange}
					readOnly={props.isReadonly}
				/>
				<input
					type="text"
					className={classes.input}
					value={props.repeatBlock.repeatBlockMax || '1000'}
					onChange={handleMaxChange}
					readOnly={props.isReadonly}
				/>
			</div>
			<div className={classes.content}>
				<CilInputOutputEditor
					inputOutput={props.repeatBlock.repeatBlockInputOutput!}
					onElementAdded={props.onElementAdded}
					onLineAdded={props.onLineAdded}
					onRepeatBlockAdded={() => {
						return;
					}}
					onRepeatBlockLineAdded={() => {
						return;
					}}
					onRepeatBlockElementAdded={(repeatBlockIndex, lineIndex, element) => {
						return;
					}}
					variant={props.variant}
					hideAddRepeatBlockButton={true}
					isReadonly={props.isReadonly}
					onElementEdited={props.onElementEdited}
					onElementDeleted={props.onElementDeleted}
					onRepeatBlockMinChange={(repeatBlockIndex, newMin) => {
						return;
					}}
					onRepeatBlockMaxChange={(repeatBlockIndex, newMax) => {
						return;
					}}
				/>
			</div>
		</div>
	);
};

export default CilInputOutputRepeatBlock;
