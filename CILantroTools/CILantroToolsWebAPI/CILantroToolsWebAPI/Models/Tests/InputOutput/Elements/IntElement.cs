namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class IntElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public int MinValue { get; set; }

        public int MaxValue { get; set; }

        public bool ExcludeZero { get; set; }
    }
}