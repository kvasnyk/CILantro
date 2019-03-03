import React, { FunctionComponent } from 'react';

import DeleteIcon from '@material-ui/icons/DeleteRounded';

import CategoriesApiClient from '../../../api/clients/CategoriesApiClient';
import CategoryReadModel from '../../../api/read-models/categories/CategoryReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilIconButton from '../../utils/CilIconButton';

interface CilDeleteCategoryButtonProps {
	category: CategoryReadModel;
	onCategoryDeleted: () => void;
}

const CilDeleteCategoryButton: FunctionComponent<CilDeleteCategoryButtonProps> = props => {
	const categoriesApiClient = new CategoriesApiClient();

	const notistack = useNotistack();

	const handleClick = async () => {
		try {
			await categoriesApiClient.deleteCategory(props.category.id);
			notistack.enqueueSuccess(translations.categories.categoryHasBeenDeleted);
			props.onCategoryDeleted();
		} catch (error) {
			notistack.enqueueError(translations.categories.errorOccurredWhileDeletingCategory);
		}
	};

	let disabledReason;
	if (props.category.isAssignedToTest) {
		disabledReason = translations.categories.categoryIsAssingedToTest;
	}

	return (
		<CilIconButton onClick={handleClick} disabledReason={disabledReason}>
			<DeleteIcon />
		</CilIconButton>
	);
};

export default CilDeleteCategoryButton;
