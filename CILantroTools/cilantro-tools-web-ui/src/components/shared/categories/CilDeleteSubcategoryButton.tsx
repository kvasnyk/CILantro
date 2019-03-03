import React, { FunctionComponent } from 'react';

import DeleteIcon from '@material-ui/icons/DeleteRounded';

import CategoriesApiClient from '../../../api/clients/CategoriesApiClient';
import SubcategoryReadModel from '../../../api/read-models/categories/SubcategoryReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilIconButton from '../../utils/CilIconButton';

interface CilDeleteSubcategoryButtonProps {
	subcategory: SubcategoryReadModel;
	onSubcategoryDeleted: () => void;
}

const CilDeleteSubcategoryButton: FunctionComponent<CilDeleteSubcategoryButtonProps> = props => {
	const categoriesApiClient = new CategoriesApiClient();

	const notistack = useNotistack();

	const handleClick = async () => {
		try {
			await categoriesApiClient.deleteSubcategory(props.subcategory.categoryId, props.subcategory.id);
			notistack.enqueueSuccess(translations.categories.subcategoryHasBeenDeleted);
			props.onSubcategoryDeleted();
		} catch (error) {
			notistack.enqueueError(translations.categories.errorOccurredWhileDeletingSubcategory);
		}
	};

	let disabledReason;
	if (props.subcategory.isAssignedToTest) {
		disabledReason = translations.categories.subcategoryIsAssignedToTest;
	}

	return (
		<CilIconButton onClick={handleClick} disabledReason={disabledReason}>
			<DeleteIcon fontSize="small" />
		</CilIconButton>
	);
};

export default CilDeleteSubcategoryButton;
