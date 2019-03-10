import React, { ChangeEvent, FunctionComponent, useState } from 'react';

import { Checkbox } from '@material-ui/core';
import CheckIcon from '@material-ui/icons/CheckRounded';
import EditIcon from '@material-ui/icons/EditRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';

import CilIconButton from './CilIconButton';

interface CilEditableCheckboxProps {
	isChecked: boolean;
	onValueChange: (value: boolean) => void;
}

const CilEditableCheckbox: FunctionComponent<CilEditableCheckboxProps> = props => {
	const [isEditable, setIsEditable] = useState<boolean>(false);
	const [value, setValue] = useState<boolean>(props.isChecked);

	const handleEditButtonClick = () => {
		setValue(props.isChecked);
		setIsEditable(true);
		return Promise.resolve();
	};

	const handleCheckboxChange = (event: ChangeEvent<HTMLInputElement>) => {
		setValue(event.target.checked);
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

	return isEditable ? (
		<>
			<Checkbox checked={value} onChange={handleCheckboxChange} />
			<CilIconButton onClick={handleOkButtonClick}>
				<CheckIcon fontSize="small" />
			</CilIconButton>
			<CilIconButton onClick={handleCancelButtonClick}>
				<NotCheckIcon fontSize="small" />
			</CilIconButton>
		</>
	) : (
		<>
			{props.isChecked ? <CheckIcon fontSize="small" /> : <NotCheckIcon fontSize="small" />}
			<CilIconButton onClick={handleEditButtonClick}>
				<EditIcon fontSize="small" />
			</CilIconButton>
		</>
	);
};

export default CilEditableCheckbox;
