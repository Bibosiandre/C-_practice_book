using System;

class Program
{
    static void Main()
    {
        // выделение массива из 128 байт
        byte[] binaryObject = new byte[128];
        // заполнение массива случайными байтами
        (new Random()).NextBytes(binaryObject);
        
        Console.WriteLine("Binary Object as bytes:");
        for (int index = 0; index < binaryObject.Length; index++)
        {
            Console.Write($"{binaryObject[index]:X} ");
        }
        Console.WriteLine();
        
        // преобразование в строку Base64 и вывод в виде текста
        string encoded = Convert.ToBase64String(binaryObject);
        Console.WriteLine($"Binary Object as Base64: {encoded}");

    }
}