// See https://aka.ms/new-console-template for more information
string[] names; // может ссылаться на любой по размеру массив строк
// выделение памяти для четырех строк в массиве
names = new string[4];
// хранение элементов с индексами позиций
names[0] = "Kate";
names[1] = "Jack";
names[2] = "Rebecca";
names[3] = "Tom";
// перебор имен
for (int i = 0; i < names.Length; i++)
{
// вывести элемент в позиции индекса i
Console.WriteLine(names[i]);
}
