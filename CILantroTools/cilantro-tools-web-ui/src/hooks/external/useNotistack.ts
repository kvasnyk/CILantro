import { SnackbarContextNext } from 'notistack/build/SnackbarContext';
import { useContext } from 'react';

const useNotistack = () => {
	const enqueueSnackbar = useContext(SnackbarContextNext);

	const enqueueSuccess = (message: string) =>
		enqueueSnackbar(message, {
			variant: 'success'
		});

	const enqueueError = (message: string) =>
		enqueueSnackbar(message, {
			variant: 'error'
		});

	return {
		enqueueError,
		enqueueSuccess
	};
};

export default useNotistack;
