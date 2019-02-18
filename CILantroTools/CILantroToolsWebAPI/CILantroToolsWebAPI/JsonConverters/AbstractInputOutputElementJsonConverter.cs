using CILantroToolsWebAPI.Models.Tests.InputOutput.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;

namespace CILantroToolsWebAPI.JsonConverters
{
    public class AbstractInputOutputElementJsonConverter : JsonConverter<AbstractInputOutputElement>
    {
        private class AbstractInputOutputElementContractResolver : DefaultContractResolver
        {
            protected override JsonConverter ResolveContractConverter(Type objectType)
            {
                if (typeof(AbstractInputOutputElement).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                    return null;
                return base.ResolveContractConverter(objectType);
            }
        }

        public override AbstractInputOutputElement ReadJson(JsonReader reader, Type objectType, AbstractInputOutputElement existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new AbstractInputOutputElementContractResolver()
            };

            var jObject = JObject.Load(reader);
            switch (jObject["type"].Value<string>())
            {
                case "ConstString":
                    return JsonConvert.DeserializeObject<ConstStringElement>(jObject.ToString(), jsonSerializerSettings);
                default:
                    throw new ArgumentException();
            }
        }

        public override void WriteJson(JsonWriter writer, AbstractInputOutputElement value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}