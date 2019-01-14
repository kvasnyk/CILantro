import * as React from 'react';

import {
    CircularProgress, StyledComponentProps, StyleRulesCallback, withStyles
} from '@material-ui/core';

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
    addCategoryData: AddCategoryData;
    searchResult: SearchResult<CategorySearchReadModel>;
    isLoading: boolean;
}

const styles: StyleRulesCallback = theme => ({
    addFab: {
        bottom: theme.spacing.unit * 2,
        color: theme.palette.common.white,
        position: 'absolute',
        right: theme.spacing.unit * 2 + 600,
    },
    loadingContainer: {
        alignItems: 'center',
        display: 'flex',
        height: '100%',
        justifyContent: 'center'
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
            isLoading: false,
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

                {this.state.isLoading ? (
                    <div className={this.props.classes!.loadingContainer}>
                        <CircularProgress className={this.props.classes!.circularProgress} />
                    </div>
                ) : (
                    <>
                        <CategoriesList searchResult={this.state.searchResult} />
                    </>
                )}
            </>
        );
    }

    private refreshCategories() {
        this.enableLoading();

        this.categoriesApiClient.searchCategories({
            orderBy: 'name'
        })
        .then(result => {
            this.setState(prevState => ({ ...prevState, searchResult: result.data }), () => {
                this.disableLoading();
            });
        })
        .catch(error => {
            alert('refresh categories - error!');
            this.disableLoading();
        })
    }

    private enableLoading() {
        this.setState(prevState => ({ ...prevState, isLoading: true }));
    }

    private disableLoading() {
        this.setState(prevState => ({ ...prevState, isLoading: false }));
    }

    private handleCategoryAdded = () => {
        this.refreshCategories();
    }
}

export default withStyles(styles)(CategoriesPage);