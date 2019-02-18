using CILantroToolsWebAPI.Models.Tests.InputOutput.Elements;
using Newtonsoft.Json;
using System;

namespace CILantroToolsWebAPI.JsonConverters
{
    public class AbstractInputOutputElementJsonConverter : JsonConverter<AbstractInputOutputElement>
    {
        public override AbstractInputOutputElement ReadJson(JsonReader reader, Type objectType, AbstractInputOutputElement existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, AbstractInputOutputElement value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}