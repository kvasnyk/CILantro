import * as React from 'react';

import { StyledComponentProps, StyleRulesCallback, withStyles } from '@material-ui/core';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';

import LocaleDisplayer from '../displayers/LocaleDisplayer';

const styles: StyleRulesCallback = theme => ({
    appBar: {
        zIndex: theme.zIndex.drawer + 1
    }
});

const MainAppBar: React.StatelessComponent<StyledComponentProps> = (props) => {
    return (
        <div>
            <AppBar color="primary" position="absolute" className={props.classes!.appBar}>
                <Toolbar>
                    <Typography variant="h6" color="inherit">
                        <LocaleDisplayer localeKey='cilantroTools' />
                    </Typography>
                </Toolbar>
            </AppBar>
        </div>
    );
};

export default withStyles(styles)(MainAppBar);