namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class UshortElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public ushort MinValue { get; set; }

        public ushort MaxValue { get; set; }

        public bool ExcludeZero { get; set; }
    }
}