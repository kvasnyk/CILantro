namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class SbyteElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public sbyte MinValue { get; set; }

        public sbyte MaxValue { get; set; }

        public bool ExcludeZero { get; set; }
    }
}