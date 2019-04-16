namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class DecimalElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public decimal MinValue { get; set; }

        public decimal MaxValue { get; set; }

        public bool ExcludeZero { get; set; }
    }
}