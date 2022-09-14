// See https://aka.ms/new-console-template for more information
using DeserializeArray;
using System;
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello, World!");

// "baz" is added in v2 and starts being returned from v1 GET operations
string jsonIn = "{ \"foo\": \"a\", \"bar\": \"b\", \"model\": { \"foo\": \"aa\", \"bar\": \"bb\" }, \"values\": [ 1, 2, 3 ] }";

byte[] utf8In = Encoding.UTF8.GetBytes(jsonIn);
Utf8JsonReader jsonReader = new Utf8JsonReader(utf8In);

Model model = Model.Deserialize(ref jsonReader);

using var stream = new MemoryStream();
using var writer = new Utf8JsonWriter(stream);
model.Write(writer);

string jsonOut = Encoding.UTF8.GetString(stream.ToArray());

Console.WriteLine("***");
Console.WriteLine(jsonOut);


Console.ReadLine();
