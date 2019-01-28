using System;

namespace CILantroToolsWebAPI.BindingModels.Categories
{
    public class AddSubcategoryBindingModel
    {
        public Guid CategoryId { get; set; }

        public string Name { get; set; }
    }
}