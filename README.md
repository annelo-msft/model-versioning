# model-versioning

1. RoundTripJsonNode - Implements round-tripping of unknown values.
2. DeserializeWithUtf8JsonReader - Implements deserialization using Utf8JsonReader for simple case, as well as case where a Model has a property of the same type.
3. DeserializeArray - Implement Utf8Reader deserialization for arrays.

1 is for https://github.com/Azure/autorest.csharp/issues/2362

2 & 3 are for https://github.com/Azure/autorest.csharp/issues/1614
