import React from 'react';

import { TablePagination, Theme } from '@material-ui/core';
import { makeStyles } from '@material-ui/styles';

import { UseSearchHookResult } from '../../hooks/useSearch';
import translations from '../../translations/translations';

const useStyles = makeStyles((theme: Theme) => ({
	pagination: {
		borderBottom: 'none'
	},
	paginationSelect: {
		fontSize: '1rem'
	},
	paginationSelectIcon: {
		top: '3px',
		right: '-5px'
	}
}));

interface CilPaginationProps<TReadModel> {
	search: UseSearchHookResult<TReadModel>;
}

const CilPagination = <TReadModel extends {}>(props: CilPaginationProps<TReadModel>) => {
	const classes = useStyles();

	const handleChangePage = (_: React.MouseEvent<HTMLButtonElement> | null, page: number) => {
		props.search.handlePageNumberChange(page + 1);
	};

	const handleChangeRowsPerChange: React.ChangeEventHandler<HTMLTextAreaElement | HTMLInputElement> = e => {
		const newPageSize = parseInt(e.target.value, 10);
		props.search.handlePageSizeChange(newPageSize);
	};

	return (
		<TablePagination
			className={classes.pagination}
			classes={{
				select: classes.paginationSelect,
				selectIcon: classes.paginationSelectIcon
			}}
			count={props.search.result.count}
			page={props.search.parameter.pageNumber - 1}
			rowsPerPage={props.search.parameter.pageSize}
			onChangePage={handleChangePage}
			onChangeRowsPerPage={handleChangeRowsPerChange}
			labelRowsPerPage={translations.shared.resultsPerPage}
		/>
	);
};

export default CilPagination;
