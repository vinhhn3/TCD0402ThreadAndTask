using System;
using System.Threading;

namespace TCD0402ThreadAndTask
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Thread mainThread = Thread.CurrentThread;
      Console.WriteLine(mainThread.Name);

      Thread thread1 = new Thread(() =>
      {
        CountDown("Timer 1...");
      });
      Thread thread2 = new Thread(() =>
      {
        CountUp("Timer 2...");
      });

      thread1.Start();
      thread2.Start();
      mainThread.Name = "Main Thread ...";


    }

    public static void CountDown(string message)
    {
      for (int i = 10; i >= 0; i--)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{message}: {i} seconds");
        Thread.Sleep(1000);
        Console.ResetColor();
      }
    }

    public static void CountUp(string message)
    {
      for (int i = 0; i <= 10; i++)
      {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"{message}: {i} seconds");
        Thread.Sleep(1000);
        Console.ResetColor();
      }
    }
  }
}
