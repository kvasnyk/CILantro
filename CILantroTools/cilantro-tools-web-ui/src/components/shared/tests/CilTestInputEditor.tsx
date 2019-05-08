import { cloneDeep } from 'lodash';
import React, { ChangeEvent, FunctionComponent, useEffect, useState } from 'react';

import { Checkbox, Dialog, IconButton, List, ListItem, Theme, Typography } from '@material-ui/core';
import CheckIcon from '@material-ui/icons/CheckRounded';
import EditIcon from '@material-ui/icons/EditRounded';
import CopyIcon from '@material-ui/icons/FileCopyRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import { makeStyles } from '@material-ui/styles';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import AbstractInputOutputElement from '../../../api/models/tests/input-output/elements/AbstractInputOutputElement';
import InputOutput from '../../../api/models/tests/input-output/InputOutput';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import SearchDirection from '../../../api/search/SearchDirection';
import useNotistack from '../../../hooks/external/useNotistack';
import useSearch from '../../../hooks/useSearch';
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
	},
	testsNameTypography: {
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
	const [input, setInput] = useState<InputOutput>(getDefaultInput(props.test.input));
	const [isCopyInputDialogOpen, setIsCopyInputDialogOpen] = useState<boolean>(false);

	const testsSearch = useSearch<TestReadModel>({
		orderBy: {
			property: 'name',
			direction: SearchDirection.Asc
		},
		orderBy2: {
			property: 'name',
			direction: SearchDirection.Asc
		},
		pageSize: 999999,
		pageNumber: 1,
		filters: []
	});

	const editTestInput = async () => {
		try {
			await testsApiClient.editTestInput(props.test.id, {
				hasEmptyInput,
				input
			});
			notistack.enqueueSuccess(translations.tests.inputHasBeenUpdated);
			props.onInputUpdated();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileUpdatingInput, error);
		}
	};

	const refreshTests = async () => {
		try {
			const searchTestsResponse = await testsApiClient.searchTests(testsSearch.parameter);
			testsSearch.setResult(searchTestsResponse.data);
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileSearchingTests, error);
		}
	};

	useEffect(
		() => {
			refreshTests();
		},
		[testsSearch.parameter]
	);

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
		props.onInputUpdated();
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

	const handleElementEdited = (lineIndex: number, elementIndex: number, element: AbstractInputOutputElement) => {
		const newInput = cloneDeep(input);
		const newElement = cloneDeep(element);
		newInput.lines[lineIndex].elements[elementIndex] = newElement;
		setInput(newInput);
	};

	const handleLineAdded = () => {
		const newInput = cloneDeep(input);
		newInput.lines.push({
			elements: []
		});
		setInput(newInput);
	};

	const handleCopyInputDialogClose = () => {
		setIsCopyInputDialogOpen(false);
	};

	const handleCopyInputButtonClick = () => {
		setIsCopyInputDialogOpen(true);
	};

	const handleCopyInputFromTestButtonClick = async (sourceTestId: string) => {
		try {
			await testsApiClient.copyTestInput(props.test.id, { sourceTestId });
			notistack.enqueueSuccess(translations.tests.inputHasBeenUpdated);
			props.onInputUpdated();
			setIsCopyInputDialogOpen(false);
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileCopyingInput, error);
		}
	};

	useEffect(
		() => {
			if (props.test.input) {
				setInput(props.test.input);
			}
		},
		[props.test.input]
	);

	return (
		<>
			<div className={classes.titleWrapper}>
				<Typography variant="h5" className={classes.titleTypography}>
					{translations.tests.testInput}
				</Typography>

				{!isEditable ? (
					<>
						<CilIconButton onClick={handleEditButtonClick}>
							<EditIcon fontSize="small" />
						</CilIconButton>
						<IconButton onClick={handleCopyInputButtonClick}>
							<CopyIcon fontSize="small" />
						</IconButton>
						<Dialog open={isCopyInputDialogOpen} onClose={handleCopyInputDialogClose} fullWidth={true}>
							<List>
								{testsSearch.result.data.map(test => (
									<ListItem key={test.id}>
										<Typography className={classes.testsNameTypography}>{test.name}</Typography>
										<CilIconButton onClick={() => handleCopyInputFromTestButtonClick(test.id)}>
											<CopyIcon fontSize="small" />
										</CilIconButton>
									</ListItem>
								))}
							</List>
						</Dialog>
					</>
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
					onElementEdited={handleElementEdited}
					onElementDeleted={handleElementDeleted}
					onLineAdded={handleLineAdded}
					isReadonly={!isEditable}
				/>
			) : null}
		</>
	);
};

export default CilTestInputEditor;
