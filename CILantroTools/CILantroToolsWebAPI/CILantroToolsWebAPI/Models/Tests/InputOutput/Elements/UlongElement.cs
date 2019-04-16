namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    public class UlongElement : AbstractInputOutputElement
    {
        public string Name { get; set; }

        public ulong MinValue { get; set; }

        public ulong MaxValue { get; set; }

        public bool ExcludeZero { get; set; }
    }
}