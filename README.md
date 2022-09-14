# model-versioning

1. RoundTripJsonNode - Implements round-tripping of unknown values.
2. DeserializeWithUtf8JsonReader - Implements deserialization using Utf8JsonReader for simple case, as well as case where a Model has a property of the same type.
3. DeserializeArray - Implement Utf8Reader deserialization for arrays.

Notes:

Starting in #2, I added an experimental `IUtf8JsonDeserializable` interface.  This is partly to mirror IUtf8JsonSerializable, but also to explore whether we can use interfaces to enforce parts of the deserialization contract without having to use static methods on interfaces, which isn't available to us in .NET Framework 1.2.

```csharp
    internal interface IUtf8JsonDeserializable<T> where T : class
    {
        T Read(ref Utf8JsonReader reader, T value);
    }
```

`Read` takes `T value` as a parameter to differentiate it from the static `Deserialize` method.  It returns value as the return type.
Question: why do we have to take it as a parameter?

- Because `Read` is an instance method and not a static method, we must have an instance of `T` in order to call read.  The static `Deserialize` method creates this instance and calls `Read` on it.
- Note: we can probably simplify this - why not just call `Read` on `T` to populate it and then return `T` from `Deserialize`?  What does passing and returning `T value` add?

`Read` takes `Utf8JsonReader reader` as ref, because if it does not, the position is not maintained when it returns from child Deserialize class.
TODO: go deeper on .NET ref structs.