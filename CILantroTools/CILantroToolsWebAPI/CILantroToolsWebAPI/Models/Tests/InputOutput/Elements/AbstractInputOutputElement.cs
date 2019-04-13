using CILantroToolsWebAPI.JsonConverters;
using Newtonsoft.Json;

namespace CILantroToolsWebAPI.Models.Tests.InputOutput.Elements
{
    [JsonConverter(typeof(AbstractInputOutputElementJsonConverter))]
    public abstract class AbstractInputOutputElement
    {
        public string Type { get; set; }

        public string Description { get; set; }
    }
}