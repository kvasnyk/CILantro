import { SnackbarContextNext } from 'notistack/build/SnackbarContext';
import { useContext } from 'react';

const useNotistack = () => {
	const enqueueSnackbar = useContext(SnackbarContextNext);

	const enqueueSuccess = (message: string) =>
		enqueueSnackbar(message, {
			variant: 'success'
		});

	const enqueueError = (message: string, externalError: unknown) => {
		let errorMessage = message;

		const extErrorObj = externalError as any;
		if (
			extErrorObj &&
			extErrorObj.response &&
			extErrorObj.response.data &&
			typeof extErrorObj.response.data === 'string'
		) {
			errorMessage = extErrorObj.response.data as string;
		}

		enqueueSnackbar(errorMessage, {
			variant: 'error'
		});
	};

	return {
		enqueueError,
		enqueueSuccess
	};
};

export default useNotistack;
