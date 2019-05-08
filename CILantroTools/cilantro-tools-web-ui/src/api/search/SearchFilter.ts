import SearchFilterType from './SearchFilterType';

interface SearchFilter<TReadModel> {
	property: keyof TReadModel;
	type: SearchFilterType;
	value?: string;
	values?: string[];
}

export default SearchFilter;
