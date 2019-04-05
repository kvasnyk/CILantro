interface SearchResult<TReadModel> {
	data: TReadModel[];
	count: number;
}

export default SearchResult;
