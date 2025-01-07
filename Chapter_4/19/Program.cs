using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        // Настройка конфигурации
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        
        IConfigurationRoot configuration = builder.Build();

        // Настройка TraceSwitch
        TraceSwitch ts = new TraceSwitch("PacktSwitch", "This switch is set via a JSON config.");
        configuration.GetSection("PacktSwitch").Bind(ts);

        // Запись данных трассировки в вывод
        Trace.WriteLineIf(ts.TraceError, "Trace error");
        Trace.WriteLineIf(ts.TraceWarning, "Trace warning");
        Trace.WriteLineIf(ts.TraceInfo, "Trace information");
        Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose");
    }
}