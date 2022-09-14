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

        public static List<int> ReadIntArray(this Utf8JsonReader reader)
        {
            List<int> list = new List<int>();

            while (reader.Read())
            {
                switch (reader.TokenType)
                {
                    case JsonTokenType.StartArray:
                        break;

                    case JsonTokenType.EndArray:
                        return list;

                    case JsonTokenType.Number:
                        list.Add(reader.GetInt32());
                        break;

                    default:
                        throw new FormatException();
                }
            }

            return list;
        }
    }
}
