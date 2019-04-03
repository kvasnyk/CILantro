import React, { ChangeEvent, FunctionComponent, useState } from 'react';

import { TextField, Theme, Typography } from '@material-ui/core';
import AddIcon from '@material-ui/icons/AddRounded';
import CheckIcon from '@material-ui/icons/CheckRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import ReplayIcon from '@material-ui/icons/ReplayRounded';
import { makeStyles } from '@material-ui/styles';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilCodeEditor from '../../utils/CilCodeEditor';
import CilIconButton from '../../utils/CilIconButton';
import CilInputOutputElement from '../../utils/CilInputOutputElement';

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
	newExampleName: {
		display: 'flex',
		flexDirection: 'row'
	},
	newExampleIoEditor: {
		display: 'flex',
		flexDirection: 'row'
	},
	newExampleNameField: {
		marginRight: '10px'
	},
	newExampleInput: {
		flexGrow: 1,
		flexBasis: 0,
		display: 'flex',
		alignItems: 'center',
		borderRadius: '5px',
		padding: '5px',
		fontFamily: 'Consolas',
		fontSize: '1rem',
		marginRight: '5px',
		minHeight: '50px'
	},
	newExampleEmptyInput: {
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center',
		fontStyle: 'italic'
	},
	newExampleOutput: {
		flexGrow: 1,
		flexBasis: 0,
		display: 'flex',
		alignItems: 'center',
		justifyContent: 'center',
		marginLeft: '5px'
	},
	newExamplePopulate: {
		margin: '0 10px'
	},
	exampleName: {
		marginBottom: '5px'
	},
	exampleInputOutput: {
		display: 'flex',
		flexDirection: 'row',
		marginBottom: '25px'
	},
	exampleInput: {
		flexGrow: 1,
		flexBasis: 0,
		marginRight: '5px'
	},
	exampleInputLine: {
		display: 'flex',
		flexDirection: 'row'
	},
	exampleOutput: {
		flexGrow: 1,
		flexBasis: 0,
		marginLeft: '5px'
	},
	elementInput: {
		color: theme.palette.common.white,
		fontSize: '0.8rem',
		background: 'inherit',
		border: 'none',
		outline: 'none',
		width: '100px'
	}
}));

interface CilTestInputOutputExamplesEditorProps {
	test: TestReadModel;
	onExampleAdded: () => void;
}

