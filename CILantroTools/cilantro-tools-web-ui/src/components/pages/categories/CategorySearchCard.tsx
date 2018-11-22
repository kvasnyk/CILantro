import * as React from 'react';

import {
    Avatar, Card, CardContent, CardHeader, Collapse, StyledComponentProps, StyleRulesCallback,
    withStyles
} from '@material-ui/core';
import indigo from '@material-ui/core/colors/indigo';

import CategorySearchReadModel from '../../../api/read-models/CategorySearchReadModel';

interface CategorySearchCardProps extends StyledComponentProps {
    category: CategorySearchReadModel
}

const styles: StyleRulesCallback = theme => ({
    avatar: {
        backgroundColor: indigo[500],
        color: 'white'
    },
    card: {
        '&:last-child': {
            marginBottom: 0
        },
        marginBottom: 20
    }
});

const CategorySearchCard: React.StatelessComponent<CategorySearchCardProps> = (props) => {
    return (
        <Card className={props.classes!.card}>
            <CardHeader
                avatar={
                    <Avatar className={props.classes!.avatar}>{props.category.code}</Avatar>
                }
                title={props.category.name}
            />
            <Collapse>
                <CardContent>
                    TEST
                </CardContent>
            </Collapse>
        </Card>
    );
}

export default withStyles(styles)(CategorySearchCard);