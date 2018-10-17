import * as React from 'react';

import {
    Divider, Drawer, List, ListItem, ListItemIcon, ListItemText, StyledComponentProps,
    StyleRulesCallback, withStyles
} from '@material-ui/core';
import CategoryIcon from '@material-ui/icons/CategoryRounded';
import CodeIcon from '@material-ui/icons/CodeRounded';
import SearchIcon from '@material-ui/icons/SearchRounded';

import { Locales } from '../../locales/Locales';

const drawerWidth = 240;

const styles: StyleRulesCallback = theme => ({
    drawerPaper: {
        position: 'relative',
        width: drawerWidth
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
                    <ListItem button={true}>
                        <ListItemIcon><SearchIcon /></ListItemIcon>
                        <ListItemText primary={Locales.findTests} />
                    </ListItem>
                </div>
            </List>
            
            <Divider />

            <List>
                <div>
                    <ListItem button={true}>
                        <ListItemIcon><CodeIcon /></ListItemIcon>
                        <ListItemText primary={Locales.tests} />
                    </ListItem>

                    <ListItem button={true}>
                        <ListItemIcon><CategoryIcon /></ListItemIcon>
                        <ListItemText primary={Locales.categories} />
                    </ListItem>
                </div>
            </List>
        </Drawer>
    );
};

export default withStyles(styles)(MainAppMenu);