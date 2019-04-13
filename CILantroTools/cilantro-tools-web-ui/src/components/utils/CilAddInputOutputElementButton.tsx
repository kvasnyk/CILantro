import React, { ChangeEvent, FormEvent, FunctionComponent, useState } from 'react';

import {
	Button,
	Checkbox,
	Dialog,
	DialogActions,
	DialogContent,
	FormControl,
	FormControlLabel,
	FormGroup,
	FormLabel,
	IconButton,
	InputLabel,
	MenuItem,
	Select,
	TextField,
	Theme
} from '@material-ui/core';
import PlusIcon from '@material-ui/icons/AddRounded';
import { makeStyles } from '@material-ui/styles';

import AbstractInputOutputElement from '../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import translations from '../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
	dialogContent: {
		'&>*': {
			marginBottom: '10px'
		}
	}
}));

interface AddInputOutputElementData {
	type: string;
	varName?: string;
	constString?: string;
	stringMinLength?: number;
	stringMaxLength?: number;
	stringBigLetters?: boolean;
	stringSmallLetters?: boolean;
	stringDigits?: boolean;
	stringSymbols?: boolean;
	minValue: number;
	maxValue: number;
	hasMinValueMinus: boolean;
	hasMaxValueMinus: boolean;
	hasMinValueComma: boolean;
	hasMaxValueComma: boolean;
}

const buildEmptyAddInputOutputElementData = (): AddInputOutputElementData => ({
	type: 'Bool',
	minValue: 0,
	maxValue: 0,
	hasMinValueMinus: false,
	hasMaxValueMinus: false,
	hasMinValueComma: false,
	hasMaxValueComma: false
});

const getMinValue = (type: string) => {
	switch (type) {
		case 'Byte':
			return 0;
		case 'Short':
			return -32768;
		case 'Int':
			return -2147483648;
		case 'Long':
			return Number.MIN_SAFE_INTEGER;
		case 'Sbyte':
			return -128;
		case 'Uint':
			return 0;
		case 'Ulong':
			return 0;
		case 'Ushort':
			return 0;
		case 'Float':
		case 'Double':
		case 'Decimal':
			return Number.MIN_SAFE_INTEGER;
		default:
			return 0;
	}
};

const getMaxValue = (type: string) => {
	switch (type) {
		case 'Byte':
			return 255;
		case 'Short':
			return 32767;
		case 'Int':
			return 2147483647;
		case 'Long':
			return Number.MAX_SAFE_INTEGER;
		case 'Sbyte':
			return 127;
		case 'Uint':
			return 4294967295;
		case 'Ulong':
			return Number.MAX_SAFE_INTEGER;
		case 'Ushort':
			return 65535;
		case 'Float':
		case 'Double':
		case 'Decimal':
			return Number.MAX_SAFE_INTEGER;
		default:
			return 0;
	}
};

const validateAddInputOutputElementData = (formData: AddInputOutputElementData, variant: 'input' | 'output') => {
	const isConstString = formData.type === 'ConstString';
	const isString = formData.type === 'String';
	const isBool = formData.type === 'Bool';
	const isByte = formData.type === 'Byte';
	const isShort = formData.type === 'Short';
	const isInt = formData.type === 'Int';
	const isLong = formData.type === 'Long';
	const isSbyte = formData.type === 'Sbyte';
	const isUint = formData.type === 'Uint';
	const isUlong = formData.type === 'Ulong';
	const isUShort = formData.type === 'Ushort';
	const isFloat = formData.type === 'Float';
	const isDouble = formData.type === 'Double';
	const isDecimal = formData.type === 'Decimal';
	const isChar = formData.type === 'Char';

	const isInput = variant === 'input';

	const hasMinMaxLengthError =
		formData.stringMinLength !== undefined &&
		formData.stringMaxLength !== undefined &&
		formData.stringMinLength > formData.stringMaxLength;

	const hasAnySymbols =
		formData.stringBigLetters || formData.stringSmallLetters || formData.stringDigits || formData.stringSymbols;

	const hasVarName = formData.varName !== undefined && formData.varName !== ' ';

	return {
		constString: isConstString && !formData.constString,
		varName:
			(isString ||
				isBool ||
				isByte ||
				isShort ||
				isInt ||
				isLong ||
				isSbyte ||
				isUint ||
				isUlong ||
				isUShort ||
				isFloat ||
				isDouble ||
				isDecimal ||
				isChar) &&
			!hasVarName,
		stringMinLength:
			isString && isInput && (!formData.stringMinLength || hasMinMaxLengthError || formData.stringMinLength < 1),
		stringMaxLength: isString && isInput && (!formData.stringMaxLength || hasMinMaxLengthError),
		stringSymbols: (isString || isChar) && isInput && !hasAnySymbols,
		minValue: formData.minValue > formData.maxValue,
		maxValue: formData.minValue > formData.maxValue
	};
};

