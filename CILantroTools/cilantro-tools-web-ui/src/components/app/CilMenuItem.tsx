import React, { StatelessComponent } from 'react';
import { Link } from 'react-router-dom';

import { ListItem, ListItemIcon, ListItemText, Theme } from '@material-ui/core';
import { SvgIconProps } from '@material-ui/core/SvgIcon';
import { makeStyles } from '@material-ui/styles';

interface CilMenuItemProps {
  to: string;
  icon: React.ReactElement<SvgIconProps>;
  label: string;
}

const useStyles = makeStyles((theme: Theme) => ({
  link: {
    textDecoration: 'none'
  }
}));

const CilMenuItem: StatelessComponent<CilMenuItemProps> = props => {
  const classes = useStyles();

  return (
    <Link to={props.to} className={classes.link}>
      <ListItem button={true}>
        <ListItemIcon>{props.icon}</ListItemIcon>
        <ListItemText primary={props.label} />
      </ListItem>
    </Link>
  );
};

export default CilMenuItem;
