// See https://aka.ms/new-console-template for more information
using static System.Console;

int a = 10; // 00001010
int b = 6; // 00000110
WriteLine($"a = {a}");
WriteLine($"b = {b}");
WriteLine($"a & b = {a & b}"); // только столбец 2-го бита
WriteLine($"a | b = {a | b}"); // столбцы 8, 4 и 2-го битов
WriteLine($"a ^ b = {a ^ b}"); // столбцы 8 и 4-го битов


// 01010000 — сдвиг влево переменной а на три битовых столбца
WriteLine($"a << 3 = {a << 3}");
// умножение переменной a на 8
WriteLine($"a * 8 = {a * 8}");
// 00000011 сдвиг вправо переменной b на один битовый столбец
WriteLine($"b >> 1 = {b >> 1}");