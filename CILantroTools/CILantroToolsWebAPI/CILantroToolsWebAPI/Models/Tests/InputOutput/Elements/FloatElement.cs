namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class FloatElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public float MinValue { get; set; }

        public float MaxValue { get; set; }

        public bool ExcludeZero { get; set; }
    }
}