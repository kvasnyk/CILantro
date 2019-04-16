import { cloneDeep } from 'lodash';
import React, { ChangeEvent, FunctionComponent, useState } from 'react';

import { Checkbox, Theme, Typography } from '@material-ui/core';
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
import CilDetailsRow from '../../utils/CilDetailsRow';
import CilIconButton from '../../utils/CilIconButton';
import CilInputOutputEditor from '../../utils/CilInputOutputEditor';

const getDefaultInput = (output?: InputOutput) => {
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
	},
	emptyInputContainer: {
		marginLeft: '50px'
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
	const [input, setInput] = useState<InputOutput>(getDefaultInput(props.test.input));

	const editTestInput = async () => {
		try {
			await testsApiClient.editTestInput(props.test.id, {
				hasEmptyInput,
				input
			});
			notistack.enqueueSuccess(translations.tests.inputHasBeenUpdated);
			props.onInputUpdated();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileUpdatingInput);
		}
	};

	const handleEditButtonClick = () => {
		setIsEditable(true);
		return Promise.resolve();
	};

	const handleOkButtonClick = () => {
		editTestInput();
		setIsEditable(false);
		return Promise.resolve();
	};

	const handleCancelButtonClick = () => {
		setHasEmptyInput(props.test.hasEmptyInput);
		setIsEditable(false);
		return Promise.resolve();
	};

	const handleHasEmptyInputChange = (event: ChangeEvent<HTMLInputElement>) => {
		setHasEmptyInput(event.target.checked);
	};

	const handleElementAdded = (lineIndex: number, element: AbstractInputOutputElement) => {
		const newInput = cloneDeep(input);
		newInput.lines[lineIndex].elements.push(element);
		setInput(newInput);
	};

	const handleElementDeleted = (lineIndex: number, elementIndex: number) => {
		const newInput = cloneDeep(input);
		newInput.lines[lineIndex].elements = newInput.lines[lineIndex].elements.filter(
			(el, elIndex) => elIndex !== elementIndex
		);
		setInput(newInput);
	};

	const handleLineAdded = () => {
		const newInput = cloneDeep(input);
		newInput.lines.push({
			elements: []
		});
		setInput(newInput);
	};

	return (
		<>
			<div className={classes.titleWrapper}>
				<Typography variant="h5" className={classes.titleTypography}>
					{translations.tests.testInput}
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

				<div className={classes.emptyInputContainer}>
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
				</div>
			</div>

			{!hasEmptyInput ? (
				<CilInputOutputEditor
					variant="input"
					inputOutput={input}
					onElementAdded={handleElementAdded}
					onElementDeleted={handleElementDeleted}
					onLineAdded={handleLineAdded}
					isReadonly={!isEditable}
				/>
			) : null}
		</>
	);
};

export default CilTestInputEditor;
