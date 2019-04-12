namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class ByteElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public byte MinValue { get; set; }

        public byte MaxValue { get; set; }
    }
}