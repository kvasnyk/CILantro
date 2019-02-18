using System.Linq;

namespace CILantroToolsWebAPI.Models.Tests.InputOutput
{
    public class InputOutput
    {
        public InputOutputLine[] Lines { get; set; } = new InputOutputLine[0];

        public bool IsEmpty => !Lines.Any(l => l.Elements.Any());
    }
}