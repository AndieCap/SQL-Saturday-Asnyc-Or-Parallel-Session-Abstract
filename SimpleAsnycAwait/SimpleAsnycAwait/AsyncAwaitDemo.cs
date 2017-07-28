using System;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleAsyncAwait
{
  public class AsyncAwaitDemo
  {
    public Task StartCounter()
    {
      return Task.Run(async () => await DoStuff());

    }
    private async Task<string> DoStuff()
    {
      var result = await LongRunningOperation();
      Console.WriteLine($"Counts complete: {result}");
      return result;
    }

    private static Task<string> LongRunningOperation()
    {
      int counter;

      for (counter = 0; counter < 10; counter++)
        {
        Thread.Sleep(3000);
        Console.WriteLine(counter);
        }

      return Task.FromResult("Counter = " + counter);
    }
  }
}