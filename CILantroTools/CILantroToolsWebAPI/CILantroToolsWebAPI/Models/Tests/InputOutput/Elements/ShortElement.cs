namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class ShortElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public short MinValue { get; set; }

        public short MaxValue { get; set; }

        public bool ExcludeZero { get; set; }
    }
}