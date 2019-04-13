using CILantroToolsWebAPI.Models.Tests.InputOutput.Elements;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;

namespace CILantroToolsWebAPI.JsonConverters
{
    public class AbstractInputOutputElementJsonConverter : JsonConverter<AbstractInputOutputElement>
    {
        private class AbstractInputOutputElementContractResolver : CamelCasePropertyNamesContractResolver
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
                case "String":
                    return JsonConvert.DeserializeObject<StringElement>(jObject.ToString(), jsonSerializerSettings);
                case "Bool":
                    return JsonConvert.DeserializeObject<BoolElement>(jObject.ToString(), jsonSerializerSettings);
                case "Byte":
                    return JsonConvert.DeserializeObject<ByteElement>(jObject.ToString(), jsonSerializerSettings);
                case "Short":
                    return JsonConvert.DeserializeObject<ShortElement>(jObject.ToString(), jsonSerializerSettings);
                case "Int":
                    return JsonConvert.DeserializeObject<IntElement>(jObject.ToString(), jsonSerializerSettings);
                case "Long":
                    return JsonConvert.DeserializeObject<LongElement>(jObject.ToString(), jsonSerializerSettings);
                case "Sbyte":
                    return JsonConvert.DeserializeObject<SbyteElement>(jObject.ToString(), jsonSerializerSettings);
                case "Uint":
                    return JsonConvert.DeserializeObject<UintElement>(jObject.ToString(), jsonSerializerSettings);
                case "Ulong":
                    return JsonConvert.DeserializeObject<UlongElement>(jObject.ToString(), jsonSerializerSettings);
                case "Ushort":
                    return JsonConvert.DeserializeObject<UshortElement>(jObject.ToString(), jsonSerializerSettings);
                default:
                    throw new ArgumentException();
            }
        }

        public override void WriteJson(JsonWriter writer, AbstractInputOutputElement value, JsonSerializer serializer)
        {
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new AbstractInputOutputElementContractResolver()
            };

            var json = JsonConvert.SerializeObject(value, jsonSerializerSettings);

            var jObject = JObject.Parse(json);
            jObject.WriteTo(writer);
        }
    }
}