using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Azure.Core;

namespace ReadFromDeserializable
{
    public partial class Model : IUtf8JsonSerializable, IUtf8JsonDeserializable<Model>
    {
        // These are internal in client libraries.
        public void Write(Utf8JsonWriter writer)
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
            Model model = new Model();
            return model.Read(ref reader, model);
        }

        // These are internal in client libraries.
        public Model Read(ref Utf8JsonReader reader, Model value)
        {
            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartObject:
                        break;

                    case JsonTokenType.EndObject:
                        return value;

                    case JsonTokenType.PropertyName:
                        {
                            if (reader.ValueTextEquals("foo"))
                            {
                                reader.Skip();
                                value.Foo = reader.GetString();
                                continue;
                            }

                            if (reader.ValueTextEquals("bar"))
                            {
                                reader.Skip();
                                value.Bar = reader.GetString();
                                continue;
                            }

                            if (reader.ValueTextEquals("model"))
                            {
                                Console.Write(reader.Position);
                                // We shouldn't do a Read/Skip here b/c it will happen in Deserialize
                                value.ModelProperty = Model.Deserialize(ref reader);
                                Console.Write(reader.Position);
                                continue;
                            }

                            // We don't recognize this property
                            // Store it in Unknown
                            if (value.UnknownProperties == null)
                            {
                                value.UnknownProperties = new Dictionary<string, JsonNode>();
                            }

                            string name = reader.GetString();
                            reader.Read();
                            JsonNode nodeValue = JsonNode.Parse(ref reader);
                            value.UnknownProperties.Add(name, nodeValue);
                        }
                        break;

                    default:
                        // Silent - log a warning.
                        break;
                }
            }

            return value;
        }
    }
}
