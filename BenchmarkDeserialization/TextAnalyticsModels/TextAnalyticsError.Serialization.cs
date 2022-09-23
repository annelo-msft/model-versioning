// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    public partial class TextAnalyticsError: IUtf8JsonDeserializable
    {
        internal static TextAnalyticsError DeserializeTextAnalyticsError(JsonElement element)
        {
            ErrorCodeValue code = default;
            string message = default;
            Optional<string> target = default;
            Optional<InnerError> innererror = default;
            Optional<IReadOnlyList<TextAnalyticsError>> details = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    code = property.Value.GetString().ToErrorCodeValue();
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("target"))
                {
                    target = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("innererror"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    innererror = InnerError.DeserializeInnerError(property.Value);
                    continue;
                }
                if (property.NameEquals("details"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<TextAnalyticsError> array = new List<TextAnalyticsError>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(DeserializeTextAnalyticsError(item));
                    }
                    details = array;
                    continue;
                }
            }
            return new TextAnalyticsError(code, message, target.Value, innererror.Value, Optional.ToList(details));
        }

        internal static TextAnalyticsError Deserialize(ref Utf8JsonReader reader)
        {
            IUtf8JsonDeserializable model = new TextAnalyticsError();
            model.Read(ref reader);
            return (TextAnalyticsError)model;
        }

        static readonly byte[] b_code = Encoding.UTF8.GetBytes("code");
        static readonly byte[] b_message = Encoding.UTF8.GetBytes("message");
        static readonly byte[] b_target = Encoding.UTF8.GetBytes("target");
        static readonly byte[] b_innererror = Encoding.UTF8.GetBytes("innererror");
        static readonly byte[] b_details = Encoding.UTF8.GetBytes("details");

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
                            if (reader.ValueTextEquals(b_code))
                            {
                                reader.Skip();
                                Code = reader.GetString().ToErrorCodeValue();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_message))
                            {
                                reader.Skip();
                                Message = reader.GetString();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_target))
                            {
                                reader.Skip();
                                Target = reader.GetString();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_innererror))
                            {
                                reader.Skip();
                                Innererror = InnerError.Deserialize(ref reader);
                                continue;
                            }

                            if (reader.ValueTextEquals(b_details))
                            {
                                reader.Read();
                                var values = new List<TextAnalyticsError>();
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    values.Add(TextAnalyticsError.Deserialize(ref reader));
                                }
                                Details = values.AsReadOnly();
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
