// See https://aka.ms/new-console-template for more information
// три переменные, которые хранят число 2 миллиона
int decimalNotation = 2_000_000;
int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
int hexadecimalNotation = 0x_001E_8480;
// убедитесь, что три переменные имеют одинаковое значение
// оба оператора выводят true
Console.WriteLine($"{decimalNotation == binaryNotation}");
Console.WriteLine(
$"{decimalNotation == hexadecimalNotation}");
