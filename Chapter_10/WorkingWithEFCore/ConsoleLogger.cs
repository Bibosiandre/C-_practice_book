using Microsoft.Extensions.Logging; // ILoggerProvider, ILogger, LogLevel

using static System.Console;

namespace Packt.Shared;

public class ConsoleLoggerProvider : ILoggerProvider
{
  public ILogger CreateLogger(string categoryName)
  {

    // у нас могут быть разные реализации логгера для
    // разные значения CategoryName, но у нас есть только одно
    return new ConsoleLogger();
  }


  // если ваш регистратор использует неуправляемые ресурсы,
  // здесь можно освободить память
  public void Dispose() { }
}

public class ConsoleLogger : ILogger
{
  // если ваш регистратор использует неуправляемые ресурсы, вы можете
  // возвращаем здесь класс, реализующий IDisposable
  public IDisposable BeginScope<TState>(TState state)
  {
    return null;
  }

  public bool IsEnabled(LogLevel logLevel)
  {

    // чтобы избежать перегрузки, вы можете фильтровать
    // на уровне журнала
    switch (logLevel)
    {
      case LogLevel.Trace:
      case LogLevel.Information:
      case LogLevel.None:
        return false;
      case LogLevel.Debug:
      case LogLevel.Warning:
      case LogLevel.Error:
      case LogLevel.Critical:
      default:
        return true;
    };
  }

  public void Log<TState>(LogLevel logLevel,
    EventId eventId, TState state, Exception? exception,
    Func<TState, Exception, string> formatter)
  {
    if (eventId.Id == 20100)
    {
      // записываем уровень и идентификатор события
      Write($"Level: {logLevel}, Event ID: {eventId.Id}");

      // выводить состояние или исключение только в том случае, если оно существует
      if (state != null)
      {
        Write($", State: {state}");
      }

      if (exception != null)
      {
        Write($", Exception: {exception.Message}");
      }
      WriteLine();
    }
  }
}
