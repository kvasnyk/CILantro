using CILantroToolsWebAPI.Enums;
using System;

namespace CILantroToolsWebAPI.BindingModels.Runs
{
    public class AddSingleTestRunBindingModel
    {
        public Guid TestId { get; set; }

        public RunType Type { get; set; }
    }
}