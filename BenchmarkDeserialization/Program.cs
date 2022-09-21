using DeserializeArray;
using System;
using System.Text;
using System.Text.Json;
using Azure.Core;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Attributes;
using Azure.AI.TextAnalytics.Models;

//class Program
//{
//    static void Main() => BenchmarkRunner.Run<MyClass>();
//}


byte[] utf8In = Encoding.UTF8.GetBytes(MyClass.jsonIn);
using var document = JsonDocument.Parse(utf8In);
var model = SentimentResponse.DeserializeSentimentResponse(document.RootElement);
Console.ReadLine();


[MemoryDiagnoser]
public class MyClass
{
    public static string jsonIn = @"{
  ""documents"": [
    {
      ""confidenceScores"": {
        ""negative"": 0,
        ""neutral"": 0,
        ""positive"": 1
      },
      ""id"": ""1"",
      ""sentences"": [
        {
          ""targets"": [
            {
              ""confidenceScores"": {
                ""negative"": 0,
                ""positive"": 1
              },
              ""length"": 10,
              ""offset"": 6,
              ""relations"": [
                {
                  ""ref"": ""#/documents/0/sentences/0/assessments/0"",
                  ""relationType"": ""assessment""
                }
              ],
              ""sentiment"": ""positive"",
              ""text"": ""atmosphere""
            }
          ],
          ""confidenceScores"": {
    ""negative"": 0,
            ""neutral"": 0,
            ""positive"": 1
          },
          ""length"": 17,
          ""offset"": 0,
          ""assessments"": [
            {
              ""confidenceScores"": {
                ""negative"": 0,
                ""positive"": 1
              },
              ""isNegated"": false,
              ""length"": 5,
              ""offset"": 0,
              ""sentiment"": ""positive"",
              ""text"": ""great""
            }
          ],
          ""sentiment"": ""positive"",
          ""text"": ""Great atmosphere.""
        },
        {
    ""targets"": [
            {
        ""confidenceScores"": {
            ""negative"": 0.01,
                ""positive"": 0.99
              },
              ""length"": 11,
              ""offset"": 37,
              ""relations"": [
                {
            ""ref"": ""#/documents/0/sentences/1/assessments/0"",
                  ""relationType"": ""assessment""
                }
              ],
              ""sentiment"": ""positive"",
              ""text"": ""restaurants""
            },
            {
        ""confidenceScores"": {
            ""negative"": 0.01,
                ""positive"": 0.99
              },
              ""length"": 6,
              ""offset"": 50,
              ""relations"": [
                {
            ""ref"": ""#/documents/0/sentences/1/assessments/0"",
                  ""relationType"": ""assessment""
                }
              ],
              ""sentiment"": ""positive"",
              ""text"": ""hotels""
            }
          ],
          ""confidenceScores"": {
        ""negative"": 0.01,
            ""neutral"": 0.86,
            ""positive"": 0.13
          },
          ""length"": 52,
          ""offset"": 18,
          ""assessments"": [
            {
        ""confidenceScores"": {
            ""negative"": 0.01,
                ""positive"": 0.99
              },
              ""isNegated"": false,
              ""length"": 15,
              ""offset"": 18,
              ""sentiment"": ""positive"",
              ""text"": ""Close to plenty""
            }
          ],
          ""sentiment"": ""neutral"",
          ""text"": ""Close to plenty of restaurants, hotels, and transit!""
        }
      ],
      ""sentiment"": ""positive"",
      ""warnings"": []
    }
  ],
  ""errors"": [],
  ""modelVersion"": ""2020-04-01""
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
