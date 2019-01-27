import { SnackbarContextNext } from 'notistack/build/SnackbarContext';
import { useContext } from 'react';

const useNotistack = () => {
  const enqueueSnackbar = useContext(SnackbarContextNext);

  return {
    enqueueSnackbar
  };
};

export default useNotistack;
