import SearchOrderParameter from './SearchOrderParameter';

interface SearchParameter<TReadModel> {
	orderBy: SearchOrderParameter<TReadModel>;
	orderBy2?: SearchOrderParameter<TReadModel>;
	orderBy3?: SearchOrderParameter<TReadModel>;
	pageSize: number;
	pageNumber: number;
}

export default SearchParameter;
