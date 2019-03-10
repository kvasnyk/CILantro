import { cloneDeep } from 'lodash';
import React, { FunctionComponent, useState } from 'react';

import { Theme, Typography } from '@material-ui/core';
import CheckIcon from '@material-ui/icons/CheckRounded';
import EditIcon from '@material-ui/icons/EditRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import { makeStyles } from '@material-ui/styles';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import AbstractInputOutputElement from '../../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import InputOutput from '../../../api/models/tests/input-output/InputOutput';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilIconButton from '../../utils/CilIconButton';
import CilInputOutputEditor from '../../utils/CilInputOutputEditor';

const getDefaultOutput = (output?: InputOutput) => {
	if (output) {
		return cloneDeep(output);
	}

	return {
		lines: [
			{
				elements: []
			}
		]
	};
};

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

interface CilTestOutputEditorProps {
	test: TestReadModel;
	onOutputUpdated: () => void;
}

const CilTestOutputEditor: FunctionComponent<CilTestOutputEditorProps> = props => {
	const testsApiClient = new TestsApiClient();

	const classes = useStyles();

	const notistack = useNotistack();

	const [isEditable, setIsEditable] = useState<boolean>(false);
	const [output, setOutput] = useState<InputOutput>(getDefaultOutput(props.test.output));

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
		return Promise.resolve();
	};

	const handleOkButtonClick = () => {
		editTestOutput();
		setIsEditable(false);
		return Promise.resolve();
	};

	const handleCancelButtonClick = () => {
		setOutput(getDefaultOutput(props.test.output));
		setIsEditable(false);
		return Promise.resolve();
	};

	const handleElementAdded = (lineIndex: number, element: AbstractInputOutputElement) => {
		const newOutput = cloneDeep(output);
		newOutput.lines[lineIndex].elements.push(element);
		setOutput(newOutput);
	};

	return (
		<>
			<div className={classes.titleWrapper}>
				<Typography variant="h5" className={classes.titleTypography}>
					{translations.tests.testOutput}
				</Typography>

				{!isEditable ? (
					<CilIconButton onClick={handleEditButtonClick}>
						<EditIcon fontSize="small" />
					</CilIconButton>
				) : null}

				{isEditable ? (
					<>
						<CilIconButton onClick={handleOkButtonClick}>
							<CheckIcon fontSize="small" />
						</CilIconButton>
						<CilIconButton onClick={handleCancelButtonClick}>
							<NotCheckIcon fontSize="small" />
						</CilIconButton>
					</>
				) : null}
			</div>

			<CilInputOutputEditor inputOutput={output} onElementAdded={handleElementAdded} isReadonly={!isEditable} />
		</>
	);
};

export default CilTestOutputEditor;
