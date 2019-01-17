import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';

import CilApp from './components/app/CilApp';

ReactDOM.render(
  <BrowserRouter>
    <CilApp />
  </BrowserRouter>,
  document.getElementById('root')
);
