// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.TextAnalytics.Models
{
    /// <summary> The SentenceTarget. </summary>
    public partial class SentenceTarget
    {
        internal SentenceTarget() { }

        /// <summary> Initializes a new instance of SentenceTarget. </summary>
        /// <param name="sentiment"> Targeted sentiment in the sentence. </param>
        /// <param name="confidenceScores"> Target sentiment confidence scores for the target in the sentence. </param>
        /// <param name="offset"> The target offset from the start of the sentence. </param>
        /// <param name="length"> The length of the target. </param>
        /// <param name="text"> The target text detected. </param>
        /// <param name="relations"> The array of either assessment or target objects which is related to the target. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="confidenceScores"/>, <paramref name="text"/> or <paramref name="relations"/> is null. </exception>
        internal SentenceTarget(TokenSentimentValue sentiment, TargetConfidenceScoreLabel confidenceScores, int offset, int length, string text, IEnumerable<TargetRelation> relations)
        {
            if (confidenceScores == null)
            {
                throw new ArgumentNullException(nameof(confidenceScores));
            }
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            if (relations == null)
            {
                throw new ArgumentNullException(nameof(relations));
            }

            Sentiment = sentiment;
            ConfidenceScores = confidenceScores;
            Offset = offset;
            Length = length;
            Text = text;
            Relations = relations.ToList();
        }

        /// <summary> Initializes a new instance of SentenceTarget. </summary>
        /// <param name="sentiment"> Targeted sentiment in the sentence. </param>
        /// <param name="confidenceScores"> Target sentiment confidence scores for the target in the sentence. </param>
        /// <param name="offset"> The target offset from the start of the sentence. </param>
        /// <param name="length"> The length of the target. </param>
        /// <param name="text"> The target text detected. </param>
        /// <param name="relations"> The array of either assessment or target objects which is related to the target. </param>
        internal SentenceTarget(TokenSentimentValue sentiment, TargetConfidenceScoreLabel confidenceScores, int offset, int length, string text, IReadOnlyList<TargetRelation> relations)
        {
            Sentiment = sentiment;
            ConfidenceScores = confidenceScores;
            Offset = offset;
            Length = length;
            Text = text;
            Relations = relations;
        }

        /// <summary> Targeted sentiment in the sentence. </summary>
        public TokenSentimentValue Sentiment { get; internal set; }
        /// <summary> Target sentiment confidence scores for the target in the sentence. </summary>
        public TargetConfidenceScoreLabel ConfidenceScores { get; internal set; }
        /// <summary> The target offset from the start of the sentence. </summary>
        public int Offset { get; internal set; }
        /// <summary> The length of the target. </summary>
        public int Length { get; internal set; }
        /// <summary> The target text detected. </summary>
        public string Text { get; internal set; }
        /// <summary> The array of either assessment or target objects which is related to the target. </summary>
        public IReadOnlyList<TargetRelation> Relations { get; internal set; }
    }
}