interface CilAddInputOutputElementButtonProps {
	variant: 'input' | 'output';
	onElementAdded: (element: AbstractInputOutputElement) => void;
}

const CilAddInputOutputElementButton: FunctionComponent<CilAddInputOutputElementButtonProps> = props => {
	const classes = useStyles();

	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);
	const [formData, setFormData] = useState<AddInputOutputElementData>(buildEmptyAddInputOutputElementData());

	const formErrors = validateAddInputOutputElementData(formData, props.variant);

	const handleDialogClose = () => {
		setFormData(buildEmptyAddInputOutputElementData());
		setIsDialogOpen(false);
	};

	const handleClick = () => {
		setIsDialogOpen(true);
	};

	const handleTypeChange = (e: ChangeEvent<HTMLSelectElement>) => {
		setFormData(prevFormData => ({
			...prevFormData,
			type: e.target.value,
			minValue: getMinValue(e.target.value),
			maxValue: getMaxValue(e.target.value)
		}));
	};

	const handleVarNameChange = (e: ChangeEvent<HTMLInputElement>) => {
		const newVarName = e.target.value;
		setFormData(prevFormData => ({
			...prevFormData,
			varName: newVarName
		}));
	};

	const handleConstStringChange = (e: ChangeEvent<HTMLInputElement>) => {
		const newConstString = e.target.value;
		setFormData(prevFormData => ({
			...prevFormData,
			constString: newConstString
		}));
	};

	const handleStringMinLengthChange = (e: ChangeEvent<HTMLInputElement>) => {
		const newMinLength = parseInt(e.target.value, 10);
		setFormData(prevFormData => ({
			...prevFormData,
			stringMinLength: newMinLength
		}));
	};

	const handleStringMaxLengthChange = (e: ChangeEvent<HTMLInputElement>) => {
		const newMaxLength = parseInt(e.target.value, 10);
		setFormData(prevFormData => ({
			...prevFormData,
			stringMaxLength: newMaxLength
		}));
	};

	const handleMinValueChange = (e: ChangeEvent<HTMLInputElement>) => {
		if (e.target.value === '-') {
			setFormData(prevFormData => ({
				...prevFormData,
				hasMinValueMinus: true
			}));
			return;
		}

		if (e.target.value[e.target.value.length - 1] === ',') {
			setFormData(prevFormData => ({
				...prevFormData,
				hasMinValueComma: true
			}));
			return;
		}

		const newMinValue = parseInt(e.target.value, 10);
		setFormData(prevFormData => ({
			...prevFormData,
			minValue: Math.min(Math.max(newMinValue, getMinValue(prevFormData.type)), getMaxValue(prevFormData.type)),
			hasMinValueMinus: false,
			hasMinValueComma: false
		}));
	};

	const handleMaxValueChange = (e: ChangeEvent<HTMLInputElement>) => {
		if (e.target.value === '-') {
			setFormData(prevFormData => ({
				...prevFormData,
				hasMaxValueMinus: true
			}));
			return;
		}

		if (e.target.value[e.target.value.length - 1] === ',') {
			setFormData(prevFormData => ({
				...prevFormData,
				hasMaxValueComma: true
			}));
			return;
		}

		const newMaxValue = parseInt(e.target.value, 10);
		setFormData(prevFormData => ({
			...prevFormData,
			maxValue: Math.min(Math.max(newMaxValue, getMinValue(prevFormData.type)), getMaxValue(prevFormData.type)),
			hasMaxValueMinus: false,
			hasMaxValueComma: false
		}));
	};

	const handleFloatMinValueChange = (e: ChangeEvent<HTMLInputElement>) => {
		if (e.target.value === '-') {
			setFormData(prevFormData => ({
				...prevFormData,
				hasMinValueMinus: true
			}));
			return;
		}

		if (e.target.value[e.target.value.length - 1] === ',') {
			setFormData(prevFormData => ({
				...prevFormData,
				hasMinValueComma: true
			}));
			return;
		}

		const newMinValue = parseFloat(e.target.value.replace(',', '.'));
		setFormData(prevFormData => ({
			...prevFormData,
			minValue: Math.min(Math.max(newMinValue, getMinValue(prevFormData.type)), getMaxValue(prevFormData.type)),
			hasMinValueMinus: false,
			hasMinValueComma: false
		}));
	};

	const handleFloatMaxValueChange = (e: ChangeEvent<HTMLInputElement>) => {
		if (e.target.value === '-') {
			setFormData(prevFormData => ({
				...prevFormData,
				hasMaxValueMinus: true
			}));
			return;
		}

		if (e.target.value[e.target.value.length - 1] === ',') {
			setFormData(prevFormData => ({
				...prevFormData,
				hasMaxValueComma: true
			}));
			return;
		}

		const newMaxValue = parseFloat(e.target.value.replace(',', '.'));
		setFormData(prevFormData => ({
			...prevFormData,
			maxValue: Math.min(Math.max(newMaxValue, getMinValue(prevFormData.type)), getMaxValue(prevFormData.type)),
			hasMaxValueMinus: false,
			hasMaxValueComma: false
		}));
	};

	const handleStringBigLettersChange = (e: ChangeEvent<HTMLInputElement>) => {
		const newBigLetters = e.target.checked;
		setFormData(prevFormData => ({
			...prevFormData,
			stringBigLetters: newBigLetters
		}));
	};

	const handleStringSmallLettersChange = (e: ChangeEvent<HTMLInputElement>) => {
		const newSmallLetters = e.target.checked;
		setFormData(prevFormData => ({
			...prevFormData,
			stringSmallLetters: newSmallLetters
		}));
	};

	const handleStringDigitsChange = (e: ChangeEvent<HTMLInputElement>) => {
		const newDigits = e.target.checked;
		setFormData(prevFormData => ({
			...prevFormData,
			stringDigits: newDigits
		}));
	};

	const handleStringSymbolsChange = (e: ChangeEvent<HTMLInputElement>) => {
		const newSymbols = e.target.checked;
		setFormData(prevFormData => ({
			...prevFormData,
			stringSymbols: newSymbols
		}));
	};

	const addElement = (element: AbstractInputOutputElement) => {
		props.onElementAdded(element);
		setFormData(buildEmptyAddInputOutputElementData());
		setIsDialogOpen(false);
	};

	const handleFormSubmit = (e: FormEvent) => {
		e.preventDefault();

		if (Object.values(formErrors).some(value => value === true)) {
			return;
		}

		if (formData.type === 'ConstString') {
			addElement({
				type: 'ConstString',
				value: formData.constString!
			});
		} else if (formData.type === 'String' || formData.type === 'Char') {
			addElement({
				type: formData.type,
				name: formData.varName!,
				minLength: formData.stringMinLength!,
				maxLength: formData.stringMaxLength!,
				hasBigLetters: formData.stringBigLetters!,
				hasSmallLetters: formData.stringSmallLetters!,
				hasDigits: formData.stringDigits!,
				hasSymbols: formData.stringSymbols!
			});
		} else if (formData.type === 'Bool') {
			addElement({
				type: 'Bool',
				name: formData.varName!
			});
		} else if (
			formData.type === 'Byte' ||
			formData.type === 'Short' ||
			formData.type === 'Int' ||
			formData.type === 'Long' ||
			formData.type === 'Sbyte' ||
			formData.type === 'Uint' ||
			formData.type === 'Ulong' ||
			formData.type === 'Ushort'
		) {
			addElement({
				type: formData.type,
				name: formData.varName!,
				minValue: formData.minValue,
				maxValue: formData.maxValue
			});
		} else if (formData.type === 'Float' || formData.type === 'Double' || formData.type === 'Decimal') {
			addElement({
				type: formData.type,
				name: formData.varName!,
				minValue: formData.minValue,
				maxValue: formData.maxValue
			});
		}
	};

	return (
		<>
			<IconButton onClick={handleClick}>
				<PlusIcon fontSize="small" />
			</IconButton>
			<Dialog open={isDialogOpen} onClose={handleDialogClose} fullWidth={true}>
				<form onSubmit={handleFormSubmit}>
					<DialogContent className={classes.dialogContent}>
						<FormControl fullWidth={true}>
							<InputLabel htmlFor="type-select">{translations.shared.type}</InputLabel>
							<Select
								name="type-select"
								fullWidth={true}
								value={formData.type}
								autoFocus={true}
								onChange={handleTypeChange}
							>
								<MenuItem value="Bool">{translations.shared.type_bool}</MenuItem>
								<MenuItem value="Byte">{translations.shared.type_byte}</MenuItem>
								<MenuItem value="Char">{translations.shared.type_char}</MenuItem>
								<MenuItem value="ConstString">{translations.shared.type_const}</MenuItem>
								<MenuItem value="Decimal">{translations.shared.type_decimal}</MenuItem>
								<MenuItem value="Double">{translations.shared.type_double}</MenuItem>
								<MenuItem value="Float">{translations.shared.type_float}</MenuItem>
								<MenuItem value="Int">{translations.shared.type_int}</MenuItem>
								<MenuItem value="Long">{translations.shared.type_long}</MenuItem>
								<MenuItem value="Sbyte">{translations.shared.type_sbyte}</MenuItem>
								<MenuItem value="Short">{translations.shared.type_short}</MenuItem>
								<MenuItem value="String">{translations.shared.type_string}</MenuItem>
								<MenuItem value="Uint">{translations.shared.type_uint}</MenuItem>
								<MenuItem value="Ulong">{translations.shared.type_ulong}</MenuItem>
								<MenuItem value="Ushort">{translations.shared.type_ushort}</MenuItem>
							</Select>
						</FormControl>

						{formData.type === 'ConstString' ? (
							<TextField
								label={translations.shared.value}
								value={formData.constString}
								fullWidth={true}
								onChange={handleConstStringChange}
								error={formErrors.constString}
							/>
						) : null}

						{formData.type === 'String' || formData.type === 'Char' ? (
							<>
								<TextField
									label={translations.shared.name}
									value={formData.varName}
									fullWidth={true}
									onChange={handleVarNameChange}
									error={formErrors.varName}
								/>

								{props.variant === 'input' ? (
									<>
										{formData.type === 'String' ? (
											<>
												<TextField
													label={translations.shared.minLength}
													value={formData.stringMinLength}
													fullWidth={true}
													onChange={handleStringMinLengthChange}
													error={formErrors.stringMinLength}
													type="number"
												/>

												<TextField
													label={translations.shared.maxLength}
													value={formData.stringMaxLength}
													fullWidth={true}
													onChange={handleStringMaxLengthChange}
													error={formErrors.stringMaxLength}
													type="number"
												/>
											</>
										) : null}

										<FormControl fullWidth={true} error={formErrors.stringSymbols}>
											<FormLabel>{translations.shared.symbols}</FormLabel>
											<FormGroup>
												<FormControlLabel
													control={
														<Checkbox checked={formData.stringBigLetters} onChange={handleStringBigLettersChange}>
															{translations.shared.bigLetters}
														</Checkbox>
													}
													label={translations.shared.bigLetters}
												/>
												<FormControlLabel
													control={
														<Checkbox checked={formData.stringSmallLetters} onChange={handleStringSmallLettersChange}>
															{translations.shared.smallLetters}
														</Checkbox>
													}
													label={translations.shared.smallLetters}
												/>
												<FormControlLabel
													control={
														<Checkbox checked={formData.stringDigits} onChange={handleStringDigitsChange}>
															{translations.shared.digits}
														</Checkbox>
													}
													label={translations.shared.digits}
												/>
												<FormControlLabel
													control={
														<Checkbox checked={formData.stringSymbols} onChange={handleStringSymbolsChange}>
															{translations.shared.otherSymbols}
														</Checkbox>
													}
													label={translations.shared.otherSymbols}
												/>
											</FormGroup>
										</FormControl>
									</>
								) : null}
							</>
						) : null}

						{formData.type === 'Bool' ? (
							<TextField
								label={translations.shared.name}
								value={formData.varName}
								fullWidth={true}
								onChange={handleVarNameChange}
								error={formErrors.varName}
							/>
						) : null}

						{formData.type === 'Byte' ||
						formData.type === 'Short' ||
						formData.type === 'Int' ||
						formData.type === 'Long' ||
						formData.type === 'Sbyte' ||
						formData.type === 'Uint' ||
						formData.type === 'Ulong' ||
						formData.type === 'Ushort' ||
						formData.type === 'Float' ||
						formData.type === 'Double' ||
						formData.type === 'Decimal' ? (
							<>
								<TextField
									label={translations.shared.name}
									value={formData.varName}
									fullWidth={true}
									onChange={handleVarNameChange}
									error={formErrors.varName}
								/>

								{props.variant === 'input' ? (
									<>
										<TextField
											label={translations.shared.minValue}
											value={
												formData.hasMinValueMinus ? '-' : `${formData.minValue}${formData.hasMinValueComma ? ',' : ''}`
											}
											fullWidth={true}
											onChange={
												formData.type === 'Float' || formData.type === 'Double' || formData.type === 'Decimal'
													? handleFloatMinValueChange
													: handleMinValueChange
											}
											error={formErrors.minValue}
										/>

										<TextField
											label={translations.shared.maxValue}
											value={
												formData.hasMaxValueMinus ? '-' : `${formData.maxValue}${formData.hasMaxValueComma ? ',' : ''}`
											}
											fullWidth={true}
											onChange={
												formData.type === 'Float' || formData.type === 'Double' || formData.type === 'Decimal'
													? handleFloatMaxValueChange
													: handleMaxValueChange
											}
											error={formErrors.maxValue}
										/>
									</>
								) : null}
							</>
						) : null}
					</DialogContent>
					<DialogActions>
						<Button color="primary" type="submit">
							{translations.shared.save}
						</Button>
					</DialogActions>
				</form>
			</Dialog>
		</>
	);
};

export default CilAddInputOutputElementButton;
