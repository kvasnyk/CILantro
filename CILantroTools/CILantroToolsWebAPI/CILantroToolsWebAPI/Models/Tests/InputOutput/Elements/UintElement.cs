namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class UintElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public uint MinValue { get; set; }

        public uint MaxValue { get; set; }

        public bool ExcludeZero { get; set; }
    }
}