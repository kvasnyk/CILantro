import React, { FunctionComponent } from 'react';

import { Typography } from '@material-ui/core';

interface CilPageSubheaderProps {
	text: string;
}

const CilPageSubheader: FunctionComponent<CilPageSubheaderProps> = props => {
	return <Typography variant="subtitle1">{props.text}</Typography>;
};

export default CilPageSubheader;
