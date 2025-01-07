using System;

string[] names = { "Adam", "Barry", "Charlie" };

foreach (string name in names)
{
    Console.WriteLine($"{name} has {name.Length} characters.");
}