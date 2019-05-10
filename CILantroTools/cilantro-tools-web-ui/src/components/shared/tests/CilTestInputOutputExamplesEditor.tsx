import React, { ChangeEvent, FunctionComponent, useState } from 'react';

import { TextField, Theme, Typography } from '@material-ui/core';
import { grey } from '@material-ui/core/colors';
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
		flexDirection: 'column',
		borderRadius: '5px',
		padding: '5px',
		fontFamily: 'Consolas',
		fontSize: '1rem',
		marginRight: '20px',
		minHeight: '50px',
		'&>*': {
			marginBottom: '5px'
		}
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
		marginLeft: '20px'
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
	},
	repeatBlock: {
		display: 'flex',
		flexDirection: 'column'
	},
	header: {
		fontSize: '1rem',
		fontFamily: 'monospace',
		textTransform: 'uppercase',
		padding: '10px',
		backgroundColor: grey[500],
		borderRadius: '5px 5px 0 0',
		color: theme.palette.common.white,
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center'
	},
	content: {
		padding: '10px',
		borderLeft: `3px solid ${grey[500]}`,
		borderRight: `3px solid ${grey[500]}`,
		borderBottom: `3px solid ${grey[500]}`,
		borderRadius: '0 0 5px 5px'
	},
	repeatBlockInput: {
		marginLeft: '10px',
		width: '100px',
		fontSize: '1rem',
		fontFamily: 'monospace',
		color: theme.palette.common.white,
		outline: 'none',
		border: 'none',
		backgroundColor: grey[500],
		borderBottom: `2px solid ${theme.palette.common.white}`
	}
}));

const createEmptyRepeatBlocksArray = (test: TestReadModel) => {
	if (test.hasEmptyInput) {
		return [];
	}

	return test.input!.lines.map(line => {
		if (line.isRepeatBlock) {
			return line.repeatBlockInputOutput!.lines.map(inputLine =>
				inputLine.elements.map(element => (element.type === 'ConstString' ? element.value : ' '))
			);
		}

		return [];
	});
};

interface CilTestInputOutputExamplesEditorProps {
	test: TestReadModel;
	onExampleAdded: () => void;
}

const CilTestInputOutputExamplesEditor: FunctionComponent<CilTestInputOutputExamplesEditorProps> = props => {
	const testsApiClient = new TestsApiClient();

	const [inputs, setInputs] = useState<string[][]>(
		props.test.hasEmptyInput
			? []
			: props.test.input!.lines.map(inputLine =>
					inputLine.elements.map(element => (element.type === 'ConstString' ? element.value : ' '))
			  )
	);

	const [repeatBlocks, setRepeatBlocks] = useState<string[][][]>(createEmptyRepeatBlocksArray(props.test));

	const classes = useStyles();

	const notistack = useNotistack();

	const nextExampleNumber = props.test.ioExamples.filter(ioe => !ioe.name.startsWith('Difficult')).length + 1;

	const [isNewExampleEditorOpen, setIsNewExampleEditorOpen] = useState<boolean>(false);
	const [isNewOutputPopulated, setIsNewOutputPopulated] = useState<boolean>(false);
	const [newExampleOutput, setNewExampleOutput] = useState<string>('');

	const buildNewInput = () => {
		if (props.test.hasEmptyInput) {
			return '';
		}

		let result = '';
		for (let i = 0; i < props.test.input!.lines.length; i++) {
			const line = props.test.input!.lines[i];

			if (!line.isRepeatBlock) {
				for (let j = 0; j < line.elements.length; j++) {
					result += inputs[i][j];
					result += ' ';
				}

				result = result.slice(0, result.length - 1);
				result += '\n';
			}

			if (line.isRepeatBlock) {
				for (let i2 = 0; i2 < line.repeatBlockInputOutput!.lines.length; i2++) {
					const repeatBlockLine = line.repeatBlockInputOutput!.lines[i2];

					for (let j2 = 0; j2 < repeatBlockLine.elements.length; j2++) {
						result += repeatBlocks[i][i2][j2];
						result += ' ';
					}

					result = result.slice(0, result.length - 1);
					result += '\n';
				}
			}
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

	const handleRepeatBlockInputsChange = (
		i: number,
		i2: number,
		j2: number,
		e: ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>
	) => {
		const newValue = e.target.value;

		setRepeatBlocks(prevRepeatBlocks => {
			const result = [...prevRepeatBlocks];
			result[i][i2][j2] = newValue;
			return result;
		});
		setIsNewOutputPopulated(false);
	};

	const clearNewExample = () => {
		setIsNewOutputPopulated(false);
		setNewExampleOutput('');
		setInputs(prevInputs => {
			const newInputs = [...prevInputs];
			for (const line of newInputs) {
				for (let i = 0; i < line.length; i++) {
					line[i] = '';
				}
			}
			return newInputs;
		});
	};

	const handleAddButtonClick = () => {
		setIsNewExampleEditorOpen(true);
		return Promise.resolve();
	};

	const handleNewExampleOkButtonClick = async () => {
		try {
			await testsApiClient.addTestInputOutputExample(props.test.id, {
				name: `Example ${nextExampleNumber}`,
				input: buildNewInput(),
				output: newExampleOutput,
				isDifficult: false
			});
			setIsNewExampleEditorOpen(false);
			clearNewExample();
			props.onExampleAdded();
			notistack.enqueueSuccess(translations.tests.ioExampleHasBeenAdded);
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileAddingIoExample, error);
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
			notistack.enqueueError(translations.tests.errorOccurredWhileGeneratingOutput, error);
		}
	};

	let newExampleOkButtonDisabledReason;
	if (!isNewOutputPopulated) {
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

			{isNewExampleEditorOpen ? (
				<>
					<div className={classes.newExampleName}>
						<TextField value={`Example ${nextExampleNumber}`} className={classes.newExampleNameField} disabled={true} />
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
										<>
											{!inputLine.isRepeatBlock ? (
												<div key={index} className={classes.exampleInputLine}>
													{inputLine.elements.map((element, elementIndex) => (
														<CilInputOutputElement key={elementIndex} variant="custom" element={element}>
															<input
																type="text"
																className={classes.elementInput}
																value={inputs[index][elementIndex]}
																onChange={e => handleInputsChange(index, elementIndex, e)}
																autoFocus={elementIndex === 0 && index === 0}
															/>
														</CilInputOutputElement>
													))}
												</div>
											) : null}

											{inputLine.isRepeatBlock ? (
												<>
													<div className={classes.repeatBlock}>
														<div className={classes.header}>
															{translations.tests.repeat}
															<input type="text" className={classes.repeatBlockInput} readOnly={true} />
															<input type="text" className={classes.repeatBlockInput} readOnly={true} />
														</div>
														<div className={classes.content}>
															{inputLine.repeatBlockInputOutput!.lines.map((inputLine2, index2) => (
																<>
																	<div key={index2} className={classes.exampleInputLine}>
																		{inputLine2.elements.map((element, elementIndex) => (
																			<CilInputOutputElement key={elementIndex} variant="custom" element={element}>
																				<input
																					type="text"
																					className={classes.elementInput}
																					value={inputs[index2][elementIndex]}
																					onChange={e => handleRepeatBlockInputsChange(index, index2, elementIndex, e)}
																					autoFocus={elementIndex === 0 && index2 === 0}
																				/>
																			</CilInputOutputElement>
																		))}
																	</div>
																</>
															))}
														</div>
													</div>
												</>
											) : null}
										</>
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
		</>
	);
};

export default CilTestInputOutputExamplesEditor;
