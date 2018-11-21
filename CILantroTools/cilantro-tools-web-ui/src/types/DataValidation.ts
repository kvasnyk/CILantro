type DataValidation<TData> = {
    [TKey in keyof TData]?: boolean;
};

export default DataValidation;