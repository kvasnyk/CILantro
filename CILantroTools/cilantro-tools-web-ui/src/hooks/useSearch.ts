import { Dispatch, SetStateAction, useState } from 'react';

import SearchFilter from '../api/search/SearchFilter';
import SearchOrderParameter from '../api/search/SearchOrderParameter';
import SearchParameter from '../api/search/SearchParameter';
import SearchResult from '../api/search/SearchResult';

export interface UseSearchHookResult<TReadModel> {
	parameter: SearchParameter<TReadModel>;
	setParameter: Dispatch<SetStateAction<SearchParameter<TReadModel>>>;
	result: SearchResult<TReadModel>;
	setResult: Dispatch<SetStateAction<SearchResult<TReadModel>>>;
	handlePageNumberChange: (newPageNumber: number) => void;
	handlePageSizeChange: (newPageSize: number) => void;
	handleOrderByChange: (newOrderBy: SearchOrderParameter<TReadModel>) => void;
	areFiltersOpen: boolean;
	setFiltersOpen: (value: boolean) => void;
	setFilter: (filter: SearchFilter<TReadModel>) => void;
	clearFilter: (property: keyof TReadModel) => void;
}

const useSearch = <TReadModel>(
	initialSearchParameter: SearchParameter<TReadModel>
): UseSearchHookResult<TReadModel> => {
	const [searchParameter, setSearchParameter] = useState<SearchParameter<TReadModel>>(initialSearchParameter);
	const [searchResult, setSearchResult] = useState<SearchResult<TReadModel>>({ data: [], count: 0 });
	const [areFiltersOpen, setAreFiltersOpen] = useState<boolean>(false);

	const handlePageNumberChange = (newPageNumber: number) => {
		setSearchParameter(prevParameter => ({
			...prevParameter,
			pageNumber: newPageNumber
		}));
	};

	const handlePageSizeChange = (newPageSize: number) => {
		setSearchParameter(prevParameter => ({
			...prevParameter,
			pageSize: newPageSize,
			pageNumber: 1
		}));
	};

	const handleOrderByChange = (newOrderBy: SearchOrderParameter<TReadModel>) => {
		setSearchParameter(prevParameter => ({
			...prevParameter,
			orderBy: newOrderBy,
			pageNumber: 1
		}));
	};

	const setFilter = (newFilter: SearchFilter<TReadModel>) => {
		setSearchParameter(prevParameter => {
			const newParam = { ...prevParameter };
			const oldFilter = newParam.filters.findIndex(f => f.property === newFilter.property);

			if (oldFilter >= 0) {
				newParam.filters[oldFilter] = newFilter;
			} else {
				newParam.filters.push(newFilter);
			}

			return newParam;
		});
	};

	const clearFilter = (property: keyof TReadModel) => {
		setSearchParameter(prevParameter => {
			const newParam = { ...prevParameter };
			newParam.filters = prevParameter.filters.filter(f => f.property !== property);
			return newParam;
		});
	};

	return {
		parameter: searchParameter,
		setParameter: setSearchParameter,
		result: searchResult,
		setResult: setSearchResult,
		handlePageNumberChange,
		handlePageSizeChange,
		handleOrderByChange,
		areFiltersOpen,
		setFiltersOpen: setAreFiltersOpen,
		setFilter,
		clearFilter
	};
};

export default useSearch;
