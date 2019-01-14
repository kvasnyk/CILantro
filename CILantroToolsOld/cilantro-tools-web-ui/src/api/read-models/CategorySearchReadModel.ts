import SubcategorySearchReadModel from './SubcategorySearchReadModel';

interface CategorySearchReadModel {
    id: string;
    name: string;
    code: string;
    subcategories: SubcategorySearchReadModel[];
}

export default CategorySearchReadModel;