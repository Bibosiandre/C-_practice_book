// See https://aka.ms/new-console-template for more information
using System.Reflection;

Assembly? assembly = Assembly.GetEntryAssembly();
if (assembly == null) return;
// перебор сборок, на которые ссылается приложение
foreach (AssemblyName name in assembly.GetReferencedAssemblies())
{
// загрузка сборки для чтения данных
Assembly a = Assembly.Load(name);
// объявление переменной для подсчета количества методов
int methodCount = 0;
// перебор всех типов в сборке
foreach (TypeInfo t in a.DefinedTypes)
{
// добавление количества методов
methodCount += t.GetMethods().Count();
}
// вывод количества типов и их методов
Console.WriteLine(
"{0:N0} types with {1:N0} methods in {2} assembly.",
arg0: a.DefinedTypes.Count(),
arg1: methodCount, arg2: name.Name);
}
