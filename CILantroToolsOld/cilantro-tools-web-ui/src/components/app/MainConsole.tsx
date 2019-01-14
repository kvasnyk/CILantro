import * as React from 'react';

import {
    Drawer, Paper, StyledComponentProps, StyleRulesCallback, Toolbar, withStyles
} from '@material-ui/core';

import { Locales } from '../../locales/Locales';

const consoleWidth = 600;

const styles: StyleRulesCallback = theme => ({
    drawerPaper: {
        position: 'relative',
        width: consoleWidth
    },
    paper: {
        alignItems: 'center',
        display: 'flex',
        fontFamily: 'Consolas',
        height: 'calc(100% - 64px)',
        justifyContent: 'center'
    }
});

const MainConsole: React.StatelessComponent<StyledComponentProps> = (props) => {
    return (
        <Drawer
            variant="permanent"
            anchor="right"
            classes={{
                paper: props.classes!.drawerPaper
            }}
        >
            <Toolbar />
            <Paper className={props.classes!.paper}>
                {Locales.consoleIsEmpty}
            </Paper>
        </Drawer>
    );
};

export default withStyles(styles)(MainConsole);