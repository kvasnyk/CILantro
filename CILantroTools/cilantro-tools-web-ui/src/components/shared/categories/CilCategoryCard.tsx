import classNames from 'classnames';
import React, { FunctionComponent, useState } from 'react';

import { Card, CardActions, CardContent, Collapse, IconButton, Theme, Typography } from '@material-ui/core';
import ExpandMoreIcon from '@material-ui/icons/ExpandMoreRounded';
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
	},
	expand: {
		marginLeft: 0,
		marginRight: 0,
		transform: 'rotate(0deg)',
		transition: theme.transitions.create('transform', {
			duration: theme.transitions.duration.shortest
		})
	},
	expandOpen: {
		transform: 'rotate(180deg)'
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

	const [isExpanded, setIsExpanded] = useState<boolean>(false);

	const handleExpandButtonClick = () => {
		setIsExpanded(prev => !prev);
	};

	return (
		<Card>
			<CardContent>
				<Typography variant="h2">{props.category.name}</Typography>
				<Collapse in={isExpanded} timeout="auto" unmountOnExit={false}>
					<ul>
						{props.category.subcategories.map(subcategory => (
							<li key={subcategory.id} className={classes.subcategoryLi}>
								<Typography className={classes.subcategoryTypography}>{subcategory.name}</Typography>
								<CilDeleteSubcategoryButton
									subcategory={subcategory}
									onSubcategoryDeleted={props.onSubcategoryDeleted}
								/>
							</li>
						))}
					</ul>
				</Collapse>
			</CardContent>
			<CardActions className={classes.cardActions}>
				<CilAddSubcategoryButton category={props.category} onSubcategoryAdded={props.onSubcategoryAdded} />
				<CilDeleteCategoryButton category={props.category} onCategoryDeleted={props.onCategoryDeleted} />
				<IconButton
					className={classNames(classes.expand, {
						[classes.expandOpen]: isExpanded
					})}
					onClick={handleExpandButtonClick}
				>
					<ExpandMoreIcon />
				</IconButton>
			</CardActions>
		</Card>
	);
};

export default CilCategoryCard;
