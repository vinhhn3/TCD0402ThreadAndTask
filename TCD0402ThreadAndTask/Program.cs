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

      Thread thread1 = new Thread(CountDown);
      Thread thread2 = new Thread(CountUp);

      thread1.Start();
      thread2.Start();
      mainThread.Name = "Main Thread ...";


    }

    public static void CountDown()
    {
      for (int i = 10; i >= 0; i--)
      {
        Console.WriteLine("Timer #1 Countdown: " + i + " seconds");
        Thread.Sleep(1000);
      }
    }

    public static void CountUp()
    {
      for (int i = 0; i <= 10; i++)
      {
        Console.WriteLine("Timer #2 Countup: " + i + " seconds");
        Thread.Sleep(1000);
      }
    }
  }
}
