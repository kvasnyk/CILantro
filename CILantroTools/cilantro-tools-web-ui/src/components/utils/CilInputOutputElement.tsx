import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import { IconButton, Theme } from '@material-ui/core';
import { blue, grey } from '@material-ui/core/colors';
import DeleteIcon from '@material-ui/icons/DeleteRounded';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import ConstStringElement from '../../api/models/tests/input-output/elements/ConstStringElement';
import StringElement from '../../api/models/tests/input-output/elements/StringElement';
import translations from '../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
	element: {
		marginRight: '5px',
		borderRadius: '5px',
		fontFamily: 'monospace',
		textAlign: 'center',
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center',
		minHeight: '44px'
	},
	elementName: {
		padding: '0 20px',
		fontSize: '1rem',
		boxSizing: 'border-box',
		height: '100%',
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center'
	},
	elementInfo: {
		padding: '0 10px',
		borderRadius: '0 5px 5px 0',
		fontSize: '0.8rem',
		boxSizing: 'border-box',
		height: '100%',
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center',
		whiteSpace: 'pre'
	},
	constElement: {
		backgroundColor: grey[800],
		color: theme.palette.common.white,
		whiteSpace: 'pre'
	},
	stringElement: {
		backgroundColor: blue[800],
		color: theme.palette.common.white
	},
	stringElementInfo: {
		backgroundColor: blue[500]
	},
	deleteButton: {
		marginLeft: '5px'
	},
	deleteIcon: {
		width: '0.8rem',
		height: '0.8rem'
	},
	constElementDeleteIcon: {
		color: theme.palette.common.white
	},
	stringElementDeleteIcon: {
		color: theme.palette.common.white
	}
}));

interface CilInputOutputElementProps {
	variant: 'input' | 'output' | 'custom';
	element: AbstractInputOutputElement;
	isEditable?: boolean;
	onElementDeleted?: () => void;
}

const CilInputOutputElement: FunctionComponent<CilInputOutputElementProps> = props => {
	const classes = useStyles();

	const isConstStringElement = props.element.type === 'ConstString';
	const constStringElement = isConstStringElement ? (props.element as ConstStringElement) : null;

	const isStringElement = props.element.type === 'String';
	const stringElement = isStringElement ? (props.element as StringElement) : null;

	const elementClassName = classNames(classes.element, {
		[classes.constElement]: isConstStringElement,
		[classes.stringElement]: isStringElement
	});

	const elementInfoClassName = classNames(classes.elementInfo, {
		[classes.stringElementInfo]: isStringElement
	});

	const deleteIconClassName = classNames(classes.deleteIcon, {
		[classes.constElementDeleteIcon]: isConstStringElement,
		[classes.stringElementDeleteIcon]: isStringElement
	});

	const handleDeleteButtonClick = () => {
		if (props.onElementDeleted) {
			props.onElementDeleted();
		}
	};

	const deleteButton = props.isEditable ? (
		<IconButton className={classes.deleteButton} onClick={handleDeleteButtonClick}>
			<DeleteIcon fontSize="small" className={deleteIconClassName} />
		</IconButton>
	) : null;

	return (
		<div className={elementClassName}>
			{constStringElement ? (
				<div className={classes.elementName}>
					{constStringElement.value}
					{deleteButton}
				</div>
			) : null}

			{stringElement ? (
				<>
					<div className={classes.elementName}>
						{stringElement.name}
						{deleteButton}
					</div>
					{props.variant === 'input' ? (
						<div className={elementInfoClassName}>
							<span>
								|{stringElement.name}| &#8714; [{stringElement.minLength}; {stringElement.maxLength}]
							</span>

							<span>
								, {stringElement.name}
								<sub>chars</sub> &#8714;
							</span>

							{' ['}
							{stringElement.hasBigLetters ? <span>{translations.shared.bigLetters}</span> : null}
							{stringElement.hasSmallLetters ? <span>{translations.shared.smallLetters}</span> : null}
							{stringElement.hasDigits ? <span>{translations.shared.digits}</span> : null}
							{']'}
						</div>
					) : null}
					{props.variant === 'custom' ? <div className={elementInfoClassName}>{props.children}</div> : null}
				</>
			) : null}
		</div>
	);
};

export default CilInputOutputElement;
