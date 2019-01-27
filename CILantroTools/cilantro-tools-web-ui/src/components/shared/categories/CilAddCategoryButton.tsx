import React, { StatelessComponent } from 'react';

import { Fab, Theme } from '@material-ui/core';
import green from '@material-ui/core/colors/green';
import AddIcon from '@material-ui/icons/AddRounded';
import { makeStyles } from '@material-ui/styles';

const useStyles = makeStyles((theme: Theme) => ({
  fab: {
    backgroundColor: green[500],
    color: theme.palette.primary.contrastText
  }
}));

const CilAddCategoryButton: StatelessComponent = props => {
  const classes = useStyles();

  return (
    <Fab className={classes.fab}>
      <AddIcon />
    </Fab>
  );
};

export default CilAddCategoryButton;
