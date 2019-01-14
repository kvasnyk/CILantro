import * as React from 'react';

import {
    Paper, StyledComponentProps, StyleRulesCallback, Table, TableBody, TableCell, TableRow,
    Typography, withStyles
} from '@material-ui/core';

import SubcategorySearchReadModel from '../../../api/read-models/SubcategorySearchReadModel';
import { Locales } from '../../../locales/Locales';

interface SubcategoriesTableProps extends StyledComponentProps {
    subcategories: SubcategorySearchReadModel[];
}

const styles: StyleRulesCallback = theme => ({
    noSubcategoriesText: {
        textAlign: 'center'
    }
});

const SubcategoriesTable: React.StatelessComponent<SubcategoriesTableProps> = (props) => {
    return (
        <>
            {props.subcategories.length > 0 ? (
                <Paper>
                    <Table>
                        <TableBody>
                            {props.subcategories.map(subcategory => (
                                <TableRow key={subcategory.id}>
                                    <TableCell>{subcategory.name}</TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </Paper>
            ) : (
                <Typography variant="body1" className={props.classes!.noSubcategoriesText}>
                    {Locales.noSubcategoriesAdded}
                </Typography>
            )}
        </>
    );
};

export default withStyles(styles)(SubcategoriesTable);