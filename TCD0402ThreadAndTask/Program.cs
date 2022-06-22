using System;
using System.Threading;
using System.Threading.Tasks;

namespace TCD0402ThreadAndTask
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Task task2 = new Task(() =>
      {
        DoSomething(5, "Task 2", ConsoleColor.Blue);
      });

      Task task3 = new Task((object obj) =>
      {
        DoSomething(7, (string)obj, ConsoleColor.Green);
      }, "Task 3");

      task2.Start();
      task3.Start();
      DoSomething(10, "Task 1", ConsoleColor.Red);
    }

    public static void DoSomething(int seconds, string message, ConsoleColor color)
    {
      lock (Console.Out)
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
}
