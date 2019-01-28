import React, { StatelessComponent } from 'react';

import {
  Card,
  CardActions,
  CardContent,
  Theme,
  Typography
} from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import CategoryReadModel from '../../../api/read-models/categories/CategoryReadModel';
import CilAddSubcategoryButton from './CilAddSubcategoryButton';

const useStyles = makeStyles((theme: Theme) => ({
  cardActions: {
    justifyContent: 'flex-end'
  }
}));

interface CilCategoryCardProps {
  category: CategoryReadModel;
}

const CilCategoryCard: StatelessComponent<CilCategoryCardProps> = props => {
  const classes = useStyles();

  return (
    <Card>
      <CardContent>
        <Typography variant="h2">{props.category.name}</Typography>
      </CardContent>
      <CardActions className={classes.cardActions}>
        <CilAddSubcategoryButton />
      </CardActions>
    </Card>
  );
};

export default CilCategoryCard;
