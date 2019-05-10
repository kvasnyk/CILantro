using CILantroToolsWebAPI.Models.Tests.InputOutput.Elements;

namespace CILantroToolsWebAPI.Models.Tests.InputOutput
{
    public class InputOutputLine
    {
        public AbstractInputOutputElement[] Elements { get; set; } = new AbstractInputOutputElement[0];



        public bool IsRepeatBlock { get; set; }

        public InputOutput RepeatBlockInputOutput { get; set; }

        public string RepeatBlockMin { get; set; }

        public string RepeatBlockMax { get; set; }
    }
}