import SearchFilter from './SearchFilter';
import SearchOrderParameter from './SearchOrderParameter';

interface SearchParameter<TReadModel> {
	orderBy: SearchOrderParameter<TReadModel>;
	orderBy2?: SearchOrderParameter<TReadModel>;
	orderBy3?: SearchOrderParameter<TReadModel>;
	pageSize: number;
	pageNumber: number;
	filters: Array<SearchFilter<TReadModel>>;
}

export default SearchParameter;
