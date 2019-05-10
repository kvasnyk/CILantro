import classNames from 'classnames';
import React, { FunctionComponent, useState } from 'react';

import { IconButton, Theme } from '@material-ui/core';
import { amber, blue, green, grey, purple } from '@material-ui/core/colors';
import DeleteIcon from '@material-ui/icons/DeleteRounded';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import BoolElement from '../../api/models/tests/input-output/elements/BoolElement';
import ConstStringElement from '../../api/models/tests/input-output/elements/ConstStringElement';
import FloatElement from '../../api/models/tests/input-output/elements/FloatElement';
import IntElement from '../../api/models/tests/input-output/elements/IntElement';
import StringElement from '../../api/models/tests/input-output/elements/StringElement';
import translations from '../../translations/translations';
import CilAddInputOutputElementButton, { buildEmptyAddInputOutputElementData } from './CilAddInputOutputElementButton';

const getIntElementTypeName = (intElement: IntElement) => {
	switch (intElement.type) {
		case 'Byte':
			return translations.shared.type_byte;
		case 'Short':
			return translations.shared.type_short;
		case 'Int':
			return translations.shared.type_int;
		case 'Long':
			return translations.shared.type_long;
		case 'Sbyte':
			return translations.shared.type_sbyte;
		case 'Uint':
			return translations.shared.type_uint;
		case 'Ulong':
			return translations.shared.type_ulong;
		case 'Ushort':
			return translations.shared.type_ushort;
	}
};

const getFloatElementTypeName = (floatElement: FloatElement) => {
	switch (floatElement.type) {
		case 'Float':
			return translations.shared.type_float;
		case 'Double':
			return translations.shared.type_double;
		case 'Decimal':
			return translations.shared.type_decimal;
	}
};

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
		justifyContent: 'center',
		borderRadius: '5px'
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
	constElementNameHover: {
		'&:hover': {
			backgroundColor: grey[900],
			cursor: 'pointer'
		}
	},
	stringElement: {
		backgroundColor: blue[800],
		color: theme.palette.common.white
	},
	stringElementNameHover: {
		'&:hover': {
			backgroundColor: blue[900],
			cursor: 'pointer'
		}
	},
	boolElement: {
		backgroundColor: purple[800],
		color: theme.palette.common.white
	},
	boolElementNameHover: {
		'&:hover': {
			backgroundColor: purple[900],
			cursor: 'pointer'
		}
	},
	intElement: {
		backgroundColor: green[800],
		color: theme.palette.common.white
	},
	intElementNameHover: {
		'&:hover': {
			backgroundColor: green[900],
			cursor: 'pointer'
		}
	},
	floatElement: {
		backgroundColor: amber[800],
		color: theme.palette.common.white
	},
	floatElementNameHover: {
		'&:hover': {
			backgroundColor: amber[900],
			cursor: 'pointer'
		}
	},
	stringElementInfo: {
		backgroundColor: blue[500]
	},
	boolElementInfo: {
		backgroundColor: purple[500]
	},
	intElementInfo: {
		backgroundColor: green[500]
	},
	floatElementInfo: {
		backgroundColor: amber[500]
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
	},
	boolElementDeleteIcon: {
		color: theme.palette.common.white
	},
	intElementDeleteIcon: {
		color: theme.palette.common.white
	},
	floatElementDeleteIcon: {
		color: theme.palette.common.white
	}
}));

interface CilInputOutputElementProps {
	variant: 'input' | 'output' | 'custom';
	element: AbstractInputOutputElement;
	isEditable?: boolean;
	onElementEdited?: (element: AbstractInputOutputElement) => void;
	onElementDeleted?: () => void;
}

