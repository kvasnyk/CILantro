namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class DoubleElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public double MinValue { get; set; }

        public double MaxValue { get; set; }

        public bool ExcludeZero { get; set; }
    }
}