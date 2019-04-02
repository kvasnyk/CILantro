using CILantroToolsWebAPI.Models.Tests.InputOutput;

namespace CILantroToolsWebAPI.BindingModels.Tests
{
    public class EditTestInputBindingModel
    {
        public bool HasEmptyInput { get; set; }

        public InputOutput Input { get; set; }
    }
}