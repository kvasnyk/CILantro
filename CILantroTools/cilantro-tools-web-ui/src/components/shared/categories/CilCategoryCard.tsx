import React, { FunctionComponent } from 'react';

import { Card, CardActions, CardContent, Theme, Typography } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import CategoryReadModel from '../../../api/read-models/categories/CategoryReadModel';
import CilAddSubcategoryButton from './CilAddSubcategoryButton';
import CilDeleteCategoryButton from './CilDeleteCategoryButton';
import CilDeleteSubcategoryButton from './CilDeleteSubcategoryButton';

const useStyles = makeStyles((theme: Theme) => ({
	cardActions: {
		justifyContent: 'flex-end',
		marginRight: '5px'
	},
	subcategoryLi: {
		display: 'flex',
		alignItems: 'center'
	},
	subcategoryTypography: {
		marginRight: '10px'
	}
}));

interface CilCategoryCardProps {
	category: CategoryReadModel;
	onSubcategoryAdded: () => void;
	onCategoryDeleted: () => void;
	onSubcategoryDeleted: () => void;
}

const CilCategoryCard: FunctionComponent<CilCategoryCardProps> = props => {
	const classes = useStyles();

	return (
		<Card>
			<CardContent>
				<Typography variant="h2">{props.category.name}</Typography>
				<ul>
					{props.category.subcategories.map(subcategory => (
						<li key={subcategory.id} className={classes.subcategoryLi}>
							<Typography className={classes.subcategoryTypography}>{subcategory.name}</Typography>
							<CilDeleteSubcategoryButton subcategory={subcategory} onSubcategoryDeleted={props.onSubcategoryDeleted} />
						</li>
					))}
				</ul>
			</CardContent>
			<CardActions className={classes.cardActions}>
				<CilAddSubcategoryButton category={props.category} onSubcategoryAdded={props.onSubcategoryAdded} />
				<CilDeleteCategoryButton category={props.category} onCategoryDeleted={props.onCategoryDeleted} />
			</CardActions>
		</Card>
	);
};

export default CilCategoryCard;
