using CILantroToolsWebAPI.Enums;

namespace CILantroToolsWebAPI.BindingModels.Categories
{
    public class AddCategoryBindingModel
    {
        public string Name { get; set; }

        public BaseLanguage Language { get; set; }
    }
}