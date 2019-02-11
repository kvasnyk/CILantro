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
			notistack.enqueueSuccess(translations.tests.categoryHasBeenUpdated);
			props.onCategoryUpdated();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileUpdatingCategory);
		}
	};

	const handleValueChange = (newCategoryId: string) => {
		editTestCategory(newCategoryId);
	};

	return (
		<CilEditableSelect
			options={props.categories.map(category => ({
				label: category.name,
				value: category.id
			}))}
			onValueChange={handleValueChange}
			selectedValue={props.test.categoryId}
		/>
	);
};

export default CilEditTestCategorySelect;
