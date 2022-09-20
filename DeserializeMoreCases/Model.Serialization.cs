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
        public void Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("requiredString");
            writer.WriteStringValue(RequiredString);

            writer.WritePropertyName("requiredInt");
            writer.WriteNumberValue(RequiredInt);

            writer.WritePropertyName("requiredLong");
            writer.WriteNumberValue(RequiredLong);

            writer.WritePropertyName("requiredFloat");
            writer.WriteNumberValue(RequiredFloat);

            writer.WritePropertyName("requiredDouble");
            writer.WriteNumberValue(RequiredDouble);

            writer.WritePropertyName("requiredDateTime");
            writer.WriteStringValue(RequiredDateTime, "O");

            writer.WritePropertyName("requiredDuration");
            writer.WriteStringValue(RequiredDuration, "P");

            writer.WritePropertyName("requiredBoolean");
            writer.WriteBooleanValue(RequiredBoolean);

            if (RequiredStringArray != null)
            {
                writer.WritePropertyName("requiredStringArray");
                writer.WriteStartArray();
                foreach (var item in RequiredStringArray)
                {
                    writer.WriteStringValue(item);
                }
                writer.WriteEndArray();
            }

            if (RequiredIntArray != null)
            {
                writer.WritePropertyName("requiredIntArray");
                writer.WriteStartArray();
                foreach (var item in RequiredIntArray)
                {
                    writer.WriteNumberValue(item);
                }
                writer.WriteEndArray();
            }

            if (RequiredChildModelArray != null)
            {
                writer.WritePropertyName("requiredChildModelArray");
                writer.WriteStartArray();
                foreach (var item in RequiredChildModelArray)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
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

                    case JsonTokenType.StartArray:
                        break;

                    case JsonTokenType.EndArray:
                        break;

                    case JsonTokenType.PropertyName:
                        {
                            if (reader.ValueTextEquals("requiredString"))
                            {
                                reader.Skip();
                                RequiredString = reader.GetString();
                                continue;
                            }

                            if (reader.ValueTextEquals("requiredInt"))
                            {
                                reader.Skip();
                                RequiredInt = reader.GetInt32();
                                continue;
                            }

                            if (reader.ValueTextEquals("requiredLong"))
                            {
                                reader.Skip();
                                RequiredLong = reader.GetInt64();
                                continue;
                            }

                            if (reader.ValueTextEquals("requiredFloat"))
                            {
                                reader.Skip();
                                RequiredFloat = reader.GetSingle();
                                continue;
                            }

                            if (reader.ValueTextEquals("requiredDouble"))
                            {
                                reader.Skip();
                                RequiredDouble = reader.GetDouble();
                                continue;
                            }

                            if (reader.ValueTextEquals("requiredDateTime"))
                            {
                                reader.Skip();
                                RequiredDateTime = reader.GetDateTimeOffset("O");
                                continue;
                            }

                            if (reader.ValueTextEquals("requiredDuration"))
                            {
                                reader.Skip();
                                RequiredDuration = reader.GetTimeSpan("P");
                                continue;
                            }

                            if (reader.ValueTextEquals("requiredBoolean"))
                            {
                                reader.Skip();
                                RequiredBoolean = reader.GetBoolean();
                                continue;
                            }

                            if (reader.ValueTextEquals("requiredIntArray"))
                            {
                                reader.Read(); // Advance to StartArray
                                RequiredIntArray = new List<int>();
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    RequiredIntArray.Add(reader.GetInt32());
                                }
                                continue;
                            }

                            if (reader.ValueTextEquals("requiredStringArray"))
                            {
                                reader.Read();
                                RequiredStringArray = new List<string>();
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    RequiredStringArray.Add(reader.GetString());
                                }
                                continue;
                            }

                            if (reader.ValueTextEquals("children"))
                            {
                                RequiredChildModelArray = reader.ReadObjectArray<ChildModel>();
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
