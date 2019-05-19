import React, { ChangeEvent, useEffect, useRef, useState } from 'react';

import { TextField } from '@material-ui/core';

import SearchFilter from '../../api/search/SearchFilter';
import SearchFilterType from '../../api/search/SearchFilterType';
import { UseSearchHookResult } from '../../hooks/useSearch';
import translations from '../../translations/translations';

interface CilStringFilterProps<TReadModel extends {}> {
	search: UseSearchHookResult<TReadModel>;
	property: keyof TReadModel;
}

const CilStringFilter = <TReadModel extends {}>(props: CilStringFilterProps<TReadModel>) => {
	const existingFilter = props.search.parameter.filters.find(f => f.property === props.property);

	const [value, setValue] = useState<string | undefined>(
		existingFilter && existingFilter.value ? existingFilter.value : undefined
	);
	const isInitialMount = useRef(true);

	const handleValueChange = (e: ChangeEvent<HTMLInputElement>) => {
		setValue(e.target.value);
	};

	useEffect(
		() => {
			if (isInitialMount.current) {
				isInitialMount.current = false;
				return;
			}

			if (!value) {
				props.search.clearFilter(props.property);
			} else {
				const filter: SearchFilter<TReadModel> = {
					property: props.property,
					type: SearchFilterType.Contains,
					value
				};
				props.search.setFilter(filter);
			}
		},
		[value]
	);

	return (
		<div>
			<TextField value={value} fullWidth={true} label={translations.shared.name} onChange={handleValueChange} />
		</div>
	);
};

export default CilStringFilter;
