using LinkedLists.Logic;

var fibonacci = new DoubleList<int>();
var limit = 10;
fibonacci.FillFibonacci(limit);
Console.WriteLine($"FIBONACCI TO {limit}:");
Console.WriteLine(fibonacci);