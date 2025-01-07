// See https://aka.ms/new-console-template for more information
object height = 1.88; // хранение double в объекте
object name = "Amir"; // хранение string в объекте
Console.WriteLine($"{name} is {height} metres tall.");
int length1 = name.Length; // Выдаст ошибку компиляции!
int length2 = ((string)name).Length; // сообщаем компилятору, что это
//строка
Console.WriteLine($"{name} has {length2} characters.");
// хранение строки в объекте dynamic
// строка имеет свойство Length
dynamic something = "Ahmed";
//int не имеет свойства Length
something = 12;
// массив любого типа имеет свойство Length
something = new[] { 3, 5, 7 };
// компилируется, но может вызвать исключение во время
// выполнения, если вы позже сохраните тип данных,
// у которого нет свойства Length
Console.WriteLine($"Length is {something.Length}");