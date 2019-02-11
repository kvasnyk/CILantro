import React, { FunctionComponent } from 'react';

import translations from '../../translations/translations';

interface CilDetailsValueProps {
	value: string;
}

const CilDetailsValue: FunctionComponent<CilDetailsValueProps> = props => {
	return <>{props.value ? props.value : translations.shared.noInfo}</>;
};

export default CilDetailsValue;
