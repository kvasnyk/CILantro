import React, { StatelessComponent } from 'react';

import CategoryReadModel from '../../../api/read-models/categories/CategoryReadModel';

interface CilCategoryCardProps {
  category: CategoryReadModel;
}

const CilCategoryCard: StatelessComponent<CilCategoryCardProps> = props => {
  return <div>CilCategoryCard</div>;
};

export default CilCategoryCard;
