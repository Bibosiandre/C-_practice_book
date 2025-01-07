using System;

class Program
{
    static void Main()
    {
        for (int i = 1; i < 15; i++)
        {
            Console.WriteLine($"{i}! = {Factorial(i):N0}");
        }
    }

    static long Factorial(int n)
    {
        if (n == 0) return 1; // Факториал 0 равен 1
        long result = 1;
        for (int i = 1; i <= n; i++)
        {
            result *= i; // Умножаем значения для вычисления факториала
        }
        return result;
    }
}