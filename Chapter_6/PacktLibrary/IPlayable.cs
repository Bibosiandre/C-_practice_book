using static System.Console;

namespace Packt.Shared;

public interface IPlayable
{
  void Play();

  void Pause();

  void Stop() // реализация интерфейса по умолчанию
  {
    WriteLine("Default implementation of Stop.");
  }
}
