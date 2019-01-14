import SearchResult from 'src/api/search/SearchResult';

export interface SearchProps<TSearchReadModel> {
    searchResult: SearchResult<TSearchReadModel>;
}

const withSearch = <TSearchReadModel, TProps extends SearchProps<TSearchReadModel>>(WrappedInput: React.StatelessComponent<TProps>) => {
    return WrappedInput;
};

export default withSearch;