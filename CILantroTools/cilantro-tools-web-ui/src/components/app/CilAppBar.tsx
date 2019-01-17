import React, { StatelessComponent } from 'react';
import { Link } from 'react-router-dom';

import { AppBar, Theme, Toolbar, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import translations from '../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
  appBar: {
    zIndex: theme.zIndex.drawer + 1
  },
  appNameLink: {
    color: theme.palette.common.white,
    textDecoration: 'none'
  }
}));

const CilAppBar: StatelessComponent = props => {
  const classes = useStyles();

  return (
    <AppBar color="primary" position="absolute" className={classes.appBar}>
      <Toolbar>
        <Link to="#" className={classes.appNameLink}>
          <Typography variant="h6" color="inherit">
            {translations.app.name}
          </Typography>
        </Link>
      </Toolbar>
    </AppBar>
  );
};

export default CilAppBar;
