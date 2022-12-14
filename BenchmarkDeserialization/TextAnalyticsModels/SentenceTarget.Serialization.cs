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
    public partial class SentenceTarget : IUtf8JsonDeserializable
    {
        internal static SentenceTarget DeserializeSentenceTarget(JsonElement element)
        {
            TokenSentimentValue sentiment = default;
            TargetConfidenceScoreLabel confidenceScores = default;
            int offset = default;
            int length = default;
            string text = default;
            IReadOnlyList<TargetRelation> relations = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("sentiment"))
                {
                    sentiment = property.Value.GetString().ToTokenSentimentValue();
                    continue;
                }
                if (property.NameEquals("confidenceScores"))
                {
                    confidenceScores = TargetConfidenceScoreLabel.DeserializeTargetConfidenceScoreLabel(property.Value);
                    continue;
                }
                if (property.NameEquals("offset"))
                {
                    offset = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("length"))
                {
                    length = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("text"))
                {
                    text = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("relations"))
                {
                    List<TargetRelation> array = new List<TargetRelation>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(TargetRelation.DeserializeTargetRelation(item));
                    }
                    relations = array;
                    continue;
                }
            }
            return new SentenceTarget(sentiment, confidenceScores, offset, length, text, relations);
        }


        internal static SentenceTarget Deserialize(ref Utf8JsonReader reader)
        {
            IUtf8JsonDeserializable model = new SentenceTarget();
            model.Read(ref reader);
            return (SentenceTarget)model;
        }

        static readonly byte[] b_sentiment = Encoding.UTF8.GetBytes("sentiment");
        static readonly byte[] b_confidencescores = Encoding.UTF8.GetBytes("confidenceScores");
        static readonly byte[] b_offset = Encoding.UTF8.GetBytes("offset");
        static readonly byte[] b_length = Encoding.UTF8.GetBytes("length");
        static readonly byte[] b_text = Encoding.UTF8.GetBytes("text");
        static readonly byte[] b_relations = Encoding.UTF8.GetBytes("relations");

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
                            if (reader.ValueTextEquals(b_sentiment))
                            {
                                reader.Skip();
                                Sentiment = reader.GetString().ToTokenSentimentValue();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_confidencescores))
                            {
                                ConfidenceScores = TargetConfidenceScoreLabel.Deserialize(ref reader);
                                continue;
                            }

                            if (reader.ValueTextEquals(b_offset))
                            {
                                reader.Skip();
                                Offset = reader.GetInt32();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_length))
                            {
                                reader.Skip();
                                Length = reader.GetInt32();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_text))
                            {
                                reader.Skip();
                                Text = reader.GetString();
                                continue;
                            }

                            if (reader.ValueTextEquals(b_relations))
                            {
                                reader.Read();
                                var list = new List<TargetRelation>();
                                while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
                                {
                                    list.Add(TargetRelation.Deserialize(ref reader));
                                }
                                Relations = list.AsReadOnly();
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
