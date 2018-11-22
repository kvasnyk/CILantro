import * as React from 'react';

import {
    Divider, Drawer, List, StyledComponentProps, StyleRulesCallback, withStyles
} from '@material-ui/core';
import CategoryIcon from '@material-ui/icons/CategoryRounded';
import CodeIcon from '@material-ui/icons/CodeRounded';
import SearchIcon from '@material-ui/icons/SearchRounded';

import { Locales } from '../../locales/Locales';
import { Routes } from '../../routes/Routes';
import MainAppMenuItem from './MainAppMenuItem';

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
                <>
                    <MainAppMenuItem
                        linkTo={Routes.tests_find}
                        text={Locales.findTests}
                        icon={<SearchIcon />}
                    />
                </>
            </List>
            
            <Divider />

            <List>
                <>
                    <MainAppMenuItem
                        linkTo={Routes.tests}
                        text={Locales.tests}
                        icon={<CodeIcon />}
                    />

                    <MainAppMenuItem
                        linkTo={Routes.categories}
                        text={Locales.categories}
                        icon={<CategoryIcon />}
                    />
                </>
            </List>
        </Drawer>
    );
};

export default withStyles(styles)(MainAppMenu);