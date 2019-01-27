import React, { StatelessComponent, useEffect, useState } from 'react';

import CategoriesApiClient from '../../api/clients/CategoriesApiClient';
import CategoryReadModel from '../../api/read-models/categories/CategoryReadModel';
import SearchResult from '../../api/search/SearchResult';
import CilPage, { PageState } from '../base/CilPage';
import CilAddCategoryButton from '../shared/categories/CilAddCategoryButton';
import CilCategoriesList from '../shared/categories/CilCategoriesList';

const CilCategoriesPage: StatelessComponent = props => {
  const categoriesApiClient = new CategoriesApiClient();

  const [pageState, setPageState] = useState<PageState>('loading');
  const [searchResult, setSearchResult] = useState<
    SearchResult<CategoryReadModel>
  >({ data: [] });

  const refreshCategories = async () => {
    try {
      const searchCategoriesResponse = await categoriesApiClient.searchCategories(
        {}
      );
      setSearchResult(searchCategoriesResponse.data);
      setPageState('success');
    } catch (error) {
      setPageState('error');
    }
  };

  useEffect(() => {
    refreshCategories();
  }, []);

  const centerChildren = searchResult.data.length <= 0;

  return (
    <CilPage
      state={pageState}
      centerChildren={centerChildren}
      menu={
        <>
          <CilAddCategoryButton />
        </>
      }
    >
      <CilCategoriesList categories={searchResult.data} />
    </CilPage>
  );
};

export default CilCategoriesPage;
