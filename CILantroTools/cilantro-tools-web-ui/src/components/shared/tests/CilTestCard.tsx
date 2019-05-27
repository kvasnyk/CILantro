import classNames from 'classnames';
import React, { FunctionComponent } from 'react';

import { Card, CardActions, CardContent, Theme, Typography } from '@material-ui/core';
import { green, red } from '@material-ui/core/colors';
import CheckIcon from '@material-ui/icons/CheckRounded';
import NotCheckIcon from '@material-ui/icons/NotInterestedRounded';
import { makeStyles } from '@material-ui/styles';

import RunOutcome from '../../../api/enums/RunOutcome';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import CilShowTestButton from './CilShowTestButton';
import CilTestChecklist from './CilTestChecklist';

interface CilTestCardProps {
	test: TestReadModel;
}

const useStyles = makeStyles((theme: Theme) => ({
	headerWrapper: {
		display: 'flex',
		flexDirection: 'row'
	},
	headerLeft: {
		flexGrow: 1,
		flexBasis: 0
	},
	headerRight: {
		display: 'flex',
		flexDirection: 'column',
		alignItems: 'center',
		justifyContent: 'space-around'
	},
	header: {
		display: 'flex',
		flexDirection: 'row',
		alignItems: 'center',
		justifyContent: 'flex-start'
	},
	headerTypography: {
		marginBottom: 0,
		marginRight: '5px'
	},
	notReadyCard: {
		backgroundColor: theme.palette.grey[300],
		color: theme.palette.getContrastText(theme.palette.grey[500])
	},
	notReadyTypography: {
		color: theme.palette.getContrastText(theme.palette.grey[500])
	},
	disabledCard: {
		backgroundColor: theme.palette.secondary.dark,
		color: theme.palette.secondary.contrastText
	},
	disabledTypography: {
		color: theme.palette.secondary.contrastText
	},
	cardActions: {
		justifyContent: 'flex-end',
		marginRight: '5px'
	},
	okIcon: {
		color: green[700],
		fontSize: '2.5rem'
	},
	wrongIcon: {
		color: red[700],
		fontSize: '2.5rem'
	},
	disabledReasonTypography: {
		textAlign: 'center',
		margin: '20px 20px 0 20px'
	}
}));

const CiLTestCard: FunctionComponent<CilTestCardProps> = props => {
	const classes = useStyles();

	const cardClassName = classNames({
		[classes.notReadyCard]: !props.test.isReady,
		[classes.disabledCard]: props.test.isDisabled
	});

	const typographyClassName = classNames({
		[classes.notReadyTypography]: !props.test.isReady,
		[classes.disabledTypography]: props.test.isDisabled
	});

	const iconClassName = typographyClassName;

	const headerTypographyClassName = classNames(typographyClassName, classes.headerTypography);

	return (
		<Card className={cardClassName}>
			<CardContent>
				<div className={classes.headerWrapper}>
					<div className={classes.headerLeft}>
						<div className={classes.header}>
							<Typography variant="h2" className={headerTypographyClassName}>
								{props.test.name}
							</Typography>
							{!props.test.isDisabled ? (
								<>
									{props.test.lastRunOutcome === RunOutcome.Ok ? <CheckIcon className={classes.okIcon} /> : null}
									{props.test.lastRunOutcome === RunOutcome.Wrong ? (
										<NotCheckIcon className={classes.wrongIcon} />
									) : null}
								</>
							) : null}
						</div>
						<Typography variant="subtitle1" className={typographyClassName}>
							...{props.test.path}
						</Typography>
					</div>

					<div className={classes.headerRight}>
						{props.test.hasCategory && props.test.hasSubcategory ? (
							<>
								<Typography variant="h4" className={typographyClassName}>
									{props.test.category.name}
								</Typography>
								<Typography variant="h4" className={typographyClassName}>
									{props.test.subcategory.name}
								</Typography>
							</>
						) : null}
					</div>
				</div>
				{!props.test.isReady && !props.test.isDisabled ? <CilTestChecklist test={props.test} /> : null}
				{props.test.isDisabled && props.test.disabledReason ? (
					<Typography variant="h3" className={classNames(classes.disabledReasonTypography, typographyClassName)}>
						{props.test.disabledReason}
					</Typography>
				) : null}
			</CardContent>
			<CardActions className={classes.cardActions}>
				<CilShowTestButton testId={props.test.id} icon="show" iconClassName={iconClassName} />
			</CardActions>
		</Card>
	);
};

export default CiLTestCard;
