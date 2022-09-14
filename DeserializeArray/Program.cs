// See https://aka.ms/new-console-template for more information
using DeserializeArray;
using System;
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello, World!");

//string jsonIn = "{ \"foo\": \"a\", \"bar\": \"b\", \"model\": { \"foo\": \"aa\", \"bar\": \"bb\" }, \"values\": [ 1, 2, 3 ] }";

// child model
string jsonIn = "{ \"qux\": 1, \"thud\": true }";


byte[] utf8In = Encoding.UTF8.GetBytes(jsonIn);
Utf8JsonReader jsonReader = new Utf8JsonReader(utf8In);

ChildModel model = ChildModel.Deserialize(ref jsonReader);

using var stream = new MemoryStream();
using var writer = new Utf8JsonWriter(stream);
model.Write(writer);

string jsonOut = Encoding.UTF8.GetString(stream.ToArray());

Console.WriteLine("***");
Console.WriteLine(jsonOut);


Console.ReadLine();
