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

            writer.WriteEndObject();
        }

        // Current JsonElement approach
        internal static ChildModel DeserializeChildModel(JsonElement element)
        {
            int qux = default;
            bool thud = default;

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("qux"))
                {
                    qux = property.Value.GetInt32();
                    continue;
                }

                if (property.NameEquals("thud"))
                {
                    thud = property.Value.GetBoolean();
                    continue;
                }
            }
            return new ChildModel(qux, thud);
        }


        internal static ChildModel Deserialize(ref Utf8JsonReader reader)
        {
            IUtf8JsonDeserializable model = new ChildModel();
            model.Read(ref reader);
            return (ChildModel)model;
        }

        static readonly byte[] b_qux = Encoding.UTF8.GetBytes("qux");
        static readonly byte[] b_thud = Encoding.UTF8.GetBytes("thud");

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
                            if (reader.ValueTextEquals(b_qux))
                            {
                                reader.Skip();
                                Qux = reader.GetInt32();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_thud))
                            {
                                reader.Skip();
                                Thud = reader.GetBoolean();
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
