import React, { FunctionComponent } from 'react';

import TestsApiClient from '../../../api/clients/TestsApiClient';
import SubcategoryReadModel from '../../../api/read-models/categories/SubcategoryReadModel';
import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';
import CilEditableSelect from '../../utils/CilEditableSelect';

interface CilEditTestSubcategorySelectProps {
	test: TestReadModel;
	subcategories: SubcategoryReadModel[];
	onSubcategoryUpdated: () => void;
	isEditable?: boolean;
}

const CilEditTestSubcategorySelect: FunctionComponent<CilEditTestSubcategorySelectProps> = props => {
	const testsApiClient = new TestsApiClient();

	const notistack = useNotistack();

	const editTestSubcategory = async (newSubcategoryId: string) => {
		try {
			await testsApiClient.editTestSubcategory(props.test.id, { subcategoryId: newSubcategoryId });
			notistack.enqueueSuccess(translations.tests.subcategoryHasBeenUpdated);
			props.onSubcategoryUpdated();
		} catch (error) {
			notistack.enqueueError(translations.tests.errorOccurredWhileUpdatingSubcategory);
		}
	};

	const handleValueChange = (newSubcategoryId: string) => {
		editTestSubcategory(newSubcategoryId);
	};

	return (
		<CilEditableSelect
			options={props.subcategories.map(subcategory => ({
				label: subcategory.name,
				value: subcategory.id
			}))}
			onValueChange={handleValueChange}
			selectedValue={props.test.subcategoryId}
			isEditable={props.isEditable}
		/>
	);
};

CilEditTestSubcategorySelect.defaultProps = {
	isEditable: true
};

export default CilEditTestSubcategorySelect;
