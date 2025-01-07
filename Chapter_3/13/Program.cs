using System;

class Program
{
    static void Main(string[] args)
    {
        int a = 5; // Example value
        int b = 3; // Example value

        Console.WriteLine();
        Console.WriteLine("Outputting integers as binary:");
        Console.WriteLine($"a = {ToBinaryString(a)}");
        Console.WriteLine($"b = {ToBinaryString(b)}");
        Console.WriteLine($"a & b = {ToBinaryString(a & b)}");
        Console.WriteLine($"a | b = {ToBinaryString(a | b)}");
        Console.WriteLine($"a ^ b = {ToBinaryString(a ^ b)}");
    }

    static string ToBinaryString(int value)
    {
        return Convert.ToString(value, toBase: 2).PadLeft(8, '0');
    }
}


