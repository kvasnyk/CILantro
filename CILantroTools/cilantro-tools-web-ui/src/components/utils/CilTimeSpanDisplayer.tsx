import React, { FunctionComponent } from 'react';

interface CilTimeSpanDisplayerProps {
	milliseconds: number;
	precision: 'seconds' | 'milliseconds';
}

const CilTimeSpanDisplayer: FunctionComponent<CilTimeSpanDisplayerProps> = props => {
	const hours = parseInt((props.milliseconds / 3600000).toString(), 10);
	const minutes = parseInt(((props.milliseconds - hours * 3600000) / 60000).toString(), 10);
	const seconds = parseInt(((props.milliseconds - hours * 3600000 - minutes * 60000) / 1000).toString(), 10);
	const milliseconds = props.milliseconds % 1000;

	const showMilliseconds = props.precision === 'milliseconds';

	return (
		<span>
			{('00' + hours).slice(-2)}:{('00' + minutes).slice(-2)}:{('00' + seconds).slice(-2)}
			{showMilliseconds ? <>.{('000' + milliseconds).slice(-3)}</> : null}
		</span>
	);
};

export default CilTimeSpanDisplayer;
