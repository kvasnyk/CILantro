import SearchDirection from './SearchDirection';

interface SearchOrderParameter<TReadModel> {
	property: keyof TReadModel;
	direction: SearchDirection;
}

export default SearchOrderParameter;
