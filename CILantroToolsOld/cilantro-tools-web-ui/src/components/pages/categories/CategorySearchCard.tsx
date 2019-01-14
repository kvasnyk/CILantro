import * as classNames from 'classnames';
import * as React from 'react';

import {
    Avatar, Card, CardContent, CardHeader, Collapse, IconButton, StyledComponentProps,
    StyleRulesCallback, withStyles
} from '@material-ui/core';
import indigo from '@material-ui/core/colors/indigo';
import ExpandMoreIcon from '@material-ui/icons/ExpandMoreRounded';

import CategorySearchReadModel from '../../../api/read-models/CategorySearchReadModel';
import SubcategoriesTable from './SubcategoriesTable';

interface CategorySearchCardProps extends StyledComponentProps {
    category: CategorySearchReadModel
}

interface CategorySearchCardState {
    isExpanded: boolean;
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
    },
    expandButton: {
        transform: 'rotate(0deg)',
        transition: theme.transitions.create('transform', {
            duration: theme.transitions.duration.shortest
        })
    },
    expandButtonOpen: {
        transform: 'rotate(90deg)'
    }
});

class CategorySearchCard extends React.Component<CategorySearchCardProps, CategorySearchCardState> {
    constructor(props: CategorySearchCardProps) {
        super(props);

        this.state = {
            isExpanded: false
        };
    }

    public render() {
        const expandButtonClassName = classNames(this.props.classes!.expandButton, {
            [this.props.classes!.expandButtonOpen!]: this.state.isExpanded
        });

        return (
            <Card className={this.props.classes!.card}>
                <CardHeader
                    avatar={
                        <Avatar className={this.props.classes!.avatar}>{this.props.category.code}</Avatar>
                    }
                    title={this.props.category.name}
                    action={
                        <IconButton onClick={this.handleExpandButtonClick} className={expandButtonClassName}>
                            <ExpandMoreIcon />
                        </IconButton>
                    }
                />
                <Collapse in={this.state.isExpanded}>
                    <CardContent>
                        <SubcategoriesTable subcategories={this.props.category.subcategories} />
                    </CardContent>
                </Collapse>
            </Card>
        );
    }

    private handleExpandButtonClick = () => {
        this.setState(prevState => ({ ...prevState, isExpanded: !prevState.isExpanded }));
    }
}

export default withStyles(styles)(CategorySearchCard);