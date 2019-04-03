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
}

const buildEmptyAddInputOutputElementData = (): AddInputOutputElementData => ({
	type: 'ConstString'
});

const validateAddInputOutputElementData = (formData: AddInputOutputElementData) => {
	const isConstString = formData.type === 'ConstString';
	const isString = formData.type === 'String';

	const hasMinMaxLengthError =
		formData.stringMinLength !== undefined &&
		formData.stringMaxLength !== undefined &&
		formData.stringMinLength > formData.stringMaxLength;

	const hasAnySymbols = formData.stringBigLetters || formData.stringSmallLetters || formData.stringDigits;

	const hasVarName = formData.varName !== undefined && formData.varName !== ' ';

	return {
		constString: isConstString && !formData.constString,
		varName: isString && !hasVarName,
		stringMinLength: isString && (!formData.stringMinLength || hasMinMaxLengthError || formData.stringMinLength < 1),
		stringMaxLength: isString && (!formData.stringMaxLength || hasMinMaxLengthError),
		stringSymbols: isString && !hasAnySymbols
	};
};

interface CilAddInputOutputElementButtonProps {
	onElementAdded: (element: AbstractInputOutputElement) => void;
}

const CilAddInputOutputElementButton: FunctionComponent<CilAddInputOutputElementButtonProps> = props => {
	const classes = useStyles();

	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);
	const [formData, setFormData] = useState<AddInputOutputElementData>(buildEmptyAddInputOutputElementData());

	const formErrors = validateAddInputOutputElementData(formData);

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
			type: e.target.value
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
		} else if (formData.type === 'String') {
			addElement({
				type: 'String',
				name: formData.varName!,
				minLength: formData.stringMinLength!,
				maxLength: formData.stringMaxLength!,
				hasBigLetters: formData.stringBigLetters!,
				hasSmallLetters: formData.stringSmallLetters!,
				hasDigits: formData.stringDigits!
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
								<MenuItem value="ConstString">{translations.tests.ioElement_ConstString}</MenuItem>
								<MenuItem value="String">{translations.tests.ioElement_String}</MenuItem>
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

						{formData.type === 'String' ? (
							<>
								<TextField
									label={translations.shared.name}
									value={formData.varName}
									fullWidth={true}
									onChange={handleVarNameChange}
									error={formErrors.varName}
								/>

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
									</FormGroup>
								</FormControl>
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
