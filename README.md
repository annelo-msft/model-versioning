# model-versioning
https://github.com/Azure/autorest.csharp/issues/2362

- **RoundTripJsonNode** - Implements round-tripping of unknown values 

# deserialization
https://github.com/Azure/autorest.csharp/issues/1614

- **DeserializeWithUtf8JsonReader** - Implements deserialization using Utf8JsonReader for simple case, as well as case where a Model has a property of the same type.
- **DeserializeArray** - Implement Utf8Reader deserialization for arrays.
- **BenchmarkDeserialization** - Implement Utf8Reader deserialization for many more types, including enums and dictionaries.

BenchmarkDeserialization results on TextAnalyticsJson

|            Method |     Mean |    Error |   StdDev |   Gen0 | Allocated |
|------------------ |---------:|---------:|---------:|-------:|----------:|
| UseUtf8JsonReader | 34.82 us | 0.430 us | 0.403 us | 4.3945 |  18.12 KB |
|   UseJsonDocument | 58.73 us | 0.824 us | 0.731 us | 4.2725 |  17.52 KB |
