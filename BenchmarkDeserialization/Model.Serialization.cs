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

            writer.WriteEndObject();

            // Needed for sample
            writer.Flush();
        }

        internal static Model DeserializeModel(JsonElement element)
        {
            string requiredString = default;
            int requiredInt = default;
            long requiredLong = default;
            float requiredFloat = default;
            double requiredDouble = default;
            bool requiredBoolean = default;
            DateTimeOffset requiredDateTime = default;
            TimeSpan requiredDuration = default;
            List<string> requiredStringArray = new List<string>();
            List<int> requiredIntArray = new List<int>();
            List<ChildModel> requiredChildModelArray = new List<ChildModel>();

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("requiredString"))
                {
                    requiredString = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("requiredInt"))
                {
                    requiredInt = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("requiredLong"))
                {
                    requiredLong = property.Value.GetInt64();
                    continue;
                }
                if (property.NameEquals("requiredFloat"))
                {
                    requiredFloat = property.Value.GetSingle();
                    continue;
                }
                if (property.NameEquals("requiredDouble"))
                {
                    requiredDouble = property.Value.GetDouble();
                    continue;
                }
                if (property.NameEquals("requiredDateTime"))
                {
                    requiredDateTime = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("requiredDuration"))
                {
                    requiredDuration = property.Value.GetTimeSpan("P");
                    continue;
                }
                if (property.NameEquals("requiredBoolean"))
                {
                    requiredBoolean = property.Value.GetBoolean();
                    continue;
                }

                if (property.NameEquals("requiredStringArray"))
                {
                    List<string> array = new List<string>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetString());
                    }
                    requiredStringArray = array;
                    continue;
                }
                if (property.NameEquals("requiredIntArray"))
                {
                    List<int> array = new List<int>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(item.GetInt32());
                    }
                    requiredIntArray = array;
                    continue;
                }
                if (property.NameEquals("requiredChildModelArray"))
                {
                    List<ChildModel> array = new List<ChildModel>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ChildModel.DeserializeChildModel(item));
                    }
                    requiredChildModelArray = array;
                    continue;
                }
            }
            return new Model(requiredString, requiredInt, requiredLong, requiredFloat, requiredDouble, requiredDateTime, requiredDuration, requiredBoolean, requiredStringArray, requiredIntArray, requiredChildModelArray);
        }

        public static Model Deserialize(ref Utf8JsonReader reader)
        {
            IUtf8JsonDeserializable model = new Model();
            model.Read(ref reader);
            return (Model)model;
        }

        static readonly byte[] b_requiredString = Encoding.UTF8.GetBytes("requiredString");
        static readonly byte[] b_requiredInt = Encoding.UTF8.GetBytes("requiredInt");
        static readonly byte[] b_requiredLong = Encoding.UTF8.GetBytes("requiredLong");
        static readonly byte[] b_requiredFloat = Encoding.UTF8.GetBytes("requiredFloat");
        static readonly byte[] b_requiredDouble = Encoding.UTF8.GetBytes("requiredDouble");
        static readonly byte[] b_requiredBoolean = Encoding.UTF8.GetBytes("requiredBoolean");
        static readonly byte[] b_requiredDateTime = Encoding.UTF8.GetBytes("requiredDateTime");
        static readonly byte[] b_requiredDuration = Encoding.UTF8.GetBytes("requiredDuration");
        static readonly byte[] b_requiredStringArray = Encoding.UTF8.GetBytes("requiredStringArray");
        static readonly byte[] b_requiredIntArray = Encoding.UTF8.GetBytes("requiredIntArray");
        static readonly byte[] b_requiredChildModelArray = Encoding.UTF8.GetBytes("requiredChildModelArray");

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
                            if (reader.ValueTextEquals(b_requiredString))
                            {
                                reader.Skip();
                                RequiredString = reader.GetString();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_requiredInt))
                            {
                                reader.Skip();
                                RequiredInt = reader.GetInt32();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_requiredLong))
                            {
                                reader.Skip();
                                RequiredLong = reader.GetInt64();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_requiredFloat))
                            {
                                reader.Skip();
                                RequiredFloat = reader.GetSingle();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_requiredDouble))
                            {
                                reader.Skip();
                                RequiredDouble = reader.GetDouble();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_requiredDateTime))
                            {
                                reader.Skip();
                                RequiredDateTime = reader.GetDateTimeOffset("O");
                                continue;
                            }

                            if (reader.ValueTextEquals(b_requiredDuration))
                            {
                                reader.Skip();
                                RequiredDuration = reader.GetTimeSpan("P");
                                continue;
                            }

                            if (reader.ValueTextEquals(b_requiredBoolean))
                            {
                                reader.Skip();
                                RequiredBoolean = reader.GetBoolean();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_requiredIntArray))
                            {
                                reader.Read(); // Advance to StartArray
                                RequiredIntArray = new List<int>();
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    RequiredIntArray.Add(reader.GetInt32());
                                }
                                continue;
                            }

                            if (reader.ValueTextEquals(b_requiredStringArray))
                            {
                                reader.Read();
                                RequiredStringArray = new List<string>();
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    RequiredStringArray.Add(reader.GetString());
                                }
                                continue;
                            }

                            if (reader.ValueTextEquals(b_requiredChildModelArray))
                            {
                                reader.Read();
                                RequiredChildModelArray = new List<ChildModel>();
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    RequiredChildModelArray.Add(ChildModel.Deserialize(ref reader));
                                }
                                continue;
                            }
                        }
                        break;

                    default:
                        throw new NotSupportedException("Not supported token type " + reader.TokenType);
                }
            }
        }
    }
}
