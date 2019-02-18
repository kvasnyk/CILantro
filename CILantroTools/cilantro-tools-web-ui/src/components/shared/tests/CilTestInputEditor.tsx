import React, { ChangeEvent, FunctionComponent, useState } from 'react';

import { Checkbox, IconButton, Theme, Typography } from '@material-ui/core';
import CheckIcon from '@material-ui/icons/CheckRounded';
import EditIcon from '@material-ui/icons/EditRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import { makeStyles } from '@material-ui/styles';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilDetailsRow from '../../utils/CilDetailsRow';

const useStyles = makeStyles((theme: Theme) => ({
	titleWrapper: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		marginBottom: '10px'
	},
	titleTypography: {
		marginRight: '10px'
	}
}));

interface CilTestInputEditorProps {
	test: TestReadModel;
	onInputUpdated: () => void;
}

const CilTestInputEditor: FunctionComponent<CilTestInputEditorProps> = props => {
	const testsApiClient = new TestsApiClient();

	const classes = useStyles();

	const notistack = useNotistack();

	const [isEditable, setIsEditable] = useState<boolean>(false);
	const [hasEmptyInput, setHasEmptyInput] = useState<boolean>(props.test.hasEmptyInput);

	const editTestInput = async () => {
		try {
			await testsApiClient.editTestInput(props.test.id, {
				hasEmptyInput
			});
			notistack.enqueueSuccess(translations.tests.inputHasBeenUpdated);
			props.onInputUpdated();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileUpdatingInput);
		}
	};

	const handleEditButtonClick = () => {
		setIsEditable(true);
	};

	const handleOkButtonClick = () => {
		editTestInput();
		setIsEditable(false);
	};

	const handleCancelButtonClick = () => {
		setHasEmptyInput(props.test.hasEmptyInput);
		setIsEditable(false);
	};

	const handleHasEmptyInputChange = (event: ChangeEvent<HTMLInputElement>) => {
		setHasEmptyInput(event.target.checked);
	};

	return (
		<>
			<div className={classes.titleWrapper}>
				<Typography variant="h5" className={classes.titleTypography}>
					{translations.tests.testInput}
				</Typography>

				{!isEditable ? (
					<IconButton onClick={handleEditButtonClick}>
						<EditIcon fontSize="small" />
					</IconButton>
				) : null}

				{isEditable ? (
					<>
						<IconButton onClick={handleOkButtonClick}>
							<CheckIcon fontSize="small" />
						</IconButton>
						<IconButton onClick={handleCancelButtonClick}>
							<NotCheckIcon fontSize="small" />
						</IconButton>
					</>
				) : null}
			</div>

			<CilDetailsRow label={translations.tests.emptyInput}>
				{isEditable ? <Checkbox checked={hasEmptyInput} onChange={handleHasEmptyInputChange} /> : null}
				{!isEditable ? (
					props.test.hasEmptyInput ? (
						<CheckIcon fontSize="small" />
					) : (
						<NotCheckIcon fontSize="small" />
					)
				) : null}
			</CilDetailsRow>
		</>
	);
};

export default CilTestInputEditor;
