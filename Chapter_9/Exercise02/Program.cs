﻿using Packt.Shared; // Circle, Rectangle, Shape
using System.Xml.Serialization; // XmlSerializer

using static System.Console;
using static System.Environment;
using static System.IO.Path;

// создать путь к файлу для записи
string path = Combine(CurrentDirectory, "shapes.xml");

// создать список объектов Shape для сериализации
List<Shape> listOfShapes = new()
{
  new Circle { Colour = "Red", Radius = 2.5 },
  new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
  new Circle { Colour = "Green", Radius = 8 },
  new Circle { Colour = "Purple", Radius = 12.3 },
  new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 }
};

// создать объект, который знает, как сериализовать и десериализовать 
// список объектов Shape
XmlSerializer serializerXml = new(listOfShapes.GetType());

WriteLine("Saving shapes to XML file:");

using (FileStream fileXml = File.Create(path))
{
  serializerXml.Serialize(fileXml, listOfShapes);
}

WriteLine("Loading shapes from XML file:");
List<Shape>? loadedShapesXml = null;

using (FileStream fileXml = File.Open(path, FileMode.Open))
{
  loadedShapesXml =
    serializerXml.Deserialize(fileXml) as List<Shape>;
}

if (loadedShapesXml == null)
{
  WriteLine($"{nameof(loadedShapesXml)} is empty.");
}
else
{
  foreach (Shape item in loadedShapesXml)
  {
    WriteLine($"{item.GetType().Name} is {item.Colour} and has an area of {item.Area:N2}");
  }
}
