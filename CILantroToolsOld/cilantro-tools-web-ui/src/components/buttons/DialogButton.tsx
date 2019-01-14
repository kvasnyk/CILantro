import * as classNames from 'classnames';
import * as React from 'react';
import { Key } from 'ts-keycode-enum';

import {
    Button, CircularProgress, Dialog, DialogActions, DialogContent, DialogTitle,
    StyledComponentProps
} from '@material-ui/core';
import green from '@material-ui/core/colors/green';
import { SvgIconProps } from '@material-ui/core/SvgIcon';

import { Locales } from '../../locales/Locales';

interface DialogButtonProps extends StyledComponentProps {
    className?: string;
    icon: React.ReactElement<SvgIconProps>;
    isLoading: boolean;
    isOkButtonDisabled?: boolean;
    okButtonLabel: string;
    onDialogClose?: () => void;
    onOkButtonClick: () => void;
    title: string;
    variant: 'fab';
}

interface DialogButtonState {
    isDialogOpen: boolean;
}

class DialogButton extends React.Component<DialogButtonProps, DialogButtonState> {
    constructor(props: DialogButtonProps) {
        super(props);

        this.state = {
            isDialogOpen: false
        };
    }

    public render() {
        const buttonColor = green[500];
        const buttonClassName = classNames(this.props.className);
        
        const isLoading = this.props.isLoading;

        return (
            <>
                <Button
                    variant={this.props.variant}
                    className={buttonClassName}
                    onClick={this.handleButtonClick}
                    disabled={isLoading}
                    style={{
                        backgroundColor: isLoading ? '#fafafa' : buttonColor
                    }}
                >
                    {isLoading ? (
                        <CircularProgress style={{
                            color: buttonColor
                        }} />
                    ) : (
                        <>
                            {this.props.icon}  
                        </>
                    )}
                </Button>
                <Dialog open={this.state.isDialogOpen} onClose={this.handleDialogClose} onKeyPress={this.handleKeyPress}>
                    <DialogTitle>
                        {this.props.title}
                    </DialogTitle>
                    <DialogContent>
                        {this.props.children}
                    </DialogContent>
                    <DialogActions>
                        <Button color="primary" onClick={this.handleOkButtonClick} disabled={this.props.isOkButtonDisabled}>
                            {this.props.okButtonLabel}
                        </Button>
                        <Button color="secondary" onClick={this.handleDialogCancelButtonClick}>
                            {Locales.cancel}
                        </Button>
                    </DialogActions>
                </Dialog>
            </>
        );
    }

    private openDialog() {
        this.setState(prevState => ({
            ...prevState,
            isDialogOpen: true
        }));
    }

    private closeDialog() {
        this.setState(prevState => ({
            ...prevState,
            isDialogOpen: false
        }), () => {
            if (this.props.onDialogClose) {
                this.props.onDialogClose();
            }
        });
    }

    private handleButtonClick = () => {
        this.openDialog();
    }

    private handleDialogClose = () => {
        this.closeDialog();
    }

    private handleOkButtonClick = () => {
        if (this.props.onOkButtonClick) {
            this.props.onOkButtonClick();
        }

        this.closeDialog();
    }

    private handleDialogCancelButtonClick = () => {
        this.closeDialog();
    }

    private handleKeyPress = (e: React.KeyboardEvent<HTMLDivElement>) => {
        switch (e.which) {
            case Key.Enter:
                if (!this.props.isOkButtonDisabled) {
                    this.handleOkButtonClick();
                }
                break;
            default:
                break;
        }
    }
}

export default DialogButton;