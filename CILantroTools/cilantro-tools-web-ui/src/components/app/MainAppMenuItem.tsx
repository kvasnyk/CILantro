import * as classNames from 'classnames';
import * as React from 'react';
import { Link, RouteComponentProps, withRouter } from 'react-router-dom';

import {
    ListItem, ListItemIcon, ListItemText, StyledComponentProps, StyleRulesCallback, withStyles
} from '@material-ui/core';
import { SvgIconProps } from '@material-ui/core/SvgIcon';

interface MainAppMenuItemProps extends StyledComponentProps, RouteComponentProps<{}> {
    icon: React.ReactElement<SvgIconProps>;
    linkTo: string;
    text: string;
}

const styles: StyleRulesCallback = theme => ({
    activeItem: {
        '&:hover': {
            backgroundColor: theme.palette.primary.main
        },
        backgroundColor: theme.palette.primary.main
    },
    activeItemText: {
        '& > span': {
            color: theme.palette.primary.contrastText
        },
        color: theme.palette.primary.contrastText
    },
    link: {
        textDecoration: 'none'
    }
});

const MainAppMenuItem: React.StatelessComponent<MainAppMenuItemProps> = (props) => {
    const isActive = props.location.pathname === props.linkTo;

    const linkClassName = classNames(props.classes!.link);
    const listItemClassName = classNames({
        [props.classes!.activeItem!]: isActive
    });
    const iconClassName = classNames({
        [props.classes!.activeItemText!]: isActive
    });
    const textClassName = classNames({
        [props.classes!.activeItemText!]: isActive
    });

    return (
        <Link to={props.linkTo} className={linkClassName}>
            <ListItem button={true} className={listItemClassName}>
                <ListItemIcon className={iconClassName}>{props.icon}</ListItemIcon>
                <ListItemText className={textClassName} primary={props.text} />
            </ListItem>
        </Link>
    );
};

export default withStyles(styles)(withRouter(MainAppMenuItem));