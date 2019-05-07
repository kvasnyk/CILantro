import React, { FunctionComponent, useState } from 'react';

import { CircularProgress, IconButton, Tooltip } from '@material-ui/core';

interface CilIconButtonProps {
	onClick: () => Promise<unknown>;
	disabledReason?: string;
	className?: string;
	iconClassName?: string;
	isLoading?: boolean;
}

const CilIconButton: FunctionComponent<CilIconButtonProps> = props => {
	const [isLoading, setIsLoading] = useState<boolean>(false);

	const handleClick = async () => {
		setIsLoading(true);
		await props.onClick();
		setIsLoading(false);
	};

	return (
		<>
			{props.disabledReason ? (
				<Tooltip title={props.disabledReason} placement="right">
					<div>
						<IconButton disabled={true} className={props.className}>
							{props.children}
						</IconButton>
					</div>
				</Tooltip>
			) : (
				<IconButton onClick={handleClick} className={props.className}>
					{isLoading || props.isLoading ? (
						<CircularProgress size={20} className={props.iconClassName} />
					) : (
						props.children
					)}
				</IconButton>
			)}
		</>
	);
};

export default CilIconButton;
