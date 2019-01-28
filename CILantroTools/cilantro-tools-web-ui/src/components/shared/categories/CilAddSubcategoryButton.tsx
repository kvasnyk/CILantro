import React, {
  ChangeEvent,
  FormEvent,
  StatelessComponent,
  useState
} from 'react';

import {
  Button,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  IconButton,
  TextField
} from '@material-ui/core';
import AddIcon from '@material-ui/icons/AddRounded';

import CategoriesApiClient from '../../../api/clients/CategoriesApiClient';
import CategoryReadModel from '../../../api/read-models/categories/CategoryReadModel';
import useNotistack from '../../../hooks/external/useNotistack';
import translations from '../../../translations/translations';

interface AddSubcategoryData {
  name: string;
}

const buildEmptyAddSubcategoryData = (): AddSubcategoryData => ({
  name: ''
});

interface CilAddSubcategoryButtonProps {
  category: CategoryReadModel;
  onSubcategoryAdded: () => void;
}

const CilAddSubcategoryButton: StatelessComponent<
  CilAddSubcategoryButtonProps
> = props => {
  const categoriesApiClient = new CategoriesApiClient();

  const notistack = useNotistack();

  const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);
  const [formData, setFormData] = useState<AddSubcategoryData>(
    buildEmptyAddSubcategoryData()
  );

  const handleClick = () => {
    setIsDialogOpen(true);
  };

  const handleDialogClose = () => {
    setIsDialogOpen(false);
  };

  const handleNameChange = (e: ChangeEvent<HTMLInputElement>) => {
    setFormData({
      ...formData,
      name: e.target.value
    });
  };

  const handleFormSubmit = async (e: FormEvent) => {
    e.preventDefault();

    try {
      await categoriesApiClient.addSubcategory({
        ...formData,
        categoryId: props.category.id
      });
      notistack.enqueueSnackbar(
        translations.categories.subcategoryHasBeenAdded,
        { variant: 'success' }
      );
      setIsDialogOpen(false);
      setFormData(buildEmptyAddSubcategoryData());
      props.onSubcategoryAdded();
    } catch (error) {
      notistack.enqueueSnackbar(
        translations.categories.errorOccurredWhileAddingSubcategory,
        { variant: 'error' }
      );
    }
  };

  return (
    <>
      <IconButton onClick={handleClick}>
        <AddIcon />
      </IconButton>

      <Dialog open={isDialogOpen} onClose={handleDialogClose} fullWidth={true}>
        <form onSubmit={handleFormSubmit}>
          <DialogTitle>{translations.categories.addSubcategory}</DialogTitle>
          <DialogContent>
            <TextField
              label={translations.categories.subcategoryName}
              value={formData.name}
              onChange={handleNameChange}
              autoFocus={true}
              fullWidth={true}
            />
          </DialogContent>
          <DialogActions>
            <Button color="primary" type="submit">
              {translations.shared.save}
            </Button>
          </DialogActions>
        </form>
      </Dialog>
    </>
  );
};

export default CilAddSubcategoryButton;
