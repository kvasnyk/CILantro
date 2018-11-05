import * as React from 'react';

import { Drawer, StyledComponentProps, StyleRulesCallback, withStyles } from '@material-ui/core';

const consoleWidth = 600;

const styles: StyleRulesCallback = theme => ({
    drawerPaper: {
        position: 'relative',
        width: consoleWidth
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
        />
    );
};

export default withStyles(styles)(MainConsole);