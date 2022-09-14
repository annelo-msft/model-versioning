# model-versioning

1. RoundTripJsonNode - Implements round-tripping of unknown values.
2. DeserializeWithUtf8JsonReader - Implements deserialization using Utf8JsonReader for simple case, as well as case where a Model has a property of the same type.
3. DeserializeArray - Implement Utf8Reader deserialization for arrays.



`Read` takes `Utf8JsonReader reader` as ref, because if it does not, the position is not maintained when it returns from child Deserialize class.
TODO: go deeper on .NET ref structs.