import * as React from 'react';

import {
    StyledComponentProps, StyleRulesCallback, Typography, withStyles
} from '@material-ui/core';

const styles: StyleRulesCallback = theme => ({
    content: {
        backgroundColor: theme.palette.background.default,
        flexGrow: 1,
        minWidth: 0,
        padding: theme.spacing.unit * 3
    },
    toolbar: theme.mixins.toolbar,
});

const MainContent: React.StatelessComponent<StyledComponentProps> = (props) => {
    return (
        <main className={props.classes!.content}>
            <div className={props.classes!.toolbar} />
            <Typography noWrap={true}>
                {'You think water moves fast? You should see ice.'}
            </Typography>
        </main>
    );
};

export default withStyles(styles)(MainContent);