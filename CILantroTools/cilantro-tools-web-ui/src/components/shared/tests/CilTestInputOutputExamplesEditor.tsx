import React, { FunctionComponent, useState } from 'react';

import { Button, TextField, Theme, Typography } from '@material-ui/core';
import AddIcon from '@material-ui/icons/AddRounded';
import CheckIcon from '@material-ui/icons/CheckRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import { makeStyles } from '@material-ui/styles';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilCodeEditor from '../../utils/CilCodeEditor';
import CilExampleInputEditor from '../../utils/CilExampleInputEditor';
import CilIconButton from '../../utils/CilIconButton';

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
	exampleOutput: {
		flexGrow: 1,
		flexBasis: 0,
		marginLeft: '5px'
	}
}));

interface CilTestInputOutputExamplesEditorProps {
	test: TestReadModel;
	onExampleAdded: () => void;
}

const CilTestInputOutputExamplesEditor: FunctionComponent<CilTestInputOutputExamplesEditorProps> = props => {
	const testsApiClient = new TestsApiClient();

	const classes = useStyles();

	const notistack = useNotistack();

	const nextExampleNumber = props.test.ioExamples.filter(ioe => !ioe.name.startsWith('Difficult')).length + 1;

	const [isNewExampleEditorOpen, setIsNewExampleEditorOpen] = useState<boolean>(false);
	const [isNewOutputPopulated, setIsNewOutputPopulated] = useState<boolean>(false);
	const [newExampleOutput, setNewExampleOutput] = useState<string>('');

	const [newExampleInput, setNewExampleInput] = useState<string>('');

	const clearNewExample = () => {
		setIsNewOutputPopulated(false);
		setNewExampleOutput('');
	};

	const handleExampleInputChange = (newInput: string) => {
		setNewExampleInput(newInput);
		setIsNewOutputPopulated(false);
	};

	const handleAddButtonClick = () => {
		setIsNewExampleEditorOpen(true);
		return Promise.resolve();
	};

	const handleNewExampleOkButtonClick = async () => {
		try {
			await testsApiClient.addTestInputOutputExample(props.test.id, {
				name: `Example ${nextExampleNumber}`,
				input: newExampleInput,
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
			const generateOutputResponse = await testsApiClient.generateOutput(props.test.id, { input: newExampleInput });
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
							<CilExampleInputEditor
								hasEmptyInput={props.test.hasEmptyInput}
								inputOutput={props.test.input}
								onInputChange={handleExampleInputChange}
							/>
						</div>
						<div className={classes.newExampleOutput}>
							{isNewOutputPopulated ? (
								<CilCodeEditor code={newExampleOutput} />
							) : (
								<div className={classes.newExamplePopulate}>
									<Button variant="contained" color="primary" onClick={handlePopulateNewOutputButtonClick}>
										{translations.tests.generateOutput}
									</Button>
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
