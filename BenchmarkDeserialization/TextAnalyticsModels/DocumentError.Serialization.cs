// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    public partial class DocumentError : IUtf8JsonDeserializable
    {
        internal static DocumentError DeserializeDocumentError(JsonElement element)
        {
            string id = default;
            TextAnalyticsError error = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("error"))
                {
                    error = TextAnalyticsError.DeserializeTextAnalyticsError(property.Value);
                    continue;
                }
            }
            return new DocumentError(id, error);
        }

        internal static DocumentError Deserialize(ref Utf8JsonReader reader)
        {
            IUtf8JsonDeserializable model = new DocumentError();
            model.Read(ref reader);
            return (DocumentError)model;
        }

        static readonly byte[] b_id = Encoding.UTF8.GetBytes("id");
        static readonly byte[] b_error = Encoding.UTF8.GetBytes("error");
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
                            if (reader.ValueTextEquals(b_id))
                            {
                                reader.Skip();
                                Id = reader.GetString();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_error))
                            {
                                Error = TextAnalyticsError.Deserialize(ref reader);
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
