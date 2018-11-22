import * as React from 'react';

import { TextField } from '@material-ui/core';
import AddIcon from '@material-ui/icons/AddRounded';

import CategoriesApiClient from '../../../api/clients/CategoriesApiClient';
import { Locales } from '../../../locales/Locales';
import DataValidation from '../../../types/DataValidation';
import ValidationHelper from '../../../validation/ValidationHelper';
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
    dataValidation: DataValidation<AddCategoryData>;
    isButtonLoading: boolean;
}

class AddCategoryDialogButton extends React.Component<AddCategoryDialogButtonProps, AddCategoryDialogButtonState> {
    private readonly categoriesApiClient: CategoriesApiClient;

    constructor(props: AddCategoryDialogButtonProps) {
        super(props);

        this.categoriesApiClient = new CategoriesApiClient();

        this.state = {
            data: this.getEmptyData(),
            dataValidation: {},
            isButtonLoading: false
        };
    }

    public componentDidMount() {
        this.updateValidation();
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
                isOkButtonDisabled={!ValidationHelper.isValid(this.state.dataValidation)}
                isLoading={this.state.isButtonLoading}
            >
                <TextField
                    autoFocus={true}
                    label={Locales.name}
                    value={this.state.data.name}
                    onChange={this.handleNameChange}
                    error={!this.state.dataValidation.name}
                />
                <br />
                <br />
                <TextField
                    label={Locales.code}
                    value={this.state.data.code}
                    onChange={this.handleCodeChange}
                    error={!this.state.dataValidation.code}
                />
            </DialogButton>
        );
    }

    private changeData(addCategoryDataKey: keyof AddCategoryData, e: React.ChangeEvent<HTMLInputElement>) {
        e.preventDefault();
        const newValue = e.currentTarget.value;

        this.setState(prevState => ({
            ...prevState,
            data: {
                ...prevState.data,
                [addCategoryDataKey]: newValue
            }
        }), () => {
            this.updateValidation();
        });
    };

    private enableButtonLoading() {
        this.setState(prevState => ({
            ...prevState,
            isButtonLoading: true
        }));
    }

    private disableButtonLoading() {
        this.setState(prevState => ({
            ...prevState,
            isButtonLoading: false
        }));
    }

    private addCategory() {
        this.enableButtonLoading();
        this.categoriesApiClient.createCategory(this.state.data)
            .then(() => {
                if(this.props.onCategoryAdded) {
                    this.props.onCategoryAdded();
                }

                this.disableButtonLoading();
            })
            .catch(() => {
                alert('add category - error!');
                this.disableButtonLoading();
            });
    }

    private clearData() {
        this.setState(prevState => ({
            ...prevState,
            data: this.getEmptyData()
        }), () => {
            this.updateValidation();
        });
    }

    private getEmptyData() {
        return ({
            code: '',
            name: ''
        });
    }

    private updateValidation() {
        this.setState(prevState => ({
            ...prevState,
            dataValidation: {
                code: ValidationHelper.isNotEmpty(prevState.data.code),
                name: ValidationHelper.isNotEmpty(prevState.data.name)
            }
        }));
    }

    private handleNameChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.changeData('name', e);
    }

    private handleCodeChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        this.changeData('code', e);
    }

    private handleOkButtonClick = () => {
        this.addCategory();
    }

    private handleDialogClose = () => {
        this.clearData();
    }
};

export default AddCategoryDialogButton;