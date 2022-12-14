// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.AI.TextAnalytics.Models
{
    public partial class TextAnalyticsWarning : IUtf8JsonDeserializable
    {
        internal static TextAnalyticsWarning DeserializeTextAnalyticsWarning(JsonElement element)
        {
            WarningCodeValue code = default;
            string message = default;
            Optional<string> targetRef = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("code"))
                {
                    code = new WarningCodeValue(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("message"))
                {
                    message = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("targetRef"))
                {
                    targetRef = property.Value.GetString();
                    continue;
                }
            }
            return new TextAnalyticsWarning(code, message, targetRef.Value);
        }


        internal static TextAnalyticsWarning Deserialize(ref Utf8JsonReader reader)
        {
            IUtf8JsonDeserializable model = new TextAnalyticsWarning();
            model.Read(ref reader);
            return (TextAnalyticsWarning)model;
        }

        static readonly byte[] b_code = Encoding.UTF8.GetBytes("code");
        static readonly byte[] b_message = Encoding.UTF8.GetBytes("message");
        static readonly byte[] b_targetref = Encoding.UTF8.GetBytes("targetRef");

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
                                Code = new WarningCodeValue(reader.GetString());
                                continue;
                            }

                            if (reader.ValueTextEquals(b_message))
                            {
                                reader.Skip();
                                Message = reader.GetString();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_targetref))
                            {
                                reader.Skip();
                                TargetRef = reader.GetString();
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
