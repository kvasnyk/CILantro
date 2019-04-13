namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class CharElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public bool HasBigLetters { get; set; }

        public bool HasSmallLetters { get; set; }

        public bool HasDigits { get; set; }

        public bool HasSymbols { get; set; }
    }
}