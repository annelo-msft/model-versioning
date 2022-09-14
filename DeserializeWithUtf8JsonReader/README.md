# DeserializeWithUtf8JsonReader

Refactored based on the observations below.

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
