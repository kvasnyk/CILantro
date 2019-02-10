import React, { FunctionComponent } from 'react';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import CategoryReadModel from '../../../api/read-models/categories/CategoryReadModel';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilEditableSelect from '../../utils/CilEditableSelect';

interface CilEditTestCategorySelectProps {
	test: TestReadModel;
	categories: CategoryReadModel[];
	onCategoryUpdated: () => void;
}

const CilEditTestCategorySelect: FunctionComponent<CilEditTestCategorySelectProps> = props => {
	const testsApiClient = new TestsApiClient();

	const notistack = useNotistack();

	const editTestCategory = async (newCategoryId: string) => {
		try {
			await testsApiClient.editTestCategory(props.test.id, { categoryId: newCategoryId });
			notistack.enqueueSnackbar(translations.tests.categoryHasBeenUpdated, {
				variant: 'success'
			});
			props.onCategoryUpdated();
		} catch (error) {
			notistack.enqueueSnackbar(translations.tests.errorOccurredWhileUpdatingCategory, { variant: 'error' });
		}
	};

	const handleValueChange = (newCategoryId: string) => {
		editTestCategory(newCategoryId);
	};

	return (
		<CilEditableSelect
			label={translations.tests.testCategory}
			options={props.categories.map(category => ({
				label: category.name,
				value: category.id
			}))}
			onValueChange={handleValueChange}
			selectedValue={props.test.category.id}
		/>
	);
};

export default CilEditTestCategorySelect;
