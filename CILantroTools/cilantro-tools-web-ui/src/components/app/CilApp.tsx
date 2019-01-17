import React, { StatelessComponent } from 'react';

import { createMuiTheme } from '@material-ui/core';
import { ThemeProvider } from '@material-ui/styles';

import CilAppBar from './CilAppBar';

const theme = createMuiTheme();

const CilApp: StatelessComponent = props => {
  return (
    <ThemeProvider theme={theme}>
      <CilAppBar />
    </ThemeProvider>
  );
};

export default CilApp;
