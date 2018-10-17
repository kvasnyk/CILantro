import * as React from 'react';
import { Link } from 'react-router-dom';

import { StyledComponentProps, StyleRulesCallback, withStyles } from '@material-ui/core';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';

import { Routes } from '../../routes/Routes';
import LocaleDisplayer from '../displayers/LocaleDisplayer';

const styles: StyleRulesCallback = theme => ({
    appBar: {
        zIndex: theme.zIndex.drawer + 1
    },
    link: {
        color: theme.palette.common.white,
        textDecoration: 'none'
    }
});

const MainAppBar: React.StatelessComponent<StyledComponentProps> = (props) => {
    return (
        <div>
            <AppBar color="primary" position="absolute" className={props.classes!.appBar}>
                <Toolbar>
                    <Link to={Routes.root} className={props.classes!.link}>
                        <Typography variant="h6" color="inherit">
                            <LocaleDisplayer localeKey='cilantroTools' />
                        </Typography>
                    </Link>
                </Toolbar>
            </AppBar>
        </div>
    );
};

export default withStyles(styles)(MainAppBar);