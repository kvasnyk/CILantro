import React, { ChangeEvent, FunctionComponent, useState } from 'react';

import { TextField, Theme, Typography } from '@material-ui/core';
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
	}
}));

interface CilEditableTextFieldProps {
	value: string;
	onValueChange: (value: string) => void;
}

const CilEditableTextField: FunctionComponent<CilEditableTextFieldProps> = props => {
	const classes = useStyles();

	const [isEditable, setIsEditable] = useState<boolean>(false);
	const [value, setValue] = useState<string>(props.value);

	const handleEditButtonClick = () => {
		setValue(props.value);
		setIsEditable(true);
		return Promise.resolve();
	};

	const handleOkButtonClick = () => {
		setIsEditable(false);
		props.onValueChange(value);
		return Promise.resolve();
	};

	const handleCancelButtonClick = () => {
		setIsEditable(false);
		return Promise.resolve();
	};

	const handleTextFieldChange = (event: ChangeEvent<HTMLInputElement>) => {
		const newValue = event.target.value;
		setValue(newValue);
	};

	return isEditable ? (
		<>
			<TextField value={value} onChange={handleTextFieldChange} fullWidth={true} />
			<CilIconButton onClick={handleOkButtonClick}>
				<CheckIcon fontSize="small" />
			</CilIconButton>
			<CilIconButton onClick={handleCancelButtonClick}>
				<NotCheckIcon fontSize="small" />
			</CilIconButton>
		</>
	) : (
		<>
			<Typography className={classes.fieldValueTypography}>{props.value || translations.shared.noInfo}</Typography>
			<CilIconButton onClick={handleEditButtonClick}>
				<EditIcon fontSize="small" />
			</CilIconButton>
		</>
	);
};

export default CilEditableTextField;
