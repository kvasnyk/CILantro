import React, { FunctionComponent } from 'react';

import { Checkbox, List, ListItem, ListItemText, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import translations from '../../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
	checkbox: {
		padding: 0,
		cursor: 'default',
		pointerEvents: 'none'
	}
}));

interface CilTestChecklistProps {
	test: TestReadModel;
}

const CilTestChecklist: FunctionComponent<CilTestChecklistProps> = props => {
	const classes = useStyles();

	return (
		<List>
			<ListItem>
				<Checkbox checked={props.test.hasCategory} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.selectTestCategory} />
			</ListItem>

			<ListItem>
				<Checkbox checked={props.test.hasSubcategory} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.selectTestSubcategory} />
			</ListItem>

			<ListItem>
				<Checkbox checked={props.test.hasIlSources} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.generateIlSources} />
			</ListItem>

			<ListItem>
				<Checkbox checked={props.test.hasExe} readOnly={true} className={classes.checkbox} />
				<ListItemText primary={translations.tests.generateExe} />
			</ListItem>
		</List>
	);
};

export default CilTestChecklist;
