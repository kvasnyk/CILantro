import React, { StatelessComponent } from 'react';

import { IconButton } from '@material-ui/core';
import AddIcon from '@material-ui/icons/AddRounded';

const CilAddSubcategoryButton: StatelessComponent = props => {
  return (
    <IconButton>
      <AddIcon />
    </IconButton>
  );
};

export default CilAddSubcategoryButton;
