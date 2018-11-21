import * as React from 'react';

import { StyledComponentProps, StyleRulesCallback, withStyles } from '@material-ui/core';
import green from '@material-ui/core/colors/green';

import CategoriesApiClient from '../../../api/clients/CategoriesApiClient';
import CategorySearchReadModel from '../../../api/read-models/CategorySearchReadModel';
import SearchResult from '../../../api/search/SearchResult';
import AddCategoryDialogButton from './AddCategoryDialogButton';
import CategoriesList from './CategoriesList';

interface AddCategoryData {
    name: string;
    code: string;
}

interface CategoriesPageState {
    isAddDialogOpen: boolean;
    addCategoryData: AddCategoryData;
    searchResult: SearchResult<CategorySearchReadModel>
}

const styles: StyleRulesCallback = theme => ({
    addFab: {
        backgroundColor: green[500],
        bottom: theme.spacing.unit * 2,
        color: theme.palette.common.white,
        position: 'absolute',
        right: theme.spacing.unit * 2 + 600,
    }
});

class CategoriesPage extends React.Component<StyledComponentProps, CategoriesPageState> {
    private categoriesApiClient: CategoriesApiClient;

    constructor(props: StyledComponentProps) {
        super(props);

        this.categoriesApiClient = new CategoriesApiClient();

        this.state = {
            addCategoryData: {
                code: '',
                name: ''
            },
            isAddDialogOpen: false,
            searchResult: {
                results: []
            }
        };
    }

    public componentDidMount() {
        this.refreshCategories();
    }

    public render() {
        return (
            <>
                <AddCategoryDialogButton variant="fab" className={this.props.classes!.addFab} onCategoryAdded={this.handleCategoryAdded} />

                <CategoriesList searchResult={this.state.searchResult} />
            </>
        );
    }

    private refreshCategories() {
        this.categoriesApiClient.searchCategories({
            orderBy: 'name'
        })
        .then(result => {
            this.setState(prevState => ({ ...prevState, searchResult: result.data }));
        });
    }

    private handleCategoryAdded = () => {
        this.refreshCategories();
    }
}

export default withStyles(styles)(CategoriesPage);