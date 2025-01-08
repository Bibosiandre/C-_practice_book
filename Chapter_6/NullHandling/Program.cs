using static System.Console;

int thisCannotBeNull = 4;

//thisCannotBeNull = ноль; // ошибка компиляции!

int? thisCouldBeNull = null;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

thisCouldBeNull = 7;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());
// Объявление переменных и параметров, не допускающих значения NULL

// Класс адреса определен выше Класс программы
Address address = new();
address.Building = null;
address.Street = null;
address.City = "London";
address.Region = null;

// Проверка на ноль

string authorName = null;


// следующее вызывает исключение NullReferenceException 
// int x = имя автора.Длина;

// вместо того, чтобы генерировать исключение, y присваивается значение null
int? y = authorName?.Length;

WriteLine($"y is null: {y is null}");


// результат будет 3, если имя автора?. Длина равна нулю
int result = authorName?.Length ?? 3;
WriteLine(result);

class Address
{
  public string? Building;
  public string Street = string.Empty;
  public string City = string.Empty;
  public string Region = string.Empty;
}
