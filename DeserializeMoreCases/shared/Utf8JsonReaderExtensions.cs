// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace Azure.Core
{
    internal static class Utf8JsonReaderExtensions
    {
        public static DateTimeOffset GetDateTimeOffset(this ref Utf8JsonReader reader, string format) => format switch
        {
            "U" when reader.TokenType == JsonTokenType.Number => DateTimeOffset.FromUnixTimeSeconds(reader.GetInt64()),
            _ => TypeFormatters.ParseDateTimeOffset(reader.GetString()!, format)
        };

        public static TimeSpan GetTimeSpan(this ref Utf8JsonReader reader, string format) =>
            TypeFormatters.ParseTimeSpan(reader.GetString()!, format);

        // The `new()` constraint will require models to be generated with internal 
        // parameterless constructors.  I don't think that is a problem if it does 
        // appropriate initialization.
        public static List<T> ReadObjectArray<T>(this ref Utf8JsonReader reader) where T : IUtf8JsonDeserializable, new()
        {
            List<T> list = new();

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartArray:
                        break;

                    case JsonTokenType.EndArray:
                        return list;

                    case JsonTokenType.StartObject:
                        T item = new();
                        item.Read(ref reader);
                        list.Add(item);
                        break;

                    default:
                        throw new FormatException();
                }
            }

            return list;
        }
    }
}
