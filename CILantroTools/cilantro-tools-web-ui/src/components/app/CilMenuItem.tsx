import classNames from 'classnames';
import React, { FunctionComponent } from 'react';
import { Link, RouteComponentProps, withRouter } from 'react-router-dom';

import { ListItem, ListItemIcon, ListItemText, Theme } from '@material-ui/core';
import { SvgIconProps } from '@material-ui/core/SvgIcon';
import { makeStyles } from '@material-ui/styles';

const useStyles = makeStyles((theme: Theme) => ({
	link: {
		textDecoration: 'none'
	},
	listItemActive: {
		backgroundColor: theme.palette.primary.main,
		'&:hover': {
			backgroundColor: theme.palette.primary.main
		}
	},
	iconActive: {
		color: theme.palette.primary.contrastText
	},
	textActive: {
		color: theme.palette.primary.contrastText,
		'&>span': {
			color: theme.palette.primary.contrastText
		}
	}
}));

interface CilMenuItemOwnProps {
	to: string;
	icon: React.ReactElement<SvgIconProps>;
	label: string;
}

type CilMenuItemProps = CilMenuItemOwnProps & RouteComponentProps;

const CilMenuItem: FunctionComponent<CilMenuItemProps> = props => {
	const classes = useStyles();

	const isActive = props.location.pathname === props.to;

	const listItemClassName = classNames({
		[classes.listItemActive]: isActive
	});
	const iconClassName = classNames({
		[classes.iconActive]: isActive
	});
	const textClassName = classNames({
		[classes.textActive]: isActive
	});

	return (
		<Link to={props.to} className={classes.link}>
			<ListItem button={true} className={listItemClassName}>
				<ListItemIcon className={iconClassName}>{props.icon}</ListItemIcon>
				<ListItemText primary={props.label} className={textClassName} />
			</ListItem>
		</Link>
	);
};

export default withRouter(CilMenuItem);
