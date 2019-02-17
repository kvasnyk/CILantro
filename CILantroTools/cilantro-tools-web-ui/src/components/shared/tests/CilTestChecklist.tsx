import React, { FunctionComponent } from 'react';

import { Checkbox, IconButton, List, ListItem, ListItemText, Theme } from '@material-ui/core';
import ArrowIcon from '@material-ui/icons/ArrowForwardRounded';
import { makeStyles } from '@material-ui/styles';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import translations from '../../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
	checkbox: {
		padding: 0,
		cursor: 'default',
		pointerEvents: 'none'
	},
	listItemText: {
		flexBasis: 'auto',
		flexGrow: 0
	}
}));

interface CilTestChecklistProps {
	test: TestReadModel;
	onGoToCategory?: () => void;
	onGoToSubcategory?: () => void;
	onGoToIlSources?: () => void;
	onGoToExe?: () => void;
	onGoToInput?: () => void;
}

const CilTestChecklist: FunctionComponent<CilTestChecklistProps> = props => {
	const classes = useStyles();

	return (
		<List>
			<ListItem>
				<Checkbox checked={props.test.hasCategory} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.selectTestCategory} className={classes.listItemText} />
				{props.onGoToCategory ? (
					<IconButton onClick={props.onGoToCategory}>
						<ArrowIcon fontSize="small" />
					</IconButton>
				) : null}
			</ListItem>

			<ListItem>
				<Checkbox checked={props.test.hasSubcategory} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.selectTestSubcategory} className={classes.listItemText} />
				{props.onGoToSubcategory ? (
					<IconButton onClick={props.onGoToSubcategory}>
						<ArrowIcon fontSize="small" />
					</IconButton>
				) : null}
			</ListItem>

			<ListItem>
				<Checkbox checked={props.test.hasIlSources} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.generateIlSources} className={classes.listItemText} />
				{props.onGoToIlSources ? (
					<IconButton onClick={props.onGoToIlSources}>
						<ArrowIcon fontSize="small" />
					</IconButton>
				) : null}
			</ListItem>

			<ListItem>
				<Checkbox checked={props.test.hasExe} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.generateExe} className={classes.listItemText} />
				{props.onGoToExe ? (
					<IconButton onClick={props.onGoToExe}>
						<ArrowIcon fontSize="small" />
					</IconButton>
				) : null}
			</ListItem>

			<ListItem>
				<Checkbox checked={props.test.hasInput} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.configureInput} className={classes.listItemText} />
				{props.onGoToInput ? (
					<IconButton onClick={props.onGoToInput}>
						<ArrowIcon fontSize="small" />
					</IconButton>
				) : null}
			</ListItem>
		</List>
	);
};

export default CilTestChecklist;
