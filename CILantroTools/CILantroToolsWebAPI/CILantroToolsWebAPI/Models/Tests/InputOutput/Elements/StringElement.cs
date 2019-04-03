namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class StringElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public int MinLength { get; set; }

        public int MaxLength { get; set; }

        public bool HasBigLetters { get; set; }

        public bool HasSmallLetters { get; set; }

        public bool HasDigits { get; set; }
    }
}