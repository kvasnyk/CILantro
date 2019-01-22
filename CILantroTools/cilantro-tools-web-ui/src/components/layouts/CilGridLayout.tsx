import React, { StatelessComponent } from 'react';

import { Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

const useStyles = makeStyles((theme: Theme) => ({
  gridLayout: {
    display: 'flex',
    flexDirection: 'row',
    flexWrap: 'wrap',
    alignItems: 'flex-start',
    justifyContent: 'flex-start'
  }
}));

interface CilGridLayoutProps {
  columns: number;
}

const CilGridLayout: StatelessComponent<CilGridLayoutProps> = props => {
  const classes = useStyles();

  const childStyles = (childIndex: number) => ({
    flexGrow: 0,
    flexBasis: 'auto',
    width: `calc(100% / ${props.columns} - 10px)`,
    marginBottom: '10px',
    marginRight:
      childIndex % props.columns === props.columns - 1 ? '0px' : '10px'
  });

  return (
    <div className={classes.gridLayout}>
      {React.Children.map(props.children, (child, childIndex) => (
        <div style={childStyles(childIndex)}>{child}</div>
      ))}
    </div>
  );
};

export default CilGridLayout;
