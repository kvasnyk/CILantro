import React, { FunctionComponent } from 'react';

import { IconButton } from '@material-ui/core';
import BuildIcon from '@material-ui/icons/BuildRounded';

const CilGenerateTestIlSourcesButton: FunctionComponent = props => {
	return (
		<IconButton>
			<BuildIcon />
		</IconButton>
	);
};

export default CilGenerateTestIlSourcesButton;
