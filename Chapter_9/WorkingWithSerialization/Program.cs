using System.Xml.Serialization; // XmlSerializer
using Packt.Shared; // Person 

using NewJson = System.Text.Json.JsonSerializer;

using static System.Console;
using static System.Environment;
using static System.IO.Path;

// создать граф объектов
List<Person> people = new()
{
  new(30000M)
  {
    FirstName = "Alice",
    LastName = "Smith",
    DateOfBirth = new(1974, 3, 14)
  },
  new(40000M)
  {
    FirstName = "Bob",
    LastName = "Jones",
    DateOfBirth = new(1969, 11, 23)
  },
  new(20000M)
  {
    FirstName = "Charlie",
    LastName = "Cox",
    DateOfBirth = new(1984, 5, 4),
    Children = new()
    {
      new(0M)
      {
        FirstName = "Sally",
        LastName = "Cox",
        DateOfBirth = new(2000, 7, 12)
      }
    }
  }
};

// создать объект, который будет форматировать людей как XML
XmlSerializer xs = new(people.GetType());

// создать файл для записи
string path = Combine(CurrentDirectory, "people.xml");

using (FileStream stream = File.Create(path))
{
  // сериализовать граф объекта в поток
  xs.Serialize(stream, people);
}

WriteLine("Written {0:N0} bytes of XML to {1}",
  arg0: new FileInfo(path).Length,
  arg1: path);

WriteLine();

// Отображение графа сериализованного объекта
WriteLine(File.ReadAllText(path));

// Десериализация с помощью XML

using (FileStream xmlLoad = File.Open(path, FileMode.Open))
{
  // десериализовать и преобразовать граф объекта в список лиц
  List<Person>? loadedPeople =
    xs.Deserialize(xmlLoad) as List<Person>;

  if (loadedPeople is not null)
  {
    foreach (Person p in loadedPeople)
    {
      WriteLine("{0} has {1} children.",
        p.LastName, p.Children?.Count ?? 0);
    }
  }
}

// создать файл для записи
string jsonPath = Combine(CurrentDirectory, "people.json");

using (StreamWriter jsonStream = File.CreateText(jsonPath))
{
  // создайте объект, который будет отформатирован как JSON
  Newtonsoft.Json.JsonSerializer jss = new();

  // сериализовать граф объекта в строку
  jss.Serialize(jsonStream, people);
}

WriteLine();
WriteLine("Written {0:N0} bytes of JSON to: {1}",
  arg0: new FileInfo(jsonPath).Length,
  arg1: jsonPath);

// Отображение графа сериализованного объекта
WriteLine(File.ReadAllText(jsonPath));

// Deserializing JSON using new APIs

using (FileStream jsonLoad = File.Open(jsonPath, FileMode.Open))
{
  // Десериализация JSON с использованием новых API
  List<Person>? loadedPeople =
    await NewJson.DeserializeAsync(utf8Json: jsonLoad,
      returnType: typeof(List<Person>)) as List<Person>;

  if (loadedPeople is not null)
  {
    foreach (Person p in loadedPeople)
    {
      WriteLine("{0} has {1} children.",
        p.LastName, p.Children?.Count ?? 0);
    }
  }
}
