import React, { ChangeEvent, FunctionComponent, useState } from 'react';

import { FormControl, MenuItem, Select, Theme, Typography } from '@material-ui/core';
import CheckIcon from '@material-ui/icons/CheckRounded';
import EditIcon from '@material-ui/icons/EditRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import { makeStyles } from '@material-ui/styles';

import translations from '../../translations/translations';
import CilIconButton from './CilIconButton';

const useStyles = makeStyles((theme: Theme) => ({
	fieldValueTypography: {
		fontSize: '1rem',
		marginRight: '10px'
	},
	formControlContainer: {
		flexGrow: 1,
		flexBasis: 0,
		display: 'flex',
		alignItems: 'center'
	}
}));

export interface SelectOption {
	label: string;
	value: string;
}

interface CilEditableSelectProps {
	options: SelectOption[];
	selectedValue?: string;
	onValueChange: (newValue: string) => void;
	isEditable?: boolean;
}

const CilEditableSelect: FunctionComponent<CilEditableSelectProps> = props => {
	const classes = useStyles();

	const [isEditable, setIsEditable] = useState<boolean>(false);
	const [value, setValue] = useState<string>(props.selectedValue || '');

	const selectedValues = props.options.filter(o => o.value === props.selectedValue);
	const selectedValue = selectedValues.length > 0 ? selectedValues[0] : null;
	const selectedLabel = selectedValue ? selectedValue.label : translations.shared.noInfo;

	const handleChange = (e: ChangeEvent<HTMLSelectElement>) => {
		const newValue = e.target.value;
		setValue(newValue);
	};

	const handleEditButtonClick = () => {
		setValue(props.selectedValue || '');
		setIsEditable(true);
		return Promise.resolve();
	};

	const handleSelectClose = () => {
		setIsEditable(false);
	};

	const handleOkButtonClick = () => {
		props.onValueChange(value);
		setIsEditable(false);
		return Promise.resolve();
	};

	const handleCancelButtonClick = () => {
		setIsEditable(false);
		return Promise.resolve();
	};

	return isEditable ? (
		<div className={classes.formControlContainer}>
			<FormControl>
				<Select fullWidth={true} onChange={handleChange} value={value} onClose={handleSelectClose}>
					{props.options.map(option => (
						<MenuItem key={option.value} value={option.value}>
							{option.label}
						</MenuItem>
					))}
				</Select>
			</FormControl>
			<CilIconButton onClick={handleOkButtonClick}>
				<CheckIcon fontSize="small" />
			</CilIconButton>
			<CilIconButton onClick={handleCancelButtonClick}>
				<NotCheckIcon fontSize="small" />
			</CilIconButton>
		</div>
	) : (
		<>
			<Typography className={classes.fieldValueTypography}>{selectedLabel}</Typography>
			{props.isEditable ? (
				<CilIconButton onClick={handleEditButtonClick}>
					<EditIcon fontSize="small" />
				</CilIconButton>
			) : null}
		</>
	);
};

CilEditableSelect.defaultProps = {
	isEditable: true
};

export default CilEditableSelect;
