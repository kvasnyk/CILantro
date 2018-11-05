import * as React from 'react';
import { Link } from 'react-router-dom';
import { Locales } from 'src/locales/Locales';

import { StyledComponentProps, StyleRulesCallback, withStyles } from '@material-ui/core';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';

import { Routes } from '../../routes/Routes';

const styles: StyleRulesCallback = theme => ({
    appBar: {
        zIndex: theme.zIndex.drawer + 1
    },
    link: {
        color: theme.palette.common.white,
        textDecoration: 'none'
    },
    logo: {
        width: 240
    }
});

const MainAppBar: React.StatelessComponent<StyledComponentProps> = (props) => {
    return (
        <div>
            <AppBar color="primary" position="absolute" className={props.classes!.appBar}>
                <Toolbar>
                    <div className={props.classes!.logo}>
                        <Link to={Routes.root} className={props.classes!.link}>
                            <Typography variant="h6" color="inherit">
                                {Locales.cilantroTools}
                            </Typography>
                        </Link>
                    </div>
                    <div className={props.classes!.title}>
                        <Typography variant="h5" color="inherit" />
                    </div>
                </Toolbar>
            </AppBar>
        </div>
    );
};

export default withStyles(styles)(MainAppBar);