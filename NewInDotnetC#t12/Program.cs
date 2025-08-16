// See https://aka.ms/new-console-template for more information
using NewInDotnetC_t12;

Console.WriteLine("=== C# 12 Cars Demo ===\n");
Console.WriteLine("=== Primary Constructor Demo ===");
var car = new Car("Tesla", "Model 3", 2023);
car.ShowInfo();

Console.WriteLine("\n=== Collection Expressions Demo ===");
CarCollection.ShowCarsCollection();

Console.WriteLine("\n=== Default Lambda Parameters Demo ===");
CarLambdaDemo.Run();

Console.WriteLine("\n=== Alias Any Type Demo ===");
CarTypeAlias.Run();
