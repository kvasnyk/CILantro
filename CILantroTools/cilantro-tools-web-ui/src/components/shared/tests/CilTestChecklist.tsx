import React, { FunctionComponent } from 'react';

import { Checkbox, List, ListItem, ListItemText, Theme } from '@material-ui/core';
import ArrowIcon from '@material-ui/icons/ArrowForwardRounded';
import { makeStyles } from '@material-ui/styles';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import translations from '../../../translations/translations';
import CilIconButton from '../../utils/CilIconButton';

const useStyles = makeStyles((theme: Theme) => ({
	checkbox: {
		padding: 0,
		cursor: 'default',
		pointerEvents: 'none'
	},
	listItem: {
		paddingTop: 0,
		paddingBottom: 0
	},
	listItemText: {
		flexBasis: 'auto',
		flexGrow: 0
	}
}));

interface CilTestChecklistProps {
	test: TestReadModel;
	onGoToCategory?: () => Promise<unknown>;
	onGoToSubcategory?: () => Promise<unknown>;
	onGoToIlSources?: () => Promise<unknown>;
	onGoToExe?: () => Promise<unknown>;
	onGoToInput?: () => Promise<unknown>;
	onGoToOutput?: () => Promise<unknown>;
	onGoToIoExamples?: () => Promise<unknown>;
}

const CilTestChecklist: FunctionComponent<CilTestChecklistProps> = props => {
	const classes = useStyles();

	return (
		<List>
			<ListItem className={classes.listItem}>
				<Checkbox checked={props.test.hasCategory} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.selectTestCategory} className={classes.listItemText} />
				{props.onGoToCategory ? (
					<CilIconButton onClick={props.onGoToCategory}>
						<ArrowIcon fontSize="small" />
					</CilIconButton>
				) : null}
			</ListItem>

			<ListItem className={classes.listItem}>
				<Checkbox checked={props.test.hasSubcategory} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.selectTestSubcategory} className={classes.listItemText} />
				{props.onGoToSubcategory ? (
					<CilIconButton onClick={props.onGoToSubcategory}>
						<ArrowIcon fontSize="small" />
					</CilIconButton>
				) : null}
			</ListItem>

			<ListItem className={classes.listItem}>
				<Checkbox checked={props.test.hasIlSources} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.generateIlSources} className={classes.listItemText} />
				{props.onGoToIlSources ? (
					<CilIconButton onClick={props.onGoToIlSources}>
						<ArrowIcon fontSize="small" />
					</CilIconButton>
				) : null}
			</ListItem>

			<ListItem className={classes.listItem}>
				<Checkbox checked={props.test.hasExe} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.generateExe} className={classes.listItemText} />
				{props.onGoToExe ? (
					<CilIconButton onClick={props.onGoToExe}>
						<ArrowIcon fontSize="small" />
					</CilIconButton>
				) : null}
			</ListItem>

			<ListItem className={classes.listItem}>
				<Checkbox checked={props.test.hasInput} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.configureInput} className={classes.listItemText} />
				{props.onGoToInput ? (
					<CilIconButton onClick={props.onGoToInput}>
						<ArrowIcon fontSize="small" />
					</CilIconButton>
				) : null}
			</ListItem>

			<ListItem className={classes.listItem}>
				<Checkbox checked={props.test.hasOutput} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.configureOutput} className={classes.listItemText} />
				{props.onGoToOutput ? (
					<CilIconButton onClick={props.onGoToOutput}>
						<ArrowIcon fontSize="small" />
					</CilIconButton>
				) : null}
			</ListItem>

			<ListItem className={classes.listItem}>
				<Checkbox checked={props.test.hasIoExample} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.addIoExample} className={classes.listItemText} />
				{props.onGoToIoExamples ? (
					<CilIconButton onClick={props.onGoToIoExamples}>
						<ArrowIcon fontSize="small" />
					</CilIconButton>
				) : null}
			</ListItem>
		</List>
	);
};

export default CilTestChecklist;
