import * as React from 'react';

import {
    Button, Dialog, DialogActions, DialogContent, DialogTitle, StyledComponentProps,
    StyleRulesCallback, TextField, withStyles
} from '@material-ui/core';
import green from '@material-ui/core/colors/green';
import AddIcon from '@material-ui/icons/AddRounded';

import { Locales } from '../../locales/Locales';

interface ICategoriesPageState {
    isAddDialogOpen: boolean;
    addCategoryData: {
        name: string
    };
}

const styles: StyleRulesCallback = theme => ({
    addFab: {
        backgroundColor: green[500],
        bottom: theme.spacing.unit * 5,
        color: theme.palette.common.white,
        position: 'absolute',
        right: theme.spacing.unit * 5
    }
});

class CategoriesPage extends React.Component<StyledComponentProps, ICategoriesPageState> {
    constructor(props: StyledComponentProps) {
        super(props);

        this.state = {
            addCategoryData: {
                name: ''
            },
            isAddDialogOpen: false
        };
    }

    public render() {
        return (
            <div>
                <Button variant="fab" className={this.props.classes!.addFab} onClick={this.handleAddFabClick}>
                    <AddIcon />
                </Button>

                <Dialog open={this.state.isAddDialogOpen} onClose={this.handleAddDialogClose}>
                    <form onSubmit={this.handleAddCategoryFormSubmit}>
                        <DialogTitle>
                            {Locales.addCategory}
                        </DialogTitle>
                        <DialogContent>
                            <TextField
                                autoFocus={true}
                                label={Locales.name}
                                value={this.state.addCategoryData.name}
                                onChange={this.handleAddDialogNameChange}
                            />
                        </DialogContent>
                        <DialogActions>
                            <Button color="primary" type="submit">
                                {Locales.save}
                            </Button>
                            <Button color="secondary" onClick={this.handleAddDialogCancelButtonClick}>
                                {Locales.cancel}
                            </Button>
                        </DialogActions>
                    </form>
                </Dialog>
            </div>
        );
    }

    private openAddDialog = () => {
        this.setState(prevState => ({ ...prevState, isAddDialogOpen: true }));
    }

    private closeAddDialog = () => {
        this.setState(prevState => ({ ...prevState, isAddDialogOpen: false }));
    }

    private clearAddCategoryData = () => {
        this.setState(prevState => ({
            ...prevState,
            addCategoryData: {
                name: ''
            }
        }));
    }

    private handleAddFabClick = () => {
        this.openAddDialog();
    }

    private handleAddDialogClose = () => {
        this.closeAddDialog();
    }

    private handleAddDialogCancelButtonClick = () => {
        this.closeAddDialog();
    }

    private handleAddDialogNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const newValue = e.target.value;
        this.setState(prevState => ({
            ...prevState,
            addCategoryData: {
                ...prevState.addCategoryData,
                name: newValue
            }
        }));
    }

    private handleAddCategoryFormSubmit = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        this.closeAddDialog();
        this.clearAddCategoryData();
    }
}

export default withStyles(styles)(CategoriesPage);