import React, { ChangeEvent, FunctionComponent, useState } from 'react';

import { Checkbox, IconButton } from '@material-ui/core';
import CheckIcon from '@material-ui/icons/CheckRounded';
import EditIcon from '@material-ui/icons/EditRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';

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
	};

	const handleCheckboxChange = (event: ChangeEvent<HTMLInputElement>) => {
		setValue(event.target.checked);
	};

	const handleOkButtonClick = () => {
		setIsEditable(false);
		props.onValueChange(value);
	};

	const handleCancelButtonClick = () => {
		setIsEditable(false);
	};

	return isEditable ? (
		<>
			<Checkbox checked={value} onChange={handleCheckboxChange} />
			<IconButton>
				<CheckIcon fontSize="small" onClick={handleOkButtonClick} />
			</IconButton>
			<IconButton>
				<NotCheckIcon fontSize="small" onClick={handleCancelButtonClick} />
			</IconButton>
		</>
	) : (
		<>
			{props.isChecked ? <CheckIcon fontSize="small" /> : <NotCheckIcon fontSize="small" />}
			<IconButton onClick={handleEditButtonClick}>
				<EditIcon fontSize="small" />
			</IconButton>
		</>
	);
};

export default CilEditableCheckbox;