const CilTestInputOutputExamplesEditor: FunctionComponent<CilTestInputOutputExamplesEditorProps> = props => {
	const testsApiClient = new TestsApiClient();

	const [inputs, setInputs] = useState<string[][]>(
		props.test.hasEmptyInput ? [] : props.test.input!.lines.map(inputLine => inputLine.elements.map(element => ''))
	);

	const classes = useStyles();

	const notistack = useNotistack();

	const nextExampleNumber = 1;

	const getNextExampleName = () => {
		return `Example ${nextExampleNumber}`;
	};

	const [isNewExampleEditorOpen, setIsNewExampleEditorOpen] = useState<boolean>(false);
	const [newExampleName, setNewExampleName] = useState<string>(getNextExampleName());
	const [isNewOutputPopulated, setIsNewOutputPopulated] = useState<boolean>(false);
	const [newExampleOutput, setNewExampleOutput] = useState<string>('');

	const buildNewInput = () => {
		if (props.test.hasEmptyInput) {
			return '';
		}

		let result = '';
		for (const line of inputs) {
			for (const elementValue of line) {
				result += elementValue;
			}
			result += '\n';
		}
		return result;
	};

	const handleInputsChange = (
		i: number,
		j: number,
		e: ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>
	) => {
		const newValue = e.target.value;

		setInputs(prevInputs => {
			const result = [...prevInputs];
			result[i][j] = newValue;
			return result;
		});
		setIsNewOutputPopulated(false);
	};

	const clearNewExample = () => {
		setIsNewOutputPopulated(false);
		setNewExampleOutput('');
		setNewExampleName(getNextExampleName());
	};

	const handleAddButtonClick = () => {
		setIsNewExampleEditorOpen(true);
		return Promise.resolve();
	};

	const handleNewExampleNameChange = (e: ChangeEvent<HTMLInputElement>) => {
		setNewExampleName(e.target.value);
	};

	const handleNewExampleOkButtonClick = async () => {
		try {
			await testsApiClient.addTestInputOutputExample(props.test.id, {
				name: newExampleName,
				input: buildNewInput(),
				output: newExampleOutput
			});
			setIsNewExampleEditorOpen(false);
			clearNewExample();
			props.onExampleAdded();
			notistack.enqueueSuccess(translations.tests.ioExampleHasBeenAdded);
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileAddingIoExample);
		}
	};

	const handleNewExampleCancelButtonClick = () => {
		setIsNewExampleEditorOpen(false);
		clearNewExample();
		return Promise.resolve();
	};

	const handlePopulateNewOutputButtonClick = async () => {
		try {
			const newInput = buildNewInput();
			const generateOutputResponse = await testsApiClient.generateOutput(props.test.id, { input: newInput });
			const newOutput = generateOutputResponse.data;
			setNewExampleOutput(newOutput);
			setIsNewOutputPopulated(true);
			notistack.enqueueSuccess(translations.tests.outputHasBeenGenerated);
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileGeneratingOutput);
		}
	};

	let newExampleOkButtonDisabledReason;
	if (newExampleName === '') {
		newExampleOkButtonDisabledReason = translations.tests.exampleNameIsEmpty;
	} else if (!isNewOutputPopulated) {
		newExampleOkButtonDisabledReason = translations.tests.noOutputGenerated;
	}

	return (
		<>
			<div className={classes.titleWrapper}>
				<Typography variant="h5" className={classes.titleTypography}>
					{translations.tests.testIOExamples}
				</Typography>
				{!isNewExampleEditorOpen ? (
					<CilIconButton onClick={handleAddButtonClick}>
						<AddIcon />
					</CilIconButton>
				) : null}
			</div>

			{props.test.ioExamples.map(e => (
				<>
					<Typography variant="h6" className={classes.exampleName}>
						{e.name}
					</Typography>
					<div className={classes.exampleInputOutput}>
						<div className={classes.exampleInput}>
							<CilCodeEditor code={e.input} />
						</div>
						<div className={classes.exampleOutput}>
							<CilCodeEditor code={e.output} />
						</div>
					</div>
				</>
			))}

			{isNewExampleEditorOpen ? (
				<>
					<div className={classes.newExampleName}>
						<TextField
							value={newExampleName}
							onChange={handleNewExampleNameChange}
							autoFocus={true}
							className={classes.newExampleNameField}
						/>
						<CilIconButton onClick={handleNewExampleOkButtonClick} disabledReason={newExampleOkButtonDisabledReason}>
							<CheckIcon fontSize="small" />
						</CilIconButton>
						<CilIconButton onClick={handleNewExampleCancelButtonClick}>
							<NotCheckIcon fontSize="small" />
						</CilIconButton>
					</div>

					<div className={classes.newExampleIoEditor}>
						<div className={classes.newExampleInput}>
							{props.test.hasEmptyInput ? (
								<div className={classes.newExampleEmptyInput}>{translations.tests.emptyInput}</div>
							) : (
								<>
									{props.test.input!.lines.map((inputLine, index) => (
										<div key={index} className={classes.exampleInputLine}>
											{inputLine.elements.map((element, elementIndex) => (
												<CilInputOutputElement key={elementIndex} variant="custom" element={element}>
													<input
														type="text"
														className={classes.elementInput}
														value={inputs[index][elementIndex]}
														onChange={e => handleInputsChange(index, elementIndex, e)}
													/>
												</CilInputOutputElement>
											))}
										</div>
									))}
								</>
							)}
						</div>
						<div className={classes.newExampleOutput}>
							{isNewOutputPopulated ? (
								<CilCodeEditor code={newExampleOutput} />
							) : (
								<div className={classes.newExamplePopulate}>
									<CilIconButton onClick={handlePopulateNewOutputButtonClick}>
										<ReplayIcon fontSize="small" />
									</CilIconButton>
								</div>
							)}
						</div>
					</div>
				</>
			) : null}
		</>
	);
};

export default CilTestInputOutputExamplesEditor;
