import * as React from 'react';

import {
    Avatar, Card, CardHeader, StyledComponentProps, StyleRulesCallback, withStyles
} from '@material-ui/core';

import CategorySearchReadModel from '../../../api/read-models/CategorySearchReadModel';

interface CategorySearchCardProps extends StyledComponentProps {
    category: CategorySearchReadModel
}

const styles: StyleRulesCallback = theme => ({
    card: {
        marginBottom: 10
    }
});

const CategorySearchCard: React.StatelessComponent<CategorySearchCardProps> = (props) => {
    return (
        <Card className={props.classes!.card}>
            <CardHeader
                avatar={
                    <Avatar>CN</Avatar>
                }
                title={props.category.name}
            />
        </Card>
    );
}

export default withStyles(styles)(CategorySearchCard);