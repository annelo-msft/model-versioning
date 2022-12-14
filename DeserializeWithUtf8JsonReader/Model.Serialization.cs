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
    public partial class Model : IUtf8JsonSerializable, IUtf8JsonDeserializable
    {
        // These are internal in client libraries.
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("foo");
            writer.WriteStringValue(Foo);
            writer.WritePropertyName("bar");
            writer.WriteStringValue(Bar);

            if (ModelProperty != null)
            {
                writer.WritePropertyName("model");
                writer.WriteObjectValue(ModelProperty);
            }

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

        public static Model Deserialize(ref Utf8JsonReader reader)
        {
            IUtf8JsonDeserializable model = new Model();
            model.Read(ref reader);
            return (Model)model;
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

                    case JsonTokenType.PropertyName:
                        {
                            if (reader.ValueTextEquals("foo"))
                            {
                                reader.Skip();
                                Foo = reader.GetString();
                                continue;
                            }

                            if (reader.ValueTextEquals("bar"))
                            {
                                reader.Skip();
                                Bar = reader.GetString();
                                continue;
                            }

                            if (reader.ValueTextEquals("model"))
                            {
                                // We don't do a Read/Skip here b/c it will happen in Deserialize
                                ModelProperty = Model.Deserialize(ref reader);
                                Console.Write(reader.Position);
                                continue;
                            }

                            // We don't recognize this property -- Store it in Unknown
                            if (UnknownProperties == null)
                            {
                                UnknownProperties = new Dictionary<string, JsonNode>();
                            }

                            string name = reader.GetString();
                            reader.Read();
                            JsonNode nodeValue = JsonNode.Parse(ref reader);
                            UnknownProperties.Add(name, nodeValue);
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
