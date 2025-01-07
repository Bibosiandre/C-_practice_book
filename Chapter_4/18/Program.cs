using System;
using System.IO; // для работы с файлами
using System.Diagnostics;

namespace _18
{
    class Program
    {
        static void Main()
        {
            // Запись в текстовый файл на рабочем столе
            Trace.Listeners.Add(new TextWriterTraceListener(
                File.CreateText(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.DesktopDirectory), "log.txt"))));
            
            // Настройка автоматической очистки буфера
            Trace.AutoFlush = true;
            
            // Вывод отладочной информации
            Debug.WriteLine("Debug says, I am watching!");
            Trace.WriteLine("Trace says, I am watching!");
        }
    }
}