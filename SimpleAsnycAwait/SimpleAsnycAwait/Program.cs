using System;

namespace SimpleAsyncAwait
{
  class Program
  {
    static void Main()
    {
      var demo = new AsyncAwaitDemo();

      var counterTask = demo.StartCounter();

      while (true)
      {
        if (!counterTask.IsCompleted)
        {
          var input = Console.ReadLine();
          Console.WriteLine($"Read {input} on the Main Thread While Counter Task is Running...................");
        }
        else
        {
          Console.WriteLine($"Doing Stuff on the Main Thread...................");
        }
      }
    }
  }
}