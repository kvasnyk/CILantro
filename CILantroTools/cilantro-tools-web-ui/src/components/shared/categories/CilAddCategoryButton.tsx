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
	TextField,
	Theme
} from '@material-ui/core';
import green from '@material-ui/core/colors/green';
import AddIcon from '@material-ui/icons/AddRounded';
import { makeStyles } from '@material-ui/styles';

import CategoriesApiClient from '../../../api/clients/CategoriesApiClient';
import BaseLanguage from '../../../api/enums/BaseLanguage';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';

interface AddCategoryData {
	name: string;
	language: BaseLanguage;
}

const buildEmptyAddCategoryData = (): AddCategoryData => ({
	name: '',
	language: BaseLanguage.CIL
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

interface CilAddCategoryButtonProps {
	onCategoryAdded: () => void;
}

const CilAddCategoryButton: FunctionComponent<CilAddCategoryButtonProps> = props => {
	const classes = useStyles();

	const categoriesApiClient = new CategoriesApiClient();

	const notistack = useNotistack();

	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);
	const [formData, setFormData] = useState<AddCategoryData>(buildEmptyAddCategoryData());

	const handleButtonClick = () => {
		setIsDialogOpen(true);
	};

	const handleDialogClose = () => {
		setIsDialogOpen(false);
	};

	const handleNameChange = (e: ChangeEvent<HTMLInputElement>) => {
		setFormData({
			...formData,
			name: e.target.value
		});
	};

	const handleLanguageChange = (e: ChangeEvent<HTMLSelectElement>) => {
		const newValue = e.target.value;
		setFormData({
			...formData,
			language: (newValue as unknown) as BaseLanguage
		});
	};

	const handleFormSubmit = async (e: FormEvent) => {
		e.preventDefault();

		try {
			await categoriesApiClient.addCategory(formData);
			notistack.enqueueSuccess(translations.categories.categoryHasBeenAdded);
			setIsDialogOpen(false);
			setFormData(buildEmptyAddCategoryData());
			props.onCategoryAdded();
		} catch (error) {
			notistack.enqueueError(translations.categories.errorOccurredWhileAddingCategory, error);
		}
	};

	return (
		<>
			<Fab className={classes.fab} onClick={handleButtonClick}>
				<AddIcon />
			</Fab>

			<Dialog open={isDialogOpen} onClose={handleDialogClose} fullWidth={true}>
				<form onSubmit={handleFormSubmit}>
					<DialogTitle>{translations.categories.addCategory}</DialogTitle>
					<DialogContent>
						<TextField
							label={translations.categories.name}
							value={formData.name}
							onChange={handleNameChange}
							autoFocus={true}
							fullWidth={true}
						/>
						<br />
						<br />
						<FormControl fullWidth={true}>
							<InputLabel shrink={true}>{translations.categories.language}</InputLabel>
							<Select value={formData.language} fullWidth={true} onChange={handleLanguageChange}>
								<MenuItem value={BaseLanguage.CIL}>{translations.shared.CIL}</MenuItem>
								<MenuItem value={BaseLanguage.CSharp}>{translations.shared.CSharp}</MenuItem>
								<MenuItem value={BaseLanguage.FSharp}>{translations.shared.FSharp}</MenuItem>
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

export default CilAddCategoryButton;
