import React, { FunctionComponent } from 'react';

import { Typography } from '@material-ui/core';

import CategoryReadModel from '../../../api/read-models/categories/CategoryReadModel';
import translations from '../../../translations/translations';
import CilGridLayout from '../../layouts/CilGridLayout';
import CilCategoryCard from './CilCategoryCard';

interface CilCategoriesListProps {
	categories: CategoryReadModel[];
	onSubcategoryAdded: () => void;
	onCategoryDeleted: () => void;
	onSubcategoryDeleted: () => void;
}

const CilCategoriesList: FunctionComponent<CilCategoriesListProps> = props => {
	return props.categories.length > 0 ? (
		<CilGridLayout columns={3}>
			{props.categories.map(category => (
				<CilCategoryCard
					key={category.id}
					category={category}
					onSubcategoryAdded={props.onSubcategoryAdded}
					onCategoryDeleted={props.onCategoryDeleted}
					onSubcategoryDeleted={props.onSubcategoryDeleted}
				/>
			))}
		</CilGridLayout>
	) : (
		<Typography variant="h2" align="center">
			{translations.categories.noCategories}
		</Typography>
	);
};

export default CilCategoriesList;
