import React, { ChangeEvent, FunctionComponent, useState } from 'react';

import { FormControl, IconButton, MenuItem, Select, Theme, Typography } from '@material-ui/core';
import EditIcon from '@material-ui/icons/EditRounded';
import { makeStyles } from '@material-ui/styles';

import translations from '../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
	fieldDetails: {
		width: '100%',
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'center',
		height: '50px'
	},
	fieldLabel: {
		width: '200px',
		flexBasis: 'auto'
	},
	fieldLabelTypography: {
		fontSize: '1rem',
		fontWeight: 500
	},
	fieldValue: {
		flexGrow: 1,
		flexBasis: 0,
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center'
	},
	fieldValueTypography: {
		fontSize: '1rem',
		marginRight: '10px'
	},
	formControl: {
		width: '300px'
	},
	formControlContainer: {
		flexGrow: 1,
		flexBasis: 0
	}
}));

export interface SelectOption {
	label: string;
	value: string;
}

interface CilEditableSelectProps {
	label: string;
	options: SelectOption[];
	selectedValue?: string;
	onValueChange: (newValue: string) => void;
}

const CilEditableSelect: FunctionComponent<CilEditableSelectProps> = props => {
	const classes = useStyles();

	const [isEditable, setIsEditable] = useState<boolean>(false);

	const selectedValues = props.options.filter(o => o.value === props.selectedValue);
	const selectedValue = selectedValues.length > 0 ? selectedValues[0] : null;
	const selectedLabel = selectedValue ? selectedValue.label : translations.shared.noInfo;

	const handleChange = (e: ChangeEvent<HTMLSelectElement>) => {
		const newValue = e.target.value;
		setIsEditable(false);
		props.onValueChange(newValue);
	};

	const handleEditButtonClick = () => {
		setIsEditable(true);
	};

	const handleSelectClose = () => {
		setIsEditable(false);
	};

	return (
		<div className={classes.fieldDetails}>
			<div className={classes.fieldLabel}>
				<Typography className={classes.fieldLabelTypography}>{props.label}</Typography>
			</div>

			{isEditable ? (
				<div className={classes.formControlContainer}>
					<FormControl className={classes.formControl}>
						<Select fullWidth={true} onChange={handleChange} value={props.selectedValue} open={isEditable} onClose={handleSelectClose}>
							{props.options.map(option => (
								<MenuItem value={option.value}>{option.label}</MenuItem>
							))}
						</Select>
					</FormControl>
				</div>
			) : (
				<div className={classes.fieldValue}>
					<Typography className={classes.fieldValueTypography}>{selectedLabel}</Typography>
					<IconButton onClick={handleEditButtonClick}>
						<EditIcon fontSize="small" />
					</IconButton>
				</div>
			)}
		</div>
	);
};

export default CilEditableSelect;
