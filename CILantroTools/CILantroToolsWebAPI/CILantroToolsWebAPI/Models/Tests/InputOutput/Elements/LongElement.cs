namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class LongElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public long MinValue { get; set; }

        public long MaxValue { get; set; }

        public bool ExcludeZero { get; set; }
    }
}