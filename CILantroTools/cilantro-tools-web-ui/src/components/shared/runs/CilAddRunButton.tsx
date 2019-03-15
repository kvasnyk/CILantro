import React, { ChangeEvent, FormEvent, FunctionComponent, useState } from 'react';

import {
	Button,
	Dialog,
	DialogActions,
	DialogContent,
	DialogTitle,
	Fab,
	FormControl,
	InputLabel,
	MenuItem,
	Select,
	Theme
} from '@material-ui/core';
import { green } from '@material-ui/core/colors';
import AddIcon from '@material-ui/icons/AddRounded';
import { makeStyles } from '@material-ui/styles';

import RunType from '../../../api/enums/RunType';
import translations from '../../../translations/translations';

interface AddRunData {
	type: RunType;
}

const buildEmptyAddRunData = (): AddRunData => ({
	type: RunType.Full
});

const useStyles = makeStyles((theme: Theme) => ({
	fab: {
		backgroundColor: green[500],
		color: theme.palette.primary.contrastText,
		'&:hover': {
			backgroundColor: green[700]
		}
	}
}));

interface CilAddRunButtonProps {
	onRunAdded: () => void;
}

const CilAddRunButton: FunctionComponent<CilAddRunButtonProps> = props => {
	const classes = useStyles();

	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);
	const [formData, setFormData] = useState<AddRunData>(buildEmptyAddRunData());

	const handleButtonClick = () => {
		setIsDialogOpen(true);
	};

	const handleDialogClose = () => {
		setIsDialogOpen(false);
	};

	const handleTypeSelectValueChange = (e: ChangeEvent<HTMLSelectElement>) => {
		setFormData(prevFormData => ({
			...prevFormData,
			type: parseInt(e.target.value, 10)
		}));
	};

	const handleFormSubmit = async (e: FormEvent) => {
		e.preventDefault();
	};

	return (
		<>
			<Fab className={classes.fab} onClick={handleButtonClick}>
				<AddIcon />
			</Fab>

			<Dialog open={isDialogOpen} onClose={handleDialogClose} fullWidth={true}>
				<form onSubmit={handleFormSubmit}>
					<DialogTitle>{translations.runs.newRun}</DialogTitle>
					<DialogContent>
						<FormControl fullWidth={true}>
							<InputLabel htmlFor="type-select">{translations.runs.type}</InputLabel>
							<Select fullWidth={true} value={formData.type} autoFocus={true} onChange={handleTypeSelectValueChange}>
								<MenuItem value={RunType.Full}>{translations.runs.full}</MenuItem>
								<MenuItem value={RunType.Quick}>{translations.runs.quick}</MenuItem>
							</Select>
						</FormControl>
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

export default CilAddRunButton;
