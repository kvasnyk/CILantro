import React, { StatelessComponent } from 'react';

import TestReadModel from '../../../api/read-models/tests/TestReadModel';
import CilGridLayout from '../../layouts/CilGridLayout';
import CiLTestCard from './CilTestCard';

interface CilTestsListProps {
  tests: TestReadModel[];
}

const CilTestsList: StatelessComponent<CilTestsListProps> = props => {
  return (
    <CilGridLayout columns={3}>
      {props.tests.map(test => (
        <CiLTestCard test={test} />
      ))}
    </CilGridLayout>
  );
};

export default CilTestsList;
