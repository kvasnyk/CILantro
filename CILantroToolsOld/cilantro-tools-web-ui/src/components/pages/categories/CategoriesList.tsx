import * as React from 'react';
import CategorySearchCard from 'src/components/pages/categories/CategorySearchCard';

import CategorySearchReadModel from '../../../api/read-models/CategorySearchReadModel';
import withSearch, { SearchProps } from '../../search/withSearch';

interface CategoriesListProps extends SearchProps<CategorySearchReadModel> {

}

const CategoriesList: React.StatelessComponent<CategoriesListProps> = (props) => {
    return (
        <div>
            {props.searchResult.results.map((category, index) => (
                <CategorySearchCard key={category.id} category={category} />
            ))}
        </div>
    );
};

export default withSearch(CategoriesList);