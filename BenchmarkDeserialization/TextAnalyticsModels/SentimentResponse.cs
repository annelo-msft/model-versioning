// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.TextAnalytics.Models
{
    /// <summary> The SentimentResponse. </summary>
    public partial class SentimentResponse
    {
        internal SentimentResponse() { }

        /// <summary> Initializes a new instance of SentimentResponse. </summary>
        /// <param name="documents"> Sentiment analysis per document. </param>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="documents"/>, <paramref name="errors"/> or <paramref name="modelVersion"/> is null. </exception>
        internal SentimentResponse(IEnumerable<DocumentSentiment> documents, IEnumerable<DocumentError> errors, string modelVersion)
        {
            if (documents == null)
            {
                throw new ArgumentNullException(nameof(documents));
            }
            if (errors == null)
            {
                throw new ArgumentNullException(nameof(errors));
            }
            if (modelVersion == null)
            {
                throw new ArgumentNullException(nameof(modelVersion));
            }

            Documents = documents.ToList();
            Errors = errors.ToList();
            ModelVersion = modelVersion;
        }

        /// <summary> Initializes a new instance of SentimentResponse. </summary>
        /// <param name="documents"> Sentiment analysis per document. </param>
        /// <param name="errors"> Errors by document id. </param>
        /// <param name="statistics"> if showStats=true was specified in the request this field will contain information about the request payload. </param>
        /// <param name="modelVersion"> This field indicates which model is used for scoring. </param>
        internal SentimentResponse(IReadOnlyList<DocumentSentiment> documents, IReadOnlyList<DocumentError> errors, RequestStatistics statistics, string modelVersion)
        {
            Documents = documents;
            Errors = errors;
            Statistics = statistics;
            ModelVersion = modelVersion;
        }

        /// <summary> Sentiment analysis per document. </summary>
        public IReadOnlyList<DocumentSentiment> Documents { get; internal set; }
        /// <summary> Errors by document id. </summary>
        public IReadOnlyList<DocumentError> Errors { get; internal set; }
        /// <summary> if showStats=true was specified in the request this field will contain information about the request payload. </summary>
        public RequestStatistics Statistics { get; internal set; }
        /// <summary> This field indicates which model is used for scoring. </summary>
        public string ModelVersion { get; internal set; }
    }
}