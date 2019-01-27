declare module 'notistack/build/SnackbarContext' {
  import { OptionsObject } from 'notistack';
  import { Context } from 'react';

  export type EnqueueSnackbar = (
    message: string,
    options?: OptionsObject
  ) => void;

  export const SnackbarContextNext: Context<EnqueueSnackbar>;
}
