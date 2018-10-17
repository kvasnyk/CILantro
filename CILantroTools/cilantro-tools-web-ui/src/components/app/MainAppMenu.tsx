import * as React from 'react';
import { Link } from 'react-router-dom';

import {
    Divider, Drawer, List, ListItem, ListItemIcon, ListItemText, StyledComponentProps,
    StyleRulesCallback, withStyles
} from '@material-ui/core';
import CategoryIcon from '@material-ui/icons/CategoryRounded';
import CodeIcon from '@material-ui/icons/CodeRounded';
import SearchIcon from '@material-ui/icons/SearchRounded';

import { Locales } from '../../locales/Locales';
import { Routes } from '../../routes/Routes';

const drawerWidth = 240;

const styles: StyleRulesCallback = theme => ({
    drawerPaper: {
        position: 'relative',
        width: drawerWidth
    },
    link: {
        textDecoration: 'none'
    },
    toolbar: theme.mixins.toolbar
});

const MainAppMenu: React.StatelessComponent<StyledComponentProps> = (props) => {
    return (
        <Drawer
            variant="permanent"
            classes={{
                paper: props.classes!.drawerPaper
            }}
        >
            <div className={props.classes!.toolbar} />
            <List>
                <div>
                    <Link to={Routes.tests_find} className={props.classes!.link}>
                        <ListItem button={true}>
                            <ListItemIcon><SearchIcon /></ListItemIcon>
                            <ListItemText primary={Locales.findTests} />
                        </ListItem>
                    </Link>
                </div>
            </List>
            
            <Divider />

            <List>
                <div>
                    <Link to={Routes.tests} className={props.classes!.link}>
                        <ListItem button={true}>
                            <ListItemIcon><CodeIcon /></ListItemIcon>
                            <ListItemText primary={Locales.tests} />
                        </ListItem>
                    </Link>

                    <Link to={Routes.categories} className={props.classes!.link}>
                        <ListItem button={true}>
                            <ListItemIcon><CategoryIcon /></ListItemIcon>
                            <ListItemText primary={Locales.categories} />
                        </ListItem>
                    </Link>    
                </div>
            </List>
        </Drawer>
    );
};

export default withStyles(styles)(MainAppMenu);