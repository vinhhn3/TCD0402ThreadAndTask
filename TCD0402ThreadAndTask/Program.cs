using System;
using System.Threading;

namespace TCD0402ThreadAndTask
{
  internal class Program
  {
    static void Main(string[] args)
    {
      DoSomething(10, "Task 1", ConsoleColor.Red);
      DoSomething(5, "Task 2", ConsoleColor.Blue);
      DoSomething(7, "Task 3", ConsoleColor.Green);




    }

    public static void DoSomething(int seconds, string message, ConsoleColor color)
    {
      Console.ForegroundColor = color;
      Console.WriteLine($"{message} starts ...");
      Console.ResetColor();
      for (int i = 0; i <= seconds; i++)
      {
        Console.ForegroundColor = color;
        Console.WriteLine($"{message,10} {i,2}");
        Console.ResetColor();
        Thread.Sleep(1000);
      }
      Console.ForegroundColor = color;
      Console.WriteLine($"{message} ends ...");
      Console.ResetColor();
    }
  }
}
