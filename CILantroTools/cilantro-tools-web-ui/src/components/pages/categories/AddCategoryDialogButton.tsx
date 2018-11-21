import * as React from 'react';

import { TextField } from '@material-ui/core';
import AddIcon from '@material-ui/icons/AddRounded';

import CategoriesApiClient from '../../../api/clients/CategoriesApiClient';
import { Locales } from '../../../locales/Locales';
import DialogButton from '../../buttons/DialogButton';

interface AddCategoryData {
    name: string;
    code: string;
}

interface AddCategoryDialogButtonProps {
    variant: 'fab';
    className?: string;
    onCategoryAdded?: () => void;
}

interface AddCategoryDialogButtonState {
    data: AddCategoryData;
}

const getEmptyData = () => {
    return ({
        code: '',
        name: ''
    });
}

class AddCategoryDialogButton extends React.Component<AddCategoryDialogButtonProps, AddCategoryDialogButtonState> {
    private readonly categoriesApiClient: CategoriesApiClient;

    constructor(props: AddCategoryDialogButtonProps) {
        super(props);

        this.categoriesApiClient = new CategoriesApiClient();

        this.state = {
            data: getEmptyData()
        };
    }

    public render() {
        return (
            <DialogButton
                variant={this.props.variant}
                className={this.props.className}
                title={Locales.addCategory}
                icon={<AddIcon />}
                okButtonLabel={Locales.save}
                onOkButtonClick={this.handleOkButtonClick}
                onDialogClose={this.handleDialogClose}
            >
                <TextField
                    autoFocus={true}
                    label={Locales.name}
                    value={this.state.data.name}
                    onChange={this.handleNameChange}
                />
                <br />
                <br />
                <TextField
                    label={Locales.code}
                    value={this.state.data.code}
                    onChange={this.handleCodeChange}
                />
            </DialogButton>
        );
    }

    private changeAddCategoryData(addCategoryDataKey: keyof AddCategoryData, e: React.ChangeEvent<HTMLInputElement>) {
        e.preventDefault();
        const newValue = e.currentTarget.value;

        this.setState(prevState => ({
            ...prevState,
            data: {
                ...prevState.data,
                [addCategoryDataKey]: newValue
            }
        }));
    };

    private addCategory() {
        this.categoriesApiClient.createCategory(this.state.data)
            .then(() => {
                if(this.props.onCategoryAdded) {
                    this.props.onCategoryAdded();
                }
            })
            .catch(() => {
                alert('add category - error!');
            });
    }

    private clearData() {
        this.setState(prevState => ({
            ...prevState,
            data: getEmptyData()
        }));
    }

    private handleNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.changeAddCategoryData('name', e);
    }

    private handleCodeChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.changeAddCategoryData('code', e);
    }

    private handleOkButtonClick = () => {
        this.addCategory();
    }

    private handleDialogClose = () => {
        this.clearData();
    }
};

export default AddCategoryDialogButton;