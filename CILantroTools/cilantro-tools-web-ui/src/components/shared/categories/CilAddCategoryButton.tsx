import React, { StatelessComponent, useState } from 'react';

import {
  Dialog,
  DialogContent,
  DialogTitle,
  Fab,
  Theme
} from '@material-ui/core';
import green from '@material-ui/core/colors/green';
import AddIcon from '@material-ui/icons/AddRounded';
import { makeStyles } from '@material-ui/styles';

import translations from '../../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
  fab: {
    backgroundColor: green[500],
    color: theme.palette.primary.contrastText
  }
}));

const CilAddCategoryButton: StatelessComponent = props => {
  const classes = useStyles();

  const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);

  const handleButtonClick = () => {
    setIsDialogOpen(true);
  };

  const handleDialogClose = () => {
    setIsDialogOpen(false);
  };

  return (
    <>
      <Fab className={classes.fab} onClick={handleButtonClick}>
        <AddIcon />
      </Fab>

      <Dialog open={isDialogOpen} onClose={handleDialogClose}>
        <DialogTitle>{translations.categories.addCategory}</DialogTitle>
        <DialogContent />
      </Dialog>
    </>
  );
};

export default CilAddCategoryButton;
