import React, { FunctionComponent, useState } from 'react';

import { Fab, Theme } from '@material-ui/core';
import { green } from '@material-ui/core/colors';
import QuickIcon from '@material-ui/icons/DirectionsRunRounded';
import FullIcon from '@material-ui/icons/HourglassEmptyRounded';
import { makeStyles } from '@material-ui/styles';

import RunsApiClient from '../../../api/clients/RunsApiClient';
import RunType from '../../../api/enums/RunType';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';

interface AddRunData {
	type: RunType;
}

const buildEmptyAddRunData = (type: RunType): AddRunData => ({
	type
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
	type: RunType;
	onRunAdded: () => void;
	testId?: string;
}

const CilAddRunButton: FunctionComponent<CilAddRunButtonProps> = props => {
	const runsApiClient = new RunsApiClient();

	const classes = useStyles();

	const notistack = useNotistack();

	// const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);
	const [formData, setFormData] = useState<AddRunData>(buildEmptyAddRunData(props.type));

	const handleButtonClick = () => {
		if (props.testId) {
			addSingleRun();
		} else {
			addRun();
		}
	};

	// const handleDialogClose = () => {
	// 	setIsDialogOpen(false);
	// };

	// const handleTypeSelectValueChange = (e: ChangeEvent<HTMLSelectElement>) => {
	// 	setFormData(prevFormData => ({
	// 		...prevFormData,
	// 		type: parseInt(e.target.value, 10)
	// 	}));
	// };

	const addRun = async () => {
		try {
			await runsApiClient.addRun(formData);
			notistack.enqueueSuccess(translations.runs.runHasBeenAdded);
			// setIsDialogOpen(false);
			setFormData(buildEmptyAddRunData(props.type));
			props.onRunAdded();
		} catch (error) {
			notistack.enqueueError(translations.runs.errorOccurredWhileAddingRun, error);
		}
	};

	const addSingleRun = async () => {
		try {
			await runsApiClient.addSingleTestRun({ ...formData, testId: props.testId! });
			notistack.enqueueSuccess(translations.runs.runHasBeenAdded);
			// setIsDialogOpen(false);
			setFormData(buildEmptyAddRunData(props.type));
			props.onRunAdded();
		} catch (error) {
			notistack.enqueueError(translations.runs.errorOccurredWhileAddingRun, error);
		}
	};

	return (
		<>
			<Fab className={classes.fab} onClick={handleButtonClick}>
				{props.type === RunType.Quick ? <QuickIcon /> : null}
				{props.type === RunType.Full ? <FullIcon /> : null}
			</Fab>

			{/* <Dialog open={isDialogOpen} onClose={handleDialogClose} fullWidth={true}>
				<form onSubmit={handleFormSubmit}>
					<DialogTitle>{translations.runs.newRun}</DialogTitle>
					<DialogContent>
						<FormControl fullWidth={true}>
							<InputLabel htmlFor="type-select">{translations.runs.type}</InputLabel>
							<Select fullWidth={true} value={formData.type} autoFocus={true} onChange={handleTypeSelectValueChange}>
								<MenuItem value={RunType.Quick}>{translations.runs.quick}</MenuItem>
								<MenuItem value={RunType.Full}>{translations.runs.full}</MenuItem>
							</Select>
						</FormControl>
					</DialogContent>
					<DialogActions>
						<Button color="primary" type="submit">
							{translations.shared.save}
						</Button>
					</DialogActions>
				</form>
			</Dialog> */}
		</>
	);
};

export default CilAddRunButton;
