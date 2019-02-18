import React, { FunctionComponent, useState } from 'react';

import { IconButton, Theme, Typography } from '@material-ui/core';
import CheckIcon from '@material-ui/icons/CheckRounded';
import EditIcon from '@material-ui/icons/EditRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import { makeStyles } from '@material-ui/styles';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import InputOutput from '../../../api/models/tests/input-output/InputOutput';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilInputOutputEditor from '../../utils/CilInputOutputEditor';

const useStyles = makeStyles((theme: Theme) => ({
	titleWrapper: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center'
	},
	titleTypography: {
		marginRight: '10px'
	}
}));

interface CilTestOutputEditorProps {
	test: TestReadModel;
	onOutputUpdated: () => void;
}

const CilTestOutputEditor: FunctionComponent<CilTestOutputEditorProps> = props => {
	const testsApiClient = new TestsApiClient();

	const classes = useStyles();

	const notistack = useNotistack();

	const [isEditable, setIsEditable] = useState<boolean>(true);
	const [output, setOutput] = useState<InputOutput>(props.test.output);

	const editTestOutput = async () => {
		try {
			await testsApiClient.editTestOutput(props.test.id, {
				output
			});
			notistack.enqueueSuccess(translations.tests.outputHasBeenUpdated);
			props.onOutputUpdated();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileUpdatingOutput);
		}
	};

	const handleEditButtonClick = () => {
		setIsEditable(true);
	};

	const handleOkButtonClick = () => {
		editTestOutput();
		setIsEditable(false);
	};

	const handleCancelButtonClick = () => {
		setIsEditable(false);
	};

	const handleOutputEdited = (newOutput: InputOutput) => {
		setOutput(newOutput);
	};

	return (
		<>
			<div className={classes.titleWrapper}>
				<Typography variant="h5" className={classes.titleTypography}>
					{translations.tests.testOutput}
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

			{isEditable ? <CilInputOutputEditor onInputOutputEdited={handleOutputEdited} /> : null}
		</>
	);
};

export default CilTestOutputEditor;
