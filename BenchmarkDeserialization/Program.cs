using DeserializeArray;
using System;
using System.Text;
using System.Text.Json;
using Azure.Core;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using Azure.AI.TextAnalytics.Models;
using BenchmarkDeserialization;

class Program
{
    static void Main() => BenchmarkRunner.Run<MyClass>();
}


//byte[] utf8In = Encoding.UTF8.GetBytes(TextAnalyticsJson.SentimentResponse);

//using var document = JsonDocument.Parse(utf8In);
//var model = SentimentResponse.DeserializeSentimentResponse(document.RootElement);

//var reader = new Utf8JsonReader(utf8In);
//var model = SentimentResponse.Deserialize(ref reader);

//Console.ReadLine();


[MemoryDiagnoser]
public class MyClass
{
    string jsonIn = TextAnalyticsJson.SentimentResponse;

    //// Model with reference and value types
    //static string jsonIn = @"{
    //      ""requiredString"": ""Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ Really Long String of Text 01234567890;#$%^ "",
    //      ""requiredInt"": 7,
    //      ""requiredLong"": 8,
    //      ""requiredFloat"": 1.5,
    //      ""requiredDouble"": 2.5,
    //      ""requiredBoolean"": true,
    //      ""requiredDateTime"": ""2019-08-01T00:00:00-07:00"",
    //      ""requiredDuration"": ""PT1S"",
    //      ""requiredStringArray"": [ ""a"", ""b"", ""c"" ],
    //      ""requiredIntArray"": [ 1, 2, 3 ],
    //      ""requiredChildModelArray"": [ { ""qux"": 1, ""thud"": true },  { ""qux"": 2, ""thud"": false },  { ""qux"": 3, ""thud"": true } ]
    //    }";

    [Benchmark]
    public void UseUtf8JsonReader()
    {
        byte[] utf8In = Encoding.UTF8.GetBytes(jsonIn);
        Utf8JsonReader jsonReader = new Utf8JsonReader(utf8In);
        SentimentResponse model = SentimentResponse.Deserialize(ref jsonReader);
    }

    [Benchmark]
    public void UseJsonDocument()
    {
        byte[] utf8In = Encoding.UTF8.GetBytes(jsonIn);
        using var document = JsonDocument.Parse(utf8In);
        SentimentResponse model = SentimentResponse.DeserializeSentimentResponse(document.RootElement);
    }
}

//[MemoryDiagnoser]
//public class MyClass
//{
//    // Model with reference and value types
//    static string jsonIn = @"{
//      ""requiredString"": ""test_string"",
//      ""requiredInt"": 7,
//      ""requiredLong"": 8,
//      ""requiredFloat"": 1.5,
//      ""requiredDouble"": 2.5,
//      ""requiredBoolean"": true,
//      ""requiredDateTime"": ""2019-08-01T00:00:00-07:00"",
//      ""requiredDuration"": ""PT1S"",
//      ""requiredStringArray"": [ ""a"", ""b"", ""c"" ],
//      ""requiredIntArray"": [ 1, 2, 3 ],
//      ""requiredChildModelArray"": [ { ""qux"": 1, ""thud"": true },  { ""qux"": 2, ""thud"": false },  { ""qux"": 3, ""thud"": true } ]
//    }";

//    [Benchmark]
//    public void UseUtf8JsonReader()
//    {
//        byte[] utf8In = Encoding.UTF8.GetBytes(jsonIn);
//        Utf8JsonReader jsonReader = new Utf8JsonReader(utf8In);
//        Model model = Model.Deserialize(ref jsonReader);
//    }

//    [Benchmark]
//    public void UseJsonDocument()
//    {
//        byte[] utf8In = Encoding.UTF8.GetBytes(jsonIn);
//        using var document = JsonDocument.Parse(utf8In);
//        Model model = Model.DeserializeModel(document.RootElement);
//    }
//}

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
