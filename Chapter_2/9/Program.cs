// See https://aka.ms/new-console-template for more information
int numberOfApples = 12;
decimal pricePerApple = 0.35M;
Console.WriteLine(
format: "{0} apples costs {1:C}",
arg0: numberOfApples,
arg1: pricePerApple * numberOfApples);
string formatted = string.Format(
format: "{0} apples costs {1:C}",
arg0: numberOfApples,
arg1: pricePerApple * numberOfApples);
//WriteToFile(formatted); // записывает строку в файл
Console.WriteLine($"{numberOfApples} apples costs {pricePerApple *
numberOfApples:C}");

Console.Write("Type your first name and press ENTER: ");
string? firstName = Console.ReadLine();
Console.Write("Type your age and press ENTER: ");
string? age = Console.ReadLine();
Console.WriteLine(
$"Hello {firstName}, you look good for {age}.");