const CilInputOutputElement: FunctionComponent<CilInputOutputElementProps> = props => {
	const classes = useStyles();

	const [isExpanded, setIsExpanded] = useState<boolean>(false);

	const isConstStringElement = props.element.type === 'ConstString';
	const constStringElement = isConstStringElement ? (props.element as ConstStringElement) : null;

	const isStringElement = props.element.type === 'String' || props.element.type === 'Char';
	const stringElement = isStringElement ? (props.element as StringElement) : null;

	const isBoolElement = props.element.type === 'Bool';
	const boolElement = isBoolElement ? (props.element as BoolElement) : null;

	const isByteElement = props.element.type === 'Byte';
	const isShortElement = props.element.type === 'Short';
	const isIntElement = props.element.type === 'Int';
	const isLongElement = props.element.type === 'Long';
	const isSbyteElement = props.element.type === 'Sbyte';
	const isUintElement = props.element.type === 'Uint';
	const isUlongElement = props.element.type === 'Ulong';
	const isUshortElement = props.element.type === 'Ushort';

	const isAnyIntElement =
		isByteElement ||
		isShortElement ||
		isIntElement ||
		isLongElement ||
		isSbyteElement ||
		isUintElement ||
		isUlongElement ||
		isUshortElement;
	const intElement = isAnyIntElement ? (props.element as IntElement) : null;

	const isFloatElement = props.element.type === 'Float';
	const isDoubleElement = props.element.type === 'Double';
	const isDecimalElement = props.element.type === 'Decimal';

	const isAnyFloatElement = isFloatElement || isDoubleElement || isDecimalElement;
	const floatElement = isAnyFloatElement ? (props.element as FloatElement) : null;

	const elementClassName = classNames(classes.element, {
		[classes.constElement]: isConstStringElement,
		[classes.stringElement]: isStringElement,
		[classes.boolElement]: isBoolElement,
		[classes.intElement]: isAnyIntElement,
		[classes.floatElement]: isAnyFloatElement
	});

	const elementInfoClassName = classNames(classes.elementInfo, {
		[classes.stringElementInfo]: isStringElement,
		[classes.boolElementInfo]: isBoolElement,
		[classes.intElementInfo]: isAnyIntElement,
		[classes.floatElementInfo]: isAnyFloatElement
	});

	const deleteIconClassName = classNames(classes.deleteIcon, {
		[classes.constElementDeleteIcon]: isConstStringElement,
		[classes.stringElementDeleteIcon]: isStringElement,
		[classes.boolElementDeleteIcon]: isBoolElement,
		[classes.intElementDeleteIcon]: isAnyIntElement,
		[classes.floatElementDeleteIcon]: isAnyFloatElement
	});

	const shouldHover = props.variant === 'input' && !isConstStringElement && !isBoolElement;

	const elementNameClassName = classNames(classes.elementName, {
		[classes.constElementNameHover]: isConstStringElement && shouldHover,
		[classes.stringElementNameHover]: isStringElement && shouldHover,
		[classes.boolElementNameHover]: isBoolElement && shouldHover,
		[classes.intElementNameHover]: isAnyIntElement && shouldHover,
		[classes.floatElementNameHover]: isAnyFloatElement && shouldHover
	});

	const handleDeleteButtonClick = () => {
		if (props.onElementDeleted) {
			props.onElementDeleted();
		}
	};

	const handleElementClick = () => {
		setIsExpanded(prev => !prev);
	};

	const deleteButton = props.isEditable ? (
		<IconButton className={classes.deleteButton} onClick={handleDeleteButtonClick}>
			<DeleteIcon fontSize="small" className={deleteIconClassName} />
		</IconButton>
	) : null;

	const data = buildEmptyAddInputOutputElementData();
	data.type = props.element.type;
	data.description = props.element.description;

	if (constStringElement) {
		data.constString = constStringElement.value;
	} else if (stringElement) {
		data.varName = stringElement.name;
		data.stringMinLength = stringElement.minLength;
		data.stringMaxLength = stringElement.maxLength;
		data.stringBigLetters = stringElement.hasBigLetters;
		data.stringSmallLetters = stringElement.hasSmallLetters;
		data.stringDigits = stringElement.hasDigits;
		data.stringSymbols = stringElement.hasSymbols;
	} else if (boolElement) {
		data.varName = boolElement.name;
	} else if (intElement) {
		data.varName = intElement.name;
		data.minValue = intElement.minValue;
		data.maxValue = intElement.maxValue;
		data.excludeZero = intElement.excludeZero;
	} else if (floatElement) {
		data.varName = floatElement.name;
		data.minValue = floatElement.minValue;
		data.maxValue = floatElement.maxValue;
		data.excludeZero = floatElement.excludeZero;
	}

	const editButton = props.isEditable ? (
		<CilAddInputOutputElementButton
			className={classes.deleteButton}
			iconClassName={deleteIconClassName}
			action="edit"
			variant={props.variant as 'input' | 'output'}
			existingData={data}
			onElementEdited={props.onElementEdited}
		/>
	) : null;

	return (
		<div className={elementClassName}>
			{constStringElement ? (
				<div className={elementNameClassName} onClick={handleElementClick}>
					{constStringElement.value}
				</div>
			) : null}

			{stringElement ? (
				<>
					<div className={elementNameClassName} onClick={handleElementClick}>
						{stringElement.name}
					</div>
					{props.variant === 'input' && isExpanded ? (
						<div className={elementInfoClassName}>
							{stringElement.type === 'String' ? (
								<span>
									|{stringElement.name}| &#8714; [{stringElement.minLength}; {stringElement.maxLength}],{' '}
								</span>
							) : null}

							<span>
								{stringElement.name}
								{stringElement.type === 'String' ? <sub>{translations.tests.chars}</sub> : null} &#8714;
							</span>

							{' ['}
							{stringElement.hasBigLetters ? <span>{translations.shared.bigLetters}</span> : null}
							{stringElement.hasSmallLetters ? <span>{translations.shared.smallLetters}</span> : null}
							{stringElement.hasDigits ? <span>{translations.shared.digits}</span> : null}
							{stringElement.hasSymbols ? <span>{translations.shared.otherSymbols}</span> : null}
							{']'}
						</div>
					) : null}
				</>
			) : null}

			{boolElement ? (
				<>
					<div className={elementNameClassName} onClick={handleElementClick}>
						{boolElement.name}
					</div>
				</>
			) : null}

			{intElement ? (
				<>
					<div className={elementNameClassName} onClick={handleElementClick}>
						{intElement.name}
					</div>

					{props.variant === 'input' && isExpanded ? (
						<div className={elementInfoClassName}>
							<span>
								{getIntElementTypeName(intElement)}, {intElement.name} &#8714; [{intElement.minValue},{' '}
								{intElement.maxValue}]{intElement.excludeZero ? <>, {intElement.name} &#8800; 0</> : null}
							</span>
						</div>
					) : null}
				</>
			) : null}

			{floatElement ? (
				<>
					<div className={elementNameClassName} onClick={handleElementClick}>
						{floatElement.name}
					</div>

					{props.variant === 'input' && isExpanded ? (
						<div className={elementInfoClassName}>
							<span>
								{getFloatElementTypeName(floatElement)}, {floatElement.name} &#8714; [{floatElement.minValue},{' '}
								{floatElement.maxValue}]{floatElement.excludeZero ? <>, {floatElement.name} &#8800; 0</> : null}
							</span>
						</div>
					) : null}
				</>
			) : null}

			{editButton && deleteButton ? (
				<div className={elementInfoClassName}>
					{editButton}
					{deleteButton}
				</div>
			) : null}

			{props.variant === 'output' && props.element.description ? (
				<div className={elementInfoClassName}>{props.element.description}</div>
			) : null}

			{props.variant === 'custom' && props.element.type !== 'ConstString' ? (
				<div className={elementInfoClassName}>{props.children}</div>
			) : null}
		</div>
	);
};

export default CilInputOutputElement;
