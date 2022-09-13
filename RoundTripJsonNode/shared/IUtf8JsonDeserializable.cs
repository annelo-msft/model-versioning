// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Text.Json;

namespace Azure.Core
{
    // note, come back and handle reference case - seems doable
    internal interface IUtf8JsonDeserializable<T> where T : class
    {
        T Read(Utf8JsonReader read, T value);
    }
}
