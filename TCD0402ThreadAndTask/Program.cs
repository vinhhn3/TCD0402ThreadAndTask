using System;
using System.Threading;
using System.Threading.Tasks;

namespace TCD0402ThreadAndTask
{
  internal class Program
  {
    static async Task Task2()
    {
      Task task2 = new Task(() =>
      {
        DoSomething(5, "Task 2", ConsoleColor.Blue);
      });

      task2.Start();

      await task2; // return
      Console.WriteLine("Task 2 completed ...");
    }

    static async Task Task3() // void
    {
      Task task3 = new Task((object obj) =>
      {
        DoSomething(7, (string)obj, ConsoleColor.Green);
      }, "Task 3");

      task3.Start();
      await task3;
      Console.WriteLine("Task 3 completed ...");
    }

    static async Task<string> Task4()
    {
      Task<string> task4 = new Task<string>(() =>
      {
        DoSomething(6, "Task 4", ConsoleColor.Magenta);
        return "Task 4 completed ...";

      });

      task4.Start();
      var result = await task4;
      return result;
    }

    static async Task<string> Task5()
    {
      Task<string> task5 = new Task<string>((object obj) =>
      {
        DoSomething(8, (string)obj, ConsoleColor.Yellow);
        return "Task 5 completed ...";
      }, "Task 5");

      task5.Start();
      var result = await task5;
      return result;
    }

    static async Task Main(string[] args)
    {

      var task2 = Task2();
      var task3 = Task3();
      var task4 = Task4();
      var task5 = Task5();

      DoSomething(3, "Task 1", ConsoleColor.Red);

      await task2;
      await task3;
      var resultTask4 = await task4;
      var resultTask5 = await task5;

      Console.WriteLine(resultTask4);
      Console.WriteLine(resultTask5);
      Console.WriteLine("Press Any Key To Exit ...");
    }

    public static void DoSomething(int seconds, string message, ConsoleColor color)
    {
      lock (Console.Out)
      {
        Console.ForegroundColor = color;
        Console.WriteLine($"{message} starts ...");
        Console.ResetColor();
      }
      for (int i = 0; i <= seconds; i++)
      {
        lock (Console.Out)
        {
          Console.ForegroundColor = color;
          Console.WriteLine($"{message,10} {i,2}");
          Console.ResetColor();
        }
        Thread.Sleep(1000);
      }
      lock (Console.Out)
      {
        Console.ForegroundColor = color;
        Console.WriteLine($"{message} ends ...");
        Console.ResetColor();
      }
    }
  }
}
