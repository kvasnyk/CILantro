import React, { StatelessComponent } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

const useStyles = makeStyles((theme: Theme) => ({
  gridLayout: {
    display: 'flex',
    flexDirection: 'row',
    flexWrap: 'wrap',
    alignItems: 'center',
    justifyContent: 'space-between'
  }
}));

interface CilGridLayoutProps {
  columns: number;
}

const CilGridLayout: StatelessComponent<CilGridLayoutProps> = props => {
  const classes = useStyles();

  const childStyles = {
    flexGrow: 0,
    flexBasis: 'auto',
    width: `calc(100% / ${props.columns} - 10px)`,
    marginBottom: '10px'
  };

  return (
    <div className={classes.gridLayout}>
      {React.Children.map(props.children, child => (
        <div style={childStyles}>{child}</div>
      ))}
    </div>
  );
};

export default CilGridLayout;
