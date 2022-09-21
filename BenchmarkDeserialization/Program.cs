﻿using DeserializeArray;
using System;
using System.Text;
using System.Text.Json;
using Azure.Core;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;

class Program
{
    static void Main() => BenchmarkRunner.Run<MyClass>();
}

[MemoryDiagnoser]
public class MyClass
{
    // Model with reference and value types
    static string jsonIn = @"{
      ""requiredString"": ""test_string"",
      ""requiredInt"": 7,
      ""requiredLong"": 8,
      ""requiredFloat"": 1.5,
      ""requiredDouble"": 2.5,
      ""requiredBoolean"": true,
      ""requiredDateTime"": ""2019-08-01T00:00:00-07:00"",
      ""requiredDuration"": ""PT1S"",
      ""requiredStringArray"": [ ""a"", ""b"", ""c"" ],
      ""requiredIntArray"": [ 1, 2, 3 ],
      ""requiredChildModelArray"": [ { ""qux"": 1, ""thud"": true },  { ""qux"": 2, ""thud"": false },  { ""qux"": 3, ""thud"": true } ]
    }";

    [Benchmark]
    public void UseUtf8JsonReader()
    {
        byte[] utf8In = Encoding.UTF8.GetBytes(jsonIn);
        Utf8JsonReader jsonReader = new Utf8JsonReader(utf8In);
        Model model = Model.Deserialize(ref jsonReader);
    }

    [Benchmark]
    public void UseJsonDocument()
    {
        byte[] utf8In = Encoding.UTF8.GetBytes(jsonIn);
        using var document = JsonDocument.Parse(utf8In);
        Model model = Model.DeserializeModel(document.RootElement);
    }
}

//Console.WriteLine("Hello, World!");

//// Model with reference and value types
//string jsonIn = @"{
//  ""requiredString"": ""test_string"",
//  ""requiredInt"": 7,
//  ""requiredLong"": 8,
//  ""requiredFloat"": 1.5,
//  ""requiredDouble"": 2.5,
//  ""requiredBoolean"": true,
//  ""requiredDateTime"": ""2019-08-01T00:00:00-07:00"",
//  ""requiredDuration"": ""PT1S"",
//  ""requiredStringArray"": [ ""a"", ""b"", ""c"" ],
//  ""requiredIntArray"": [ 1, 2, 3 ],
//  ""requiredChildModelArray"": [ { ""qux"": 1, ""thud"": true },  { ""qux"": 2, ""thud"": false },  { ""qux"": 3, ""thud"": true } ]
//}";

//// Model with ChildModel
////string jsonIn = "{ \"foo\": \"a\", \"bar\": \"b\", \"children\": [ { \"qux\": 1, \"thud\": true },  { \"qux\": 2, \"thud\": false },  { \"qux\": 3, \"thud\": true } ] }";

//byte[] utf8In = Encoding.UTF8.GetBytes(jsonIn);
//Utf8JsonReader jsonReader = new Utf8JsonReader(utf8In);

//Model model = Model.Deserialize(ref jsonReader);

//using var stream = new MemoryStream();
//using var writer = new Utf8JsonWriter(stream);
//model.Write(writer);

//string jsonOut = Encoding.UTF8.GetString(stream.ToArray());

//Console.WriteLine("***");
//Console.WriteLine(jsonOut);

//Console.ReadLine();
