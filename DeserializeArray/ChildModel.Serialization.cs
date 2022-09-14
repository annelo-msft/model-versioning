using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.Core;

namespace DeserializeArray
{
    public partial class ChildModel : IUtf8JsonSerializable, IUtf8JsonDeserializable
    {
        // These are internal in client libraries.
        public void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("qux");
            writer.WriteNumberValue(Qux);
            writer.WritePropertyName("thud");
            writer.WriteBooleanValue(Thud);

            if (UnknownProperties != null)
            {
                foreach (var property in UnknownProperties)
                {
                    writer.WritePropertyName(property.Key);
                    property.Value.WriteTo(writer);
                }
            }

            writer.WriteEndObject();

            // Needed for sample
            writer.Flush();
        }

        public static ChildModel Deserialize(ref Utf8JsonReader reader)
        {
            IUtf8JsonDeserializable model = new ChildModel();
            model.Read(ref reader);
            return (ChildModel)model;
        }

        // These are internal in client libraries.
        void IUtf8JsonDeserializable.Read(ref Utf8JsonReader reader)
        {
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        break;

                    case JsonTokenType.EndObject:
                        return;

                    case JsonTokenType.StartArray:
                        break;

                    case JsonTokenType.EndArray:
                        break;

                    case JsonTokenType.PropertyName:
                        {
                            if (reader.ValueTextEquals("qux"))
                            {
                                reader.Skip();
                                Qux = reader.GetInt32();
                                continue;
                            }

                            if (reader.ValueTextEquals("thud"))
                            {
                                reader.Skip();
                                Thud = reader.GetBoolean();
                                continue;
                            }

                            // We don't recognize this property -- Store it in Unknown
                            if (UnknownProperties == null)
                            {
                                UnknownProperties = new Dictionary<string, JsonNode>();
                            }

                            string name = reader.GetString();
                            reader.Read();
                            UnknownProperties.Add(name, JsonNode.Parse(ref reader));
                        }
                        break;

                    default:
                        // Silent - log a warning.
                        break;
                }
            }
        }
    }
}
