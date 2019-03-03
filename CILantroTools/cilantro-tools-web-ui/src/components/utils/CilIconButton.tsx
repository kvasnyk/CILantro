import React, { FunctionComponent } from 'react';

import { IconButton, Tooltip } from '@material-ui/core';

interface CilIconButtonProps {
	onClick: () => Promise<unknown>;
	disabledReason?: string;
}

const CilIconButton: FunctionComponent<CilIconButtonProps> = props => {
	return (
		<>
			{props.disabledReason ? (
				<Tooltip title={props.disabledReason} placement="right">
					<div>
						<IconButton onClick={props.onClick} disabled={true}>
							{props.children}
						</IconButton>
					</div>
				</Tooltip>
			) : (
				<IconButton onClick={props.onClick}>{props.children}</IconButton>
			)}
		</>
	);
};

export default CilIconButton;
