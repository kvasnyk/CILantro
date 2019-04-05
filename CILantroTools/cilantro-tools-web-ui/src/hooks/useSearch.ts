import { Dispatch, SetStateAction, useState } from 'react';

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
}

const useSearch = <TReadModel>(
	initialSearchParameter: SearchParameter<TReadModel>
): UseSearchHookResult<TReadModel> => {
	const [searchParameter, setSearchParameter] = useState<SearchParameter<TReadModel>>(initialSearchParameter);
	const [searchResult, setSearchResult] = useState<SearchResult<TReadModel>>({ data: [], count: 0 });

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

	return {
		parameter: searchParameter,
		setParameter: setSearchParameter,
		result: searchResult,
		setResult: setSearchResult,
		handlePageNumberChange,
		handlePageSizeChange,
		handleOrderByChange
	};
};

export default useSearch;
