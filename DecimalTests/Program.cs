// See https://aka.ms/new-console-template for more information

using DecimalTests.Templates;

Console.WriteLine("Hello, World!");

var binaryAddTest = new BinaryAddTests("binary_add", "c:\\temp\\1");

binaryAddTest.Exec();