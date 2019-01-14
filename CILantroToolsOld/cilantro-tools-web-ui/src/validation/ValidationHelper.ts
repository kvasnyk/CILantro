import DataValidation from '../types/DataValidation';

class ValidationHelper {
    public static isValid<TData>(dataValidation: DataValidation<TData>) {
        return Object.keys(dataValidation).every(key => dataValidation[key]);
    }

    public static isNotEmpty(value: string) {
        if (!value) {
            return false;
        }

        return value !== '';
    }
}

export default ValidationHelper;